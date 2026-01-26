#!/usr/bin/env python3
"""
Watch a repository for new .csproj files and automatically add them to the solution
(using `dotnet sln add <path>`). Safe defaults: it will not auto-commit or push unless
explicit flags are given.

Usage:
  python3 scripts/auto_add_projects.py --repo-root /path/to/backend [--commit] [--push]

Requirements:
  pip install watchdog

This script is intentionally conservative: it skips files under bin/ or obj/ directories
and checks whether the project is already listed in the solution before adding.
"""

import argparse
import os
import subprocess
import sys
import time
from pathlib import Path

try:
    from watchdog.observers import Observer
    from watchdog.events import PatternMatchingEventHandler
except Exception:
    print("Missing dependency: watchdog. Install with: pip install watchdog")
    sys.exit(2)


def run(cmd, cwd):
    print(f"> {' '.join(cmd)} (cwd={cwd})")
    proc = subprocess.run(cmd, cwd=cwd, stdout=subprocess.PIPE, stderr=subprocess.PIPE, text=True)
    if proc.returncode != 0:
        print(f"ERROR: command failed with exit {proc.returncode}\nstdout:\n{proc.stdout}\nstderr:\n{proc.stderr}")
    return proc


def projects_in_solution(repo_root):
    proc = run(["dotnet", "sln", "list"], cwd=repo_root)
    if proc.returncode != 0:
        return []
    lines = proc.stdout.splitlines()
    projects = []
    for l in lines:
        l = l.strip()
        if not l:
            continue
        # dotnet sln list prints a header sometimes; collect lines that look like paths
        if l.endswith('.csproj') or '\\' in l or '/' in l:
            # try to extract path-like token
            if '.csproj' in l:
                # take substring containing .csproj
                idx = l.find('.csproj')
                start = l.rfind(' ', 0, idx) + 1
                path = l[start:idx+7]
                projects.append(os.path.normpath(path))
    return projects


def add_project_to_solution(repo_root, proj_path, do_git_add=False, do_commit=False, do_push=False):
    # proj_path should be absolute or relative path to the .csproj
    repo_root = os.path.abspath(repo_root)
    rel = os.path.relpath(os.path.abspath(proj_path), repo_root)

    # safety: ignore bin/ and obj/
    parts = Path(rel).parts
    if 'bin' in parts or 'obj' in parts:
        print(f"Ignoring project inside build artifacts: {rel}")
        return

    # check if already present
    existing = projects_in_solution(repo_root)
    normalized_existing = [os.path.normpath(p) for p in existing]
    if rel in normalized_existing or os.path.normpath(rel) in normalized_existing:
        print(f"Project already in solution: {rel}")
        return

    # run dotnet sln add
    proc = run(["dotnet", "sln", "add", rel], cwd=repo_root)
    if proc.returncode == 0:
        print(f"Added {rel} to solution")
        if do_git_add:
            run(["git", "add", "backend.sln"], cwd=repo_root)
        if do_commit:
            msg = f"Auto-add project {rel} to solution"
            run(["git", "commit", "-m", msg], cwd=repo_root)
        if do_push:
            run(["git", "push"], cwd=repo_root)


class CsprojHandler(PatternMatchingEventHandler):
    def __init__(self, repo_root, do_git_add, do_commit, do_push):
        super().__init__(patterns=["*.csproj"], ignore_directories=True, case_sensitive=False)
        self.repo_root = repo_root
        self.do_git_add = do_git_add
        self.do_commit = do_commit
        self.do_push = do_push

    def on_created(self, event):
        print(f"Detected created: {event.src_path}")
        add_project_to_solution(self.repo_root, event.src_path, self.do_git_add, self.do_commit, self.do_push)

    def on_moved(self, event):
        print(f"Detected moved: {event.dest_path}")
        add_project_to_solution(self.repo_root, event.dest_path, self.do_git_add, self.do_commit, self.do_push)


def initial_scan(repo_root, handler):
    # find all csproj in tree (depth limited to 3 levels by default) and try to add missing ones
    for path in Path(repo_root).rglob('*.csproj'):
        # skip projects inside obj/bin
        if 'obj' in path.parts or 'bin' in path.parts:
            continue
        add_project_to_solution(repo_root, str(path), handler.do_git_add, handler.do_commit, handler.do_push)


def main():
    p = argparse.ArgumentParser(description="Auto-add new .csproj files to a dotnet solution")
    p.add_argument('--repo-root', default='.', help='Path to repository root that contains the .sln file')
    p.add_argument('--commit', action='store_true', help='Automatically git commit the updated solution (disabled by default)')
    p.add_argument('--push', action='store_true', help='Also push after commit (disabled by default)')
    p.add_argument('--no-scan', action='store_true', help='Skip initial scan of existing .csproj files')
    args = p.parse_args()

    repo_root = os.path.abspath(args.repo_root)
    print(f"Repository root: {repo_root}")

    # basic sanity checks
    sln = os.path.join(repo_root, 'backend.sln')
    if not os.path.exists(sln):
        print(f"Could not find solution file at {sln}. Make sure --repo-root points to the folder containing backend.sln")
        sys.exit(3)

    handler = CsprojHandler(repo_root, do_git_add=not args.commit and True, do_commit=args.commit, do_push=args.push)

    if not args.no_scan:
        print("Running initial scan for existing .csproj files...")
        initial_scan(repo_root, handler)

    observer = Observer()
    observer.schedule(handler, repo_root, recursive=True)
    observer.start()
    print("Watching for new .csproj files. Press Ctrl+C to stop.")
    try:
        while True:
            time.sleep(1)
    except KeyboardInterrupt:
        observer.stop()
    observer.join()


if __name__ == '__main__':
    main()
