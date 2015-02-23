using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoPixel
{
    public class ModeSetupView: EditorModeBase
    {
        private Point startObjectLocation = new Point();
        private Point startMouseLocation = new Point();
        private bool isMove = false;

        public ModeSetupView(DepthSpriteEditor editor) : base(editor) { }

        public override bool OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            return base.OnMouseDown(e);
        }

        public override bool OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            return base.OnMouseMove(e);
        }

        public override bool OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
             return base.OnMouseUp(e);
        }
    }
}
