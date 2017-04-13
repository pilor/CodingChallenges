using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1_Maze
{
    public class Pointer
    {
        private int y;
        private int x;

        public Pointer() { }

        public Pointer(int y, int x)
        {
            this.y = y;
            this.x = x;
        }

        public int getY()
        {
            return y;
        }

        public int getX()
        {
            return x;
        }

        public void setY(int y)
        {
            y = this.y;
        }

        public void setX(int x)
        {
            x = this.x;
        }
    }
}
