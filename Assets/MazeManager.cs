using Assets;
using LabyrinthGenerator;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static LabyrinthGenerator.Room;

public class MazeManager : MonoBehaviour
{
    Room[,] _maze;
    public GameObject cell;

    List<Cell> cells = new List<Cell>();
    // Start is called before the first frame update
    void Start()
    {
        LabyrinthGenerator.LabyrinthGenerator generator = new LabyrinthGenerator.LabyrinthGenerator();
        _maze = generator.Generate(10, 10, 80);

        for (int x = _maze.GetLength(1) - 1; x >= 0; x--)
        {
            for (int y = 0; y < _maze.GetLength(0); y++)
            {
                if (_maze[x, y].IsVisited)
                {
                    GameObject go = Instantiate(cell, new Vector3(x * 3, 0, y * 3), Quaternion.identity);
                    Cell newCell = go.GetComponent<Cell>();
                    newCell.x = x;
                    newCell.y = y;

                    cells.Add(newCell);
                    if (_maze[x, y].IsFirst)
                    {
                        go.ChangeColor(Color.green);
                    }

                    if (_maze[x, y].IsLast)
                    {
                        go.ChangeColor(Color.red);
                    }

                    foreach (Direction dir in Enum.GetValues(typeof(Direction)))
                    {
                        if (dir == Direction.None)
                            continue;
                        Debug.Log(dir);
                        if (!((_maze[x, y].Doors & dir) == dir))
                        {
                            Destroy(newCell.walls.First(wall => wall.direction == dir).wall);
                        }
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
