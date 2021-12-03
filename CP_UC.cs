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
using System.Windows.Media.Animation;

namespace TestPT
{
    /// <summary>
    /// CP_UCxaml.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CP_UC : UserControl
    {
        // Using a DependencyProperty as the backing store for Percentage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PercentageProperty =
            DependencyProperty.Register("Percentage", typeof(double), typeof(CP_UC), new PropertyMetadata(65d, new PropertyChangedCallback(OnPercentageChanged)));

        // Using a DependencyProperty as the backing store for StrokeThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register("StrokeThickness", typeof(int), typeof(CP_UC), new PropertyMetadata(5, new PropertyChangedCallback(OnThicknessChanged)));

        //// Using a DependencyProperty as the backing store for SegmentColor.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty SegmentColorProperty =
        //    DependencyProperty.Register("SegmentColor", typeof(Brush), typeof(CP_UC), new PropertyMetadata(new SolidColorBrush(Colors.Red), new PropertyChangedCallback(OnColorChanged)));

        // Using a DependencyProperty as the backing store for Radius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RadiusProperty =
            DependencyProperty.Register("Radius", typeof(int), typeof(CP_UC), new PropertyMetadata(25, new PropertyChangedCallback(OnPropertyChanged)));

        // Using a DependencyProperty as the backing store for Angle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register("Angle", typeof(double), typeof(CP_UC), new PropertyMetadata(120d, new PropertyChangedCallback(OnPropertyChanged)));

        public CP_UC()
        {
            InitializeComponent();
            //Angle = (Percentage * 360) / 100;
            //RenderArc();
        }

        public void Storyboard_Completed(object sender, EventArgs e)
        {
            //if (Application.Current.MainWindow is MainWindow mainwindow)
            //{
            //    mainwindow.Start_Btn.IsChecked = false;
            //}
        }

        public int Radius
        {
            get { return (int)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }

        public int StrokeThickness
        {
            get { return (int)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        public double Percentage
        {
            get { return (double)GetValue(PercentageProperty); }
            set { SetValue(PercentageProperty, value); }
        }

        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }


        private static void OnThicknessChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            CP_UC circle = sender as CP_UC;
            circle.Set_tick((int)args.NewValue);
        }

        private static void OnPercentageChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            CP_UC circle = sender as CP_UC;
            if (circle.Percentage > 100) circle.Percentage = 100;
            circle.Angle = (circle.Percentage * 360) / 100;
        }

        private static void OnPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            CP_UC circle = sender as CP_UC;
            circle.RenderArc();
        }

        public void Set_tick(int n)
        {
            ProgressPath.StrokeThickness = n;
        }

        public void RenderArc()
        {
            Point startPoint = new Point(Radius, 0);
            Point endPoint = ComputeCartesianCoordinate(Angle, Radius);
            endPoint.X += Radius;
            endPoint.Y += Radius;

            ProgressPath.Width = (Radius * 2) + StrokeThickness;
            ProgressPath.Height = (Radius * 2) + StrokeThickness;
            ProgressPath.Margin = new Thickness(StrokeThickness, StrokeThickness, 0, 0);

            bool largeArc = Angle > 180.0;

            Size outerArcSize = new Size(Radius, Radius);

            pathFigure.StartPoint = startPoint;

            if (startPoint.X == Math.Round(endPoint.X) && startPoint.Y == Math.Round(endPoint.Y))
                endPoint.X -= 0.01;

            arc.Point = endPoint;
            arc.Size = outerArcSize;
            arc.IsLargeArc = largeArc;
        }

        private Point ComputeCartesianCoordinate(double angle, double radius)
        {
            // convert to radians
            double angleRad = (Math.PI / 180.0) * (angle - 90);

            double x = radius * Math.Cos(angleRad);
            double y = radius * Math.Sin(angleRad);

            return new Point(x, y);
        }
    }
}
