//Bonga Maswanganye
using System;
namespace NqueenHillClimbing
{
    class Program
    {
        private static Random r = new Random();
        private static int heuristic = 0;
        private static int numberofboardsmade = 0;
        static void Main(string[] args)
        {
            int CurrentH;
            int n;
            Console.WriteLine("enter interger ammount for n (where n is number of queens): ");
            n = Convert.ToInt32(Console.ReadLine());
            if (n <= 3)
            {
                Console.WriteLine("NQueen not possible with 3 or less pieces, restart program and try different N");
                Console.ReadLine();
            }
            else
            {
                //start
                Console.WriteLine("Starting Board");
                numberofboardsmade++;
                NQueen[] CurrentBoard = CreateBoard(n);
                BoardPrint(CurrentBoard,n);
                Console.WriteLine("--------------"+numberofboardsmade+"-------------------------");
                CurrentH = findHeuristic(CurrentBoard);
                while (CurrentH != 0)
                {
                    CurrentBoard = nextBoard(CurrentBoard,n);
                    CurrentH = heuristic;
                    numberofboardsmade++;
                    BoardPrint(CurrentBoard, n);
                    Console.WriteLine("----------------Step number: " + numberofboardsmade + "-------------------------");
                }
                //finish
                BoardPrint(CurrentBoard,n);
                Console.WriteLine("Done!");
            }
           
        }

        public static NQueen[] CreateBoard(int n)
        {
            NQueen[] Board = new NQueen[n];
            for (int i = 0; i<n;i++)
            {
                Board[i] = new NQueen(r.Next(n),i);
            }
            return Board;
        }

        private static void BoardPrint(NQueen[] State, int n)
        {
            int[,] printBoard = new int[n,n];
            for (int i = 0; i < n; i++)
            {
                printBoard[State[i].GetRow(), State[i].GetColumn()] = 1;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(printBoard[i,j] + " ");
                }
                Console.WriteLine(" ");
            }
        }

        public static int findHeuristic(NQueen[] state)
        {
            //check each queen for possible conflicts, increase heuristic by 1 for each conflict
            int heuristic = 0;
            for (int i = 0; i < state.Length; i++)
            {
                for (int j = i + 1; j < state.Length; j++)
                {
                    if (state[i].BoardCheck(state[j]))
                    {
                        heuristic++;
                    }
                }
            }
            return heuristic;
        }

        public static NQueen[] nextBoard(NQueen[] presentBoard, int n)
        {
            NQueen[] nextBoard = new NQueen[n];
            NQueen[] tmpBoard = new NQueen[n];
            int presentHeuristic = findHeuristic(presentBoard);
            int bestHeuristic = presentHeuristic;
            int tempH;

            for (int i = 0; i < n; i++)
            {
                //  Copy present board as best board and temp board
                nextBoard[i] = new NQueen(presentBoard[i].GetRow(), presentBoard[i].GetColumn());
                tmpBoard[i] = nextBoard[i];
            }
            //  Check each column
            for (int i = 0; i < n; i++)
            {
                if (i > 0)
                    tmpBoard[i - 1] = new NQueen(presentBoard[i - 1].GetRow(), presentBoard[i - 1].GetColumn());
                tmpBoard[i] = new NQueen(0, tmpBoard[i].GetColumn());
                //  Check each row
                for (int j = 0; j < n; j++)
                {
                    //Find the heuristic
                    tempH = findHeuristic(tmpBoard);
                    //Check which board is better
                    //if tempboard is better
                    if (tempH < bestHeuristic)
                    { 
                        //  Copy the temp board as best board
                        bestHeuristic = tempH;
                        for (int k = 0; k < n; k++)
                        {
                            nextBoard[k] = new NQueen(tmpBoard[k].GetRow(), tmpBoard[k].GetColumn());
                        }
                    }
                    //Move the queen
                    if (tmpBoard[i].GetRow() != n - 1)
                        tmpBoard[i].MoveRow();
                }
            }
            //Check whether the present bord and the best board found have same heuristic

            if (bestHeuristic == presentHeuristic)
            {
                //if they do, make a random new board to avoid maxima
                nextBoard = CreateBoard(n); 
                heuristic = findHeuristic(nextBoard);
            }
            else
            {
                heuristic = bestHeuristic;
            }

            return nextBoard;
        }


    }
}
