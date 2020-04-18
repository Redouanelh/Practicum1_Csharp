using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TicTacToeEngine;

namespace Practicum_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
          //  Dit werkt:
            TicTacToe t = new TicTacToe();
          //  System.Windows.Forms.MessageBox.Show(t.Test());

            System.Windows.Forms.MessageBox.Show(t.Board());
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Spel is gereset!");
        }
    }
}
