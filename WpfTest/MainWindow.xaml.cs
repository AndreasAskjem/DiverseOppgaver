using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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

namespace WpfTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _count = 0;
        private double move = 5;
        private int direction = 1;
        private int numberOfMoves { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            numberOfMoves = 5;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            _count++;
            CountLabel.Content = $"You have clicked {_count} times!";

            await Animation(100);
        }

        public async Task Animation(int fps)
        {
            int repetitions;
            try
            {
                repetitions = int.Parse(Input.Text);
            }
            catch
            {
                Input.Text = "";
                return;
            }
            var i = 0;
            while (i<repetitions)
            {

                MovableSquare.SetValue(Canvas.BottomProperty, (double)MovableSquare.GetValue(Canvas.BottomProperty) + move*direction);

                MoveSquare();

                await Task.Delay(1000 / fps);
                i++;
            }
        }

        public void MoveSquare()
        {
            if ((double)MovableSquare.GetValue(Canvas.BottomProperty) >= 314d ||
                (double)MovableSquare.GetValue(Canvas.BottomProperty) + move < 1d)
            {
                direction = -direction;
            }
        }
    }
}