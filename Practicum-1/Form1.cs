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
            this.label3.Hide(); // De label die laat zien wie er gewonnen heeft, die wil je nu natuurlijk nog niet laten zien

            this.t = new TicTacToe(); // De library
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

            t.CheckForStatusChange(); // Check of iemand heeft gewonnen
            if (t.status.Equals(GameStatus.Equal) || t.status.Equals(GameStatus.PlayerOWins) || t.status.Equals(GameStatus.PlayerXWins)) 
            { 
                disableBoardAfterWin();
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

            this.label3.Hide(); // Verstopt 't eindbericht weer

            this.label2.Show(); // Toont weer de label met de zetten
            this.label2.Text = "PlayerO aan zet..."; // Spel begint opnieuw, en PlayerO begint altijd

        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void disableBoardAfterWin() // Disabled all buttons op het spelbord nadat er iemand heeft gewonnen.
        {
            foreach (Control c in this.Controls)
            {
                if (c is Button && c.Name != "button10" && c.Name != "button11") // button10 en button11 zijn de Quit en Restart buttons
                {
                    c.Enabled = false; // Maakt de button weer enabled zodat je weer erop kunt klikken
                }
            }

            this.label2.Hide(); // Verstop de label die weergeeft wie aan de beurt is

            // Checkt wie heeft gewonnen/of er gelijk is gespeeld
            switch (t.status)
            {
                case GameStatus.PlayerOWins:
                    this.label3.Text = "PlayerO heeft gewonnen, gefeliciteerd!"; // Stop de juiste eindbericht in de label
                    this.label3.Show(); // Toont de eindbericht
                    break;
                case GameStatus.PlayerXWins:
                    this.label3.Text = "PlayerX heeft gewonnen, gefeliciteerd!";
                    this.label3.Show();
                    break;
                case GameStatus.Equal:
                    this.label3.Text = "Gelijkspel, probeer het nog eens!";
                    this.label3.Show();
                    break;
            }
        }

    }
}
