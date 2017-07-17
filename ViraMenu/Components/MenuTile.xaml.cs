using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace ViraMenu.Components
{
    /// <summary>
    /// Interaction logic for MenuTile.xaml
    /// </summary>
    public partial class MenuTile : UserControl
    {
        public MenuTile()
        {
            InitializeComponent();
            (Content as FrameworkElement).DataContext = this;
        }

        //protected override GeometryHitTestResult HitTestCore(GeometryHitTestParameters hitTestParameters)
        //{
        //    Console.WriteLine("HitTest gr");
                        
        //    return base.HitTestCore(hitTestParameters);
        //}

        //protected override HitTestResult HitTestCore(PointHitTestParameters hitTestParameters)
        //{
        //    Console.WriteLine("HitTest tr");

        //    return new PointHitTestResult(this, hitTestParameters.HitPoint);
        //    //return base.HitTestCore(hitTestParameters);
        //}

        #region Dependency Properties

        public static readonly DependencyProperty StartPointProperty =
        DependencyProperty.Register("StartPoint", typeof(Point), typeof(MenuTile), new UIPropertyMetadata(new Point(0,0)));
        public Point StartPoint
        {
            get { return (Point)GetValue(StartPointProperty); }
            set { SetValue(StartPointProperty, value); }
        }

        public static readonly DependencyProperty LineOneEndProperty =
        DependencyProperty.Register("LineOneEnd", typeof(Point), typeof(MenuTile), new UIPropertyMetadata(new Point(0, 0)));
        public Point LineOneEnd
        {
            get { return (Point)GetValue(LineOneEndProperty); }
            set { SetValue(LineOneEndProperty, value); }
        }
        public static readonly DependencyProperty LineTwoEndProperty =
        DependencyProperty.Register("LineTwoEnd", typeof(Point), typeof(MenuTile), new UIPropertyMetadata(new Point(0, 0)));
        public Point LineTwoEnd
        {
            get { return (Point)GetValue(LineTwoEndProperty); }
            set { SetValue(LineTwoEndProperty, value); }
        }
        public static readonly DependencyProperty LargeArcEndProperty =
        DependencyProperty.Register("LargeArcEnd", typeof(Point), typeof(MenuTile), new UIPropertyMetadata(new Point(0, 0)));
        public Point LargeArcEnd
        {
            get { return (Point)GetValue(LargeArcEndProperty); }
            set { SetValue(LargeArcEndProperty, value); }
        }

        public static readonly DependencyProperty SmallArcSizeProperty =
       DependencyProperty.Register("SmallArcSize", typeof(Size), typeof(MenuTile), new UIPropertyMetadata(new Size(0, 0)));
        public Size SmallArcSize
        {
            get { return (Size)GetValue(SmallArcSizeProperty); }
            set { SetValue(SmallArcSizeProperty, value); }
        }

        public static readonly DependencyProperty LargeArcSizeProperty =
      DependencyProperty.Register("LargeArcSize", typeof(Size), typeof(MenuTile), new UIPropertyMetadata(new Size(0, 0)));
        public Size LargeArcSize
        {
            get { return (Size)GetValue(LargeArcSizeProperty); }
            set { SetValue(LargeArcSizeProperty, value); }
        }

        public static readonly DependencyProperty ImgSourceProperty =
       DependencyProperty.Register("ImgSource", typeof(string), typeof(MenuTile), new UIPropertyMetadata(String.Empty));
        public string ImgSource
        {
            get { return (string)GetValue(ImgSourceProperty); }
            set { SetValue(ImgSourceProperty, value); }
        }

        public static readonly DependencyProperty ActionProperty =
        DependencyProperty.Register("Action", typeof(string), typeof(MenuTile), new PropertyMetadata(String.Empty));
        public string Action
        {
            get { return (string)GetValue(ActionProperty); }
            set { SetValue(ActionProperty, value); }
        }

        #endregion

        #region EventHandlers

        private void MenuItemPath_MouseEnter(object sender, MouseEventArgs e)
        {
            Path item = (Path)sender;

            DoubleAnimation da = (DoubleAnimation)FindResource("ItemMouseIn");
            Storyboard story = new Storyboard();
            story.Children.Add(da);
            story.Begin(item,true);
        }

        private void MenuItemPath_MouseLeave(object sender, MouseEventArgs e)
        {
            Path item = (Path)sender;
            DoubleAnimation da = (DoubleAnimation)FindResource("ItemMouseOut");
            Storyboard story = new Storyboard();
            story.Children.Add(da);
            story.Begin(item,true);  
        }
        #endregion
        

    }//class
}//ns
