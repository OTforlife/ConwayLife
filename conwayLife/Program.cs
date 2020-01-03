using System;
using System.Threading;
namespace conwayLife
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            bool[,] grid2 = new bool[17 , 17];
            bool[,] grid = new bool[17, 17];

            //blinker starting state
            grid[4, 4] = true;
            grid[4, 5] = true;
            grid[4, 6] = true;
            grid[6, 8] = true;
            grid[6, 7] = true;
            grid[6, 9] = true;
            grid[10, 10] = true;
            grid[10, 11] = true;
            grid[11, 10] = true;
            grid[11, 11] = true;
            grid[9, 9] = true;
            grid[10, 9] = true;
            grid[15, 8] = true;
            grid[15, 7] = true;
            grid[9, 5] = true;
            grid[15, 4] = true;
            grid[15, 3] = true;
            grid[15, 5] = true;

            grid[5, 5] = true;
            grid[5, 6] = true;
            grid[5, 7] = true;
            grid[6, 5] = true;
            grid[6, 6] = true;
            grid[6, 7] = true;
            while (true)
            {
                Console.Clear();
                //Console.SetCursorPosition(0, 0);
                //grid drawing for row
                for (int i = 0; i < 17; i++)// row
                {
                    
                    //drawing for column
                    for (int j = 0; j < 17; j++)//column
                    {
                        if (grid[i, j] == true)
                        {
                            Console.Write("[*]");
                        }
                        else
                        {
                            Console.Write("[ ]");
                        }

                    }
                    Console.WriteLine();
                    
                }

                

                //scanning row
                for (int i = 1; i < 16; i++)
                {
                    //scanning column
                    for (int j = 1; j < 16; j++)
                    {
                        //if cell is live, count how many neighbors
                        //covers rules 1-3

                        int counter = 0;

                        if (grid[i + 1, j] == true)
                        {
                            counter++;
                        }

                        if (grid[i + 1, j + 1] == true)
                        {
                            counter++;
                        }
                        if (grid[i + 1, j - 1] == true)
                        {
                            counter++;
                        }
                        if (grid[i, j + 1] == true)
                        {
                            counter++;
                        }
                        if (grid[i - 1, j + 1] == true)
                        {
                            counter++;
                        }
                        if (grid[i - 1, j] == true)
                        {
                            counter++;
                        }
                        if (grid[i - 1, j - 1] == true)
                        {
                            counter++;
                        }
                        if (grid[i, j - 1] == true)
                        {
                            counter++;
                        }


                        if (grid[i, j] == true)
                        {


                            //first rule

                            if (counter < 2)
                            {
                                grid2[i, j] = false;

                            }

                            //second rule
                            //any live cell with 2 or 3 live neighbors
                            if (counter == 2 || counter == 3)
                            {
                                grid2[i, j] = true;
                            }

                            //third rule
                            //any live cell with more than 3 live neighbors dies
                            if (counter > 3)
                            {
                                grid2[i, j] = false;
                            }


                        }
                        //fourth rule
                        //any dead cell with exactly 3 live neighbors becomes alive
                        else if (grid[i, j] == false)
                        {
                            if (counter == 3)
                            {
                                grid2[i, j] = true;
                            }
                            else
                            {
                                grid2[i, j] = false;
                            }
                        }


                    }



                }

                

                grid = grid2;
                grid2 = new bool[17, 17];

                Thread.Sleep(500);
            }    


            
        }
    }
}