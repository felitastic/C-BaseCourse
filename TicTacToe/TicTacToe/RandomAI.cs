using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class RandomAI : IAI
    {
        public Move SelectMove(IGame game)
        {
            IList<Move> possibleMoves = game.GetMoves().ToList();

            Random rand = new Random();

            return possibleMoves[rand.Next(possibleMoves.Count)];            
        }
    }
}