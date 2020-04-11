using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BoardSharp.Chess;

namespace BoardSharp 
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ChessBoard myChessBoard = new ChessBoard();
            myChessBoard.ResetBoard();
            myChessBoard.InitBoardGui(this);

            Trace.WriteLine(myChessBoard);
        }
    }
}
