using System;
using System.Linq;
using System.Windows.Forms;

namespace MemClass
{
    public partial class Main : Form
    {
        private Memory m = new Memory("BlackOpsColdWar");

        private enum Status
        {
            SUCCESS,
            SIG_NOT_FOUND,
        }

        public Main()
        {
            InitializeComponent();
        }

        private void camoBtn_Click(object sender, EventArgs e)
        {
            Output output = new Output(outputBox);
            Camos result = new Camos(camoBox.Text);
            output.Clear();

            byte camo = result.getCamo();

            switch (setCamo(camo))
            {
                case Status.SUCCESS:
                    output.AddText("[+] " + camoBox.Text + " set successfully!");
                    break;
                case Status.SIG_NOT_FOUND:
                    output.AddText("[x] Sig not found!");
                    output.AddText("[x] Make sure to set shards as one of your camos!");
                    break;
                default:
                    output.AddText("[x] An unknown error has occured");
                    break;
            }
        }

        private Status setCamo(byte camo)
        {
            long scan = m.FindBytes("01 ? ? ? ? ? ? ? 03 ? ? ? ? ? ? ? 0F A3 ? AF", m.BaseAddress + 0x16000000, m.BaseAddress + 0x18000000, true).FirstOrDefault<long>();

            if (scan == default)
                return Status.SIG_NOT_FOUND;

            m.Write<byte>(scan, camo);
            return Status.SUCCESS;
        }
    }
}
