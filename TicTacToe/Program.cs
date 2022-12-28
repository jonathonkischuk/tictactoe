using System;

namespace TicTacToe
{
    internal class Program
    {
        static char[,] gameBoard = 
        { 
            {'1','2','3'},
            {'4','5','6'},
            {'7','8','9'}
        };

        static int turns = 0;


        static void Main(string[] args)
        {
            int player = 2;
            int input = 0;
            bool inputCorrect = true;

            


            do
            {

                if (player == 2)
                {
                    player = 1;
                    EnterXorO(player, input);
                }
                else if (player == 1)
                {
                    player = 2;
                    EnterXorO(player, input);
                }

                SetField();

                #region
                // check winning condition
                char[] playerChars = { 'X', 'O' };

                foreach (char playerChar in playerChars)
                {
                    if (((gameBoard[0, 0] == playerChar) && (gameBoard[0, 1] == playerChar) && (gameBoard[0, 2] == playerChar))
                        || ((gameBoard[1, 0] == playerChar) && (gameBoard[1, 1] == playerChar) && (gameBoard[1, 2] == playerChar))
                        || ((gameBoard[2, 0] == playerChar) && (gameBoard[2, 1] == playerChar) && (gameBoard[2, 2] == playerChar)) || ((gameBoard[1, 0] == playerChar) && (gameBoard[1, 1] == playerChar) && (gameBoard[1, 2] == playerChar))
                        || ((gameBoard[0, 0] == playerChar) && (gameBoard[1, 0] == playerChar) && (gameBoard[2, 0] == playerChar))
                        || ((gameBoard[0, 1] == playerChar) && (gameBoard[1, 1] == playerChar) && (gameBoard[2, 1] == playerChar))
                        || ((gameBoard[0, 2] == playerChar) && (gameBoard[1, 2] == playerChar) && (gameBoard[2, 2] == playerChar))
                        || ((gameBoard[0, 0] == playerChar) && (gameBoard[1, 1] == playerChar) && (gameBoard[2, 2] == playerChar))
                        || ((gameBoard[0, 2] == playerChar) && (gameBoard[1, 1] == playerChar) && (gameBoard[2, 0] == playerChar)))
                    {
                        if (playerChar == 'X')
                        {
                            Console.WriteLine("\nPlayer 2 is the Winner!");
                        }
                        else
                        {
                            Console.WriteLine("\nPlayer 1 is the Winner!");
                        }

                        Console.WriteLine("Please press any key to reset the game!");
                        Console.ReadKey();

                        // reset field
                        ResetField();

                        break;
                    }
                    else if (turns == 10)
                    {
                        Console.WriteLine("\nDraw!");
                        Console.WriteLine("Please press any key to reset the game!");
                        Console.ReadKey();
                        ResetField();
                        break;
                    }
                }


                #endregion

                #region
                // test if field is already taken
                do
                {
                    Console.Write("\nPlayer {0}: Choose your field! ", player);
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a number!");
                    }

                    if ((input == 1) && (gameBoard[0, 0] == '1'))
                        inputCorrect = true;
                    else if ((input == 2) && (gameBoard[0,1] == '2'))
                        inputCorrect = true;
                    else if ((input == 3) && (gameBoard[0, 2] == '3'))
                        inputCorrect = true;
                    else if ((input == 4) && (gameBoard[1, 0] == '4'))
                        inputCorrect = true;
                    else if ((input == 5) && (gameBoard[1, 1] == '5'))
                        inputCorrect = true;
                    else if ((input == 6) && (gameBoard[1, 2] == '6'))
                        inputCorrect = true;
                    else if ((input == 7) && (gameBoard[2, 0] == '7'))
                        inputCorrect = true;
                    else if ((input == 8) && (gameBoard[2, 1] == '8'))
                        inputCorrect = true;
                    else if ((input == 9) && (gameBoard[2, 2] == '9'))
                        inputCorrect = true;
                    else
                    {
                        Console.WriteLine("\nIncorrect input! Please use another field!");
                        inputCorrect = false;
                    }


                } while (!inputCorrect);
                #endregion

            } while (true);
            
        }

        public static void ResetField()
        {
            char[,] gameBoardInitial =
            {
                {'1','2','3'},
                {'4','5','6'},
                {'7','8','9'}
            };
            gameBoard = gameBoardInitial;
            SetField();
            turns = 0;
        }


        public static void SetField()
        {
            Console.WriteLine("     |     |    ");
            Console.WriteLine("   {0} |  {1}  |   {2}", gameBoard[0,0], gameBoard[0,1], gameBoard[0,2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |    ");
            Console.WriteLine("   {0} |  {1}  |   {2}", gameBoard[1,0], gameBoard[1,1], gameBoard[1,2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |    ");
            Console.WriteLine("   {0} |  {1}  |   {2}", gameBoard[2,0], gameBoard[2,1], gameBoard[2,2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |    ");
            turns++;
        }

        public static void EnterXorO(int player, int input)
        {
            char playerSign = ' ';

            if (player == 1)
            {
                playerSign = 'X';
            }
            else if (player == 2)
            {
                playerSign = 'O';
            }

            switch (input)
            {
                case 1:
                    gameBoard[0, 0] = playerSign; break;
                case 2:
                    gameBoard[0, 1] = playerSign; break;
                case 3:
                    gameBoard[0, 2] = playerSign; break;
                case 4:
                    gameBoard[1, 0] = playerSign; break;
                case 5:
                    gameBoard[1, 1] = playerSign; break;
                case 6:
                    gameBoard[1, 2] = playerSign; break;
                case 7:
                    gameBoard[2, 0] = playerSign; break;
                case 8:
                    gameBoard[2, 1] = playerSign; break;
                case 9:
                    gameBoard[2, 2] = playerSign; break;
            }
        }
    }
}
