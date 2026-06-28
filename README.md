# L2.Net

L2.Net is an automated assistant tool (commonly referred to as a 'bot') for Lineage 2 that assists a player's experience during their play. It is similar to [L2Divine](http://www.l2divine.com/) and [L2Walker](http://www.towalker.com/).

WARNING: This software is not designed to circumvent anti-bot software nor is it supported for retail versions of Lineage 2. Using this on servers where botting is not allowed is not supported or condoned in any way.

## Features
* Out of Game Mode, allowing you to fully control your characters without being inside the normal Lineage 2 Client.
* In Game Mode, allowing you to attach to a game client and enhance the gameplay experience (best of both worlds).
* Top-Down Overview map allowing you to interact with the world.
* Combat / Buff/Heal Options to automate skill usage.
* Custom Scripting Support, including packet detection and logic chains.
* Selectable client chronicle/protocol on the login screen (CT1 through High Five).

## Agreement
This program is developed on and for L2J servers ONLY.
Use of this program on any other type of server is against the EULA.
This program comes with no warranty expressed or implied.
Any concerns about copyright or other challenges can be messaged to the open source contributor for review and removal.

## Status (June 2026)
The project has been migrated from .NET Framework / SlimDX to **.NET 10** (Windows Forms, GDI+ map renderer). SlimDX is no longer a dependency, and so is `Microsoft.Windows.Compatibility` (no more `System.Data.SqlClient` vulnerability warnings). See [CHANGELOG.md](CHANGELOG.md) for the full history, including the 2026-06-28 round of bot-logic/scripting fixes (summon assist range, follow distance, party/trade invite events, debug packet logging, etc.).

## Requirements
* Windows 10/11
* [.NET 10 SDK](https://dotnet.microsoft.com/download) or newer
* No native third-party dependencies (SlimDX was removed)

## Compiling
```bash
git clone https://github.com/hyperthermya/L2Net.git
cd L2Net
dotnet restore
dotnet build L2NET.csproj
```
Output is always written to `bin\Release\` (regardless of `-c Debug`/`-c Release`).

Runtime data (`data\`, `config\`, `crests\`, `scripts\`, `maps\`, `icons\`, `sounds\`) lives in [`GameData\`](GameData/) at the repo root and is copied into the build output automatically — no manual setup needed.

## Running
Run `bin\Release\L2NET.exe`. On first launch, pick a chronicle on the login screen (the Protocol field fills in automatically) and either use OOG (out-of-game) login or attach to a running game client (IG).
