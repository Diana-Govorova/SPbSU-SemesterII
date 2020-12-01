using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private ClickHandler handler;
        private char currentSign;

        private void CheckIfEnd()
        {
            if (handler.CheckIfEnd())
            {
                label1.Text = handler.GetStatus();
            }
        }

        private void ChangeCurrentSign()
        {
            currentSign = currentSign == 'X' ? '0' : 'X';
        }

        public Form1()
        {
            handler = new ClickHandler();
            currentSign = 'X';

            InitializeComponent();
        }

        private void button00_Click(object sender, EventArgs e)
        {
            var button = sender as Button;

            var coords = ParseName(button.Name);

            if (button.Enabled && handler.Handle(coords, currentSign))
            {
                button.Text = currentSign.ToString();
                button.Enabled = false;

                CheckIfEnd();

                ChangeCurrentSign();
            }
        }

        private (int, int) ParseName(string name)
        {
            int x;
            int y;

            x = Int32.Parse(name[6].ToString());
            y = Int32.Parse(name[7].ToString());

            return (x, y);
        }
    }
}
