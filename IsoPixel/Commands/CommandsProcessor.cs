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
        private int historySize = 256;

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
            if (currentCommandIndex > 0)
            {
                currentCommandIndex--;
                commands[currentCommandIndex].Undo();
            }
        }

        public void Redo()
        {
            if (currentCommandIndex < commands.Count)
            {
                commands[currentCommandIndex].Execute();
                currentCommandIndex++;
            }
        }
    }
}
