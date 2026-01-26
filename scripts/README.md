# Auto-add .csproj watcher

This small script watches the repository for new `.csproj` files and automatically adds them to the `backend.sln` using `dotnet sln add`.

Usage
-----

Install dependency:

```bash
python3 -m pip install --user watchdog
```

Run the watcher (recommended from the repo root):

```bash
python3 scripts/auto_add_projects.py --repo-root .
```

By default the script will add new projects to the solution but will not commit or push the solution change. To commit and push automatically (use with care):

```bash
python3 scripts/auto_add_projects.py --repo-root . --commit --push
```

macOS: run as a launchd service
-----------------------------
Create a plist in `~/Library/LaunchAgents/` that runs the script at login. Example `~/Library/LaunchAgents/com.user.autoaddprojects.plist`:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE plist PUBLIC "-//Apple//DTD PLIST 1.0//EN" "http://www.apple.com/DTDs/PropertyList-1.0.dtd">
<plist version="1.0">
  <dict>
    <key>Label</key>
    <string>com.user.autoaddprojects</string>
    <key>ProgramArguments</key>
    <array>
      <string>/usr/bin/python3</string>
      <string>/absolute/path/to/backend/scripts/auto_add_projects.py</string>
      <string>--repo-root</string>
      <string>/absolute/path/to/backend</string>
    </array>
    <key>RunAtLoad</key>
    <true/>
    <key>KeepAlive</key>
    <true/>
    <key>StandardOutPath</key>
    <string>/tmp/auto_add_projects.out</string>
    <key>StandardErrorPath</key>
    <string>/tmp/auto_add_projects.err</string>
  </dict>
</plist>
```

Replace `/absolute/path/to/backend` with your repository path.

Security / safety notes
-----------------------
- The script by default will not commit or push changes. Automatic commits/pushes can be enabled with `--commit` and `--push`, but be careful: you might commit intermediate artifacts or unwanted changes.
- The script ignores `.csproj` files inside `bin/` and `obj/` directories.

Feedback / improvements
-----------------------
- Could add a dry-run mode, or email/notification on changes.
- Could integrate with a CI pipeline instead of a local watcher to keep repository state consistent across machines.
