# Unity Slot Machine Game

## Game Overview

This is a simple slot machine game created in Unity for a game development assignment.

The player spins three slot reels using a spin button. The player wins when all three reels stop on the same symbol. Different symbols have different payout values.

The goal of this project is to demonstrate basic Unity development skills, clean code structure, reel animation, random number generation, UI handling, and simple game logic.

---

## Planned Features

- Three slot machine reels
- Smooth reel spinning animation
- Randomized symbol results
- Win condition when all three symbols match
- Different payout values for different symbols
- Clear win and lose messages
- WebGL build included in the repository

---

## How to Play

1. Open the game.
2. Pull the lever.
3. If all three reels stop on the same symbol, the player wins coins.
4. If the symbols do not match, the player can try again.

---

## WebGL Build

A WebGL build of the game is included in this repository.

Build location:

```text
Build/WebGL
```

### How to Run the WebGL Build

Unity WebGL builds should be run through a local web server.

Opening `index.html` directly may not work in some browsers because WebGL files can be blocked when loaded using `file://`.

To make running the build easier, a batch file is included inside the WebGL build folder.

### Run on Windows

1. Open the project folder.

2. Go to:

```text
Build/WebGL
```

3. Double-click:

```text
Run_WebGL_Server.bat
```

4. The game should automatically open in your browser at:

```text
http://localhost:8000
```

If the browser does not open automatically, copy and paste the link above into your browser.

### Alternative Method

If the batch file does not work, open a terminal inside the `Build/WebGL` folder and run:

```bash
py -m http.server 8000
```

Then open this link in your browser:

```text
http://localhost:8000
```

---

## Screenshot

<img width="1079" height="607" alt="image" src="https://github.com/user-attachments/assets/ecb3dd51-fa30-4d4a-bd54-384ffe910b01" />

---

## Gameplay Video

https://github.com/user-attachments/assets/3eff8a42-6972-4a05-a949-4b92984e2e51

## Built With

- Unity
- C#

---

## Asset Notice

The visual assets used in this project were provided as part of the Slot Game Assignment test material.

They are included only for the purpose of completing and submitting this assignment. I do not claim ownership of the provided art assets.

---

## Developer

Created by **Kavindu Pabasara Geeganage**
