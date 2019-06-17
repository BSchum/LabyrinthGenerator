using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LabyrinthGenerator.Room;

public class Cell : MonoBehaviour
{
    public int x;
    public int y;
    public List<Wall> walls;
}
