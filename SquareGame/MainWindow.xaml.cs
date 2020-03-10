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

namespace SquareGame
{
    public partial class MainWindow : Window
    {

        private System.Windows.Threading.DispatcherTimer gameTickTimer = new System.Windows.Threading.DispatcherTimer();
        public Player Player;

        public MainWindow()
        {
            InitializeComponent();
            gameTickTimer.Tick += GameTickTimer_Tick;
            Player.Pos {
                var x = PlayerRectangle.GetValue(Canvas.BottomProperty);
            };
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            DrawGameArea();

        }

        private void DrawGameArea()
        {
            throw new NotImplementedException();
        }

        private void GameTickTimer_Tick(object sender, EventArgs e)
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            if (Player.PositionX < 0)
            {
                PlayerRectangle.Margin.Bottom = 0;
            }
        }
    }
}
