using AirtableWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateRecordContentPage : ContentPage
    {
        public CreateRecordContentPage()
        {
            InitializeComponent();

            var chores = StandingsCalculator.Chores;
            var intensity = new List<string> { "Half", "Full" };
            var participants = StandingsCalculator.Participants;

            var participantPicker = new Picker
            {
                Title = "Participant",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            participantPicker.ItemsSource = participants;

            var chorePicker = new Picker
            {
                Title = "Chore completed",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            chorePicker.ItemsSource = chores;

            var intensityPicker = new Picker
            {
                Title = "Intensity",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            intensityPicker.ItemsSource = intensity;

            Button button = new Button
            {
                Text = "Click to Rotate Text!",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };

            button.Clicked += (sender, args) => AirtableHandler.SendRecord(new AirtableWeb.Models.RecordFields
            {
                Chore = new List<string>
                {
                    StandingsCalculator.GetChoreIdentifierByName(chorePicker.Items[chorePicker.SelectedIndex])
                },
                Participant = participantPicker.Items[participantPicker.SelectedIndex],
                Points = EstimatePoints(intensityPicker.Items[intensityPicker.SelectedIndex])
            }
            );
        }

        public double EstimatePoints(string intensity)
        {
            switch(intensity)
            {
                case "Half":
                    return 0.5;
                case "Full":
                    return 1;
                default:
                    return 0;
            }
        }
    }
}