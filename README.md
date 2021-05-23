# Game of Life - Unity

It is a zero-player game based on the concept by John Horton Conway. Game's evolution is determined by its initial state. The Game is two-dimensional orthogonal grid of square cells. Each Cell can have 2 possible states "Alive" or "Dead".

Rules are simple : 
   1. Any live cell with fewer than two live neighbours dies, as if by underpopulation.
   2. Any live cell with two or three live neighbours lives on to the next generation.
   3. Any live cell with more than three live neighbours dies, as if by overpopulation.
   4. Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.

This project is pretty much based on the same concept. For now, the initial state is randomely generated. theres a Button to start the Game and a slider to control the evolution speed.

The `Cell.cs` script contains the properties of Cell. And `Game.cs` contains the rest of the logic. At the moment, It randomely sets Alive state of cells at the start, but you could add a manual way to do that. Just remove the line `grid[x, y].SetAlive(RandomAlive());` from `Game.cs/PlaceCells()` and use mouse click events in `Cell.cs`.

### Project was made with Unity version 2019.3.11f1.
