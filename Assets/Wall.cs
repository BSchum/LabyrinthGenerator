using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static LabyrinthGenerator.Room;

namespace Assets
{
    [Serializable]
    public struct Wall
    {
        public GameObject wall;
        public Direction direction;
        public GameObject anchor;
    }
}
