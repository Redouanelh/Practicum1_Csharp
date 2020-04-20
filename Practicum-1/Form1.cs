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
        private TicTacToe t;
        public Form1()
        {
            InitializeComponent();
            this.t = new TicTacToe();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int cell_number = int.Parse(button.Name.Substring(button.Name.Length - 1));

            // PlayerO begint met zijn/haar beurt
            if (t.status.Equals(GameStatus.PlayerOPlays))
            {
                t.ChooseCell(cell_number);
                button.Text = "O"; // Zet de zet op de juiste plek
                button.Enabled = false; // Zorgt ervoor dat niemand meer op die button een zet kan plaatsen

                this.label2.Text = "PlayerX aan zet..."; // Past label aan op basis van wie aan de beurt is
            } else
            {
                t.ChooseCell(cell_number);
                button.Text = "X";
                button.Enabled = false;

                this.label2.Text = "PlayerO aan zet...";
            }

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            t.Reset(); // Reset het bord in de library, zet de status weer op PlayerOPlays

            foreach (Control c in this.Controls)
            {
                if (c is Button && c.Name != "button10" && c.Name != "button11") // button10 en button11 zijn de Quit en Restart buttons
                {
                    c.Text = ""; // Maakt de button leeg
                    c.Enabled = true; // Maakt de button weer enabled zodat je weer erop kunt klikken
                }
            }

            this.label2.Text = "PlayerO aan zet..."; // Spel begint opnieuw, en PlayerO begint altijd

        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
