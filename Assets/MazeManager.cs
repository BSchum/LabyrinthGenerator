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

    // Start is called before the first frame update
    void Start()
    {
        LabyrinthGenerator.LabyrinthGenerator generator = new LabyrinthGenerator.LabyrinthGenerator();
        _maze = generator.Generate(5, 5, 20);


        for (int y = 0; y < _maze.GetLength(1); y++)
        {
            for (int x = 0; x < _maze.GetLength(0); x++)
            {
                if (_maze[x, y].IsVisited)
                {
                    GameObject go = Instantiate(cell, new Vector3(x *3 * 5, 0, y*3 * 3), Quaternion.identity);
                    Cell newCell = go.GetComponent<Cell>();
                    newCell.x = x;
                    newCell.y = y;
                    go.name = $"Cell {newCell.x},{newCell.y}";

                    if (_maze[x, y].IsFirst)
                    {
                        go.ChangeColor(Color.green);
                    }
                    else
                    {
                        go.GetComponentInChildren<Camera>().gameObject.SetActive(false);
                    }

                    if (_maze[x, y].IsLast)
                    {
                        go.ChangeColor(Color.red);
                    }

                    foreach (Direction dir in Enum.GetValues(typeof(Direction)))
                    {
                        if (dir == Direction.None)
                            continue;
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
