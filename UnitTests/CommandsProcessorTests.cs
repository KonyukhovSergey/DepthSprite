using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IsoPixel;

namespace UnitTests
{
    [TestClass]
    public class CommandsProcessorTests
    {
        [TestMethod]
        public void TestCommandsProcessor()
        {
            CommandsProcessor cp = new CommandsProcessor(2);

            CommandBase command = new CommandForTest();

            cp.Execute(command);
            Assert.AreEqual(1, CommandForTest.Counter);

            cp.Undo();
            Assert.AreEqual(0, CommandForTest.Counter);

            cp.Undo();
            Assert.AreEqual(0, CommandForTest.Counter);

            cp.Redo();
            Assert.AreEqual(1, CommandForTest.Counter);

            cp.Redo();
            Assert.AreEqual(1, CommandForTest.Counter);

            cp.Execute(command);
            Assert.AreEqual(2, CommandForTest.Counter);

            cp.Execute(command);
            Assert.AreEqual(3, CommandForTest.Counter);

            cp.Redo();
            Assert.AreEqual(3, CommandForTest.Counter);

            cp.Undo();
            cp.Undo();
            Assert.AreEqual(1, CommandForTest.Counter);

            cp.Undo();
            Assert.AreEqual(1, CommandForTest.Counter);

            cp.Execute(command);
            Assert.AreEqual(2, CommandForTest.Counter);

            cp.Redo();
            Assert.AreEqual(2, CommandForTest.Counter);

            cp.Execute(command);
            cp.Execute(command);
            cp.Execute(command);
            cp.Execute(command);
            Assert.AreEqual(6, CommandForTest.Counter);

            cp.Undo();
            cp.Undo();
            cp.Undo();
            cp.Undo();
            Assert.AreEqual(4, CommandForTest.Counter);

            cp.Redo();
            cp.Redo();
            cp.Redo();
            cp.Redo();
            Assert.AreEqual(6, CommandForTest.Counter);
        }

        internal class CommandForTest : CommandBase
        {
            private static int counter = 0;

            public static int Counter { get { return counter; } }

            public override bool Execute()
            {
                counter++;
                return true;
            }

            public override void Undo()
            {
                counter--;
            }
        }
    }
}
