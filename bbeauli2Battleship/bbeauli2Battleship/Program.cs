using bbeauli2Battleship;
/* Author:      Bruce Beaulieu
 * Project:     Battleship
 * Due Date:    9/15/22 
 * 
 */
Game game = new Game();
Random rng = new Random();
//game.RunGame();
List<int> location = new List<int>();
int[] array = new int[] { };

location.Add(5);

array = location.ToArray();
Console.Write($"{array.Length}");


