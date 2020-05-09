using System;

namespace TicTacToe
{
    public interface IAI
    {
        /// <summary>
        /// Randomly selects a move from a list of possible moves
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        Move SelectMove(IGame game);
    }
}