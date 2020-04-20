using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeEngine
{
    public class TicTacToe
    {
        public GameStatus status { get; private set; } = GameStatus.PlayerOPlays; // Voor het gemak (volgens opdracht) begint PlayerO.

        private char[] current_board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' }; // Wou eigenlijk nested Tuple gebruiken, kreeg 't niet werkend...

    public String Board()
        {

        String current_board = String.Format("     |     |      \n" +
                                "  {0}  |  {1}  |  {2}\n" +
                                "_____|_____|_____ \n" +
                                "     |     |      \n" +
                                "  {3}  |  {4}  |  {5}\n" +
                                "_____|_____|_____ \n" +
                                "     |     |      \n" +
                                "  {6}  |  {7}  |  {8}\n" +
                                "     |     |      ", this.current_board[0], this.current_board[1], this.current_board[2], this.current_board[3], this.current_board[4],
                                                                this.current_board[5], this.current_board[6], this.current_board[7], this.current_board[8]);

            return current_board;
        }

        public Boolean ChooseCell(int cell)
        {
            // Checks voor juiste invoer (moet tussen de 1 en 9, mag niet op een plek waar al een X of O staat
            if (!(cell >= 1 && cell <= 9) || this.current_board[cell - 1].Equals('X') || this.current_board[cell - 1].Equals('O'))
            {
                return false;
            } else
            {
                // check status om te zien welke letter wordt gezet
                if (this.status.Equals(GameStatus.PlayerOPlays))
                {
                    this.current_board[cell - 1] = 'O';
                    // PlayerO is geweest, nu is PlayerX aan de beurt
                    this.status = GameStatus.PlayerXPlays;
                } else
                {
                    this.current_board[cell - 1] = 'X';
                    // PlayerX is geweest, nu is PlayerO aan de beurt
                    this.status = GameStatus.PlayerOPlays;
                }
                return true;
            }
        }

        // Methode die telkens checkt of er iemand heeft gewonnen. Als de hele lijst gevuld is met O en X, dan is het gelijkspel
        // Diegene die als laatst aan zet was, en ervoor zorgt dat 1 van de if-statements wordt aangeraakt, wint natuurlijk het spel
        public void CheckForStatusChange()
        {
            // Eerste rij
            if (current_board[0].Equals(current_board[1]) && current_board[1].Equals(current_board[2]))
            { this.status = this.status.Equals(GameStatus.PlayerOPlays) ? GameStatus.PlayerXWins : GameStatus.PlayerOWins; }
            // Tweede rij
            else if (current_board[3].Equals(current_board[4]) && current_board[4].Equals(current_board[5]))
            { this.status = this.status.Equals(GameStatus.PlayerOPlays) ? GameStatus.PlayerXWins : GameStatus.PlayerOWins; }
            // Derde rij
            else if (current_board[6].Equals(current_board[7]) && current_board[7].Equals(current_board[8]))
            { this.status = this.status.Equals(GameStatus.PlayerOPlays) ? GameStatus.PlayerXWins : GameStatus.PlayerOWins; }


            // Eerste kolom
            else if (current_board[0].Equals(current_board[3]) && current_board[3].Equals(current_board[6]))
            { this.status = this.status.Equals(GameStatus.PlayerOPlays) ? GameStatus.PlayerXWins : GameStatus.PlayerOWins; }
            // Tweede kolom
            else if (current_board[1].Equals(current_board[4]) && current_board[4].Equals(current_board[7]))
            { this.status = this.status.Equals(GameStatus.PlayerOPlays) ? GameStatus.PlayerXWins : GameStatus.PlayerOWins; }
            // Derde kolom
            else if (current_board[2].Equals(current_board[5]) && current_board[5].Equals(current_board[8]))
            { this.status = this.status.Equals(GameStatus.PlayerOPlays) ? GameStatus.PlayerXWins : GameStatus.PlayerOWins; }


            // Diagonaal 1
            else if (current_board[0].Equals(current_board[4]) && current_board[4].Equals(current_board[8]))
            { this.status = this.status.Equals(GameStatus.PlayerOPlays) ? GameStatus.PlayerXWins : GameStatus.PlayerOWins; }
            // Diagonaal 2
            else if (current_board[2].Equals(current_board[4]) && current_board[4].Equals(current_board[6]))
            { this.status = this.status.Equals(GameStatus.PlayerOPlays) ? GameStatus.PlayerXWins : GameStatus.PlayerOWins; }

            // Gelijk spel
            else if (current_board[0] != '1' && current_board[1] != '2' && current_board[2] != '3' 
                     && current_board[3] != '4' && current_board[4] != '5' && current_board[5] != '6' 
                     && current_board[6] != '7' && current_board[7] != '8' && current_board[8] != '9')
            { this.status = GameStatus.Equal; }
        }

        public void Reset()
        {
            char[] current_board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            this.current_board = current_board;
            this.status = GameStatus.PlayerOPlays;    
        }
    }

    public enum GameStatus { PlayerOPlays, PlayerXPlays, Equal, PlayerOWins, PlayerXWins }
}
