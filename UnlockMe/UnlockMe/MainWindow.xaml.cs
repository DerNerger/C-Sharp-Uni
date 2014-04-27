using System;
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

namespace UnlockMe
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void compute(object sender, RoutedEventArgs e)
        {
            //First Token is the red Token
            Token[] Tokens = new Token[11];
            Tokens[0] = new Token(new Vector(0, 2), Alignment.horizontal, 2, 1);
            Tokens[1] = new Token(new Vector(0, 0), Alignment.vertical, 2, 2);
            Tokens[2] = new Token(new Vector(1, 0), Alignment.horizontal, 3, 3);
            Tokens[3] = new Token(new Vector(5, 0), Alignment.vertical, 3, 4);
            Tokens[4] = new Token(new Vector(2, 1), Alignment.vertical, 3, 5);
            Tokens[5] = new Token(new Vector(3, 1), Alignment.vertical, 2, 6);
            Tokens[6] = new Token(new Vector(1, 4), Alignment.horizontal, 2, 7);
            Tokens[7] = new Token(new Vector(3, 3), Alignment.vertical, 2, 8);
            Tokens[8] = new Token(new Vector(4, 3), Alignment.horizontal, 2, 9);
            Tokens[9] = new Token(new Vector(1, 5), Alignment.horizontal, 3, 10);
            Tokens[10] = new Token(new Vector(4, 4), Alignment.vertical, 2, 11);

            Board board = new Board(Tokens);

            BoardUnlocker bl = new BoardUnlocker();
            String result = bl.unlockBoard(board);
            LabelResult.Content = result;
        }


    }
}
