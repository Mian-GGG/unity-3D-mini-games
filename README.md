# Unity Mini Games Collection

A collection of three small 3D games developed in **Unity and C#** as part of my university Game Design and Development coursework.

The project brings together three different gameplay experiences: a rolling ball maze, a shooting practice game and a first-person alien shooter. Each mini-game explores different gameplay mechanics, player controls, collision detection and UI functionality.

#Gameplay Video: [Watch the Mini Games gameplay video](https://youtu.be/aXUhnNYF-EU)

## Games Included

### 1. Rolling Ball Game

A 3D maze game where the player controls a ball, navigates through a maze and collects coins along the way.

**Features:**
- Rigidbody-based ball movement.
- Jump functionality.
- Coin collection and score tracking.
- Camera following the player.
- Rotating coin objects.
- Start, pause, resume and restart functionality.
- Win screen with options to restart, return to the main menu or quit.
- Background music.

### 2. Shooting Practice Game

A timed shooting challenge set inside a shooting practice booth. The objective is to hit all available targets before the countdown reaches zero.

**Features:**
- Mouse-controlled crosshair movement using `Quaternion.Euler`.
- Projectile-based shooting.
- Target collision detection.
- Targets become affected by gravity after being hit.
- Target collision is disabled after a successful hit to prevent repeated scoring.
- Countdown timer and score tracking.
- Win and loss screens.
- Pause, restart and main menu functionality.
- Background music and shooting sound effects.

### 3. Alien Shooter

A first-person shooting game where the player uses a sci-fi weapon to eliminate alien targets.

**Features:**
- First-person player movement using Unity's Character Controller.
- Mouse-controlled camera rotation.
- Walking, running, jumping and crouching.
- Raycast-based shooting and hit detection.
- Weapon recoil animation.
- Muzzle flash particle effects.
- Shooting audio effects.
- Destructible alien objects using intact and broken model replacements.
- Score tracking and remaining alien counter.
- Pause and win screens.

## Main Menu

The project includes a central menu that allows players to select between the three mini-games:

- Rolling Ball Game
- Shooting Practice Game
- Alien Shooter

Each game has its own scene and gameplay logic.

## Technical Highlights

### Different approaches to player movement

The project explores multiple approaches to player movement, including Rigidbody-based physics for the rolling ball and Character Controller-based movement for the first-person shooter.

### Projectile shooting and raycasting

The Shooting Practice Game uses instantiated projectile objects with collision detection. In the Alien Shooter, I used Physics Raycasts to detect targets directly, avoiding the need to instantiate physical bullets for every shot.

### Destructible objects

The Alien Shooter uses two versions of the alien model: an intact version and a broken version. When the player successfully shoots an alien, the intact model is replaced by the broken version to create a destruction effect.

### Gameplay systems and UI

All three games include gameplay-related UI elements and systems, such as score counters, timers, pause menus, restart functionality and win conditions.

## Technologies Used

- C#
- Unity
- Unity Physics and Rigidbody
- Character Controller
- Physics Raycasting
- TextMeshPro
- Particle Systems
- Unity Scene Management
- Unity Audio Sources

## Controls

### Rolling Ball Game
- **W / S / A / D:** Move the ball
- **Space:** Jump
- **Escape:** Pause the game

### Shooting Practice Game
- **Mouse:** Aim the crosshair
- **Left Mouse Button:** Shoot
- **Escape:** Pause the game

### Alien Shooter
- **W / A / S / D:** Move
- **Mouse:** Look around and aim
- **Left Shift:** Run
- **Space:** Jump
- **R:** Crouch
- **Left Mouse Button:** Shoot
- **Escape:** Pause
- **K:** Resume the game

## Repository Contents

This repository contains selected C# scripts from the original Unity project, organised by mini-game.

The complete Unity project, including its scenes, models, textures, audio and other assets, is not included due to its size. A playable Windows build is provided separately through the GitHub Releases section.

## Download and Play

A Windows build is available under [**GitHub Releases**.](https://github.com/Mian-GGG/unity-3D-mini-games/releases/tag/v1.0)

1. Download the Windows ZIP archive.
2. Extract the archive.
3. Open the extracted folder.
4. Run the game executable.

## Project Background

This collection was developed as part of three separate Unity lab tasks during my university studies. Each task introduced different gameplay mechanics and provided an opportunity to experiment with Unity's physics, player controls, shooting systems, animations and user interface functionality.

The project helped me develop practical experience with Unity and C#, particularly in implementing gameplay mechanics and working with different approaches to interaction and collision detection.
