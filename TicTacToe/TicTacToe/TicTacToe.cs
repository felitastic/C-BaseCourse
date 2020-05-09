using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TicTacToe
{
    public class TicTacToe : IGame
    {
        const int Width = 3;
        const int Height = 3;
        field?[,] allFields = new field?[Width, Height];
        // Braucht kein setter, da er nur im Konstruktor geändert wird
        public field ActivePlayer { get; }

        /// <summary>
        /// Konstruktor
        /// Es kann mehrere Konstruktoren geben, solange diese sich unterscheiden was die benötigten Parameter angeht
        /// </summary>
        public TicTacToe()
        {
            for (int i = 0; i < Height; ++i)
            {
                for (int j = 0; j < Width; ++j)
                {
                    allFields[i, j] = null;
                }
            }
            ActivePlayer = field.cross;
        }

        /// <summary>
        /// Überladener Konstruktor, der von ApplyMove aufgerufen wird
        /// </summary>
        /// <param name="move"></param>
        /// <param name="oldTicTacToe"></param>
        public TicTacToe(Move move, TicTacToe oldTicTacToe)
        {
            for (int i = 0; i < Height; ++i)
            {
                for (int j = 0; j < Width; ++j)
                {
                    this.allFields[i, j] = oldTicTacToe.allFields[i, j];
                }
            }

            this[move] = oldTicTacToe.ActivePlayer;

            if (oldTicTacToe.ActivePlayer == field.circle)
                this.ActivePlayer = field.cross;
            else
                this.ActivePlayer = field.circle;
        }

        /// <summary>
        /// Wird von GetWinner aufgerufen, um festzustellen, ob jemand gewonnen hat oder ein Remis erreicht wurde
        /// </summary>
        /// <param name="_field"></param>
        /// <returns></returns>
        private bool CheckFieldsForWin(field _field)
        {
            // Concat: Packt alle in eine Liste
            // Any: Checkt ob irgendeines der Elemente
            // line.All() holt sich die einzelnen Moves
            // All: ist bei alle Moves in dieser line die Bedingung "this[thisfield] == _field" erfüllt
            return GetRows().Concat(GetColumns().Concat(GetDiagonals())).Any(line => line.All(thisfield => this[thisfield] == _field));
        }

        public winner? GetWinner()
        {
            if (CheckFieldsForWin(field.circle))
                return winner.circle;

            if (CheckFieldsForWin(field.cross))
                return winner.cross;

            if (GetMoves().Count() == 0)
            {
                return winner.remis;
            }
            return null;
        }

        public IEnumerable<Move> GetMoves()
        {
            for (int i = 0; i < Height; ++i)
            {
                for (int j = 0; j < Width; ++j)
                {
                    if (allFields[i, j] == null)
                    {
                        yield return new Move(i, j);
                    }
                }
            }
        }

        public string OutPutToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(" --------- \n");

            for (int j = 0; j < Height; ++j)
            {
                output.Append("|");

                for (int i = 0; i < Width; ++i)
                {
                    if (allFields[i, j] == field.circle)
                        output.Append(" o ");
                    else if (allFields[i, j] == field.cross)
                        output.Append(" x ");
                    else
                        output.Append("   ");
                }
                output.Append("|\n");
            }

            output.Append(" --------- \n");

            if (!GetWinner().HasValue)
                output.Append("It's " + ActivePlayer + " 's turn!\n");

            return output.ToString();
        }

        /// <summary>
        /// Indexer für Field
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        public field? this[Move move]
        {
            get { return (allFields[move.x, move.y]); }
            private set { allFields[move.x, move.y] = value; }
        }

        public TicTacToe ApplyMove(Move move)
        {
            return new TicTacToe(move, this);
        }

        /// <summary>
        /// Gives back all Rows, calls OneRow
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IEnumerable<Move>> GetRows()
        {
            for (int i = 0; i < Height; ++i)
            {
                yield return GetOneRow(i);
            }
        }

        /// <summary>
        /// Called by GetRows, gives back one Row
        /// </summary>
        /// <param name="whichRow"></param>
        /// <returns></returns>
        IEnumerable<Move> GetOneRow(int whichRow)
        {
            for (int i = 0; i < Width; ++i)
            {
                yield return new Move(whichRow, i);
            }
        }

        /// <summary>
        /// Gives back all Columns, calls GetOneColumn
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IEnumerable<Move>> GetColumns()
        {
            for (int i = 0; i < Height; ++i)
            {
                yield return GetOneColumn(i);
            }
        }

        /// <summary>
        /// Called by GetColumns, gives back one Column
        /// </summary>
        /// <param name="whichColumn"></param>
        /// <returns></returns>
        IEnumerable<Move> GetOneColumn(int whichColumn)
        {
            for (int i = 0; i < Width; ++i)
            {
                yield return new Move(i, whichColumn);
            }
        }

        /// <summary>
        /// Gives back all Diagonals, calls GetOneDiagonal
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IEnumerable<Move>> GetDiagonals()
        {
            yield return GetOneDiagonal(new Move(0,0), new Move(1, 1), new Move(2, 2));
            yield return GetOneDiagonal(new Move(0,2), new Move(1, 1), new Move(0, 2));
        }

        /// <summary>
        /// Called by GetDiagonal, gives back one Diagonal
        /// </summary>
        /// <param name="move1"></param>
        /// <param name="move2"></param>
        /// <param name="move3"></param>
        /// <returns></returns>
        IEnumerable<Move> GetOneDiagonal(Move move1, Move move2, Move move3)
        {
            yield return move1;
            yield return move2;
            yield return move3;
        }
    }
}


