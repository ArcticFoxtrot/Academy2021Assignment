# Academy2021Assignment

Known issues:
On game over, if the player happens to click once right after the player has hit an obstacle, the game restarts because the "click anywhere" condition for restarting the game has been fulfilled. Not game breaking.

Features that I would like to add:

Obstacle ordering to sequences:
Currently the spawning of obstacles is done randomly from a pool of prefabs. This is not particularly rewarding gameplay if by chance the player gets the same obstacle multiple times in a row, even with changing rotation directions. Creating ordered obstacle sequences could be done with multiple ways. One would be to change the spawning to work on a higher level where the different x amount of obstacles are bundled under one gameobject, and that parent object is spawned. This would allow designers more power over what the gameplay feels like. Another way to handle something similar could be to tag the different obstacles to have a difficulty level or other type, and these types would have separate pools. Then the spawner could every time pick one obstacle from a different pool to create variation, and the spawner could be told to pick 1 from each pool in sequence, so you could have e.g. a rising level of difficulty for every 4 obstacles.

Oscillating obstacles:
In the current implementation the objects only rotate around a pivot point, either their own pivot or a parent object's pivot. Having objects that move around would be in interesting gameplay feature. There are many ways to achieve this, but a sufficient way could be to create a sine wave movement for the obstacle's transform.position.

Highscore saving:
It would be great to know what was the highest score the player has had at least for the current session. I'd do this by creating a persistent object in the GameScene which is not destroyed on load, and which maintains itself as a singleton. Then this object could store in itself always the maximum score for that one active session. This could also be applied to Player Prefs so that it would not be specific to that one active session

