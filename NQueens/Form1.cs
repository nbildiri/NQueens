using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LCW_Queens
              
{
    public partial class NQueensMenu : Form
    {

        private static int boardSize;
        private static int[] queenColumns;
        private static Boolean finishGame = false;
      

        public NQueensMenu()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGo_Click(object sender, EventArgs e)
        {

            ChessBoard board = CreateChessBoard();
            board.Refresh();
            board.Show();
            printSolutionOrTryNextPosition(board,0);

        }


        private ChessBoard CreateChessBoard()
        {
            int size = (int)nudNumQueens.Value;
            boardSize = size;
            queenColumns = new int[boardSize];
            finishGame = false;
            return new ChessBoard(size);
        }


        /**
         * *************************************************************************
         * Try all permutations using backtracking
         * *************************************************************************
         */
        private static void printSolutionOrTryNextPosition(ChessBoard board, int thisRow)
        {
            if (!finishGame)
            {
                if (thisRow == boardSize)
                {
                    printSolution(board, queenColumns);
                    board.Refresh();
                    finishGame = true;
                }
                else
                {
                    for (int col = 0; col < boardSize && !finishGame; ++col)
                    {
                        queenColumns[thisRow] = col;
                        if (thereAreNoCaptures(queenColumns, thisRow))
                        {
                            printSolutionOrTryNextPosition(board, thisRow + 1);
                            
                        }
                    }
                }
            }
        }

        /**
         * *************************************************************************
         * Return true if queen placement queens[row] does not conflict with other
         * queens queens[0] through queens[n-1]
         * *************************************************************************
         */
        private static Boolean thereAreNoCaptures(int[] queens, int thisRow)
        {
            Boolean noCaptures = true;
            for (int row = 0; row < thisRow; ++row)
            {
                if (queens[row] == queens[thisRow])
                {
                    noCaptures = false;   // same column
                    break;
                }
                int colGap = queens[thisRow] - queens[row];
                int rowGap = thisRow - row;
                if (colGap == -rowGap) // same major diagonal
                {
                    noCaptures = false;   // capture along major diagonal
                    break;
                }
                if (colGap == rowGap) // same minor diagonal
                {
                    noCaptures = false;   // capture along minor diagonal
                    break;
                }
            }
            return noCaptures;
        }

        /**
         * *************************************************************************
         * Prints n-by-n placement of queens from permutation queens in ASCII.
         * *************************************************************************
         */
        private static void printSolution(ChessBoard board, int[] queens)
        {
            int nrQueens = queens.Length;
            for (int row = 0; row < nrQueens; ++row)
            {
                for (int col = 0; col < nrQueens; ++col)
                {
                    if (queens[row] == col)
                    {
                        board.squares[row, col].Text = "\u2655";
                        board.squares[row,col].Refresh();
                        board.Refresh();

                    }
                }

            }
        } }}





