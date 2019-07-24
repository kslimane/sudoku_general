using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DlxLib;

namespace Sudoku
{
    class solver_dancing_link : SudokuLib.ISudokuSolver
    {
        public SudokuLib.Sudoku Solve(SudokuLib.Sudoku sudoku)
        {
            var matrix = createMatrix(sudoku);
            var dlx = new Dlx();
            var firstTwoSolutions = dlx.Solve(matrix).First();
            SudokuLib.Sudoku toReturn = createSudoku(firstTwoSolutions);
            return toReturn;
        }

        private SudokuLib.Sudoku createSudoku(Solution firstTwoSolutions)
        {
            SudokuLib.Sudoku toReturn = new SudokuLib.Sudoku();
            for (int i = 0; i < 81; i++)
            {
                toReturn.SetCell(i / 9, i % 9, firstTwoSolutions.RowIndexes.ElementAt(i)%9+1);
            }
            return toReturn;
        }

        private bool[,] createMatrix(SudokuLib.Sudoku sudoku)
        {

            int[,] grille = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    grille[i, j] = sudoku.GetCell(i,j);
                }
                 
            };

            //nombre de valeur initial dans le sudoku
            int countInitialNumber = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    //Console.WriteLine(grille[i, j]);
                    if (grille[i, j] != 0)
                    {
                        //Console.WriteLine("add");
                        countInitialNumber++;
                    }
                    //Console.ReadLine();
                }
            }
            Console.WriteLine(countInitialNumber);
            //matrix contraintes (regles du sudoku) (false par defaut)
            bool[,] matrix = new bool[729, 324 + countInitialNumber];
            for (int cellVal = 0; cellVal < 729; cellVal++)
            {

                int val = cellVal % 9 + 1;
                int col = (cellVal / 9 % 9) + 1;
                int row = (cellVal / 9 / 9) + 1;
                int zone = ((cellVal / 9 % 9) / 3 + 1) + 3* (cellVal / 9 / 27 );

                //contrainte strictement 1 nombre par case
                for (int rowcol = 0; rowcol < 81; rowcol++)
                {

                    if (cellVal / 9 == rowcol)
                    {
                        matrix[cellVal, rowcol] = true;
                    }
                }

                //contrainte: strictement 1 fois un nombre par ligne
                for (int rowVal = 0; rowVal < 81; rowVal++)
                {
                    if ((rowVal % 9 == val - 1) && (rowVal / 9) == row - 1)
                    {
                        matrix[cellVal, rowVal + 81] = true;
                    }
                }


                //contrainte: strictement 1 fois un nombre par colonne 
                for (int colVal = 0; colVal < 81; colVal++)
                {
                    if ((colVal % 9 == val - 1) && (colVal / 9) == col - 1)
                    {
                        matrix[cellVal, colVal + 162] = true;
                    }
                }

                //contrainte: strictement 1 fois un nombre par zone
                for (int zoneVal = 0; zoneVal < 81; zoneVal++)
                {
                    if ((zoneVal % 9) + 1 == val && zoneVal / 9 == zone - 1)
                    {
                        matrix[cellVal, zoneVal + 243] = true;
                    }
                }
            }

            //contrainte: valeurs initiales du sudoku
            int colValIni = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (grille[i, j] != 0)
                    {
                        matrix[(i * 81 + j * 9 + grille[i, j] - 1), colValIni + 324] = true;
                        colValIni++;
                    }

                }
            }
            for (int j = 0; j < 324; j++)
            {
                int countrue = 0;
                for (int i = 0; i < 729; i++)
                {
                    if (matrix[i,j])
                    {
                        countrue++;
                    }
                }
                if (countrue !=9)
                {

                    Console.WriteLine("erreur");
                    Console.WriteLine(countrue);
                    Console.WriteLine(j);
                }
            }

            return matrix;
        }

    }
}
