using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcadeCubeSimulator.enums;
using ArcadeCubeSimulator.classes.main;

namespace ArcadeCubeSimulator.classes.Snake
{
    public class Snake
    {
        private List<Led> _body = new List<Led>();

        public int[] Head { get; set; }

        public List<Led> MyBody
        {
            get { return _body; }
            set { _body = value; }
        }

        public Direction MyDirection { get; set; } = Direction.PositiveX;

        public Snake(List<Led> startBody)
        {
            foreach(Led led in startBody)
            {
                MyBody.Add(led);
                led.Value = 2;
            }

            Head = new int[3];
            Head[0] = 500000;
            Head[1] = 500000;
            Head[2] = 500000;
        }
    }
}
