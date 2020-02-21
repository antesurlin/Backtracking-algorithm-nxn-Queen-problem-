using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backtracking
{
    class Program
    {
        static int N;
        static void print(int[,] board) 
        {
            for(int i = 0; i < N; i++)
            {
                for(int j = 0; j < N; j++)
                {
                    Console.Write(board[i, j] + " "); 
                }
                Console.Write("\n");
            }
        }
        static Boolean setUp(int[,] board, int row, int column) 
        {
            int i, j;
            for(i = 0; i < column; i++)
            {
                if (board[row, i] == 1)
                    return false;
            }
            for(i = row, j = column; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == 1)
                    return false;
            }
            for (i = row, j = column; j >= 0 && i < N; i++, j--)
            {
                if (board[i, j] == 1)
                    return false;
            }
            return true;
        }
        static Boolean solution(int[,] board, int column) 
        {
            if (column >= N)
                return true;
            for(int i = 0; i < N; i++)
            {
                if(setUp(board, i, column))
                {
                    board[i, column] = 1;
                    if(solution(board, column + 1))
                        return true;
                    board[i, column] = 0;
                    
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("What board dimension would you like to try out (nxn):");            
            try
            {
                N = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Wrong board dimension entry!");
                Console.ReadLine();
            }
            int[,] ploca = new int[N, N];
            if (!solution(ploca, 0))
                Console.WriteLine("Solution not found!");
            print(ploca);
            Console.WriteLine("Number 1 acts like a queen on the board while number 0 represents empty spot.");
            Console.ReadLine();
            

        }
    }
}
