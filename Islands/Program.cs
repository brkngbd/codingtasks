using System;

/*
Islands:
Given a two dimensional array of 1’s and 0’s, find the number of contiguous 1’s.  For example, imagine we are given this array:
 
{0, 0, 0, 1
 0, 0, 0, 1
 1, 0, 0, 0
 1, 1, 0, 0}
The method would output 2, because it would count the island in the upper right and the bottom left.  Similarly,
 
{1, 1
 1, 1} 
 
Would output 1, because it is all one island.
 
An input like 
{0, 0, 0
0, 0, 0
0, 0, 0} would output 0, because there are no islands.
 
{1, 0,
0, 1}

 */

namespace Islands
{
    class Program
    {
        static void Main(string[] args)
        {
            var sea = new[,]
            {
                { 0, 0, 0, 1 },
                { 0, 0, 0, 1 },
                { 1, 0, 0, 0 },
                { 1, 1, 0, 0 }
            };

            //var sea = new[,]
            //{
            //    { 1, 1},
            //    { 1, 1}
            //};

            //var sea = new[,]
            //{
            //    { 0, 0, 0, 0 },
            //    { 0, 0, 0, 0 },
            //    { 0, 0, 0, 0 },
            //    { 0, 0, 0, 0 }
            //};

            //var sea = new[,]
            //{
            //    { 1, 0},
            //    { 0, 1}
            //};

            printSea(sea);

            var islandCount = MarkIslands(sea);

            printSea(sea);

            Console.WriteLine($"Island count : {islandCount}");
        }

        static int MarkIslands(int[,] sea)
        {
            var islands = 0;
            for (var x = 0; x < sea.GetLength(0); x++)
            {
                for (var y = 0; y < sea.GetLength(0); y++)
                {
                    if (sea[x, y] == 1)
                    {
                        JoinIslandParts(sea, x, y);
                        islands++;
                    }
                }
            }
            return islands;
        }

        static void JoinIslandParts(int[,] sea, int xStart, int yStart)
        {
            var deltas = new (int x, int y)[]
                {
                    ( -1, 0  ), // left
                    (  0, -1 ), // up
                    (  1, 0  ), // rigth
                    (  0, 1  ), // down
                };

                foreach (var delta in deltas)
                {
                    var newX = xStart + delta.x;
                    var newY = yStart + delta.y;

                    if ( newX >= 0 &&
                         newX < sea.GetLength(0) &&
                         newY >= 0 &&
                         newY < sea.GetLength(1))
                    {
                        if(sea[newX, newY]==1)
                        {
                            sea[newX, newY] = -1;
                            JoinIslandParts(sea, newX, newY);
                        }
                    }
                }
        }

        static void printSea(int[,] sea)
        {
            Console.WriteLine();
            for (var x = 0; x < sea.GetLength(0); x++)
            {
                Console.WriteLine();
                for (var y = 0; y < sea.GetLength(0); y++)
                {
                    Console.Write($"\t{sea[x, y]}");
                }
            }
            Console.WriteLine();
        }
    }
}
