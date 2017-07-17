using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using ViraMenu.Utilities;

namespace ViraMenu.Components
{
    /// <summary>
    /// Interaction logic for MenuItem.xaml
    /// </summary>
    public partial class MenuItem : UserControl
    {
   //protected override GeometryHitTestResult HitTestCore(GeometryHitTestParameters hitTestParameters)
        //{
        //    Console.WriteLine("HitTest mi ght");
        //    return base.HitTestCore(hitTestParameters);
        //}

        //protected override HitTestResult HitTestCore(PointHitTestParameters hitTestParameters)
        //{
        //    Console.WriteLine("HitTest mi ht");

        //    return new PointHitTestResult(this, hitTestParameters.HitPoint);
        //    //return base.HitTestCore(hitTestParameters);
        //}

        #region Dependency Properties 
        public static readonly DependencyProperty ImgSourceProp =
        DependencyProperty.Register("MainImgSource", typeof(string), typeof(MenuItem), new UIPropertyMetadata(String.Empty));
        public string MainImgSource
        {
            get { return (string)GetValue(ImgSourceProp); }
            set { SetValue(ImgSourceProp, value); }
        }
        #endregion

        #region Variables 

        private DispatcherTimer timer;
      
        private double timerInterval = 3.0;
        private MenuAnimationFactory animationFactory;

       
        #endregion

        #region Event Handlers

        public MenuItem()
        {
            InitializeComponent();

        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            animationFactory = new MenuAnimationFactory();
            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(timerInterval)
            };
            timer.Tick += Timer_Tick;
        }




        private void Timer_Tick(object sender, EventArgs e)
        {
            if (animationFactory.isSubMenuOpen)
            {
                animationFactory.Animate((Storyboard)this.FindResource(Utilities.Resources.SubClose));
            }
            else
            {
                timer.Start();
            }
        }

        private void MainTile_MouseEnter(object sender, MouseEventArgs e)
        {
            
            if (MenuAnimationFactory.isMenuOpen)
            {
                Storyboard story = (Storyboard)this.FindResource(Utilities.Resources.SubOpen);

                animationFactory.isSubMenuOpen = true;
                animationFactory.Animate(story);
                timer.IsEnabled = false;
            }
        }
        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            timer.Start();
        }

        #endregion
    

    }//class
}//ns
