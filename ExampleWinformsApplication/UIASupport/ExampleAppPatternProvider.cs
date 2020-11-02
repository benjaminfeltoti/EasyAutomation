using System.Windows.Forms;

namespace ExampleWinformsApplication.UIASupport
{
    public class ExampleAppPatternProvider : IExampleAppPatternProvider
    {
        private Control control;

        public ExampleAppPatternProvider(Control control)
        {
            this.control = control;
        }

        public void SetInputPath(string path)
        {
            DataBaseFile.Path = path;
        }
    }
}
