using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public static class SudokuConsolePrinter
    {
        public static void ConsolePrint(int[,] table, int offsetX = 0, int offsetY = 0)
        {
            for (int row = 0; row < 9; row++)
            {
                int rowGridOffset = (int)(row / 3);
                for (int col = 0; col < 9; col++)
                {
                    int colGridOffset = ((int)(col / 3)*2);

                    if (table[row, col] != 0) {                        
                        Console.SetCursorPosition(colGridOffset + offsetX + (col * 2), rowGridOffset + offsetY + (row ));
                        Console.Write(table[row, col].ToString());                        
                    };
                    if (col == 2 || col == 5)
                    {
                        Console.SetCursorPosition(colGridOffset + offsetX + (col * 2) +2, offsetY + row+ rowGridOffset);
                        Console.Write("|");
                    }                    
                }
                if (row == 2 || row == 5)
                {
                    Console.SetCursorPosition(offsetX, offsetY + row + rowGridOffset + 1);
                    Console.Write(new string('-', 21));
                }                
            }
            Console.SetCursorPosition(0, offsetY + table.GetLength(1)+3);
        }

    }
}
