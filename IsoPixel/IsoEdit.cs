using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsoPixel
{
    public partial class IsoEdit : Form, IMessageFilter
    {
        private DepthContainer sprites = new DepthContainer();
        private EditorModes mode = EditorModes.DEFAULT;

        public IsoEdit()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);
            Update();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Application.RemoveMessageFilter(this);
            base.OnClosing(e);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.A:
                    mode = EditorModes.ADD_SPRITE_TO_SPRITE;
                    Update();
                    break;
            }
            return true;
        }

        private void tsmiImportSprite_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                DefaultExt = "*.png|.png files",
                Multiselect = true,
                RestoreDirectory = true
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var fileName in fileDialog.FileNames)
                {
                    sprites.Add(new DepthSprite(Image.FromFile(fileName)) { name = Path.GetFileNameWithoutExtension(fileName) });
                }
                Update();
            }
        }

        private void Update()
        {
            listSprites.ItemsCount = sprites.Count;
            tsslMode.Text = mode.ToString();
        }

        private Bitmap listSprites_OnGetItemBitmap(int index)
        {
            var item = sprites[index];
            FastGraphics fastGraphics = new FastGraphics(item.Width, item.Height);

            item.DrawTo(fastGraphics, sprites);
            return fastGraphics.Bitmap;
        }

        private string listSprites_OnGetItemTitle(int index)
        {
            return sprites[index].name;
        }

        private void listSprites_OnSelectItem(int index)
        {
            switch (mode)
            {
                case EditorModes.DEFAULT:
                    spriteEditor.SetSprite(sprites[index], sprites);
                    break;

                case EditorModes.ADD_SPRITE_TO_SPRITE:
                    spriteEditor.GetSprite().sprites.Add(new SpritePosition() { id = sprites[index].id });
                    sprites.ClearCacheFor(spriteEditor.GetSprite().id);
                    Update();
                    break;
            }
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog()
            {
                DefaultExt = "*.dsp|.dsp files",
                FileName = "*.dsp",
                RestoreDirectory = true
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(fileDialog.FileName, sprites.ToJsonSring(), Encoding.UTF8);
            }
        }

        private void tsmiLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                DefaultExt = "*.dsp|.dsp files",
                Multiselect = false,
                RestoreDirectory = true
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                sprites = DepthContainer.Parse(File.ReadAllText(fileDialog.FileName, Encoding.UTF8));
                Update();
            }
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_KEYUP)
            {
                mode = EditorModes.DEFAULT;
                Update();
            }
            return false;
        }

        const int WM_KEYDOWN = 0x100;
        const int WM_SYSKEYDOWN = 0x104;
        const int WM_KEYUP = 0x101;
        const int WM_SYSKEYUP = 0x105;


    }
    public enum EditorModes
    {
        DEFAULT,
        ADD_SPRITE_TO_SPRITE,
        SELECT_RECTANGLE,
        MOVE_SELECTION,
    }
}
