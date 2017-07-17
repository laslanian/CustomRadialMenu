using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;
using ViraMenu.Components;

namespace ViraMenu.Utilities
{
    class MenuAnimationFactory
    {
        #region Experimentation Dependency Properties --Unused--

        //private DispatcherTimer timer;

        //private double ToProperty;
        //public double To { get { return (Double)ToProperty; } set { ToProperty = value; } }

        //private double TickIntervalProperty;
        //public double TickInterval { get { return (Double)TickIntervalProperty; } set { TickIntervalProperty = value; } }

        //private Duration BeginTimeProperty;
        //public Duration BeginTime { get { return (Duration)BeginTimeProperty; } set { BeginTimeProperty = value; } }

        //private Duration AnimDurationProperty;
        //public Duration AnimDuration { get { return (Duration)AnimDurationProperty; } set { AnimDurationProperty = value; } }
        
        //public MenuAnimationFactory(double to, Duration beginTime, Duration animDuration)
        //{
        //    timer = new DispatcherTimer
        //    {
        //        Interval = TimeSpan.FromSeconds(TickInterval)
        //    };
        //    timer.Tick += Timer_Tick;
        //}

        #endregion

        #region Properties
        private static bool isMenuOpenProperty;
        public static bool isMenuOpen { get { return (bool)isMenuOpenProperty; } set { isMenuOpenProperty = value; } }

        private  static bool isSubMenuOpenProperty;
        public  bool isSubMenuOpen { get { return (bool)isSubMenuOpenProperty; } set { isSubMenuOpenProperty = value; } }

        
        private  Storyboard _story;
        private static string _storyName;
        
        #endregion

        #region Event Handlers
        public MenuAnimationFactory()
        {

        }

     

        private void Story_Completed(object sender, EventArgs e)
        {
            checkStory();
        }

        #endregion

        #region Methods

        public void startPathAnimation(object sender, DoubleAnimation da)
        {
            Path item = (Path)sender;
            _story.Children.Add(da);
            _story.Begin();
        }

        #endregion

   
        public void Animate(Storyboard st)
        {
            _story = st;
            if (_story != null)
            {
                _storyName = st.Name;
                _story.Completed += Story_Completed;
                _story.Stop();
                _story.Begin();
            }
        }
        //public async void Animate(Storyboard s)
        //{

        //}
        //public async void TheEnclosingMethod()
        //{
        //    tbkLabel.Text = "two seconds delay";

        //    await Task.Delay(2000);
        //    var page = new Page2();
        //    page.Show();
        //}


        private void checkStory()
        {
            if (_storyName.Equals(Utilities.Resources.mOpen))
            {
                isMenuOpen = true;
            }
            else if (_storyName.Equals(Utilities.Resources.mClose))
            {
                isMenuOpen = false;
            }
            else if (_storyName.Equals(Utilities.Resources.sOpen))
            {
                isSubMenuOpen = true;
            }
            else if (_storyName.Equals(Utilities.Resources.sClose))
            {
                isSubMenuOpen = false;
            }

        }
    }//class
}
