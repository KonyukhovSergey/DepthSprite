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

        private IDictionary<EditorModes, EditorModeBase> modes = new Dictionary<EditorModes, EditorModeBase>();

        public IsoEdit()
        {
            InitializeComponent();
            UpdateUI();

            modes[EditorModes.DEFAULT] = new EditorModeBase(spriteEditor);
            modes[EditorModes.SETUP_VIEW] = new ModeSetupView(spriteEditor);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    Mode = EditorModes.DEFAULT;
                    SetInfo("");
                    break;

                case Keys.V:
                    Mode = EditorModes.SETUP_VIEW;
                    break;

                case Keys.A:
                    Mode = EditorModes.ADD_SPRITE_TO_SPRITE;
                    SetInfo("pick sprite for add to current sprite...");
                    break;

                case Keys.Z | Keys.Control:
                    commands.Undo();
                    break;

                case Keys.Y | Keys.Control:
                    commands.Redo();
                    break;

                case Keys.Z:
                    Mode = EditorModes.SET_Z_VALUES;
                    break;

                default:
                    return false;
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
                    commands.Execute(new CommandImportSprite(fileName, container, listSprites));
                }
            }
        }

        private EditorModes Mode
        {
            get { return mode; }
            set
            {
                mode = value;
                if (modes.ContainsKey(mode))
                {
                    spriteEditor.Mode = modes[mode];
                    SetInfo("current mode: " + spriteEditor.Mode.Name);
                }
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

                commands.ClearHistory();

                UpdateUI();
            }
        }

        private void listSprites_OnSelectItem(string id)
        {
            switch (Mode)
            {
                case EditorModes.DEFAULT:
                    {
                        spriteEditor.Sprite = container[id];
                        listSubSprites.RemoveAll();
                        foreach (var ss in spriteEditor.Sprite.subSprites)
                        {
                            listSubSprites.AddId(ss.id);
                        }
                        listContainedIn.RemoveAll();
                        foreach (var ds in container.Values)
                        {
                            if (ds.subSprites.Count(e => e.id == id) > 0)
                            {
                                listContainedIn.AddId(ds.id);
                            }
                        }
                    }
                    break;

                case EditorModes.ADD_SPRITE_TO_SPRITE:
                    if (commands.Execute(new CommandAddSubSprite(new SubSprite(id, 0, 0, 0), spriteEditor.Sprite, listSubSprites)))
                    {
                        listSprites.SelectedId = spriteEditor.Sprite.id;
                    }
                    mode = EditorModes.DEFAULT;
                    UpdateUI();
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
        SET_Z_VALUES,
        SETUP_VIEW,
    }
}
