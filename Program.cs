using System;

namespace SpaceGame
{
    class Program
    {

        static void Main(string[] args)
        {


            //setting up game
            Random rand = new Random();
            int score = 0;
            int coinPos = 0;


            int size = 11; // size based on difficulty
            string[,] game = new string[size, size];

            for (int i = 1; i < game.GetLength(0); i++) // width    //filling in array
            {
                for (int j = 1; j < game.GetLength(1); j++) // height
                {
                    game[i, j] = " ";
                }
            }

            for (int i = 0; i < size; i++)      //left border
            {
                game[i, 0] = "|";
            }

            for (int i = 0; i < size; i++)      //right border
            {
                game[i, size - 1] = "|";
            }

            for (int j = 0; j < size; j++)      //top border
            {
                game[0, j] = "_";
            }

            int playerPos = size - (size / 2);
            int oldPosition = playerPos;
            game[size - 1, playerPos] = "V";    //player starting position

            int gameCounter = 0;

            int playerPosX = size - 1;

            while (gameCounter <= 100)       //game loop
            {


                for (int j = 1; j < (game.GetLength(0) - 1); j++)   //clears first line of old coins
                {
                    if (game[1, j] == "o")
                    {
                        game[1, j] = " ";
                    }

                }

                coinPos = rand.Next(1, size - 2);
                game[1, coinPos] = "o";            //creates new coin

                Print2DArray(game, score);




                ConsoleKeyInfo awd = new ConsoleKeyInfo();
                awd = Console.ReadKey();

                switch (awd.Key)
                {
                    case ConsoleKey.A: //left
                        playerPos -= 1;
                        oldPosition = playerPos + 1;
                        game[playerPosX, oldPosition] = " ";
                        game[playerPosX, playerPos] = "V";
                        if (game[playerPosX - 1, playerPos] == "o")
                        {
                            score++;
                        }
                        copyRows(size, game);
                        Console.Clear();
                        break;
                    case ConsoleKey.D: //right
                        playerPos += 1;
                        oldPosition = playerPos - 1;
                        game[playerPosX, oldPosition] = " ";
                        game[playerPosX, playerPos] = "V";
                        if (game[playerPosX - 1, playerPos] == "o")
                        {
                            score++;
                        }
                        copyRows(size, game);
                        Console.Clear();
                        break;
                    case ConsoleKey.W: //stay in place
                        if (game[playerPosX - 1, playerPos] == "o")
                        {
                            score++;
                        }
                        copyRows(size, game);
                        Console.Clear();
                        break;

                }



                gameCounter++;
                //Console.WriteLine($"\n{score}");
            }

            Console.ReadLine();
        }

        public static void Print2DArray<T>(T[,] matrix, int score)
        {
            Console.WriteLine($"Score: {score}");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void copyRows(int size, string[,] game)     //moves coins from top to bottom
        {
            for (int x = 2; x < size; x++)
            {
                int rowAbove = x + 1;

                for (int j = 1; j < (game.GetLength(0) - 1); j++)
                {
                    if (rowAbove == size)   //keeps rows from copying the top border
                    {
                        break;
                    }
                    game[size - x, j] = game[size - rowAbove, j];   //copies top row to bottom row

                }
            }
        }
    }
}
