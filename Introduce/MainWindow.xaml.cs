using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Introduce
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Rg1.Rect = new Rect(new Point(0, 0), new Size(SystemParameters.PrimaryScreenWidth, SystemParameters.PrimaryScreenHeight));
            Canvas1.Visibility = Visibility.Collapsed;
        }

        public Point Point { get; set; }

        private void ShowTop(object sender, RoutedEventArgs e)
        {
            ShowOrHidden();
            var res = PositionHandler.Draw(Grid,typeof(Button), "Button", 50, 0, -50, -50,PositionDirectionEnum.Top);
            Tb.Width = 250;
            Tb.SetValue(Canvas.LeftProperty, res.Xy[0]);
            Tb.SetValue(Canvas.TopProperty, res.Xy[1]);
            Pg.Data = res.PathGeometry;
            Rg2.Rect = res.Rect;
        }
        private void ShowLeft(object sender, RoutedEventArgs e)
        {
            ShowOrHidden();
            var res = PositionHandler.Draw(Grid, typeof(Button), "Button", 0, 50, -50, -50,PositionDirectionEnum.Left);
            Tb.Width = 20;
            Tb.SetValue(Canvas.LeftProperty, res.Xy[0]);
            Tb.SetValue(Canvas.TopProperty, res.Xy[1]);
            Pg.Data = res.PathGeometry;
            Rg2.Rect = res.Rect;
        }
        private void ShowRight(object sender, RoutedEventArgs e)
        {
            ShowOrHidden();
            var res = PositionHandler.Draw(Grid, typeof(Button), "Button", 0, 50, 0, -50, PositionDirectionEnum.Right);
            Tb.Width = 20;
            Tb.SetValue(Canvas.LeftProperty, res.Xy[0]);
            Tb.SetValue(Canvas.TopProperty, res.Xy[1]);
            Pg.Data = res.PathGeometry;
            Rg2.Rect = res.Rect;
        }
        private void ShowBottom(object sender, RoutedEventArgs e)
        {
            ShowOrHidden();
            var res = PositionHandler.Draw(Grid, typeof(Button), "Button", 50, 0, -50, 50, PositionDirectionEnum.Bottom);
            Tb.Width = 250;
            Tb.SetValue(Canvas.LeftProperty, res.Xy[0]);
            Tb.SetValue(Canvas.TopProperty, res.Xy[1]);
            Pg.Data = res.PathGeometry;
            Rg2.Rect = res.Rect;
        }
        private void Hidden(object sender, MouseButtonEventArgs e)
        {
            ShowOrHidden();
        }

        private void ShowOrHidden()
        {
            Canvas1.Visibility = Canvas1.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }


    }
}
