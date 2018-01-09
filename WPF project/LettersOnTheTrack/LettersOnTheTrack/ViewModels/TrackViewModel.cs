using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LettersOnTheTrack
{
    [AddINotifyPropertyChangedInterface]

    public class TrackViewModel : INotifyPropertyChanged
    {
        private string letter = "";
        private int speed;
        private StringBuilder track = new StringBuilder(new string(' ', 60));

        public ObservableCollection<MovingLetter> Letters = new ObservableCollection<MovingLetter>();

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public TrackViewModel()
        {
            this.GoButtonCommand = new RelayCommand(GoButton);
            this.StopButtonCommand = new RelayCommand(StopButton);
        }

        private void GoButton()
        {
            if (string.IsNullOrEmpty(this.Letter))
            {
                return;
            }
            //if the input is longer than one character
            else if (this.Letter.Length > 1)
            {
                MessageBox.Show("Just a single letter please.");
                return;
            }
            //if the input in not a letter
            else if (!char.IsLetter(char.Parse(this.Letter)))
            {
                MessageBox.Show("Only letters are allowed to hit the track.");
                return;
            }
            else
            {
                char letter = char.Parse(this.Letter);

                if (Letters.Any(l => l.Letter == letter))
                {
                    Actions.ChangeOfSpeed(Letters, letter, this.Speed);

                    this.Letter = "";
                    this.Speed = 0;
                }
                else
                {
                    Actions.AddingANewLetter(Letters, letter, this.Speed);

                    this.Letter = "";
                    this.Speed = 0;

                    track.Append(letter);
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Track)));
                }
            }
        }

        private void StopButton()
        {
            if (string.IsNullOrEmpty(this.Letter))
            {
                return;
            }
            //if the input is longer than one character
            else if (this.Letter.Length > 1)
            {
                MessageBox.Show("Just a single letter please.");
                return;
            }
            //if the input in not a letter
            else if (!char.IsLetter(char.Parse(this.Letter)))
            {
                MessageBox.Show("Only letters are allowed to hit the track.");
                return;
            }
            else
            {
                char letter = char.Parse(this.Letter);

                if(Letters.Any(l => l.Letter == letter))
                {
                    Actions.RemoveALetterFromCollection(Letters, letter);
                    Actions.RemoveAFromTrack(letter, track);
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Track)));
                }
            }
        }

        public ICommand GoButtonCommand { get; set; }

        public ICommand StopButtonCommand { get; set; }

        public string Letter
        {
            get
            {
                return this.letter;
            }
            set
            {
                this.letter = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Letter)));
            }
        }

        public int Speed
        {
            get
            {
                return this.speed;
            }
            set
            {
                this.speed = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Speed)));
            }
        }

        public StringBuilder Track
        {
            get
            {
                return track;
            }
            set
            {
                this.track = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Track)));
            }
        }
    }
}
