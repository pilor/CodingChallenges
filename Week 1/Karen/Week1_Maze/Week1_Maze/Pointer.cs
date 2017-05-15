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
        private int current;
        private Pointer parentPointer;

        public Pointer() { }

        public Pointer(int y, int x)
        {
            this.y = y;
            this.x = x;
        }

        public Pointer(int y, int x, int current)
        {
            this.y = y;
            this.x = x;
            this.current = current;
        }

        public Pointer(Pointer newPointer)
        {
            this.y = newPointer.y;
            this.x = newPointer.x;
            this.current = newPointer.current;
            this.parentPointer = newPointer.parentPointer;
        }

        ////public int Y
        ////{
        ////    get { return this.y; }
        ////    set { this.y = value; }
        ////}

        public int Y { get; set; }

        public int getX()
        {
            return x;
        }

        public int getCurrent()
        {
            return current;
        }

        public Pointer GetParentPointer()
        {
            return parentPointer;
        }

        public void setY(int y)
        {
            this.y = y;
        }

        public void setX(int x)
        {
            this.x = x;
        }

        public void setCurrent(int current)
        {
            this.current = current;
        }

        public void setParentPointer(Pointer parentPointer)
        {
            this.parentPointer = parentPointer;
        }
    }
}
