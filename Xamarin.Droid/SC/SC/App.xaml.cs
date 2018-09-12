using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SC
{
    public class DataObject
    {
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
    }

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //List<DataObject> myObjects = new List<DataObject>()
            //        {
            //            new DataObject(){Value1 = "Value 1", Value2 = "value2", Value3 = "Value 3"},
            //            new DataObject(){Value1 = "Value 1", Value2 = "value2", Value3 = "Value 3"},
            //            new DataObject(){Value1 = "Value 1", Value2 = "value2", Value3 = "Value 3"},
            //            new DataObject(){Value1 = "Value 1", Value2 = "value2", Value3 = "Value 3"},
            //            new DataObject(){Value1 = "Value 1", Value2 = "value2", Value3 = "Value 3"},
            //            new DataObject(){Value1 = "Value 1", Value2 = "value2", Value3 = "Value 3"},
            //            new DataObject(){Value1 = "Value 1", Value2 = "value2", Value3 = "Value 3"},
            //            new DataObject(){Value1 = "Value 1", Value2 = "value2", Value3 = "Value 3"}
            //        };

            //ContentPage p = new ContentPage();
            //StackLayout s = new StackLayout();
            //Grid outG = new Grid();
            //ScrollView sc = new ScrollView();
            //Grid innerG = new Grid();

            ////create the columns for the header
            //outG.ColumnDefinitions = new ColumnDefinitionCollection()
            //        {
            //            new ColumnDefinition(){Width = GridLength.Auto},
            //            new ColumnDefinition(){Width = GridLength.Auto},
            //            new ColumnDefinition(){Width = GridLength.Auto},
            //        };
            //outG.Children.Add(new Label() { Text = "Title 1" }, 0, 0);
            //outG.Children.Add(new Label() { Text = "Title 2" }, 1, 0);
            //outG.Children.Add(new Label() { Text = "Title 3" }, 2, 0);

            ////create you columns for the rows
            //innerG.ColumnDefinitions = new ColumnDefinitionCollection()
            //        {
            //            new ColumnDefinition(){Width = GridLength.Auto},
            //            new ColumnDefinition(){Width = GridLength.Auto},
            //            new ColumnDefinition(){Width = GridLength.Auto},
            //        };

            //innerG.RowDefinitions = new RowDefinitionCollection();
            ////create a new row for each object in datacollection
            //for (int i = 0; i < myObjects.Count; i++)
            //{
            //    innerG.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            //    innerG.Children.Add(new Label() { Text = myObjects[i].Value1 }, 0, i);
            //    innerG.Children.Add(new Label() { Text = myObjects[i].Value2 }, 1, i);
            //    innerG.Children.Add(new Label() { Text = myObjects[i].Value3 }, 2, i);
            //}

            //sc.Content = innerG; //content in scrollview
            //s.Children.Add(outG); //header grid view in stackLayout
            //s.Children.Add(sc); // scrollview in stackLayout
            //p.Content = s; //page content = stacklayout

            MainPage = new StandingsTabbedPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
