using Sudoku;

var generator = new SudokuGenerator();


while (true)
{
    var filledCells = ReadInt(5,81);

    generator.Generate(20, filledCells);    
    Console.WriteLine(generator.GetAsStringFormatted());

    Console.Write("Press any key to generate new board. Esc to finish the program: ");    
    var key = Console.ReadKey();
    if(key.Key == ConsoleKey.Escape)
    {
        break;
    }
    var pos = Console.GetCursorPosition();
    Console.SetCursorPosition(0, pos.Top - 1);
    Console.WriteLine("                                                                  ");
}

static int ReadInt(int min, int max)
{
    int value;
    do
    {
        Console.SetCursorPosition(0,1);
        Console.Write("                      ");
        Console.SetCursorPosition(0, 0);
        Console.WriteLine($"Please choose filled cells count ({min}, {max}): ");
    } while (!(int.TryParse(Console.ReadLine(), out value) && value >= min && value <= max));
    return value;
}