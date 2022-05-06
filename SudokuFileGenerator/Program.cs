using Sudoku;

var generator = new SudokuGenerator();


var filledCells = MyConsole.ReadIntFromRange(5, 81, "Please choose filled cells count");
var boardsCount = MyConsole.ReadIntFromRange(1, 10000, "How many boards generate?");
var filename = MyConsole.ReadLine("Save as filename: ");

if (string.IsNullOrEmpty(filename))
{
    MyConsole.WriteError("Filename cannot be empty");    
    MyConsole.WaitForKey();
    return;
}
var solver = new SudokuCPSolver();

var rnd = new Random();

using var fileStream = new FileStream(filename, FileMode.Create);
using var stringWriter = new StreamWriter(fileStream);
using var fileStreamSolved = new FileStream(filename+"_solved", FileMode.Create);
using var stringWriterSolved = new StreamWriter(fileStreamSolved);

for (int i = 0; i < boardsCount; i++)
{
    var board = generator.Generate(rnd.Next(20) + 30, filledCells);
    stringWriter.WriteLine(board.FormatAsString());

    var solved = solver.Solve(board);
    stringWriterSolved.WriteLine(solved.FormatAsString());
}

Console.WriteLine($"{boardsCount} has been saved to: {filename}_(solved) files");
MyConsole.WaitForKey();