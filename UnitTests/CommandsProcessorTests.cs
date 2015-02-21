using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IsoPixel;

namespace UnitTests
{
    [TestClass]
    public class CommandsProcessorTests
    {
        [TestMethod]
        public void CommandsProcessorExecute()
        {
            CommandsProcessor cp = new CommandsProcessor(2);
            CommandForTest command = new CommandForTest();

            cp.Execute(command);
            Assert.AreEqual(1, command.Counter);

            cp.Execute(command);
            cp.Execute(command);
            Assert.AreEqual(3, command.Counter);

            cp.Undo();
            cp.Undo();
            cp.Execute(command);
            cp.Redo();
            Assert.AreEqual(2, command.Counter);
        }

        [TestMethod]
        public void CommandsProcessorUndo()
        {
            CommandsProcessor cp = new CommandsProcessor(2);
            CommandForTest command = new CommandForTest();

            cp.Undo();
            Assert.AreEqual(0, command.Counter);

            cp.Execute(command);
            Assert.AreEqual(1, command.Counter);

            cp.Undo();
            Assert.AreEqual(0, command.Counter);

            cp.Undo();
            Assert.AreEqual(0, command.Counter);
        }

        [TestMethod]
        public void CommandsProcessorRedo()
        {
            CommandsProcessor cp = new CommandsProcessor(2);
            CommandForTest command = new CommandForTest();

            cp.Redo();
            Assert.AreEqual(0, command.Counter);

            cp.Execute(command);
            cp.Undo();
            cp.Redo();
            Assert.AreEqual(1, command.Counter);

            cp.Redo();
            Assert.AreEqual(1, command.Counter);

            cp.Execute(command);
            cp.Redo();
            Assert.AreEqual(2, command.Counter);

            cp.Undo();
            cp.Undo();
            cp.Undo();
            cp.Redo();
            Assert.AreEqual(1, command.Counter);
            cp.Redo();
            Assert.AreEqual(2, command.Counter);
        }

        [TestMethod]
        public void CommandsProcessorClear()
        {
            CommandsProcessor cp = new CommandsProcessor(2);
            CommandForTest command = new CommandForTest();

            cp.Execute(command);
            cp.Execute(command);

            cp.ClearHistory();
            cp.Undo();
            Assert.AreEqual(2, command.Counter);

            cp.Redo();
            Assert.AreEqual(2, command.Counter);
        }

        internal class CommandForTest : CommandBase
        {
            private int counter = 0;

            public int Counter { get { return counter; } }

            public override bool Execute()
            {
                counter++;
                return true;
            }

            public override void Cancel()
            {
                counter--;
            }
        }
    }
}
