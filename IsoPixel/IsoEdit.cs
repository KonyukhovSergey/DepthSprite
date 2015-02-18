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
        private DepthContainer container = new DepthContainer();
        private EditorModes mode = EditorModes.DEFAULT;

        public IsoEdit()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);
            UpdateUI();
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
                    UpdateUI();
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
                    string key = Path.GetFileNameWithoutExtension(fileName);
                    if (!container.ContainsKey(key))
                    {
                        container.Add(new DepthSprite(Image.FromFile(fileName), key, container));
                        listSprites.AddId(key);
                    }
                }
                UpdateUI();
            }
        }

        private void UpdateUI()
        {
            listSprites.Invalidate();
            spriteEditor.Invalidate();
            tsslMode.Text = mode.ToString();
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
                File.WriteAllText(fileDialog.FileName, container.ToJsonSring(), Encoding.UTF8);
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
                container = DepthContainer.Parse(File.ReadAllText(fileDialog.FileName, Encoding.UTF8));

                listSprites.RemoveAll();

                foreach(var item in container.Keys)
                {
                    listSprites.AddId(item);
                }

                UpdateUI();
            }
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_KEYUP)
            {
                mode = EditorModes.DEFAULT;
                UpdateUI();
            }
            return false;
        }

        const int WM_KEYDOWN = 0x100;
        const int WM_SYSKEYDOWN = 0x104;
        const int WM_KEYUP = 0x101;
        const int WM_SYSKEYUP = 0x105;

        private void listSprites_OnSelectItem(string id)
        {
            switch (mode)
            {
                case EditorModes.DEFAULT:
                    spriteEditor.Sprite = container[id];
                    break;

                case EditorModes.ADD_SPRITE_TO_SPRITE:
                    if (container.CanAddSpriteToSprite(id, spriteEditor.Sprite.id))
                    {
                        spriteEditor.Sprite.subSprites.Add(new SubSprite(id, 0, 0, -1));
                        spriteEditor.Sprite.ClearCache();
                        UpdateUI();
                    }
                    else
                    {
                        MessageBox.Show("cycle reference");
                    }
                    break;
            }
        }

        private Image listSprites_OnGetItemImage(string id)
        {
            return container[id].Bitmap;
        }
    }
    public enum EditorModes
    {
        DEFAULT,
        ADD_SPRITE_TO_SPRITE,
        SELECT_RECTANGLE,
        MOVE_SELECTION,
    }
}
