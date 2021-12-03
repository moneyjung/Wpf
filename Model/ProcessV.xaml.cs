﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace TestPT
{
    /// <summary>
    /// ProcessValue.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ProcessV : UserControl
    {
        public static readonly DependencyProperty ValuesProperty =
                    DependencyProperty.Register("Values", typeof(double), typeof(ProcessV), new PropertyMetadata(50D, new PropertyChangedCallback(OnValueChanged)));

        public static readonly DependencyProperty FactorProperty =
            DependencyProperty.Register("Factor", typeof(double), typeof(ProcessV), new PropertyMetadata(1D));


        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(double), typeof(ProcessV), new PropertyMetadata(0D, new PropertyChangedCallback(OnMinimumChanged)));

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(double), typeof(ProcessV), new PropertyMetadata(100D, new PropertyChangedCallback(OnMaximumChanged)));


        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register("Orientation", typeof(Orientation), typeof(ProcessV), new PropertyMetadata(Orientation.Vertical, new PropertyChangedCallback(OnOrientationChanged)));


        public static readonly DependencyProperty BorderSizeProperty =
            DependencyProperty.Register("BorderSize", typeof(double), typeof(ProcessV), new PropertyMetadata(1D, new PropertyChangedCallback(OnBorderSizeChanged)));


        public static readonly DependencyProperty BorderColorProperty =
            DependencyProperty.Register("BorderColor", typeof(Color), typeof(ProcessV), new PropertyMetadata(Colors.White, new PropertyChangedCallback(OnBorderColorChanged)));


        public static readonly DependencyProperty ProcessColorProperty =
            DependencyProperty.Register("ProcessColor", typeof(Color), typeof(ProcessV), new PropertyMetadata(Colors.OrangeRed));

        public ProcessV()
        {
            InitializeComponent();
        }

        [Category("HMI Professional")]
        [Browsable(true)]
        [DisplayName("Values")]

        public double Values
        {
            get { return (double)GetValue(ValuesProperty); }
            set { SetValue(ValuesProperty, value); }
        }

        [Category("HMI Professional")]
        [Browsable(true)]
        [DisplayName("Factor")]

        public double Factor
        {
            get { return (double)GetValue(FactorProperty); }
            set { SetValue(FactorProperty, value); }
        }

        [Category("HMI Professional")]
        [Browsable(true)]
        [DisplayName("Minimum")]

        public double Minimum
        {
            get { return (double)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        [Category("HMI Professional")]
        [Browsable(true)]
        [DisplayName("Maximum")]

        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        [Category("HMI Professional")]
        [Browsable(true)]
        [DisplayName("Orientation")]

        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        [Category("HMI Professional")]
        [Browsable(true)]
        [DisplayName("BorderSize")]

        public double BorderSize
        {
            get { return (double)GetValue(BorderSizeProperty); }
            set { SetValue(BorderSizeProperty, value); }
        }

        [Category("HMI Professional")]
        [Browsable(true)]
        [DisplayName("BorderColor")]

        [DefaultValue("Gray")]
        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        [Category("HMI Professional")]
        [Browsable(true)]
        [DisplayName("ProcessColor")]
        [DefaultValue("Gray")]

        public Color ProcessColor
        {
            get { return (Color)GetValue(ProcessColorProperty); }
            set { SetValue(ProcessColorProperty, value); }
        }

        private static void OnOrientationChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ProcessV ObjProcessLevel = sender as ProcessV;
            ObjProcessLevel.OnRender(null);
        }

        public static void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ProcessV ObjProcessLevel = sender as ProcessV;
            ObjProcessLevel.OnRender(null);
        }

        public static void OnBorderSizeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ProcessV ObjProcessLevel = sender as ProcessV;
            double value = 0D;
            if (e.NewValue != null)
                value = (double)e.NewValue;
            ObjProcessLevel.BorderThickness = new Thickness(value, value, value, value);
            ObjProcessLevel.OnRender(null);
        }

        public static void OnBorderColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ProcessV ObjProcessLevel = sender as ProcessV;
            Color value = Colors.Gray;
            if (e.NewValue != null)
                value = (Color)e.NewValue;
            ObjProcessLevel.BorderBrush = new SolidColorBrush(value);
            ObjProcessLevel.OnRender(null);
        }

        public static void OnMinimumChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ProcessV ObjProcessLevel = sender as ProcessV;
            ObjProcessLevel.OnRender(null);
        }

        public static void OnMaximumChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ProcessV ObjProcessLevel = sender as ProcessV;
            ObjProcessLevel.OnRender(null);
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            switch (Orientation)
            {
                case Orientation.Horizontal:
                    this.Factor = this.Width / this.Maximum;
                    this.LinearProcessBrush.EndPoint = new Point(0, 0.5);

                    this.ProcessValuep.Width = Values * Factor; // Gia tri.
                    this.ProcessValuep.Height = this.Height;
                    this.ProcessValuep.VerticalAlignment = VerticalAlignment.Center;
                    this.ProcessValuep.HorizontalAlignment = HorizontalAlignment.Left;
                    break;
                case Orientation.Vertical:
                    this.Factor = this.Height / this.Maximum;
                    this.LinearProcessBrush.EndPoint = new Point(0.5, 0);

                    this.ProcessValuep.Height = Values * Factor; // Gia tri.
                    this.ProcessValuep.Width = this.Width;
                    this.ProcessValuep.VerticalAlignment = VerticalAlignment.Bottom;
                    this.ProcessValuep.HorizontalAlignment = HorizontalAlignment.Center;
                    break;
            }
        }
    }
}
