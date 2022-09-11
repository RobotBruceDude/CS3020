using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using bbeauli2Battleship;

namespace bbeauli2Battleship
{
    public class Game
    {
        
        ship Destroyer1 = new()
        {
            name = "Destroyer 1",
            length = 2,
            hits = 0
        };
        ship Destroyer2 = new()
        {
            name = "Destroyer 2",
            length = 2,
            hits = 0
        };


        Gameboard board = new Gameboard(); //be able to call methods within gameboard
        int[,] _shipLocation = new int[10, 10];

        public void RunGame()
        {
            DisplayWelcomeMethod();
            PlaceShip();
            board.Initialize();
            board.Draw();
            


        }

        private void DisplayWelcomeMethod()
        {
            Console.WriteLine("Welcome to battleship. When choosing a coordinate to shoot\n" +
                "make sure to the column then the row. Ex: ('05').");
        }

        public void PlaceShip()
        {
            int shipSize = 0;
            

            for (int i = 0; i < 2; i++)
            {
                switch (i)
                {
                    case 0:
                        shipSize = Destroyer1.length;
                        break;
                    case 1:
                        shipSize = Destroyer2.length;
                        break;
                }
                

                


            }

            
            
        }

        public int[] CheckPlace(int length) //this will create all values possible and check if it can fit
        {
            Random rng = new();
            bool allowed = false;
            int startPos;
            int direction;
            int distance;
            int[] location = new int[5];
            

            do
            {
                startPos = rng.Next(100);
                direction = rng.Next(4);

                switch (direction)
                {
                    case 1: //Up
                        direction = -10;
                        break;
                    case 2: //Down
                        direction = 10;
                        break;
                    case 3: //Left
                        direction = - 1;
                        break;
                    default: //Right
                        direction = 1;
                        break;
                }

                for (int i = 0; i < length; i++)
                {

                }





            } while (allowed == false);



            return location;
            
        }


        public bool isHit(int input)
        {
            int[] location = new int[] { };

            for (int i = 0; i < 2; i++) //only 2 for testing
            {
                switch (i)
                {
                    case 0:
                        location = Destroyer1.coordinates.ToArray();
                        break;
                    case 1:
                        location = Destroyer2.coordinates.ToArray();
                        break;
                }

                if(location.Length != 0)
                {
                    foreach (var coords in location)
                    {
                        if (input == coords)
                        {
                            return true;
                        }
                    }
                }


            }

            return false;
        }

        public void Input()
        {

        }


        public void Logic()
        {
            

        }
    }
}