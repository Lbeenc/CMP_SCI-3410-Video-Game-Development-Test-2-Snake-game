# CMP_SCI-3410-Video-Game-Development-Test-2-Snake-game


CS3410 Video Game Design and Development - Test 2
Due: 5/18 (11:59PM)
Requirements:
● Create a 3D game named Snake Byte. The game should meet the following
requirements:
○ See the accompanying video and implement this game. Your game should
basically look and work like the one in the video. You may customize the skin
color of your snake as you like.
○ The object of the game is to eat as many apples as you can before you die by
bumping into a wall or yourself.
○ First create a 20 20 rectangular grid, surrounded by walls (see Fig. 1). The snake
is made up of a chain of cubes, where each cube is occupying exactly one grid
cell.
○ The snake moves discretely, not continuously, from one grid cell to the next. For
example, the snake occupying 5 cells (10, 10), (10, 9), (10, 8), (10, 7), (10, 6),
moves in one step to (10, 11), (10, 10), (10, 9), (10, 8), (10, 7) if the current
moving direction is up.– The user presses LEFT, RIGHT, UP, DOWN arrow keys
to turn left, right, up, down, respectively.However, only 90-degree turn is allowed
each time. For example, nothing happens if you press LEFT while the snake is
moving RIGHT (180-degree turn is not allowed).
○ If no key is pressed, the snake continues to move in the current direction (the
snake never stops moving whether a key is pressed or not). Thus, user doesn’t
need to hold down a key to keep it moving.
○ It is important to note that when the snake turns, only the head cube turns. Each
of the remaining cubes in the snake body then simply shifts one unit to the cube
right in front of it (towards head). And that is why we see the snake possibly
bending in multiple places as in Fig. 1.
○ Each time the snake eats an apple, the snake gets longer by 3 units. This is
accomplished by adding 3 tail cubes at the current tail cube position, then over
the next 3 snake steps, a longer snake will emerge. Initially, the snake has the
length of 5 cubes moving upward.
○ Each time the snake eats an apple (sphere), a new apple is generated at a
random grid cell that is not currently occupied by snake body and at least 5 units
away from the snake head.
○ Display and update score to indicate the number of apples eaten so far. Use
BradBunR font included in test2 assets.zip.
○ When the snake bumps into a wall or itself, stop the game and display Game
Over. Note that collision must be detected before snake actually penetrates wall
or self (see video).
○ Generate sound when snake bites apple (bite apple.mp3), and when bumps into
wall/self (zap.mp3).
○ Add Restart button to let user restart once the game is over. (Missing restart
button will lead to point deduction)
● Finally, build your game as follows:
○ First, create the Build folder under your Unity project directory.
○ Select Windows as your target platform (even if you’re using Mac).
○ Click Build and select the Build folder you just created.
○ The build file (.exe) must be created under the Build folder. (Missing build file
will lead to point deduction)
