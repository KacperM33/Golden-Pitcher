# 🏆 Golden Pitcher 
This project is a **2D RPG game** with a top-down view, where the player takes on the role of an undying knight. 
The goal is to defeat an ominous threat while navigating through dark catacombs, interacting with other knights, 
combat with ghosts, and collecting magical artifacts in the form of Golden Pitchers.

## 📚 About This Project
This project was completed as the final assignment for the *Computer Games Development* course during my engineering studies.

## 🧰 Development Tools
- Unity Engine
- C#
- [Tilemap](https://learn.unity.com/tutorial/introduction-to-tilemaps#)

## 🎮 Gameplay
### 🔸 Main Menu
The player starts on the main menu screen, where they can:
- Start the game
- Check the controls
- Exit the game

![image](https://github.com/user-attachments/assets/39f249b9-9c64-4201-a848-017ebfec8a36)

### 🔸 Controls
Player controls are as follows:
- Move up: **W**
- Move down: **S**
- Move right: **D**
- Move left: **A**
- Run: **Left Shift**
- Interact: **E**
- Attack: **Left Mouse Button**

![image](https://github.com/user-attachments/assets/838206fc-907d-48ac-917e-1581f5d425b1)

### 🔸 Game start
When the player starts the game, they spawn in the game world. There is one map level, divided into chapters.. 
<br>The goal is to collect **Golden Pitchers**, which are used to unlock gates and access new chambers until reaching the end of the game.

![image](https://github.com/user-attachments/assets/0b89fa04-4072-4908-88ca-9aa852cb3602)

### 🔸 User Interface
The user interface is simple and includes two main elements at the top of the screen:
1. **Health and Energy Bars** – The red bar shows health. When it reaches 0, the player dies. The green bar represents energy used for running. It depletes while sprinting and regenerates when the player stops.
2. **Golden Pitchers Counter** – Displays the number of collected **Golden Pitchers**.

![image](https://github.com/user-attachments/assets/6492437c-82cc-4554-bc19-6dff7d475df8)

### 🔸 Interactions
The player can interact with:
- ***Bonfires*** - Restore health, create a respawn point at the current location, and revive all enemies.
- ***NPCs*** - Non-player characters that offer information about the game world.
- ***Golden Pitchers*** - Must be collected to progress through the game.
- ***Gates*** - Block access to new chapters. The player needs a required number of **Golden Pitchers** to open them.

![image](https://github.com/user-attachments/assets/5b307061-749e-4b5b-8d2b-0ebb23375450)

### 🔸 Exploring through the world
While exploring, the player encounters enemies in the form of dark ghosts. These ghosts vary in health points and damage stats.
<br>Environmental elements and decorations can also obstruct the player's movement.
<br><br>When an enemy spots the player, it begins to attack. The player can only fight **one enemy at a time**. 
If more than one enemy engages, the player must retreat, break their aggro, and return to fight them one by one (or avoid them entirely).

![image](https://github.com/user-attachments/assets/f3179d1e-90ab-42c9-8fbd-44114cfa29fd)

### 🔸 Death
When the player dies, a death screen appears. Choosing to respawn returns the player to the last bonfire they rested at.

![image](https://github.com/user-attachments/assets/103cefee-73f7-4f49-b4e5-3ec61cba119b)

### 🔸 Map

![image](https://github.com/user-attachments/assets/46ab0837-bf65-4590-a92c-86f7b0842bae)

## 💭 Personal Experience
Creating this game was an interesting and enriching experience. It showed me how much effort is required to create your own game. However,
working on this project was a lot of fun and great opportunity to learn new things, such as game development, including mechanics, world creation, design,
and storytelling. I enjoyed tackling challenges, despite the fact that sometimes they were a struggle, but they ultimately led me to a better understanding 
of game desing. The hardest and most arduous part of the project was finding and creating/changing graphics that would match the game's theme.

## 🎨 Assets & Resources
Graphics:
- [Rogue Fantasy "Catacombs"](https://szadiart.itch.io/rogue-fantasy-catacombs)
- [Tiny Swords](https://pixelfrog-assets.itch.io/tiny-swords)
- [Cloud City Tileset](https://finalbossblues.itch.io/cloud-city-tileset)
- Other graphics was generated with AI ( [ChatGPT](https://chatgpt.com) & [Google Gemini](https://gemini.google.com) )

Fonts:
- [Almendra](https://www.fontsquirrel.com/fonts/almendra )
- [Dragons Gravity](https://fontriver.com/font/dragons_gravity)
- [ST-Nizhegorodsky](https://fontriver.com/font/st_nizhegorodsky)
- [Fear Logo Fires](https://fontriver.com/font/fear_logo_fires)
