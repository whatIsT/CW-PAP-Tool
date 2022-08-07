using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemClass
{
    public class Output
    {
        private TextBox tb { get; set; }
        public Output(TextBox tb)
        {
            this.tb = tb;
        }

        public void AddText(string text)
        {
            tb.Text += text + Environment.NewLine;
        }

        public void Clear()
        {
            tb.Clear();
            AddText("=-=-=-= Output Log =-=-=-=");
        }
    }
}
