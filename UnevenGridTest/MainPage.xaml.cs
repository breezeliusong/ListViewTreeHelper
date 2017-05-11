using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UnevenGridTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            list.Add(new DataModel() { Name = "long text" });
            list.Add(new DataModel() { Name = "Two"});
            list.Add(new DataModel() { Name = "Three hello my world Three hello my world Three hello my world Three hello my world Three hello my world Three hello my world Three hello my world" });
            list.Add(new DataModel() { Name = "Four"});
            list.Add(new DataModel() { Name = "Five"});
            list.Add(new DataModel() { Name = "Six"});

            

            MyGridView.DataContext = list;
        }

        ObservableCollection<DataModel> list = new ObservableCollection<DataModel>();

        private void ButtonFrom_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TakeNext_Loading(FrameworkElement sender, object args)
        {

        }
    }

    public class DataModel
    {
        public string Name { get; set; }
        public string TakeNext { get; set; }
    }

}
