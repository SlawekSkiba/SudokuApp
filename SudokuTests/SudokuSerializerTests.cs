using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;

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
    }
}