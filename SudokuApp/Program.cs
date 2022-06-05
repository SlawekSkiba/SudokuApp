using Sudoku;
using SudokuApp;
using System.Diagnostics;

var generator = new SudokuGenerator();

if (args.Length == 0)
{
    MyConsole.WriteError("You must provide filename with board to solve!");
    Console.WriteLine("Usage: SudokuApp <filename>");
    Console.WriteLine("     : SudokuApp /g  - to generate boards");
    Console.ReadKey();
    return;
}

if(args[0] == "/g")
{
    var boardsCount = MyConsole.ReadIntFromRange(1, 1000, "How many boards to generate?");
    Console.Write("Write folderName (SampleBoards): ");
    var folderName = Console.ReadLine();
    if (string.IsNullOrEmpty(folderName))
    {
        folderName = "SampleBoards";
    }
    if (!Directory.Exists(folderName))
    {
        Directory.CreateDirectory(folderName);
    }
    BoardsFilesGenerator.Generate(boardsCount, folderName);
    Console.WriteLine("Files hase been generated in folder {0}", folderName);
    return;
}

if (!File.Exists(args[0]))
{
    MyConsole.WriteError($"File {args[0]} not found");
    return;
}

int[,] board = await SudokuBoardsExtensions.LoadFromBoardFile(args[0]);

var solver = new SudokuCPSolver();

Console.Clear();

board.ConsolePrint(0, 2);
var timePerParse = Stopwatch.StartNew();
var solved = solver.Solve(board);
timePerParse.Stop();

board.ConsolePrint(30, 2);
Console.SetCursorPosition(0, 20);
Console.WriteLine($"Board has been solved in: {timePerParse.ElapsedMilliseconds} ms");

var extension = Path.GetExtension(args[0]);
var outFileName = args[0].Replace(extension, "_solved" + extension);

SudokuBoardsExtensions.SaveToBoardFile(board, outFileName);
        