# Volleyball

The Volleyball Game Controller project is a Unity-based application designed to manage and control a volleyball game with two player characters. The project includes scripts for player movement, ball movement, game controls, and score tracking. Each script is responsible for different aspects of the game, ensuring smooth gameplay and interactive features.

The GameController.cs script acts as the main game controller, initializing and updating game states. While currently minimal, it provides the foundation for integrating more complex game logic and interactions as needed.

The StartGameButton.cs script manages the navigation between different scenes in the game. It allows the player to start the game, view controls, and return to the main menu. This script uses Unity's SceneManager to load the appropriate scenes based on user input.

The QuitGame.cs script handles the quitting functionality of the game. It resets and saves the game scores using PlayerPrefs and listens for the Escape key press to quit the application. This ensures that the game state is preserved even when the player exits the game.

The BallMovement.cs script controls the physics and movement of the volleyball. It handles the ball's response to player collisions, applying force in the appropriate direction based on the collision. This script ensures that the ball behaves realistically during the game, adding to the overall gameplay experience.

The BlueLimbMovement.cs and RedLimbMovement.cs scripts manage the limb animations for the blue and red player characters, respectively. They animate the limbs based on user input, creating a dynamic and responsive visual experience for the players.

The BluePlayerControl.cs and RedPlayerControl.cs scripts manage the movement and actions of the blue and red player characters. These scripts handle jumping, moving, and hitting the ball, ensuring that players can interact with the game environment effectively. The control scripts use Unity's physics engine to apply forces and detect collisions, providing a realistic and engaging gameplay experience.

The ScoreCounter.cs script tracks and updates the scores for both players. It displays the scores on the screen using TextMeshProUGUI components and checks for win conditions. When a player scores, it updates the score, saves it, and reloads the appropriate scene to continue the game. The script ensures that the game progresses smoothly and that players are informed of the current scores and win conditions.

Overall, the Volleyball Game Controller project provides a comprehensive framework for managing a volleyball game in Unity. It integrates various scripts to control player actions, ball movement, game states, and scores, creating an interactive and engaging experience for players. The modular design of the scripts allows for easy extension and modification, enabling developers to add new features and improve gameplay as needed.
