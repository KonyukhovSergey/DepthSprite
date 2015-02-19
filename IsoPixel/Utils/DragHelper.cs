using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsoPixel.Utils
{
    public class DragHelper
    {
        private Point startObjectLocation;
        private Point mouseDownLocation;

        public int CurrentObjectLocationX { get; private set; }
        public int CurrentObjectLocationY { get; private set; }

        private bool isMouseDown = false;

        public void OnMouseDown(MouseEventArgs e, int objectLocationX, int objectLocationY)
        {
            startObjectLocation.X = objectLocationX;
            startObjectLocation.Y = objectLocationY;
            mouseDownLocation = e.Location;
            isMouseDown = true;
        }

        public bool OnMouseMove(MouseEventArgs e)
        {
            if (isMouseDown)
            {
                CurrentObjectLocationX = startObjectLocation.X + e.X - mouseDownLocation.X;
                CurrentObjectLocationY = startObjectLocation.Y + e.Y - mouseDownLocation.Y;
                return true;
            }
            return false;
        }

        public bool OnMouseUp(MouseEventArgs e)
        {
            if (isMouseDown)
            {
                OnMouseMove(e);
                isMouseDown = false;
                return true;
            }
            return false;
        }
    }
}
