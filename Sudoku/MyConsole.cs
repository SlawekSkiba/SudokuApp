namespace Sudoku
{
    public static class MyConsole
    {
        public static int ReadIntFromRange(int min, int max, string question)
        {
            int value = int.MinValue;
            do
            {
                if (value > int.MinValue)
                {
                    var (top, left) =Console.GetCursorPosition();
                    Console.SetCursorPosition(0, top);
                    Console.WriteLine("".PadRight(Console.BufferWidth));
                    Console.SetCursorPosition(0, top);
                }
                Console.Write($"{question} ({min}, {max}): ");
            } while (!(int.TryParse(Console.ReadLine(), out value) && value >= min && value <= max));
            return value;
        }

        public static string? ReadLine(string message)
        {
            Console.Write($"{message} ");
            return Console.ReadLine();
        }

        public static ConsoleKeyInfo WaitForKey(string message = "Press any key")
        {
            Console.WriteLine(message);
            return Console.ReadKey();
        }
        public static void WriteError(string message)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ForegroundColor = color;
        }

    }
}
