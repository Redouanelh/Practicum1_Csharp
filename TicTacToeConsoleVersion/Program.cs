using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeEngine;

namespace TicTacToeConsoleVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeConsoleGame();
        }

        static void TicTacToeConsoleGame()
        {
            // De library
            TicTacToe t = new TicTacToe();

            // Intro
            Console.WriteLine("Welkom bij TicTacToe!\n\n" +
                              "Er zijn 2 spelers: PlayerO & PlayerX.\n\n" +
                              "Alleen invoer van 1 t/m 9 is mogelijk!\n" +
                              "Invoer op een positie waar al O of X staat is niet toegestaan!\n\n" +
                              "Veel plezier!\n\n\n" +
                              "Huidige bord:\n");
          
            while (true)
            {
                // Huidige bord
                Console.WriteLine(t.Board() + "\n\n");

                // Wie is aan zet?
                String zet = t.status.Equals(GameStatus.PlayerOPlays) ? "PlayerO is aan zet" : "PlayerX is aan zet";

                // Nummer selecteren
                int cell;
                Console.WriteLine(zet + "\nKies een beschikbare nummer van het bord...");
                if (!int.TryParse(Console.ReadLine(), out cell) || !t.ChooseCell(cell))
                {
                    Console.WriteLine("\nJe hebt geen geldige zet ingevoerd, lees de regels bovenaan!");
                }

                // Check of iemand wint/of er gelijk is gespeelt. Zoja, verander status
                t.CheckForStatusChange();

                if (t.status.Equals(GameStatus.Equal) || t.status.Equals(GameStatus.PlayerOWins) || t.status.Equals(GameStatus.PlayerXWins)) { break; }
            }

            // Het bord nogmaals tonen
            Console.WriteLine(t.Board() + "\n");

            // Eindbericht
            switch (t.status)
            {
                case GameStatus.PlayerOWins:
                    Console.WriteLine("PlayerO heeft gewonnen, gefeliciteerd!");
                    break;
                case GameStatus.PlayerXWins:
                    Console.WriteLine("PlayerX heeft gewonnen, gefeliciteerd!");
                    break;
                case GameStatus.Equal:
                    Console.WriteLine("Gelijkspel, probeer het nog eens!");
                    break;
            }

            // Reset optie
            Console.WriteLine("\nOpnieuw spelen? Zeg dan 'reset'...\nStoppen? Zeg dan alles behalve 'reset'...");
            if (Console.ReadLine().Equals("reset"))
            {
                Console.Clear();

                t.Reset(); // Is dit wel nodig? Want de methode hieronder restart het ook?
                TicTacToeConsoleGame();
            }
        }

    }
}
