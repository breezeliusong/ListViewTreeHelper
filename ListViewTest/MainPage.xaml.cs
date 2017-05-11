using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ListViewTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            collection = new ObservableCollection<DataModel>();
            collection.Add(new DataModel { Name = "One" });
            collection.Add(new DataModel { Name = "Two" });
            collection.Add(new DataModel { Name = "Three" });
            collection.Add(new DataModel { Name = "Four"});
            this.DataContext = this;
        }
        public ObservableCollection<DataModel> collection { get; set; }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            DisplayVisualTree(MyList, 0);
            Debug.WriteLine(list.Count);
            foreach(var bt in list)
            {
                bt.Background = new SolidColorBrush(Colors.Blue);
            }
        }

        List<Button> list = new List<Button>();
        private void DisplayVisualTree(DependencyObject control, int indent)
        {
            string tab = "";
            for (int i = 1; i <= indent; i++)
                tab += "t";
            

            System.Diagnostics.Debug.WriteLine(string.Format("{0}{1}",
                tab, control.ToString()));

            int childNumber = VisualTreeHelper.GetChildrenCount(control);

            for (int i = 0; i < childNumber; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(control, i);
                if(child is Button)
                {
                    Button BT = (Button )child;
                    list.Add(BT);
                }

                DisplayVisualTree(child, indent + 1);
            }
        }

        private void ChangViewModel(object sender, RoutedEventArgs e)
        {
            var ob = collection[2];
            ob.BackgroundColor = new SolidColorBrush(Colors.Red);
        }

        //private DependencyObject FindChildControl<T>(DependencyObject control, string ctrlName)
        //{
        //    List<T> list = new List<T>();
        //    int childNumber = VisualTreeHelper.GetChildrenCount(control);
        //    for (int i = 0; i < childNumber; i++)
        //    {
        //        DependencyObject child = VisualTreeHelper.GetChild(control, i);
        //        FrameworkElement fe = child as FrameworkElement;
        //        // Not a framework element or is null
        //        if (fe == null) return null;

        //        if (child is T && fe.Name == ctrlName)
        //        {
        //            // Found the control so return
        //            return child;
        //        }
        //        else
        //        {
        //            // Not found it - search children
        //            DependencyObject nextLevel = FindChildControl<T>(child, ctrlName);
        //            if (nextLevel != null)
        //                return nextLevel;
        //        }
        //    }
        //    return null;
        //}
    }

    public  class DataModel:INotifyPropertyChanged
    {
        public string Name { get; set; }

        private Brush _background;

        public event PropertyChangedEventHandler PropertyChanged;

        public Brush BackgroundColor
        {
            get { return _background; }
            set
            {
                _background = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("BackgroundColor"));
                }
            }
        }
    }
}
