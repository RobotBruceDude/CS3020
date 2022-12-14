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
        List<ship> ships = new List<ship>(); //redo this to work better. Make the ships a funct. and put into the list
        ship Carrier = new()
        {
            name = "Carrier",
            length = 5,
            hits = 0
        };
        ship Battleship = new()
        {
            name = "Battleship",
            length = 4,
            hits = 0
        };
        ship Submarine1 = new()
        {
            name = "Submarine 1",
            length = 3,
            hits = 0
        };
        ship Submarine2 = new()
        {
            name = "Submarine 2",
            length = 3,
            hits = 0
        };
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
            board.Initialize();
            PlaceShip();
            board.Draw();

            //ships.Exists(x => x.coordinates == 0);
        }

        private void DisplayWelcomeMethod()
        {
            Console.WriteLine("Welcome to battleship. When choosing a coordinate to shoot\n" +
                "make sure to the column then the row. Ex: ('05').");
        }

        public void PlaceShip()
        {
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine();
                int[] store = new int[] { };//reset array after every use

                //switch statement of all all the ships
                switch (i)
                {
                    case 0:
                        store = CreateCoords(Carrier.length);
                        Carrier.coordinates.AddRange(store);
                        break;
                    case 1:
                        store = CreateCoords(Battleship.length);
                        Battleship.coordinates.AddRange(store);
                        break;
                    case 2:
                        store = CreateCoords(Submarine1.length);
                        Submarine1.coordinates.AddRange(store);
                        break;
                    case 3:
                        store = CreateCoords(Submarine2.length);
                        Submarine2.coordinates.AddRange(store);
                        break;
                    case 4:
                        store = CreateCoords(Destroyer1.length);
                        Destroyer1.coordinates.AddRange(store);
                        break;
                    case 5:
                        store = CreateCoords(Destroyer2.length);
                        Destroyer2.coordinates.AddRange(store);
                        break;
                }


                foreach (var value in store)
                {
                    int x, y;
                    x = (value % 10);
                    y = (value / 10); 
                    Console.WriteLine($"{x}, {y}");
                    board.StoreInput(x, y, 3);
                }
            }
            board.Draw();
        }

        bool horizontal;
        public int[] CreateCoords(int length) //this will create all values possible and check if it can fit
        {
            Random rng = new();
            List<int> location = new List<int>();
            bool allowed = false;
            bool current = true;

            do
            {
                location.Clear();
                int startPos, currentPos, direction, counter = 0;
                

                startPos = rng.Next(99);
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

                //This will take all the possible positions and test if it is valid
                for (int i = 0; i < length; i++)
                {  
                    
                    if (i != 0) //anything but the current pos
                    {
                        currentPos += direction;
                        current = isEqual(currentPos); //checks if it is equal to another coordinate

                        if (current == false && horizontal == true)
                            current = notWithinRangeX(currentPos, range(startPos));
                        if (current == false && horizontal == false)
                            current = notWithinRangeY(currentPos);
                    }
                    
                    if (i == 0) //current position
                    {
                        current = isEqual(startPos);
                    }

                    if (current == false) 
                    {
                        location.Add(currentPos);
                        counter++;
                        current = true;
                    }
                }

                if (counter == length)
                    allowed = true;
                
            } while (allowed == false);

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

            for (int i = 0; i < 6; i++) //only 2 for testing
            {
                //fun switch statements of all possible coords to pull from
                switch (i)
                {
                    case 0:
                        location = Carrier.coordinates.ToArray();
                        break;
                    case 1:
                        location = Battleship.coordinates.ToArray();
                        break;
                    case 2:
                        location = Submarine1.coordinates.ToArray();
                        break;
                    case 3:
                        location = Submarine2.coordinates.ToArray();
                        break;
                    case 4:
                        location = Destroyer1.coordinates.ToArray();
                        break;
                    case 5:
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
        public bool notWithinRangeX(int input, int actualRange)
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

        public bool notWithinRangeY(int input)
        {
            bool result = true;
            if (range(input) > 0)
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

            int intRange = -1; //default value of range

            if (value > 0 && value <= 9)
                intRange = 0;
            if (value > 9 && value <= 19)
                intRange = 1;
            if (value > 19 && value <= 29)
                intRange = 2;
            if (value > 29 && value <= 39)
                intRange = 3;
            if (value > 39 && value <= 49)
                intRange = 4;
            if (value > 49 && value <= 59)
                intRange = 5;
            if (value > 59 && value <= 69)
                intRange = 6;
            if (value > 69 && value <= 79)
                intRange = 7;
            if (value > 79 && value <= 89)
                intRange = 8;
            if (value > 89 && value <= 99)
                intRange = 9;

            return intRange;
        }


        public void clear()
        {
            Carrier.coordinates.Clear();
            Battleship.coordinates.Clear();
            Submarine1.coordinates.Clear();
            Submarine2.coordinates.Clear();
            Destroyer1.coordinates.Clear();
            Destroyer2.coordinates.Clear();
        }
        public void Input()
        {

        }


        public void Logic()
        {
            

        }
    }
}