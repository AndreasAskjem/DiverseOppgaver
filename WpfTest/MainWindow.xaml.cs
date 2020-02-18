using System;
using System.Collections.Generic;
using System.Linq;
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
        private double move = 20;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _count++;
            CountLabel.Content = $"Du har trykket {_count} ganger!";
            var value = MovableSquare.GetValue(Canvas.BottomProperty);
            /*
            var i = 0;
            while (i < 100)
            {
                i++;
            }
            */
            Animation(100);
        }

        private void Animation(int fps)
        {
            var i = 0;
            while (i<1)
            {
                MovableSquare.SetValue(Canvas.TopProperty, (double)MovableSquare.GetValue(Canvas.TopProperty) + move);
                if ((double)MovableSquare.GetValue(Canvas.TopProperty) > 300d)
                {
                    move = -20d;
                }
                else if ((double)MovableSquare.GetValue(Canvas.TopProperty) < 20d)
                {
                    move = 20d;
                }



                Thread.Sleep(1000/fps);
                i++;
            }
        }

    }
}