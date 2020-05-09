using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class ConsoleUI
    {
        private IGame _TicTacToe;
        private IAI _RandomAI;

        /// <summary>
        /// True if the player has given a usable input
        /// </summary>
        private bool correctInput = false;

        /// <summary>
        /// Konstruktor 
        /// </summary>
        /// <param name="ticTacToe"></param>
        public ConsoleUI(IGame ticTacToe, IAI randomAI)
        {
            _TicTacToe = ticTacToe;
            _RandomAI = randomAI;
        }

        /// <summary>
        /// Führt Züge furch, bis ein Ende erreicht wurde, gibt Resultat/Gewinner aus
        /// </summary>
        public void Play()
        {
            while (!_TicTacToe.GetWinner().HasValue)
            {
                PlayTurn();
            }

            if (_TicTacToe.GetWinner() == winner.remis)
            {
                Console.WriteLine(_TicTacToe.OutPutToString());
                Console.WriteLine("Nobody wins!");
            }
            else
            {
                Console.WriteLine(_TicTacToe.OutPutToString());
                Console.WriteLine("The winner is: " + _TicTacToe.GetWinner());
            }
        }

        /// <summary>
        /// Checks if the field is empty, returns true if so
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool IsChosenFieldEmpty(int x, int y)
        {
            IList<Move> possibleMoves = _TicTacToe.GetMoves().ToList();

            for (int i = 0; i < possibleMoves.Count; ++i)
            {
                if (possibleMoves[i].x == x && possibleMoves[i].y == y)
                {
                    _TicTacToe = _TicTacToe.ApplyMove(possibleMoves[i]);
                    correctInput = true;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Zeigt Spielstand und mögliche Züge, liest Zug von der Konsole 
        /// </summary>
        public void PlayTurn()
        {
            if (_TicTacToe.ActivePlayer == field.circle)
            {
                _TicTacToe = _TicTacToe.ApplyMove(_RandomAI.SelectMove(_TicTacToe));
            }
            else
            {
                Console.WriteLine(_TicTacToe.OutPutToString());
                Console.WriteLine("Press 1-9 to set your mark...");            
                correctInput = false;
            
                while (!correctInput)
                {
                    var PressedKey = Console.ReadKey().Key;
                    Console.WriteLine("");

                    switch (PressedKey)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            if (!IsChosenFieldEmpty(0,0))
                                Console.WriteLine("This field is not empty!");

                            break;
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            if (!IsChosenFieldEmpty(0,1))
                                Console.WriteLine("This field is not empty!");

                            break;
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            if (!IsChosenFieldEmpty(0,2))
                                Console.WriteLine("This field is not empty!");

                            break;
                        case ConsoleKey.D4:
                        case ConsoleKey.NumPad4:
                            if (!IsChosenFieldEmpty(1,0))
                                Console.WriteLine("This field is not empty!");

                            break;
                        case ConsoleKey.D5:
                        case ConsoleKey.NumPad5:
                            if (!IsChosenFieldEmpty(1,1))
                                Console.WriteLine("This field is not empty!");

                            break;
                        case ConsoleKey.D6:
                        case ConsoleKey.NumPad6:
                            if (!IsChosenFieldEmpty(1,2))
                                Console.WriteLine("This field is not empty!");

                            break;
                        case ConsoleKey.D7:
                        case ConsoleKey.NumPad7:
                            if (!IsChosenFieldEmpty(2,0))
                                Console.WriteLine("This field is not empty!");

                            break;
                        case ConsoleKey.D8:
                        case ConsoleKey.NumPad8:
                            if (!IsChosenFieldEmpty(2,1))
                                Console.WriteLine("This field is not empty!");

                            break;
                        case ConsoleKey.D9:
                        case ConsoleKey.NumPad9:
                            if (!IsChosenFieldEmpty(2,2))
                                Console.WriteLine("This field is not empty!");

                            break;
                        default:
                            Console.Write("Only numbers please!");
                            break;
                    }
                }
            }
        }
    }
}
