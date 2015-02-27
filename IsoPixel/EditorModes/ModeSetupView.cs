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

        public ModeSetupView(IsoEdit editor) : base(editor) { }

        public override bool OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == System.Windows.Forms.Keys.Add)
            {
                //if (editor.zoom < 32) { editor.zoom++; }
                editor.Invalidate();
                return true;
            }

            if (e.KeyData == System.Windows.Forms.Keys.Subtract)
            {
                //if (editor.zoom > 1) { editor.zoom--; }
                editor.Invalidate();
                return true;
            }

            return base.OnKeyDown(e);
        }

        public override bool OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            isMove = true;
            startMouseLocation = e.Location;
            //startObjectLocation.X = editor.left;
            //startObjectLocation.Y = editor.top;
            return true;
        }

        public override bool OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            if (isMove)
            {
                //editor.left = (e.X - startMouseLocation.X) + startObjectLocation.X;
                //editor.top = (e.Y - startMouseLocation.Y) + startObjectLocation.Y;

                //if (editor.left >= editor.Width) { editor.left = editor.Width; }
                //if (editor.left + editor.Sprite.Width * editor.zoom < 0) { editor.left = -editor.Sprite.Width * editor.zoom; }
                //if (editor.top >= editor.Height) { editor.top = editor.Height; }
                //if (editor.top + editor.Sprite.Height * editor.zoom < 0) { editor.top = -editor.Sprite.Height * editor.zoom; }

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
