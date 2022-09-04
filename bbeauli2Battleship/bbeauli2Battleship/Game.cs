using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bbeauli2Battleship;

namespace bbeauli2Battleship
{
    public class Game
    {
        Gameboard board = new Gameboard();//be able to call methods within gameboard
        public void RunGame()
        {
            DisplayWelcomeMethod();
            board.Initialize();
            board.Draw();


        }

        public void DisplayWelcomeMethod()
        {
            Console.WriteLine("Welcome to battleship. When choosing a coordinate to shoot\n" +
                "make sure to put the letter than the number. Ex: ('B5'). Have Fun!");
        }

        public void Input()
        {

        }


        public void Logic()
        {
            throw new System.NotImplementedException();
        }
    }
}