using BenchmarkDotNet.Running;
using Sudoku;
using SudokuBenchmark;

var summary = BenchmarkRunner.Run<SudokuBenchmarks>();


MyConsole.WaitForKey();