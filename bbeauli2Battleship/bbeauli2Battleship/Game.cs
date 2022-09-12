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
         

            for (int i = 0; i < 2; i++)
            {
                int[] store = new int[] { }; //reset array after every use

                switch (i)
                {
                    case 0:
                        store = CheckCoords(Destroyer1.length);
                        Destroyer1.coordinates.AddRange(store);
                        break;
                    case 1:
                        store = CheckCoords(Destroyer2.length);
                        Destroyer2.coordinates.AddRange(store);
                        break;
                }

                Console.WriteLine($"{Destroyer1.coordinates}        {Destroyer2.coordinates}");
                


            }

            
            
        }

        bool horizontal;
        public int[] CheckCoords(int length) //this will create all values possible and check if it can fit
        {
            Random rng = new();
            List<int> location = new List<int>();
            bool allowed = false;
            bool current = true;

            do
            {
                int startPos, currentPos, direction, counter = 0;
                
                startPos = rng.Next(100);
                direction = rng.Next(4);

                currentPos = startPos;

                //Randomizes a direction for the ship to go
                switch (direction) 
                {
                    case 1: //Up
                        direction = -10;
                        horizontal = false;
                        break;
                    case 2: //Down
                        direction = 10;
                        horizontal = false;
                        break;
                    case 3: //Left
                        direction = - 1;
                        horizontal = true;
                        break;
                    default: //Right
                        direction = 1;
                        horizontal = true;
                        break;
                }

                for (int i = 0; i < length; i++)
                {
                    
                    if (i != 0) //anything but the current pos
                    {
                        currentPos += direction;
                        current = isEqual(currentPos);

                        if (current == false && horizontal == true)
                            current = notWithinRange(currentPos, range(startPos));

                        location.Add(currentPos);
                    }
                    
                    if (i == 0) //current position
                    {
                        current = isEqual(startPos);
                        location.Add(startPos);
                    }

                    if (current == false) 
                    {
                        counter++;
                        current = true;
                    }
                }

                if (counter == length)
                    allowed = true;
                
            } while (allowed == true);

            return location.ToArray(); //if section is successful return the length in location
        }

        /// <summary>
        /// Will compare the ship placement values to all positions that exist for other ships
        /// </summary>
        /// <param name="input"> The value that will be compared to every ship position </param>
        /// <returns> True if any value does equal, False if no values equal </returns>
        public bool isEqual(int input)
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

                if (location.Length != 0)
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

        /// <summary>
        /// Checks to see if the values is a non negative and is within the proper range
        /// </summary>
        /// <param name="input"> the input given </param>
        /// <param name="actualRange"> the range that the bow of the ship starts from belongs to </param>
        /// <returns> True if it is not valid, and False if it is valid </returns>
        public bool notWithinRange(int input, int actualRange)
        {
            bool result = true;
            int inputRange = range(input);

            if (input > 0) // test to see if the value is not negative
                if (inputRange == actualRange) //test to see if it is within the proper range
                    result = false;
                
                else
                    result = true;

            return result;
        }
        
        /// <summary>
        /// Fun big thing of ranges along the x-axis to make sure the ships do not go out of range
        /// </summary>
        /// <param name="value"> The value that returns what range of numbers it belongs in </param>
        /// <returns> returns a value 0-9 based on the values range </returns>
        public int range(int value)
        {
            int intRange = 0;

            if (value > 0 && value <= 10)
                intRange = 0;
            if (value > 10 && value <= 20)
                intRange = 1;
            if (value > 20 && value <= 30)
                intRange = 2;
            if (value > 30 && value <= 40)
                intRange = 3;
            if (value > 40 && value <= 50)
                intRange = 4;
            if (value > 50 && value <= 60)
                intRange = 5;
            if (value > 60 && value <= 70)
                intRange = 6;
            if (value > 70 && value <= 80)
                intRange = 7;
            if (value > 80 && value <= 90)
                intRange = 8;
            if (value > 90 && value <= 100)
                intRange = 9;

            return intRange;
        }

        public void Input()
        {

        }


        public void Logic()
        {
            

        }
    }
}