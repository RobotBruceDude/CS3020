using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bbeauli2Battleship
{
    public class Gameboard
    {
        Random rnd = new Random();
        char[,] _board = new char[10, 10];
        int[,] _shotResult = new int[10, 10];

        public void initialize()
        {
            for (int i = 0; i < _shotResult.GetLength(0); i++)
                for (int j = 0; j < _shotResult.GetLength(1); j++)
                    _shotResult[i, j] = 0;
        }

        /// <summary>
        /// Draws the gameboard onto the console window.
        /// </summary>
        public void Draw()
        {

            for (int row = 0; row < _board.GetLength(0); row++)
            {
                Console.Write($"{row} ");
                for (int col = 0; col < _board.GetLength(1); col++)
                        Console.Write($"[ {_board[row, col]} ] ");

                Console.WriteLine();
            }

            DrawColumnNumbers();
        }


        /// <summary>
        /// Draws the final row labeling all the columns using letters
        /// </summary>
        private void DrawColumnNumbers()
        {
            char[] colLetters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J'};
            Console.Write("    ");
            for (int col = 0; col < _board.GetLength(1); col++)
            {
                Console.Write($"{colLetters[col]}     ");
            }
        }

        /// <summary>
        /// Fill the board with a particular characters
        /// </summary>
        public void Fill()
        {
            for (int i = 0; i < _shotResult.GetLength(0); i++)
                for (int j = 0; j < _shotResult.GetLength(1); j++)
                    _shotResult[i, j] = 0;

            _shotResult[2, 2] = 1;
            _shotResult[5, 2] = 3;
            _shotResult[6, 3] = 2;



            for (int row = 0; row < _board.GetLength(0); row++)
            {
                for (int col = 0; col < _board.GetLength(1); col++)
                {
                    if (_shotResult[row, col] == 1) //If the shot hits
                        _board[row, col] = 'O';
                    if (_shotResult[row, col] == 2) //If the shot misses
                        _board[row, col] = 'X';
                    if (_shotResult[row, col] == 3) //If cheats are activated
                        _board[row, col] = 'S';
                    else                            //If there is nothing set to that current square
                        _board[row, col] = ' ';
                }
            }
        }


        public int RandomHit()
        {
            return (rnd.Next(10));
        }



    }
}