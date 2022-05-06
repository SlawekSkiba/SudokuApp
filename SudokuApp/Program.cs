using Sudoku;
using System.Diagnostics;

var generator = new SudokuGenerator();

if (args.Length == 0)
{
    MyConsole.WriteError("You must provide filename with boards to solve!");
    Console.WriteLine("Usage: SudokuApp <filename>");
    return;
}

if (File.Exists(args[0]))
{
    var boards = (await File.ReadAllLinesAsync(args[0])).Select(line => SudokuBoardsExtensions.LoadFromString(line)).ToList();
    Console.WriteLine($"{boards.Count} loaded");
    MyConsole.WaitForKey("Press any key to solve next board.");

    var solver = new SudokuCPSolver();
    var boardNum = 0;
    foreach (var board in boards)
    {
        Console.Clear();
        Console.WriteLine($"Board {++boardNum}");

        board.ConsolePrint(0, 2);
        var timePerParse = Stopwatch.StartNew();
        var solved = solver.Solve(board);
        timePerParse.Stop();

        board.ConsolePrint(30, 2);
        Console.SetCursorPosition(0, 20);
        Console.WriteLine($"Board has been solved in: {timePerParse.ElapsedMilliseconds} ms");

        var key = MyConsole.WaitForKey("Esc - Exit");
        if(key.Key == ConsoleKey.Escape)
        {
            break;
        }
    }
}