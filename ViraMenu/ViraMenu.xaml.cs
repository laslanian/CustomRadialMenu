using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using ViraMenu.Utilities;
using ViraMenu.Components;

namespace ViraMenu
{
    /// <summary>
    /// Interaction logic for PieMenu.xaml
    /// </summary>
    public partial class PieMenu : Window
    {
        #region Init
        public PieMenu()
        {
            InitializeComponent();
            animationFactory = new MenuAnimationFactory();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(timerInterval)
            };

            timer.Tick += Timer_Tick;
            initItems();           
        }

        #endregion

        #region Variables

        private DispatcherTimer timer;
        private double timerInterval = 10.0;
        private MenuAnimationFactory animationFactory;

        private string _viraState ="off";

        #endregion


        #region Events

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (MenuAnimationFactory.isMenuOpen)
            {
                if (!animationFactory.isSubMenuOpen)
                {
                    MenuAnimationFactory.isMenuOpen = false; 
                    animationFactory.Animate((Storyboard)this.FindResource(Utilities.Resources.MenuClose));
                }
            }
            else
            {
                timer.Start();
            }
        }
        private void Element_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!MenuAnimationFactory.isMenuOpen)
            {
                Storyboard story = (Storyboard)this.FindResource(Utilities.Resources.MenuOpen);

                animationFactory.Animate(story);
                timer.IsEnabled = false;

            }
        }
        private void M_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Vira Menu " + ((MenuTile)sender).Action);
        }
        private void CenterTile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            changeViraState(_viraState.Equals("on") ? "off" : "on");
        }

        private void Element_MouseLeave(object sender, MouseEventArgs e)
        {
            timer.Start();
        }

        #endregion 

        #region Methods

        private void initItems()
        {
            changeViraState(_viraState);

            #region Settings Tile Properties

            Settings.MainTile.Action = "Settings";
            Settings.SubItem.Action = "ManageMic";
            Settings.SubItem.ToolTip = "Manage microphone";
            Settings.SubItem2.Action = "CalibrateAudio";
            Settings.SubItem2.ToolTip = "Calibrate audio";
           

            Settings.MainImgSource = "pack://application:,,,/ViraMenu;component/Resources/Img/settings.rotate.png";
            Settings.SubItem.imageBrush.ImageSource = new BitmapImage(
                new Uri("pack://application:,,,/ViraMenu;component/Resources/Img/manage.microphone.rotate.png"));
            Settings.SubItem2.imageBrush.ImageSource = new BitmapImage(
                new Uri("pack://application:,,,/ViraMenu;component/Resources/Img/audio.calibration.rotate.png"));
            Settings.SubItem1.Visibility = Visibility.Collapsed;

            #endregion

            #region Commands Tile Properties

            Commands.MainTile.Action = "Commands";
            Commands.SubItem.Action = "AddCommand";
            Commands.SubItem2.Action = "CommandGuide";
            Commands.SubItem.ToolTip ="Add command";
            Commands.SubItem2.ToolTip = "Command guide";

            Commands.MainImgSource = "pack://application:,,,/ViraMenu;component/Resources/Img/commands.rotate.png";
            Commands.SubItem.imageBrush.ImageSource = new BitmapImage(
                new Uri("pack://application:,,,/ViraMenu;component/Resources/Img/add.cmd.rotate.png"));  
            Commands.SubItem2.imageBrush.ImageSource = new BitmapImage(
                new Uri("pack://application:,,,/ViraMenu;component/Resources/Img/command.guide.rotate.png"));
            Commands.SubItem1.Visibility = Visibility.Collapsed;

            #endregion

            #region Accuracy Tile Properties

            Accuracy.MainTile.Action = "Accuracy";

            Accuracy.SubItem.Action = "Import";
            Accuracy.SubItem1.Action = "Export";
            Accuracy.SubItem2.Action = "TrainWord";
            Accuracy.SubItem.ToolTip = "Import vocabulary";
            Accuracy.SubItem1.ToolTip = "Export vocabulary";
            Accuracy.SubItem2.ToolTip ="Train word";

            Accuracy.MainImgSource = "pack://application:,,,/ViraMenu;component/Resources/Img/accuracy.rotate.png";
            Accuracy.SubItem.imageBrush.ImageSource = new BitmapImage(
                new Uri("pack://application:,,,/ViraMenu;component/Resources/Img/import.rotate.png"));
            Accuracy.SubItem1.imageBrush.ImageSource = new BitmapImage(
                new Uri("pack://application:,,,/ViraMenu;component/Resources/Img/export.rotate.png"));
            Accuracy.SubItem2.imageBrush.ImageSource = new BitmapImage(
                new Uri("pack://application:,,,/ViraMenu;component/Resources/Img/train.word.rotate.png"));

            #endregion

            #region AddWord Tile Properties

            AddWord.MainTile.Action = "AddWord";
            AddWord.MainTile.ToolTip = "Add word";
            
            AddWord.MainImgSource = "pack://application:,,,/ViraMenu;component/Resources/Img/add.word.rotate.png";

            AddWord.MainTile.imageBrush.AlignmentX = AlignmentX.Center;
            AddWord.SubItem.Visibility = Visibility.Collapsed;
            AddWord.SubItem1.Visibility = Visibility.Collapsed;
            AddWord.SubItem2.Visibility = Visibility.Collapsed;

            #endregion

            AddWord.MainTile.MouseDown += M_MouseDown;
            CMI.MouseDown += CenterTile_MouseDown;

            foreach (object o in ViraMenuGrid.Children)
            {
                if (o is MenuItem)
                {
                    MenuItem m = (MenuItem)o;
                    setButtonClickHandlers(m);
                }
            }
        }
        private void setButtonClickHandlers(MenuItem mi)
        {
            System.Windows.Controls.Grid g = (System.Windows.Controls.Grid)mi.Content;
            foreach (MenuTile m in g.Children)
            {
                if(!m.Name.Equals("MainTile"))
                m.MouseDown += M_MouseDown;
            }
        }

        #endregion

     
        public void changeViraState(String state)
        {
            _viraState = state != null ?state: "off";
            CMI.ImgSrc = 
                (_viraState.ToLower().Equals("on")) ?
                  "pack://application:,,,/ViraMenu;component/Resources/Img/microphone.normal.state.png" 
                : "pack://application:,,,/ViraMenu;component/Resources/Img/microphone.sleeping.state.png";
        }
    }//class
}//ns
