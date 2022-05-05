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
    public partial class ChessBoard : Form
    {
        public Label[,] squares { get; set; }
        readonly int SQUARE_SIZE = 50;


        public ChessBoard(int rowSize)
        {
            InitializeComponent();
            InitializeBoard(rowSize);
     
        }

        private void ChessBoard_Load(object sender, EventArgs e)
        {

        }

        internal void InitializeBoard(int rowSize) 
        {
            Size = new Size(SQUARE_SIZE * rowSize + 100, SQUARE_SIZE * rowSize + 100);
            squares = new Label[rowSize, rowSize];
            for (int row = 0; row < rowSize; row++)
            {
                for (int col = 0; col < rowSize; col++)
                {
                    Label square = CreateSquare(row, col, rowSize);
                    
                    squares[row, col] = square;
                    pnlSquares.Controls.Add(square);
                }
            }
        }

        internal Label CreateSquare(int row, int col, int rowSize)
        {
            Label square = new Label();
            square.Font = new Font("Calibri", SQUARE_SIZE / 2);
            square.TextAlign = ContentAlignment.MiddleCenter;
            square.Height = square.Width = SQUARE_SIZE;
            square.Location = new Point(col * SQUARE_SIZE, row * SQUARE_SIZE);

            Color light = Color.LightBlue;
            Color _dark = Color.DarkBlue;


            if (rowSize % 2 == 0)
            {
                square.BackColor = (row + col) % 2 == 0
                    ? light
                    : _dark;
            }
            else 
            {
                square.BackColor = (row + col) % 2 != 0
                   ? light
                   : _dark;
            }

            return square;
        }
       
    }
}
