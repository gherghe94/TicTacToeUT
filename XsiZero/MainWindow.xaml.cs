using System.Windows;
using System.Windows.Controls;

namespace XsiZero
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isZeroTurn = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (!string.IsNullOrEmpty(button.Content.ToString()))
            {
                return;
            }


            button.Content = _isZeroTurn ? "0" : "X";

            var winner = ValidateWinner();
            if (winner == 0 || winner == 1)
            {
                MessageBox.Show("We have a winner: " + GetNameOfWinner(winner));
                ResetGame();
                return;
            }

            if (winner == 2)
            {
                MessageBox.Show("We have a tie!");
                ResetGame();
                return;
            }

            _isZeroTurn = !_isZeroTurn;
        }

        private string GetNameOfWinner(int who)
        {
            return who == 0 ? "0" : "X";
        }

        /// <summary>
        /// 0 - if 0 wins
        /// 1 - if x wins
        /// 2 - if draw
        /// 3 - if continue
        /// This can be optimized but this is a how-to project.
        /// It is not made as a professional would do.
        /// </summary>
        /// <returns></returns>
        private int ValidateWinner()
        {
            var linia0 = WhoWon(b00, b01, b02);
            if (linia0 != 3)
            {
                return linia0;
            }

            var linia1 = WhoWon(b10, b11, b12);
            if (linia1 != 3)
            {
                return linia1;
            }

            var linia2 = WhoWon(b20, b21, b22);
            if (linia2 != 3)
            {
                return linia2;
            }

            var coloana0 = WhoWon(b00, b10, b20);
            if (coloana0 != 3)
            {
                return coloana0;
            }

            var coloana1 = WhoWon(b01, b11, b21);
            if (coloana1 != 3)
            {
                return coloana1;
            }

            var coloana2 = WhoWon(b02, b12, b22);
            if (coloana2 != 3)
            {
                return coloana2;
            }

            var diagonalaPrincipala = WhoWon(b00, b11, b22);
            if (diagonalaPrincipala != 3)
            {
                return diagonalaPrincipala;
            }

            var diagonalaSecundara = WhoWon(b02, b11, b20);
            if (diagonalaSecundara != 3)
            {
                return diagonalaSecundara;
            }

            return IsDraw() ? 2 : 3;
        }

        private bool IsDraw()
        {
            return
                !string.IsNullOrEmpty(b00.Content.ToString()) &&
                !string.IsNullOrEmpty(b01.Content.ToString()) &&
                !string.IsNullOrEmpty(b02.Content.ToString()) &&
                !string.IsNullOrEmpty(b10.Content.ToString()) &&
                !string.IsNullOrEmpty(b11.Content.ToString()) &&
                !string.IsNullOrEmpty(b12.Content.ToString()) &&
                !string.IsNullOrEmpty(b20.Content.ToString()) &&
                !string.IsNullOrEmpty(b21.Content.ToString()) &&
                !string.IsNullOrEmpty(b22.Content.ToString());
        }

        private int WhoWon(Button b1, Button b2, Button b3)
        {
            if (b1.Content.ToString() == b2.Content.ToString() &&
                b2.Content.ToString() == b3.Content.ToString() &&
                string.IsNullOrEmpty(b1.Content.ToString()) == false)
            {
                return b1.Content.ToString() == "0" ? 0 : 1;
            }

            return 3;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ResetGame();
        }

        private void ResetGame()
        {
            b00.Content = "";
            b01.Content = "";
            b02.Content = "";
            b10.Content = "";
            b11.Content = "";
            b12.Content = "";
            b20.Content = "";
            b21.Content = "";
            b22.Content = "";
        }
    }
}
