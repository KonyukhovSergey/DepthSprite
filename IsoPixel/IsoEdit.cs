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
    public partial class IsoEdit : Form
    {
        private DepthContainer container = new DepthContainer();
        private EditorModes mode = EditorModes.DEFAULT;
        private CommandsProcessor commands = new CommandsProcessor();

        public IsoEdit()
        {
            InitializeComponent();
            UpdateUI();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    mode = EditorModes.DEFAULT;
                    SetInfo("");
                    break;
                case Keys.A:
                    mode = EditorModes.ADD_SPRITE_TO_SPRITE;
                    SetInfo("pick sprite for add to current sprite...");
                    break;
            }

            UpdateUI();

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
                        new DepthSprite(Image.FromFile(fileName), key, container);
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

                foreach (var item in container.Keys)
                {
                    listSprites.AddId(item);
                }

                UpdateUI();
            }
        }

        private void listSprites_OnSelectItem(string id)
        {
            switch (mode)
            {
                case EditorModes.DEFAULT:
                    {
                        spriteEditor.Sprite = container[id];
                        listContains.RemoveAll();
                        foreach (var ss in spriteEditor.Sprite.subSprites)
                        {
                            listContains.AddId(ss.id);
                        }
                        listContainedIn.RemoveAll();
                        foreach(var ds in container.Values)
                        {
                            if (ds.subSprites.Count(e => e.id == id)>0)
                            {
                                listContainedIn.AddId(ds.id);
                            }
                        }
                    }
                    break;

                case EditorModes.ADD_SPRITE_TO_SPRITE:
                    if (container.CanAddSpriteToSprite(id, spriteEditor.Sprite.id))
                    {
                        spriteEditor.Sprite.subSprites.Add(new SubSprite(id, 0, 0, 1));
                        spriteEditor.Sprite.ClearCache();
                        SetInfo("sprite added");
                        mode = EditorModes.DEFAULT;
                        UpdateUI();
                    }
                    else
                    {
                        SetError("cycle references");
                    }
                    listContains.SelectedId = spriteEditor.Sprite.id;
                    break;
            }
        }

        private Image listSprites_OnGetItemImage(string id)
        {
            return container[id].Bitmap;
        }

        private void SetError(string message)
        {
            tsslInfo.ForeColor = Color.Red;
            tsslInfo.Text = message;
        }

        private void SetInfo(string message)
        {
            tsslInfo.ForeColor = Color.DarkMagenta;
            tsslInfo.Text = message;
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
