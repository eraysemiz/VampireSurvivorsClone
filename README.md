# Hellswarm - Game with Unity

#### Video Demo:  <https://youtu.be/Q5D3X1vZRM0>

#### Description:
I made a rogue-lite game with Unity for my final project for CS50's Introduction to Computer Science course. This game is an action game, and some people call this type of game 'bullet hell.' When I was making this game, I was inspired by the famous game called 'Vampire Survivors.' My goal was to create an intense survival experience where players must constantly fight off waves of enemies while upgrading their character to survive longer.

When you start the game, it welcomes you with a login page where you can enter your preferred username and begin playing. Once you hit the 'Start Game' button, the game begins, and you are now in control of a character who is trapped in a hellish universe filled with relentless enemies. You must navigate this dangerous world, surviving as long as possible while fighting off countless waves of enemies.

### Gameplay Mechanics:
You have two weapons at your disposal:
1. **Knife** – A ranged weapon that is thrown in the direction you are moving. It is effective at targeting enemies in front of you.
2. **Garlic** – An area-of-effect weapon that deals continuous damage to enemies within a certain radius around your character. This weapon rotates and damages enemies as they approach.

### Enemies:
There are three types of enemies in this game:
1. **Bat** – The weakest enemy in the game, but it appears in large numbers. The longer you survive, the more frequently they spawn.
2. **Red Bat (a.k.a. Mini Boss)** – A stronger version of the bat with higher health and attack power. It spawns less frequently but becomes more common as time passes.
3. **Dracula (a.k.a. Final Boss)** – The most powerful enemy in the game. Dracula has a massive health pool and deals significant damage. He appears when the player reaches a certain level and begins following them. He attacks by shooting fireballs and energy balls, which cause enormous damage upon impact.

Bats and Red Bats continuously spawn in waves, increasing in frequency as the game progresses. When Dracula is defeated, the game ends, and the player is taken to the end-game screen, where they can view their score on the scoreboard or start a new game.

### Leveling and Upgrades:
When enemies are defeated, they drop **experience gems**. By collecting enough of these gems, you can level up. Each time you level up, you are presented with three upgrade options:
- **Upgrade your knife weapon** – Increases the damage and speed of your knife attacks, allowing for faster eliminations.
- **Upgrade your garlic weapon** – Expands its area of effect and increases its damage, making it more effective against swarming enemies.
- **Upgrade your physical stats** – Increases your character's maximum health and movement speed, enhancing survivability.

Throughout the game, you can pause by pressing the **Escape** button on your keyboard. The pause menu allows you to continue playing or exit the game.

### World Design and Items:
To add more depth to the world, I included breakable props scattered throughout the map. These props contain useful items and can be destroyed by the player. When broken, they drop one of two potions:
1. **Speed Potion** – Temporarily increases the player's movement speed.
2. **Health Potion** – Restores missing health, allowing the player to recover from damage taken during fights.

These props spawn randomly at various locations on the map, adding an element of strategy as players must decide whether to destroy them for potential rewards or focus on fighting enemies.

### Controls:
- **Movement:** Controlled using the "WASD" keys.
- **Attacks:** The knife is thrown in the direction the player is facing, while the garlic weapon automatically damages nearby enemies.
- **Enemy Behavior:** Enemies move toward the player's current location. If an enemy or their projectiles hit the player, they lose health. When the player's health reaches zero, they die, and the game ends.

### How to Play:
1. Run the game by clicking "VampireSurvivorsClone.exe."
2. Enter your username.
3. Hit the start button.
4. Move your character using the "WASD" keys.
5. Survive as long as possible by attacking enemies and collecting upgrades.

### Folder and File Structure:
The project follows a structured organization, with assets and scripts divided into specific folders:

- **Assets/Prefabs** – Contains prefabs of game objects.
- **Assets/Scenes** – Stores game scenes.
- **Assets/Scriptable Objects** – Holds scriptable objects that define stats for players, enemies, and weapons.
- **Assets/Scripts/Enemy** – Scripts controlling enemy behavior, attacks, animations, and stats.
- **Assets/Scripts/Player** – Scripts managing player behavior, attacks, animations, stats, controls, and camera movement.
- **Assets/Scripts/FinalBoss** – Scripts that define Dracula's behavior and attacks.
- **Assets/Scripts/Weapons** – Scripts handling weapon mechanics, stats, and functionality.
- **Assets/Scripts/Pick-ups** – Scripts controlling collectible items and their effects.
- **Assets/Scripts/Map** – Scripts governing the game world, prop spawning, and prop randomization.
- **Assets/Scripts/Menu** – Scripts that handle menu navigation and the upgrade system.
- **Assets/Scripts/** – General scripts for button functionality and database interaction.

### Additional Features and Future Improvements:
While the game is fully functional, there are several ways it can be expanded and improved:
1. **New Weapons and Abilities** – Adding more weapon types with unique mechanics, such as fire-based attacks or summoning minions.
2. **More Enemy Variants** – Introducing different enemy types with unique attack patterns and behaviors.
3. **Multiplayer Mode** – Implementing a co-op mode where multiple players can fight waves of enemies together.
4. **More Maps and Levels** – Expanding the world with different environments and level designs.
5. **Sound and Visual Enhancements** – Improving the game's sound effects and animations for a more immersive experience.

With these improvements, **Hellswarm** has the potential to become an even more engaging and thrilling game for players who enjoy fast-paced action and survival mechanics.

