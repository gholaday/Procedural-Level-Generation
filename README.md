# Procedural Level Generation (Spleunky)
Trying to replicate procedural generation algorithms - starting with Spelunky.

# How it works
It is a procedural algorithm that makes a 4x4 levels, 12 "rooms" in all. 
It starts on the top row and goes from left to right, when it hits a wall, it places a "down" room and moves down, where it then places a up room.
How I did it was create a 4x4 2D array, and populate it with the type of room that the generator makes. 1 for empty room, 2 for left-right, 3 for down and 4 for up.

Then I create by hand prefabs that correspond to the type of rooms. So a left-right room has an opening to the left and right, an up room has an opening at the top, and so on.
This way, there will always be a path from the top to the bottom row that you can take without having to destroy a tile. 

Eventually I will implement randomness to each prefab room. This works by iterating through each tile, and randomly replacing certain tiles.
Then of course, enemies, chests and items need to be placed randomly as well. 

As you can see, even from just a handful of prefabs and tilesets I can already generate pretty unique levels. The green rooms is the designated "starting room" and the red is the "ending room".

![Screenshot1](http://i.imgur.com/mzbsJpo.png)

(although due to an error with one of my prefab rooms the path is blocked by one tile - oops!)

![Screenshot2](http://i.imgur.com/nSY0ors.png)
![Screenshot3](http://i.imgur.com/aS1fn0T.png)
