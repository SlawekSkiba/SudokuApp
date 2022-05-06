using BenchmarkDotNet.Attributes;
using Sudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuBenchmark
{
    public class SudokuBenchmarks
    {
        private readonly List<int[,]> boards_15;
        private readonly List<int[,]> boards_25;
        private readonly List<int[,]> boards_36;


        public SudokuBenchmarks()
        {
            boards_15 = File.ReadAllLines("SampleBoards\\sudoku_15_10000").Select(line => SudokuBoardsExtensions.LoadFromString(line)).Take(10).ToList();
            boards_25 = File.ReadAllLines("SampleBoards\\sudoku_25_10000").Select(line => SudokuBoardsExtensions.LoadFromString(line)).Take(10).ToList();
            boards_36 = File.ReadAllLines("SampleBoards\\sudoku_36_10000").Select(line => SudokuBoardsExtensions.LoadFromString(line)).Take(10).ToList();
        }

        
        [Benchmark]
        public void TestSolver_Board15()
        {
            var solver = new SudokuCPSolver();
            foreach (var board in boards_15)
            {
                solver.Solve(board);
            }
        }

        [Benchmark]
        public void TestSolver_Board25()
        {
            var solver = new SudokuCPSolver();
            foreach (var board in boards_25)
            {
                solver.Solve(board);
            }
        }

        [Benchmark]
        public void TestSolver_Board36()
        {
            var solver = new SudokuCPSolver();
            foreach (var board in boards_36)
            {
                solver.Solve(board);
            }
        }
    }
}
