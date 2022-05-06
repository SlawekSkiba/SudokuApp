

using Sudoku;

var solver = new SudokuCPSolver();

var generator = new SudokuGenerator();


while (true)
{
    Console.Clear();
    var filledCells = ReadInt(5, 81);

    var board = generator.Generate(30, filledCells);

    Console.WriteLine("Original board           Generated board");
    (int px, int py) = Console.GetCursorPosition();
    SudokuConsolePrinter.ConsolePrint(generator.FilledBoard, 0, 3);
    SudokuConsolePrinter.ConsolePrint(generator.Board, 25, 3);    

    var solved = solver.Solve(board);
    Console.WriteLine("Solved board");
    Console.WriteLine("------------");
    Console.WriteLine(SudokuGenerator.GetAsStringFormatted(solved));
    

    Console.Write("Press any key to generate new board. Esc to finish the program: ");
    var key = Console.ReadKey();    
    if (key.Key == ConsoleKey.Escape)
    {
        break;
    }
}

static int ReadInt(int min, int max)
{
    int value;
    do
    {
        Console.SetCursorPosition(0, 1);
        Console.Write("                      ");
        Console.SetCursorPosition(0, 0);
        Console.WriteLine($"Please choose filled cells count ({min}, {max}): ");
    } while (!(int.TryParse(Console.ReadLine(), out value) && value >= min && value <= max));
    return value;
}