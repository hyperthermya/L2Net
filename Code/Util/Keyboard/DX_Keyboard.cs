using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace L2_login
{
    public class DX_Keyboard
    {
        private Thread dx_keyboard_thread;

        public DX_Keyboard()
        {
            dx_keyboard_thread = new Thread(DX_KeyboardEngine);
            dx_keyboard_thread.IsBackground = true;
            dx_keyboard_thread.Start();
        }

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        private const int VK_F9 = 0x78;
        private const int VK_F10 = 0x79;

        private void DX_KeyboardEngine()
        {
            while (true)
            {
                Thread.Sleep(Globals.SLEEP_DirectInputDelay);
                UpdateKeyboard();
            }
        }

        private void UpdateKeyboard()
        {
            bool f9 = (GetAsyncKeyState(VK_F9) & 0x8000) != 0;
            bool f10 = (GetAsyncKeyState(VK_F10) & 0x8000) != 0;

            if (f9)
            {
                if (!Globals.DirectInputLast)
                {
                    Globals.l2net_home.Toggle_Botting();
                    Globals.DirectInputLast = true;
                }
            }
            else
            {
                Globals.DirectInputLast = false;
            }

            if (f10)
            {
                if (!Globals.DirectInputLast2)
                {
                    Globals.DirectInputLast2 = true;
                    Util.KillThreads();
                    Util.Stop_Connections();
                }
            }
            else
            {
                Globals.DirectInputLast2 = false;
            }

            if (Globals.DirectInputSetup)
            {
                for (int i = 0; i <= 0xFF; i++)
                {
                    if ((GetAsyncKeyState(i) & 0x8000) != 0)
                    {
                        Globals.DirectInputSetupValue = ((Keys)i).ToString();
                        try
                        {
                            Globals.DirectInputSetup = false;
                            Globals.setupwindow.label_toggle_key.Text = Globals.DirectInputSetupValue;
                            Globals.setupwindow.button_change_toggle.Enabled = true;
                            Globals.setupwindow.button_change_kill.Enabled = true;
                            Globals.setupwindow.comboBox_voice.Enabled = true;
                            Globals.setupwindow.textBox_l2path.Enabled = true;
                            Globals.setupwindow.textBox_key.Enabled = true;
                            Globals.setupwindow.comboBox_texturemode.Enabled = true;
                            Globals.setupwindow.comboBox_viewrange.Enabled = true;
                        }
                        catch { }
                        break;
                    }
                }
            }

            if (Globals.DirectInputSetup2)
            {
                for (int i = 0; i <= 0xFF; i++)
                {
                    if ((GetAsyncKeyState(i) & 0x8000) != 0)
                    {
                        Globals.DirectInputSetupValue2 = ((Keys)i).ToString();
                        try
                        {
                            Globals.DirectInputSetup2 = false;
                            Globals.setupwindow.label_kill_key.Text = Globals.DirectInputSetupValue2;
                            Globals.setupwindow.button_change_kill.Enabled = true;
                            Globals.setupwindow.button_change_toggle.Enabled = true;
                            Globals.setupwindow.comboBox_voice.Enabled = true;
                            Globals.setupwindow.textBox_l2path.Enabled = true;
                            Globals.setupwindow.textBox_key.Enabled = true;
                            Globals.setupwindow.comboBox_texturemode.Enabled = true;
                            Globals.setupwindow.comboBox_viewrange.Enabled = true;
                        }
                        catch { }
                        break;
                    }
                }
            }
        }
    }
}
