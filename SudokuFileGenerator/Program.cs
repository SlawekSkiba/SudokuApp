using Sudoku;

var generator = new SudokuGenerator();


while (true)
{
    var filledCells = ReadIntFromRange(5, 81, "Please choose filled cells count");    

    generator.Generate(40, filledCells);
    Console.WriteLine(generator.GetAsStringFormatted());

    Console.Write("Press any key to generate new board. Esc to finish the program: ");
    var key = Console.ReadKey();
    if (key.Key == ConsoleKey.Escape)
    {
        break;
    }
    var pos = Console.GetCursorPosition();
    Console.SetCursorPosition(0, pos.Top - 1);
    Console.Write("                                                                               ");
}

static int ReadIntFromRange(int min, int max, string question)
{
    int value;
    do
    {
        Console.SetCursorPosition(0, 1);
        Console.Write("                      ");
        Console.SetCursorPosition(0, 0);
        Console.WriteLine($"{question} ({min}, {max}): ");
    } while (!(int.TryParse(Console.ReadLine(), out value) && value >= min && value <= max));
    return value;
}