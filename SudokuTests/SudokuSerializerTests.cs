using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;
using System.Threading.Tasks;

namespace SudokuTests
{
    [TestClass]
    public class SudokuSerializerTests
    {
        [TestMethod]
        public void WriteAndReadSudoku_ShouldGetSameResults()
        {
            var generator = new SudokuGenerator();            

            var board = generator.Generate(30, 50);

            var boardString = board.FormatAsString();
            var newBoard = SudokuBoardsExtensions.LoadFromString(boardString);

            newBoard.Should().BeEquivalentTo(board);            
        }


        [TestMethod]
        public async Task WriteAndReadSudokuToFile_ShouldGetSameResults()
        {
            var generator = new SudokuGenerator();
            var filename = "./boardTests";
            var board = generator.Generate(30, 50);

            SudokuBoardsExtensions.SaveToBoardFile(board, filename);
            var newBoard = await SudokuBoardsExtensions.LoadFromBoardFile(filename);

            newBoard.Should().BeEquivalentTo(board);
        }
    }
}