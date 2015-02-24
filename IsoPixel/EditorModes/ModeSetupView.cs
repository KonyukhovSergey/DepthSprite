using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoPixel
{
    public class ModeSetupView : EditorModeBase
    {
        private Point startObjectLocation = new Point();
        private Point startMouseLocation = new Point();
        private bool isMove = false;

        public ModeSetupView(DepthSpriteEditor editor) : base(editor) { }

        public override bool OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            isMove = true;
            startMouseLocation = e.Location;
            startObjectLocation.X = editor.left;
            startObjectLocation.Y = editor.top;
            return true;
        }

        public override bool OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            if(isMove)
            {
                editor.left = (e.X - startMouseLocation.X) + startObjectLocation.X;
                editor.top = (e.Y - startMouseLocation.Y) + startObjectLocation.Y;
                editor.Invalidate();
            }
            return true;
        }

        public override bool OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            OnMouseMove(e);
            isMove = false;
            return true;
        }
    }
}
