using Sudoku;
using SudokuBenchmark;

var boards = 1000;
var solverBenchmark = new SudokuBenchmarks(boards);

Console.WriteLine("Measure boards");

Console.WriteLine();
Console.WriteLine($"Solving {boards} boards of 36 filled fields");
var time36 = MeasureTime.Measure(solverBenchmark.TestSolver_Board36);

Console.WriteLine($"Solving {boards} boards of 25 filled fields");
var time25 = MeasureTime.Measure(solverBenchmark.TestSolver_Board25);

Console.WriteLine($"Solving {boards} boards of 15 filled fields");
var time15 = MeasureTime.Measure(solverBenchmark.TestSolver_Board15);

Console.WriteLine();
Console.WriteLine("Measured time");
Console.WriteLine("{0,10}     {1,10}     {2,10}", 36, 25, 15);
Console.WriteLine("{0,10}     {1,10}     {2,10}", time36.TotalMilliseconds, time25.TotalMilliseconds, time15.TotalMilliseconds);




