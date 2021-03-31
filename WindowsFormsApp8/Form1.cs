using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Keys vKey);

        [DllImport("user32.dll")]

        static extern void mouse_event(int a, int b, int c, int d, int e);

        int Mouse3Down = 0x0020;
        int Mouse3Up = 0x0040;
        public Form1()
        {
            InitializeComponent();
        }

        // cześć kirdzik, wiedziałem że tu zajrzysz :)

        void AutoBhop()
        {
            while (true)
            {
                if (GetAsyncKeyState(Keys.Space)<0)
                {
                    mouse_event(Mouse3Down, 0, 0, 0, 0);
                    Thread.Sleep(9);
                    mouse_event(Mouse3Up, 0, 0, 0, 0);
                    Thread.Sleep(9);
                }
                Thread.Sleep(10); //Thread.Sleep(5);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread BunnyHop = new Thread(AutoBhop) { IsBackground = true };
            BunnyHop.Start();
        }
    }
}
