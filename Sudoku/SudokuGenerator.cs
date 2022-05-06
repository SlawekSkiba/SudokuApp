using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    /// <summary>
    /// Klasa służy do generowania tablicy sudoku o wymiarach 9x9, podanym wskaźniku wymieszania i ilości wypełnionych pól
    /// </summary>
    public class SudokuGenerator
    {
        private int[,] _grid = new int[9, 9];
        private int[,] _filledGrid = new int[9, 9];

        public int[,] FilledBoard => _filledGrid;
        public int[,] Board => _grid;

        public int[,] Generate(int shuffleLevel, int filledCells)
        {
            if (filledCells < 1 || filledCells > 81)
            {
                throw new ArgumentException($"{nameof(filledCells)} must be in range 1-81", nameof(filledCells));
            }
            Init();

            Random rand = new Random(Guid.NewGuid().GetHashCode());
            Random rand2 = new Random(Guid.NewGuid().GetHashCode());

            for (int repeat = 0; repeat < shuffleLevel; repeat++)
            {
                ShuffleTwoCells(rand.Next(1, 9), rand2.Next(1, 9));
            }
            Array.Copy(_grid, 0, _filledGrid, 0, 81);

            ClearRandomCells(filledCells);

            return _grid;
        }

        private void ClearRandomCells(int filledCells)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            
            List<int> cellsToClear = Enumerable.Range(0, 80).ToList();
            do
            {
                cellsToClear.RemoveAt(rand.Next(0, cellsToClear.Count - 1));
            } while (cellsToClear.Count > 81 - filledCells);

            foreach (var cellIdx in cellsToClear)
            {
                var col = cellIdx % 9;
                var row = cellIdx / 9;
                ClearCell(row, col);
            }
        }

        public string GenerateSolved(int shuffleLevel)
        {
            Init();

            for (int repeat = 0; repeat < shuffleLevel; repeat++)
            {
                Random rand = new Random(Guid.NewGuid().GetHashCode());
                Random rand2 = new Random(Guid.NewGuid().GetHashCode());
                ShuffleTwoCells(rand.Next(1, 9), rand2.Next(1, 9));
            }

            return GetAsString();
        }

        private bool ClearCell(int row, int col)
        {
            if (_grid[row, col] == 0)
            {
                return false;
            };
            _grid[row, col] = 0;
            return true;
        }
        private string GetAsString()
        {
            StringBuilder sb = new StringBuilder();
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    sb.Append(_grid[x, y].ToString());
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public string GetAsStringFormatted()
        {
            return GetAsStringFormatted(_grid);
        }

        public static string GetAsStringFormatted(int [,] table, int offset = 0)
        {
            StringBuilder sb = new StringBuilder();            
            for (int x = 0; x < 9; x++)
            {
                if(offset > 0) sb.Append(new string(' ', offset));
                for (int y = 0; y < 9; y++)
                {
                    sb.Append((table[x, y] == 0 ? " " : table[x, y].ToString()) + " ");
                    if (y == 2 || y == 5) sb.Append("| ");
                }
                sb.AppendLine();
                if (x == 2 || x == 5) sb.AppendLine($"{new string(' ', offset)}----------------------");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Zamiana miejscami wartości tak aby zachować unikalność w wierszu, columnie i bloku
        /// </summary>
        /// <param name="findValue1"></param>
        /// <param name="findValue2"></param>
        private void ShuffleTwoCells(int findValue1, int findValue2)
        {
            int xParm1, yParm1, xParm2, yParm2;
            xParm1 = yParm1 = xParm2 = yParm2 = 0;
            for (int i = 0; i < 9; i += 3)
            {
                for (int k = 0; k < 9; k += 3)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        for (int z = 0; z < 3; z++)
                        {
                            if (_grid[i + j, k + z] == findValue1)
                            {
                                xParm1 = i + j;
                                yParm1 = k + z;

                            }
                            if (_grid[i + j, k + z] == findValue2)
                            {
                                xParm2 = i + j;
                                yParm2 = k + z;

                            }
                        }
                    }
                    _grid[xParm1, yParm1] = findValue2;
                    _grid[xParm2, yParm2] = findValue1;
                }
            }
        }

        /// <summary>
        /// Resetowanie tablicy do wartości domyślnych
        /// </summary>
        private void Init()
        {            
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    _grid[r, c] = (r * 3 + r / 3 + c) % 9 + 1;
                }
            }
        }
    }
}
