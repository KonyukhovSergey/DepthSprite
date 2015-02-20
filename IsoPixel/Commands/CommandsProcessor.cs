using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoPixel
{
    public class CommandsProcessor
    {
        private List<CommandBase> commands = new List<CommandBase>();
        private int currentCommandIndex = 0;
        private int historySize;

        public CommandsProcessor() : this(256) { }

        public CommandsProcessor(int historySize)
        {
            this.historySize = historySize;
        }

        public void Execute(CommandBase command)
        {
            if (command.Execute())
            {
                commands.RemoveRange(currentCommandIndex, commands.Count - currentCommandIndex);
                commands.Add(command);
                currentCommandIndex++;

                if (commands.Count > historySize)
                {
                    commands.RemoveAt(0);
                    currentCommandIndex--;
                }
            }
        }

        public void Undo()
        {
            if (CanUndo)
            {
                currentCommandIndex--;
                commands[currentCommandIndex].Undo();
            }
        }

        public void Redo()
        {
            if (CanRedo)
            {
                commands[currentCommandIndex].Execute();
                currentCommandIndex++;
            }
        }

        public bool CanUndo { get { return currentCommandIndex > 0; } }

        public bool CanRedo { get { return currentCommandIndex < commands.Count; } }
    }
}
