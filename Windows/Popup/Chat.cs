using System;
using System.Windows.Forms;

namespace L2_login
{
    public partial class Chat : Base
    {
        public Chat()
        {
            InitializeComponent();
        }

        private void button_sendtext_Click(object sender, EventArgs e)
        {
            string msg = this.textBox_say.Text;

            if (msg != "")
            {
                ServerPackets.Send_Text(0, msg, "");
                this.textBox_say.Text = "";
            }
        }
    }
}
