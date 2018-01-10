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
        private StringBuilder track = new StringBuilder(new string(' ', 140));

        public ObservableCollection<LetterObject> Letters = new ObservableCollection<LetterObject>();

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public TrackViewModel()
        {
            this.GoButtonCommand = new RelayCommand(GoButton);
            this.StopButtonCommand = new RelayCommand(StopButton);
        }

        private void GoButton()
        {
            #region Validation
            //Validation
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
            #endregion
            #region Change of speed or creating a new letter
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
                    var newLetter = new LetterObject()
                    {
                        Letter = letter,
                        Speed = speed,
                    };

                    Letters.Add(newLetter);

                    this.Letter = "";
                    this.Speed = 0;

                    Task.Run(async () =>
                    {
                        while (Letters.Contains(newLetter))
                        {
                            if (newLetter.Speed > 0)
                            {
                                await Task.Delay(newLetter.Speed * 50);
                                if (Letters.Contains(newLetter))
                                {
                                    LetterMoves(track, newLetter);
                                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Track)));
                                }
                            }
                        }
                    });
                }
            }
            #endregion
        }

        private void StopButton()
        {
            #region Validation
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
            #endregion
            #region Remove a letter from track and from the collection
            else
            {
                char letter = char.Parse(this.Letter);

                if (Letters.Any(l => (char)l.Letter == letter))
                {
                    Actions.RemoveALetterFromCollection(Letters, letter);
                    track.Replace(letter, ' ');
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Track)));
                }

                this.Letter = "";
                this.Speed = 0;
            }
            #endregion
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

        private void LetterMoves(StringBuilder track, LetterObject letter)
        {
            MovementOfLetters.MakeAStep(letter, track);
        }
    }
}
