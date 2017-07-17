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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ViraMenu.Components
{
    /// <summary>
    /// Interaction logic for CenterItem.xaml
    /// </summary>
    public partial class CenterItem : UserControl
    {
        public CenterItem()
        {
            InitializeComponent();
            this.ImgSrc = "pack://application:,,,/ViraMenu;component/Resources/Img/add.word.rotate.png";
        }
       

        #region Dependency Properties

        public static readonly DependencyProperty ImgSrcProperty =
        DependencyProperty.Register("ImgSrc", typeof(string), typeof(CenterItem), new UIPropertyMetadata(String.Empty));
        public string ImgSrc
        {
            get { return (string)GetValue(ImgSrcProperty); }
            set { SetValue(ImgSrcProperty, value); }
        }

        public static readonly DependencyProperty ActionProperty =
       DependencyProperty.Register("Action", typeof(string), typeof(CenterItem), new PropertyMetadata(String.Empty));
        public string Action
        {
            get { return (string)GetValue(ActionProperty); }
            set { SetValue(ActionProperty, value); }
        }

        #endregion

        private void CenterTile_MouseEnter(object sender, MouseEventArgs e)
        {
            Ellipse item = (Ellipse)sender;
            DoubleAnimation da = (DoubleAnimation)FindResource("ItemMouseIn");
            Storyboard story = new Storyboard();
            story.Children.Add(da);
            story.Begin(item);
        }

        private void CenterTile_MouseLeave(object sender, MouseEventArgs e)
        {
            Ellipse item = (Ellipse)sender;
            DoubleAnimation da = (DoubleAnimation)FindResource("ItemMouseOut");
            Storyboard story = new Storyboard();
            story.Children.Add(da);
            story.Begin(item);
        }

    }
}
