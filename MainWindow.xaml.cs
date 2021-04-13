using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Cells;
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
using Syncfusion.UI.Xaml.Grid.Helpers;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using Syncfusion.Data;
using Syncfusion.UI.Xaml.Utility;
using System.ComponentModel;

namespace SfMultiColumnDropDownDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MultiColumnControl.Loaded += MultiColumnControl_Loaded;
        }

        void MultiColumnControl_Loaded(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)GridUtil.FindDescendantChildByType(MultiColumnControl, typeof(TextBox));
            textBox.PreviewMouseLeftButtonUp += TextBox_PreviewMouseLeftButtonUp;
            textBox.LostFocus += TextBox_LostFocus;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            //Enable the boolean property after lost focus of SfMultiColumnDropDownControl 
            mouseClickSelection = true;
        }

        //declare the bollean property 
        bool mouseClickSelection = true;

        private async void TextBox_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TextBox tb = sender as TextBox;
            //Check the condition when selection apply or not 
            if (mouseClickSelection)
            {
                await Application.Current.Dispatcher.InvokeAsync(tb.SelectAll);
                //disable the boolean porperty to selection apply only first time in SfMultiColumnDropDownControl via mouse click 
                mouseClickSelection = false;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            TextBox textBox = (TextBox)GridUtil.FindDescendantChildByType(MultiColumnControl, typeof(TextBox));
            textBox.PreviewMouseLeftButtonUp -= TextBox_PreviewMouseLeftButtonUp;
            this.MultiColumnControl.Loaded -= MultiColumnControl_Loaded;
        }
    }
}
         
   

