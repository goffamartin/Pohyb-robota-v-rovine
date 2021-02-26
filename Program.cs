using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pohyb_robota_v_rovině
{
    class Program
    {
        //Maze
        static int[,] maze1 = new int[10, 10] 
        {
            {0,0,0,1,1,1,1,1,1,1},
            {1,1,0,0,0,0,0,1,1,1},
            {1,0,0,1,0,1,0,1,1,1},
            {1,0,1,1,1,0,0,0,1,1},
            {1,0,0,0,0,1,1,0,1,1},
            {1,1,1,1,1,0,1,0,0,1},
            {1,1,1,0,0,0,0,0,0,1},
            {1,1,0,0,1,1,1,1,0,1},
            {1,0,0,1,1,1,1,1,0,1},
            {1,1,0,0,0,0,0,0,0,0},
        };
        static int[,] maze2 = new int[10, 10]
        {
            {1,1,1,1,1,1,1,1,1,1},
            {1,0,1,0,1,1,0,1,1,1},
            {1,0,0,0,1,1,0,1,1,1},
            {1,0,1,0,1,0,0,0,0,1},
            {1,0,1,0,1,0,1,0,1,1},
            {0,0,1,0,1,1,1,0,1,1},
            {1,0,1,0,0,0,0,0,1,0},
            {1,0,1,1,1,1,1,1,0,0},
            {1,0,0,1,0,0,0,1,0,1},
            {1,1,0,0,0,1,0,0,0,1},
        };
        static int[,] maze3 = new int[10, 10]
        {
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,0,1,0,0,1,1,0,1},
            {1,1,0,1,1,0,1,1,0,1},
            {1,1,0,0,0,0,0,0,0,1},
            {1,1,0,1,1,0,1,1,1,1},
            {1,0,0,0,0,0,1,1,1,1},
            {1,0,0,1,1,0,1,1,1,1},
            {1,0,0,1,1,0,0,0,1,1},
            {1,0,1,1,1,1,1,0,0,1},
            {1,1,1,1,1,1,1,1,0,1},
        };
        //Souřadnice
        static int[] position = new int[2];
        static int[] previous = new int[2];
        static int[] start;
        static int[] finish;
        static void Main(string[] args)
        {
            start = new int[2] { 0, 0 };
            finish = new int[2] { 9, 6 };
            StartMaze(maze1);
            start = new int[2] { 6, 9 };
            finish = new int[2] { 4, 5 };
            StartMaze(maze2);
            start = new int[2] { 9, 8 };
            finish = new int[2] { 8, 1 };
            StartMaze(maze3);
        }
        private static void Move(int[,] maze)
        {
            //cíl dole vpravo
            if(position[1] <= finish[1] && position[0] <= finish[0])
            {
                //dolů
                if ((position[0] + 1) < maze.GetLength(0) && maze[position[0] + 1, position[1]] == 0 && previous[0] != position[0] + 1)
                {
                    MoveDown();
                }
                //vpravo
                else if (position[1] + 1 < maze.GetLength(1) && maze[position[0], position[1] + 1] == 0 && previous[1] != position[1] + 1)
                {
                    MoveRigth();
                }
                //vlevo
                else if ((position[1] - 1) >= 0 && maze[position[0], position[1] - 1] == 0 && previous[1] != position[1] - 1)
                {
                    MoveLeft();
                }
                //nahoru
                else if ((position[0] - 1) >= 0 && maze[position[0] - 1, position[1]] == 0 && previous[0] != position[0] - 1)
                {
                    MoveUp();
                }
                else
                {
                    MoveBack();
                }
            }
            //cíl dole vlevo
            else if (position[1] >= finish[1] && position[0] <= finish[0])
            {
                //dolů
                if ((position[0] + 1) < maze.GetLength(0) && maze[position[0] + 1, position[1]] == 0 && previous[0] != position[0] + 1)
                {
                    MoveDown();
                }
                //vlevo
                else if ((position[1] - 1) >= 0 && maze[position[0], position[1] - 1] == 0 && previous[1] != (position[1] - 1))
                {
                    MoveLeft();
                }
                //vpravo
                else if ((position[1] + 1) < maze.GetLength(1) && maze[position[0], position[1] + 1] == 0 && previous[1] != position[1] + 1)
                {
                    MoveRigth();
                }
                //nahoru
                else if ((position[0] - 1) >= 0 && maze[position[0] - 1, position[1]] == 0 && previous[0] != position[0] - 1)
                {
                    MoveUp();
                }
                else
                {
                    MoveBack();
                }
            }
            //cíl nahoře vpravo
            else if (position[1] <= finish[1] && position[0] >= finish[0])
            {
                //vpravo
                if ((position[1] + 1) < maze.GetLength(1) && maze[position[0], position[1] + 1] == 0 && previous[1] != position[1] + 1)
                {
                    MoveRigth();
                }
                //nahoru
                else if ((position[0] - 1) >= 0 && maze[position[0] - 1, position[1]] == 0 && previous[0] != position[0] - 1)
                {
                    MoveUp();
                }
                //vlevo
                else if ((position[1] - 1) >= 0 && maze[position[0], position[1] - 1] == 0 && previous[1] != position[1] - 1)
                {
                    MoveLeft();
                }
                //dolů
                else if ((position[0] + 1) < maze.GetLength(0) && maze[position[0] + 1, position[1]] == 0 && previous[0] != position[0] + 1)
                {
                    MoveDown();
                }
                else
                {
                    MoveBack();
                }
            }
            //cíl nahoře vlevo
            else if (position[1] >= finish[1] && position[0] >= finish[0])
            {
                //vlevo
                if ((position[1] - 1) >= 0 && maze[position[0], position[1] - 1] == 0 && previous[1] != position[1] - 1)
                {
                    MoveLeft();
                }
                //nahoru
                else if ((position[0] - 1) >= 0 && maze[position[0] - 1, position[1]] == 0 && previous[0] != position[0] - 1)
                {
                    MoveUp();
                }
                //vpravo
                else if ((position[1] + 1) < maze.GetLength(1) && maze[position[0], position[1] + 1] == 0 && previous[1] != position[1] + 1)
                {
                    MoveRigth();
                }
                //dolů
                else if ((position[0] + 1) < maze.GetLength(0) && maze[position[0] + 1, position[1]] == 0 && previous[0] != position[0] + 1)
                {
                    MoveDown();
                }
                else
                {
                    MoveBack();
                }
            }
        }
        private static void MoveRigth()
        {
            previous[0] = position[0];
            previous[1] = position[1];
            position[1]++;
        }
        private static void MoveLeft()
        {
            previous[0] = position[0];
            previous[1] = position[1];
            position[1]--;
        }
        private static void MoveDown()
        {
            previous[0] = position[0];
            previous[1] = position[1];
            position[0]++;
        }
        private static void MoveUp()
        {
            previous[0] = position[0];
            previous[1] = position[1];
            position[0]--;
        }
        private static void MoveBack()
        {
            int x = position[0];
            int y = position[1];
            position[0] = previous[0];
            position[1] = previous[1];
            previous[0] = x;
            previous[1] = y;
        }
        private static void StartMaze(int[,] maze)
        {
            bool finished = false;
            position[0] = start[0];
            position[1] = start[1];
            //Výpis
            while (!finished)
            {
                Move(maze);
                Console.Clear();
                Console.WriteLine(@"Welcome to The Maze:
----------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                for (int i = 0; i < maze.GetLength(0); i++)
                {
                    for (int j = 0; j < maze.GetLength(1); j++)
                    {
                        if (i == position[0] && j == position[1])
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(" X ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        else if (i == start[0] && j == start[1])
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(" S ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        else if (i == finish[0] && j == finish[1])
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" F ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                            Console.Write($" {maze[i, j]} ");
                    }
                    Console.WriteLine();
                }
                if (position[0] == finish[0] && position[1] == finish[1])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Finished");
                    finished = true;
                }
                Console.ReadLine();
            }
        }
    }
}
