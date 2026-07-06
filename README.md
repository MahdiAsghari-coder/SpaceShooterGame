Name : MahdiAsghari
StudentNumber: 403411123

# Space Shooter Game

A classic 2D space shooter arcade game built using **C#** and **Windows Forms (WinForms)**. Protect the galaxy from enemy waves, collect coins, buy upgrades, and defeat the final boss!

---

🎮 Game Features & Mechanics

### Core Mechanics
* **Player Movement:** Control your spaceship smoothly using **Arrow Keys**.
* **Shooting System:** Press the **Spacebar** to shoot lasers at enemy ships.
* **Wave Progression:** The game features **10 progressive waves**. The difficulty increases with each wave.
* **Enemy Variety:** Different types of enemies with unique movement patterns, speeds, and health points (HP).
* **Final Boss Battle:** A powerful **Heavy Tank Enemy** appears exclusively in **Wave 10** as the final boss encounter.
* **Game Pause/Exit:** Press the **Esc** key at any time to pause or exit the game.

### UI & Systems
* **Main Menu:** Easy navigation between Start Game, Shop, Options, and About sections.
* **Options Menu:** * Separate **Audio Controls** to mute/unmute Background Music and Sound Effects (SFX) individually.
* **Controls Guide** displaying clear text instructions on how to play the game.
* **About Page:** Displays project info and safely hides the main menu when opened.

---

## ⭐ Bonus Features
* **Shop & Customization System:** Earn coins during gameplay to unlock custom **Ship Skins**, **Background Skins**, and **Bullet Skins**. You can also purchase **Extra HP** upgrades.
* **In-Game Currency:** Features two types of coins with different values:
  * **Silver Coins:** Worth 1 point.
  * **Gold Coins:** Worth 5 points.
  * Drop rates change based on the enemy type and current wave.
* **Power-Up Upgrades:** 3 distinct types of power-ups drop after every 4th enemy kill. 
  * Power-ups freeze and stand still during wave transitions to ensure fair gameplay.
* **Enemy Health Display:** Enemy HP bars are visible right above their heads during battles.
* **Database Integration:** Local database implementation to securely save player high scores, total coins, and purchased store items.

---

## 🚀 How to Run the Project (Step-by-Step)

### Prerequisites
Before running the game, make sure you have installed:
* **Visual Studio** (2022 or newer recommended)
* **.NET Desktop Development** workload (installed via Visual Studio Installer)

### Step 1: Open the Solution
1. Download the project files or clone the repository to your computer.
2. Locate the main solution file named `SpaceShooterGame.sln`.
3. Double-click the `.sln` file to open it automatically in Visual Studio.

### Step 2: Build the Project
1. Look at the top menu bar in Visual Studio.
2. Ensure the build configuration dropdown is set to **Debug** or **Release** and the architecture is set to **Any CPU** or **x64**.
3. Go to the top menu and click on **Build** -> **Build Solution** (or press `Ctrl + Shift + B`).
4. Wait for the output window to show: `Build: 1 succeeded, 0 failed`.

### Step 3: Run the Game
1. Click the green **Start** button (with the play icon) at the top menu bar, or simply press **F5** on your keyboard.
2. The Main Menu will appear, and you can start playing!
