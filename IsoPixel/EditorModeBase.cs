using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsoPixel
{
    public class EditorModeBase
    {
        private DepthSpriteEditor editor;

        public EditorModeBase(DepthSpriteEditor editor)
        {
            this.editor = editor;
        }

        public virtual bool OnMouseDown(MouseEventArgs e) { return false; }
        public virtual bool OnMouseMove(MouseEventArgs e) { return false; }
        public virtual bool OnMouseUp(MouseEventArgs e) { return false; }

        public virtual void OnDraw(Graphics gr) { };

        public virtual string Name { get { return GetType().ToString(); } }
    }
}
