using System;

namespace TicTacToe
{    
    class Programm
    {       
        static void Main(string[] args)
        {
            TicTacToe _TicTacToe = new TicTacToe();
            RandomAI _RandomAI = new RandomAI();
            ConsoleUI _ConsoleUI = new ConsoleUI(_TicTacToe, _RandomAI);            

            _ConsoleUI.Play();

        }
    }
}
