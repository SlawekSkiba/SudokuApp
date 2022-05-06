using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Google.OrTools.Sat;

namespace Sudoku
{
    public class SudokuCPSolver
    {

        public int[,] Solve(int[,] grid)
        {
            var model = new CpModel();
            var rowsCount = grid.GetLength(0);
            var collsCount = grid.GetLength(1);

            //Przygotowanie tablicy zmiennych zawierających opis domeny dla każdego pola odpowiadającej rozmiarowi tablicy wejściowej
            IntVar[,] varGrid = new IntVar[rowsCount, collsCount];

            for (int r = 0; r < rowsCount; ++r)
            {
                for (int c = 0; c < rowsCount; ++c)
                {
                    if (grid[r, c] == 0)
                    {
                        varGrid[r, c] = model.NewIntVar(1, 9, $"R{r}C{c}");  // kiedy pole jest 0 oznacza że jest nie wypełnione, więc solver ma wstawić wartość od 1 do 9
                    }
                    else
                    {
                        varGrid[r, c] = model.NewIntVar(grid[r, c], grid[r, c], $"R{r}C{c}");  // pole już wypełnione więc wartość do wypełnienia jest stała = wartości źródłowej
                    }

                }
            }


            // Dodajemy reguły
            // liczby w wierszach nie mogą się powtarzać
            for (int r = 0; r < rowsCount; ++r)
            {
                var rowConstraint = new List<IntVar>();
                for (int c = 0; c < collsCount; ++c)
                {
                    rowConstraint.Add(varGrid[r, c]);
                }
                model.AddAllDifferent(rowConstraint);
            }

            // liczby w kolumnach nie mogą się powtarzać
            for (int c = 0; c < collsCount; ++c)
            {
                var columnConstraints = new List<IntVar>();
                for (int r = 0; r < rowsCount; ++r)
                {
                    columnConstraints.Add(varGrid[r, c]);
                }

                model.AddAllDifferent(columnConstraints);
            }

            // liczby w blokach nie mogą się powtarzać
            for (int c = 0; c < 3; ++c)
            {                
                for (int r = 0; r < 3; ++r)
                {
                    AddBLockConstraints(r, c, model, varGrid);
                }
            }

            CpSolver solver = new CpSolver();

            var status = solver.Solve(model);
                        
            // wypisanie wyników
            for (int c = 0; c < collsCount; ++c)
            {
                for (int r = 0; r < rowsCount; ++r)
                {
                    if (grid[r, c] == 0)
                    {
                        grid[r, c] = (int)solver.Value(varGrid[r, c]);
                    }
                }
            }
            
            return grid;
        }

        private static void AddBLockConstraints(int rr, int rc, CpModel model, IntVar[,] varGrid)
        {
            for (int c = 0; c < 3; ++c)
            {
                var blockConstraints = new List<IntVar>();
                for (int r = 0; r < 3; ++r)
                {
                    blockConstraints.Add(varGrid[(rr*3)+r, (rc*3)+c]);
                }

                model.AddAllDifferent(blockConstraints);
            }
        }
    }
}
