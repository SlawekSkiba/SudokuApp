using Sudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApp
{
    internal static class BoardsFilesGenerator
    {
        internal static void Generate(int boardsCount, string folderName)
        {
            var generator = new SudokuGenerator();
            for (var i = 0; i < boardsCount; i++)
            {
                var board = generator.Generate(20, 30);
                var filename = Path.Combine(folderName, $"board_30_{i+1,2:D4}.txt");
                SudokuBoardsExtensions.SaveToBoardFile(board, filename);
            }
        }
    }
}
