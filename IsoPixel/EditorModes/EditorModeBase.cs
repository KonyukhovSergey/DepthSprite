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
        protected IsoEdit editor;

        public EditorModeBase(IsoEdit editor)
        {
            this.editor = editor;
        }

        public virtual bool OnKeyDown(KeyEventArgs e) { return false; }

        public virtual bool OnMouseDown(MouseEventArgs e) { return false; }
        public virtual bool OnMouseMove(MouseEventArgs e) { return false; }
        public virtual bool OnMouseUp(MouseEventArgs e) { return false; }

        public virtual void OnDraw(Graphics gr) { }

        public virtual string Name { get { return GetType().ToString(); } }
    }
}
