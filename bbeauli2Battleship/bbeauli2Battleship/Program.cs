using bbeauli2Battleship;
/* Author:      Bruce Beaulieu
 * Project:     Battleship
 * Due Date:    9/15/22 
 * 
 */
Game game = new Game();
//game.RunGame();


Gameboard board = new Gameboard();
int test1 = 0;
int test2 = 0;
int test3 = 0;
board.Initialize();

for (int i = 0; i < 4; i++)
{
    test1 = 0;
    test2 = i;
    test3 = Convert.ToInt32(Console.ReadLine());

    board.StoreInput(test1, test2, test3);
}

board.Draw();

board.StoreInput(3,4,3);
board.Draw();
