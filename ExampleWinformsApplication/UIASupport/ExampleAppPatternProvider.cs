using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
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
