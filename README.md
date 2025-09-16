DIgital Drift
Digital Drift is a fast-paced 2D arcade platformer set inside a stylized digital world. Players control Hercules, a digital avatar navigating through corrupted system levels inspired by computer hardware components. The game challenges reflexes, precision, and adaptability through three uniquely themed environments with escalating difficulty.
Game Overview
Genre: 2D Arcade Platformer
Platform: PC (Unity)
Visual Style: Retro-digital with glitch aesthetics
Main Character: Hercules
Digital Drift combines narrative cutscenes with fast-paced gameplay, where each level represents repairing a corrupted computer system component. The game starts with a broken boot sequence and progresses through BIOS, RAM, and monitor restoration.
Gameplay Features

Three Distinct Levels with unique mechanics and challenges
Narrative Structure told through stylized cutscenes between levels
Escalating Difficulty that tests different player skills
Endless Mode unlocked after completing the story
Retro-Digital Aesthetic with glitch effects and terminal visuals

Level Breakdown
Level 1: BIOS Blitz
Dodge and Collect Challenge
Players must dodge falling blocks while collecting 10 BIOS chips scattered from above. Movement is lateral with highly responsive controls. Block spawn rate increases over time while BIOS chips become rarer, creating mounting tension. One collision with a block results in instant failure.
Mechanics:

Left/right movement
Falling hazard avoidance
Item collection (BIOS chips)
Increasing spawn difficulty


Level 2: RAM Rush
Endless Runner with Jumping
Set in a memory overflow environment, players must outrun a corrupt data wall advancing from behind. Jump between floating memory platforms while maintaining forward momentum. The level ends successfully when reaching the exit without being caught or falling.
Mechanics:

Horizontal movement with camera following
Platform jumping
Advancing threat (data wall)
Precision platforming


Level 3: Monitor Maneuver
Flappy Bird-Inspired Challenge
Navigate through gaps in corrupted monitor distortions by tapping to "flap" upward while gravity pulls down. Players must pass through 10 obstacle gaps without collision. Success requires mastering rhythm and timing with minimal controls.
Mechanics:

Tap-to-flap flight
Gravity physics
Precision gap navigation
Rhythm-based gameplay


Endless Mode
Post-Game Survival Challenge
Unlocked after story completion, this mode features procedurally generated platforms with increasing speed. Players aim for high scores while surviving as long as possible.
![Endless Mode Screenshot Placeholder]
Screenshot: Procedurally generated endless level
Technical Implementation
Unity Development
Engine: Unity
Programming Language: C#
Audio: SoundLab assets
Art Tools: Photoshop, Illustrator
Code Structure
The game implements several key systems:
Player Controller

Responsive movement mechanics
State-based animation system
Collision detection and response

Level Management

Scene transitions between cutscenes and gameplay
Progress tracking and save states
Dynamic difficulty scaling

Spawning Systems

Procedural hazard generation
Collectible placement algorithms
Endless mode level generation

Audio Integration

Dynamic sound effects triggered by game events
Layered background music system
Audio optimization for performance

Performance Considerations

Efficient object pooling for spawned elements
Optimized sprite rendering
Memory management for endless mode
Cross-platform compatibility testing

Narrative Structure
The game follows a computer boot sequence metaphor:

Broken Boot (Cutscene) - System crash and Hercules launch
BIOS Blitz (Level 1) - Restore basic system functions
BIOS Restored (Cutscene) - Memory module detection
RAM Rush (Level 2) - Fix memory overflow
System Check (Cutscene) - Monitor driver corruption detected
Monitor Maneuver (Level 3) - Repair display system
Working Boot (Cutscene) - System fully restored

Each cutscene displays terminal-style boot logs and system status updates, creating an immersive digital repair narrative.
Installation & Setup
Prerequisites

Unity 2021.3 LTS or later
Windows PC for testing
Basic understanding of Unity project structure

Running the Game

Clone or download the project repository
Open the project in Unity
Load the main menu scene
Press Play in Unity editor or build for standalone

Building for Distribution

Open Build Settings in Unity
Select target platform (PC, Mac, Linux)
Configure build settings
Click Build to create executable

Controls
Menu Navigation: Mouse click
Level 1 & 2: A/D or Arrow Keys (left/right movement), Space (jump in Level 2)
Level 3: Space or Mouse Click (flap)
General: ESC (pause/menu)
Known Issues & Future Development
Current Limitations

Score overflow bug in endless mode (scores above 999)
Limited platform variety in endless mode
No mobile optimization

Planned Features

Mobile touch controls
Additional hardware-themed levels (CPU, GPU, Storage)
Leaderboard system
Sound options menu
Visual accessibility options

Development Notes
This project was developed as a collaborative effort focusing on rapid prototyping and iterative design. The game serves as both an entertaining arcade experience and a technical demonstration of Unity development skills.
The retro-digital aesthetic was chosen to complement the computer hardware theme while maintaining visual clarity for fast-paced gameplay. Each level introduces new mechanics to keep the experience varied despite the short play time.
Credits
Programming: Ethan - Game logic, mechanics, scene transitions
Character Art: Tevin - Sprite design, animations, UI elements
Sound Design: Gideon - Music composition, SFX integration
Level Design: Herfser - Layout, pacing, challenge balancing
Project Management: Alvin Michael Ogola - Testing, coordination, quality assurance
License
This project is developed for educational purposes. All original assets and code are available under standard academic use guidelines.
