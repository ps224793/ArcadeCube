﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcadeCubeSimulator.enums;

namespace ArcadeCubeSimulator.classes
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

        public Direction MyDirection { get; set; } = Direction.NegetiveX;

        public Snake(List<Led> startBody)
        {
            foreach(Led led in startBody)
            {
                MyBody.Add(led);
                led.Value = 2;
            }

            Head = new int[3];
            Head[0] = 0;
            Head[1] = 0;
            Head[2] = 0;
        }
    }
}
