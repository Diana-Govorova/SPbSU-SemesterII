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

        private void checkIfEnd()
        {
            if (handler.checkIfEnd())
            {
                label1.Text = handler.getStatus();
            }
        }

        private void changeCurrentSign()
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
            if (button00.Enabled && handler.handle((0, 0), currentSign))
            {
                button00.Text = currentSign.ToString();
                button00.Enabled = false;

                checkIfEnd();

                changeCurrentSign();
            }
        }

        private void button01_Click(object sender, EventArgs e)
        {
            if (button01.Enabled && handler.handle((0, 1), currentSign))
            {
                button01.Text = currentSign.ToString();
                button01.Enabled = false;

                checkIfEnd();

                changeCurrentSign();
            }
        }

        private void button02_Click(object sender, EventArgs e)
        {
            if (button02.Enabled && handler.handle((0, 2), currentSign))
            {
                button02.Text = currentSign.ToString();
                button02.Enabled = false;

                checkIfEnd();

                changeCurrentSign();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (button10.Enabled && handler.handle((1, 0), currentSign))
            {
                button10.Text = currentSign.ToString();
                button10.Enabled = false;

                checkIfEnd();

                changeCurrentSign();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (button11.Enabled && handler.handle((1, 1), currentSign))
            {
                button11.Text = currentSign.ToString();
                button11.Enabled = false;

                checkIfEnd();

                changeCurrentSign();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (button12.Enabled && handler.handle((1, 2), currentSign))
            {
                button12.Text = currentSign.ToString();
                button12.Enabled = false;

                checkIfEnd();

                changeCurrentSign();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (button20.Enabled && handler.handle((2, 0), currentSign))
            {
                button20.Text = currentSign.ToString();
                button20.Enabled = false;

                checkIfEnd();

                changeCurrentSign();
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (button21.Enabled && handler.handle((2, 1), currentSign))
            {
                button21.Text = currentSign.ToString();
                button21.Enabled = false;

                checkIfEnd();

                changeCurrentSign();
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (button22.Enabled && handler.handle((2, 2), currentSign))
            {
                button22.Text = currentSign.ToString();
                button22.Enabled = false;

                checkIfEnd();

                changeCurrentSign();
            }
        }
    }
}
