using System;
using System.Collections.Generic;

namespace TicTacToe
{
    /// <summary>
    /// Functions the game - in this case TicTacToe - needs to implement
    /// </summary>
    public interface IGame
    {
        /// <summary>
        /// Checkt ob es einen Gewinner gibt und gibt diesen zurück
        /// </summary>
        /// <returns></returns>
        winner? GetWinner();

        /// <summary>
        /// The player whose turn it is
        /// </summary>
        field ActivePlayer { get; }

        /// <summary>
        /// Gibt alle möglichen Züge zurück
        /// </summary>
        /// <returns></returns>
        IEnumerable<Move> GetMoves();

        /// <summary>
        /// Schreibt das Spiel und Infos in die Konsole
        /// </summary>
        /// <returns></returns>
        string OutPutToString();

        /// <summary>
        /// Ruft überladenen Konstruktur auf und übergibt altes TicTacToe, sowie den Zug
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        TicTacToe ApplyMove(Move move);
        
    }
}