using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public static class SudokuBoardsExtensions
    {
        public static void ConsolePrint(this int[,] table, int offsetX = 0, int offsetY = 0)
        {
            for (int row = 0; row < 9; row++)
            {
                int rowGridOffset = (int)(row / 3);
                for (int col = 0; col < 9; col++)
                {
                    int colGridOffset = ((int)(col / 3) * 2);

                    if (table[row, col] != 0)
                    {
                        Console.SetCursorPosition(colGridOffset + offsetX + (col * 2), rowGridOffset + offsetY + (row));
                        Console.Write(table[row, col].ToString());
                    };
                    if (col == 2 || col == 5)
                    {
                        Console.SetCursorPosition(colGridOffset + offsetX + (col * 2) + 2, offsetY + row + rowGridOffset);
                        Console.Write("|");
                    }
                }
                if (row == 2 || row == 5)
                {
                    Console.SetCursorPosition(offsetX, offsetY + row + rowGridOffset + 1);
                    Console.Write(new string('-', 21));
                }
            }
            Console.SetCursorPosition(0, offsetY + table.GetLength(1) + 3);
        }

        public static string FormatAsString(this int[,] board)
        {
            var sb = new StringBuilder();
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    sb.Append(board[row, col].ToString());
                }
            }
            return sb.ToString();
        }

        public static int[,] LoadFromString(string board)
        {
            var result = new int[9, 9];

            var idx = 0;
            if (board == null || board.Length != 81)
            {
                throw new ArgumentException("Board string has incorrect size");
            }

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    result[row, col] = int.Parse(board[idx++].ToString());
                }
            }
            return result;
        }
    }
}
