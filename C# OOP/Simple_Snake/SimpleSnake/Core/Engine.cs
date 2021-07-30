using SimpleSnake.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private Point[] pointsOfDirection;

        public void Run()
        {

        }

        private void CreateDirections()
        {
            this.pointsOfDirection[0] = new Point(1, 0);
            this.pointsOfDirection[1] = new Point(-1, 0);
            this.pointsOfDirection[2] = new Point(0, 1);
            this.pointsOfDirection[3] = new Point(0, -1);
        }

        private void GetNextDirection()
        {

        }

    }
}
