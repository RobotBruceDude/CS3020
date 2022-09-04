using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleshipInClass
{
    public class Gameboard
    {
        Random rnd = new Random();
        char[,] _board = new char[10, 10];
        int[,] _hit = new int[10, 10];

        /// <summary>
        /// Draws the gameboard to the the console
        /// </summary>
        public void Draw()
        {

            for (int row = 0; row < _board.GetLength(0); row++)
            {
                Console.WriteLine($"{row} ");
                for (int col = 0; col < _board.GetLength(1); col++)
                {
                    Console.Write($"[{_board[row, col]}]");

                }

                Console.WriteLine();
            }

            DrawColumnNumbers();
        }


        /// <summary>
        /// Draws out a label row for all of the columns
        /// </summary>
        private void DrawColumnNumbers()
        {
            for (int col = 0; col < _board.GetLength(1); col++)
            {
                Console.Write("  ");
                Console.WriteLine($" {col} ");
            }
        }

        /// <summary>
        /// Fill the board with a particular characters
        /// </summary>
        /// <param name="value">The character that you are filling the board with.</param>
        public void Fill()
        {
            for (int i = 0; i < _hit.GetLength(0); i++)
                for (int j = 0; j < _hit.GetLength(1); j++)
                    _hit[i, j] = 0;

            RandomHit();


            for (int row = 0; row < _board.GetLength(0); row++)
            {
                for (int col = 0; col < _board.GetLength(1); col++)
                {
                    if (_hit[row, col] == 1)
                        _board[row, col] = 'X';

                }
            }
        }


        public void RandomHit()
        {
            int amount = 5;
            for (int m = 0; m < amount; m++)
            {
                    _hit[rnd.Next(10), rnd.Next(10)] = 1;
            }
        }



    }
}
