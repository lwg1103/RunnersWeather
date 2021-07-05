using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Windows.Forms;

namespace RunnersWeather.Logger.Tests
{
    [TestClass()]
    public class ConsoleLogTests
    {
        WindowFormConsoleLog TestSubject;
        TextBox TextBoxMock;

        [TestMethod()]
        public void AddEntryLogsMessageToTextBoxInNewLine()
        {
            setupTest();

            TestSubject.AddEntry("msg");

            Assert.AreEqual("text" + System.Environment.NewLine + "msg", TextBoxMock.Text);
        }

        [TestMethod()]
        public void ClearClearsTextBox()
        {
            setupTest();

            TestSubject.Clear();

            Assert.AreEqual("", TextBoxMock.Text);
        }

        private void setupTest()
        {
            var mock = new Mock<TextBox>();
            mock.SetupProperty(textBox => textBox.Text, "text");

            TextBoxMock = mock.Object;
            TestSubject = new WindowFormConsoleLog(TextBoxMock);
        }
    }
}