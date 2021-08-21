# Academy2021Assignment

This Code Switcher clone was created as an Assignment to the recruitment process of Next Games' Game Developer Trainee program 2021.
The game is a simple clicker where the player can jump upwards by clicking the game screen. The objective is to collect stars and avoid wrong colored obstacles.

Player and Camera:
I implemented this Code Switcher using a bunch of built-in functionality from Unity, like Rigidbody2D physics handling the player's movement and gravity.
The player's interaction with obstacles, stars and colorswitchers are handled through the use of 2D colliders. This is a fairly simple way to call necessary functions from each interacting object.

Camera controls are based on the position of the player with a damping so that the movement should be semi-smooth.

Spawned objects - Obstacles, Colorswitchers and Stars:
For the obstacles I used the sprite editor to create custom polygon colliders, where I also tried to implement some buffer between the collission areas and the actual obstacle sprites to avoid those moments where the player thinks they didn't hit the obstacle, when in fact the player object hit the obstacle right at the edge.
The obstacles in this implementation only rotate around their own pivot point or around a parent objects' pivot.
Obstacles are spawned at random from a pool of 7 obstacles at a set interval. I chose this as the way to spawn the obstacles since it does create variation to every playthrough, but the approach does sometimes lead to repeating the same obstacle a couple of times in a row.
To handle the player hitting and obstacle I created an event in the PlayerDeathHandler. This prevented having some tight couplings between objects

The colorswitchers use circle colliders to interact with the player, and this interaction calls a function from the player object, which sets a new color for the player. This also causes the colorswitcher to self-destruct and give off a nice jingle and some particle effects.

The stars also use a circle collider to interact with the player. I thought that for this object it was a close enough way to handle the interaction. Hitting a star causes the score keeper to increase the current score for the player.

The spawners of stars, colorswitchers and obstacles all move with the camera, and since the camera does not move downward the spawning functionality was fairly simple to achieve. However, having a unified distance between spawns of obstacles can make some distances between obstacles too easy or too difficult.

Other:
To do some housekeeping and prevent the gamescene being cluttered with gameobjects during gameplay, I added a Shredder object to destroy any gameobjects which are below the play area. This functions with 2D colliders and layermasking.

Scorekeeping was done with a singleton pattern ScoreKeeper component for simplicity. This could be further elaborated to Player Prefs.

UI management components are all under the same UI Canvas object, and they handle the game start and game over situations with the SceneLoader.

Known issues:
On game over, if the player happens to click once right after the player has hit an obstacle, the game restarts because the "click anywhere" condition for restarting the game has been fulfilled. Not game breaking.

Features that I would like to add:

Obstacle ordering to sequences:
Currently the spawning of obstacles is done randomly from a pool of prefabs. This is not particularly rewarding gameplay if by chance the player gets the same obstacle multiple times in a row, even with changing rotation directions. Creating ordered obstacle sequences could be done with multiple ways. One would be to change the spawning to work on a higher level where the different x amount of obstacles are bundled under one gameobject, and that parent object is spawned. This would allow designers more power over what the gameplay feels like. Another way to handle something similar could be to tag the different obstacles to have a difficulty level or other type, and these types would have separate pools. Then the spawner could every time pick one obstacle from a different pool to create variation, and the spawner could be told to pick 1 from each pool in sequence, so you could have e.g. a rising level of difficulty for every 4 obstacles.

Oscillating obstacles:
In the current implementation the objects only rotate around a pivot point, either their own pivot or a parent object's pivot. Having objects that move around would be in interesting gameplay feature. There are many ways to achieve this, but a sufficient way could be to create a sine wave movement for the obstacle's transform.position.

Highscore saving:
It would be great to know what was the highest score the player has had at least for the current session. I'd do this by creating a persistent object in the GameScene which is not destroyed on load, and which maintains itself as a singleton. Then this object could store in itself always the maximum score for that one active session. This could also be applied to Player Prefs so that it would not be specific to that one active session

