using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    private static int WIDTH = 64;
    private static int HEIGHT = 48;
    public GameObject cellPref;
    public float speed = 0.1f;

    private float timer;
    private bool isGameStarted = false;

    Cell[,] grid = new Cell[WIDTH, HEIGHT];

    //Start the game
    public void StartGame()
    {
        PlaceCells();
        isGameStarted = true;
    }

    public void ChangeSpeed(float sliderSpeed)
    {
        sliderSpeed = 1 - sliderSpeed;
        speed = sliderSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameStarted)
        {
            if (timer >= speed)
            {
                timer = 0;
                CountNeighbors();

                PopulationControl();
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }
	
	void PlaceCells()
	{
		for(int y = 0; y < HEIGHT; y++)
		{
			for(int x = 0; x < WIDTH; x++)
			{
                var obj = Instantiate(cellPref, new Vector2(x, y), Quaternion.identity);
                Cell cell = obj.GetComponent<Cell>();
				grid[x, y] = cell;
				grid[x, y].SetAlive(RandomAlive());
			}
		}
	}
	
	void CountNeighbors()
	{
		for(int y = 0; y < HEIGHT; y++)
		{
			for (int x = 0; x < WIDTH; x++)
			{
				int numNeighbours = 0;
				if(y+1 < HEIGHT)
				{
					if(grid[x, y + 1].isAlive)
						numNeighbours++;
				}
				if(x+1 < WIDTH)
				{
					if(grid[x+1, y].isAlive)
						numNeighbours++;
				}
				if(y-1 >= 0)
				{
					if(grid[x, y-1].isAlive)
						numNeighbours++;
				}
				if(x-1 >= 0)
				{
					if(grid[x-1, y].isAlive)
						numNeighbours++;
				}
				
				if(x+1 < WIDTH && y+1 < HEIGHT)
				{
					if(grid[x+1, y+1].isAlive)
						numNeighbours++;
				}
				
				if(x-1 >= 0 && y+1 < HEIGHT)
				{
					if(grid[x-1, y+1].isAlive)
						numNeighbours++;
				}
				if(x+1 < WIDTH && y-1 >= 0)
				{
					if(grid[x+1, y-1].isAlive)
						numNeighbours++;
				}
				
				if(x-1 >= 0 && y-1 >= 0)
				{
					if(grid[x-1, y-1].isAlive)
						numNeighbours++;
				}
				
				grid[x, y].neighbours = numNeighbours;
			}
		}
	}
	
	void PopulationControl()
	{
		for(int y = 0; y < HEIGHT; y++)
		{
			for (int x = 0; x < WIDTH; x++)
			{
				if(grid[x, y].isAlive)
				{
					if(grid[x, y].neighbours != 2 && grid[x, y].neighbours != 3)
					{
						grid[x, y].SetAlive(false);
					}
				}
				else
				{
					if(grid[x, y].neighbours == 3)
						grid[x, y].SetAlive(true);
				}
			}
		}
	}
	
	bool RandomAlive()
	{
		int rand = UnityEngine.Random.Range(0, 100);
		if(rand < 40)
			return true;
		else
			return false;
	}
}
