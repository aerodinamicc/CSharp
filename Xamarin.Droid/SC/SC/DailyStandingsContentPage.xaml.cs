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
	public partial class DailyStandingsContentPage : ContentPage
	{
		public DailyStandingsContentPage ()
		{
            InitializeComponent();

            StandingsCalculator.CalculateResults(true);
            var resultsByCategory = StandingsCalculator.ResultsByCategory;

            var grid = new Grid();

            var participants = resultsByCategory.Keys.ToList();
            //filling up the first row
            for (int i = 1; i < participants.Count; i++)
            {
                grid.Children.Add(new Label { Text = participants[i] }, 0, i);
            }

            //filling up the first column
            var randomParticipant = participants.First();
            for (int row = 1; row < resultsByCategory[randomParticipant].Count; row++)
            {
                grid.Children.Add(new Label { Text = resultsByCategory[randomParticipant][row].Key }, row, 0);
            }

            //filling up the participants columns
            var columnsCount = participants.Count + 1;

            foreach (var participant in participants)
            {
                for (int col = 1; col < columnsCount; col++)
                {
                    for (int row = 1; row < resultsByCategory[participant].Count; row++)
                    {
                        grid.Children.Add(new Label { Text = resultsByCategory[participant][row].Value.ToString() }, row, col);
                    }
                }
            }

            Content = grid;
            Title = "Daily";
        }
	}
}