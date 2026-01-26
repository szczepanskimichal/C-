Cel
====
Chcemy, żeby twój asystent AI (np. GitHub Copilot / Copilot Chat / JetBrains AI) był łatwo dostępny w Riderze i działał jako główne narzędzie pomocnicze przy debugowaniu i developmentcie.

Co zrobiłem już
---------------
- Utworzyłem keymap do importu: `rider-Copilot-Keymap.xml` (przypisuje ⌘7 do Quick Fix / Context Actions oraz opcjonalnie przypisuje komentowanie liniowe).

Plan i lista rzeczy do wykonania (wybierz, co chcesz zrobić teraz)
-----------------------------------------------------------------
- [ ] Zainstalować i zalogować się w GitHub Copilot / Copilot Chat lub JetBrains AI w Riderze.
- [ ] Zaimportować keymap (`rider-Copilot-Keymap.xml`) aby mieć wygodny skrót ⌘7.
- [ ] Przypisać (opcjonalnie) skrót do otwierania panelu Copilot Chat (np. ⌃⌥C).
- [ ] Włączyć i skonfigurować Quick Fix / Context Actions w edytorze (⌥+Enter lub ⌘7 po imporcie keymap).
- [ ] Skonfigurować Code With Me dla współdzielenia sesji debugowania (gdy chcesz zaprosić inną osobę).

Krok po kroku — Rider (macOS)
-----------------------------
1. Zainstaluj wtyczkę
   - Rider → Preferences (⌘,) → Plugins → Marketplace.
   - Wyszukaj i zainstaluj "GitHub Copilot" lub "GitHub Copilot Chat" (albo "JetBrains AI").
   - Po instalacji zrestartuj Ridera, jeśli poprosi.

2. Zaloguj się
   - Po restarcie zobaczysz w menu: Tools → GitHub Copilot Chat lub w Preferences → Tools → GitHub Copilot.
   - Wybierz Sign in i zaloguj się przez GitHub (upewnij się, że dajesz uprawnienia wymagane przez Copilot).

3. Importuj keymap (plik już jest w repo)
   - Preferences → Keymap → trzy kropki (ikona ustawień) → Import Keymap...
   - Wskaż plik: `backend/rider-Copilot-Keymap.xml`.
   - Po imporcie sprawdź, że: "Show Context Actions" (może być identyfikator `ShowIntentionActions`) ma skrót Command+7 (⌘7).

4. Ustaw (opcjonalnie) skrót do Copilot Chat
   - Preferences → Keymap → wyszukaj "Copilot" lub "Copilot Chat".
   - Dodaj skrót np. Control+Option+C (⌃⌥C) lub inny, który nie koliduje z Twoim układem norweskim.

5. Quick Fix / Context Actions
   - Domyślny skrót: Option+Enter (⌥⏎). Jeśli Twój norweski layout sprawia problemy — użyj ⌘7 po imporcie keymap.
   - W edytorze ustaw kursor na linii i naciśnij ⌘7 — powinno pojawić menu "intentions/quick fixes".
   - Jeśli chcesz, by Copilot oferował code actions w tym menu, w ustawieniach wtyczki włącz odpowiednią opcję (np. "Show actions in editor").

6. Code With Me (wspólne debugowanie)
   - Tools → Code With Me → Start Session.
   - Ustaw uprawnienia: "Full access" jeśli chcesz, by zaproszona osoba mogła debugować.
   - Wyślij link zaproszenia. Zabezpiecz sesję i nie udostępniaj tajnych kluczy.

7. Zdalne debugowanie (jeśli chcesz zaprosić osobę spoza sieci)
   - Skonfiguruj port forwarding / ssh tunnel lub użyj narzędzi chmurowych.
   - W Riderze: Run → Edit Configurations → wybierz Remote Debug i skonfiguruj host/port.

Przydatne skróty (sugestie dla norweskiego układu)
--------------------------------------------------
- Quick Fix / Context Actions: Command+7 (⌘7) — import keymap.
- Otwórz Copilot Chat: Control+Option+C (⌃⌥C) — dodaj w Keymap.
- Komentowanie linii: Option+Command+/ (⌥⌘/) — jeśli slash jest trudno dostępny, przypisz inną kombinację (np. ⌘7 lub ⌥⌘7).

Jeśli Copilot "nie trybi" — checklista debugowania
---------------------------------------------------
- Zaktualizuj Rider do najnowszej wersji.
- Upewnij się, że plugin jest kompatybilny z Twoją wersją Ridera.
- Sprawdź logi: Help → Show Log in Finder → otwórz `idea.log` i znajdź wpisy od Copilot.
- Wyloguj i zaloguj ponownie w pluginie.
- Usuń cache: File → Invalidate Caches / Restart.

Bezpieczeństwo i prywatność
----------------------------
- Nie wysyłaj kluczy, tokenów, plików `.env` ani bazy danych do narzędzi AI.
- Ustaw Code With Me i zdalny debug tylko z zaufanymi osobami i tylko na czas sesji.

Szybkie polecenia do uruchomienia w terminalu (przydatne do testów)
-----------------------------------------------------------------
- Build projektu (po wprowadzeniu zmian):

```bash
cd /Users/michalszczepanski/Documents/GitHub/backend/C#/01
dotnet build
```

- Uruchom projekt:

```bash
dotnet run
```

Dalsze opcje, które mogę wykonać teraz
------------------------------------
- Mogę dopisać krótki README z tymi instrukcjami w repo (już gotowe).
- Mogę automatycznie dodać skróty w plikach konfiguracyjnych IDE (już stworzyłem `rider-Copilot-Keymap.xml` — importuj go lokalnie).
- Mogę poprowadzić Cię krok-po-kroku na żywo przez instalację (powiedz, które kroki robisz, a będę weryfikować po kolei).

Status zmian
------------
- `rider-Copilot-Keymap.xml` — utworzony w repo (ścieżka: `backend/rider-Copilot-Keymap.xml`).
- `IDE-SETUP.md` — utworzony w repo (zawiera komplet instrukcji).

Następny krok — co chcesz teraz?
--------------------------------
- Chcesz, żebym importował keymap za Ciebie (nie mogę bez GUI) i poprowadził Cię krok po kroku podczas gdy to robisz?
- Chcesz, żebym dodał precyzyjne skróty do Copilot Chat i przetestował działanie (poproszę Cię o wynik po zalogowaniu)?

Wybierz jedną opcję i zaczynam — poprowadzę Cię dokładnie krok po kroku i zweryfikuję efekty.
