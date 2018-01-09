
using System;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LettersOnTheTrack
{
    public class MovingLetter
    {
        private char letter;
        private int speed;
        private int currentPosition;
        private string direction;

        public MovingLetter()
        {
            this.currentPosition = 0;
            this.direction = "right";

            //Task.Run(async () =>
            //{
            //    while (true)
            //    {
            //        await Task.Delay(1000);
            //        char empty = ' ';
            //        track = track.Replace(track[currentPosition+1], track[currentPosition]).Replace(track[currentPosition], empty);
            //    }
            //});
            //Task.Run(async () =>
            //{
            //    while (true) //avoiding movement when the speed is 0 (reversed to 10)  - this.Speed != 10
            //    {
            //        await Task.Delay(this.Speed * 100);

            //        int stepToTheRight = currentPosition + 1;
            //        int stepToTheLeft = currentPosition - 1;
            //        char emptySpace = ' ';

            //        if (direction == "right")
            //        {
            //            if (stepToTheRight < track.Length && track[stepToTheRight] == ' ')
            //            {
            //                track = track.Replace(track[stepToTheRight], track[currentPosition]).Replace(track[currentPosition], emptySpace);
            //            }
            //            //change of direction in case it's the end of the line or the spot to the right is already taken
            //            else if ((stepToTheRight >= track.Length || track[stepToTheRight] != ' ') &&
            //                        track[stepToTheLeft] != ' ')
            //            {
            //                this.Direction = "left";
            //                track = track.Replace(track[stepToTheLeft], track[currentPosition]).Replace(track[currentPosition], emptySpace);

            //                //track.Replace(track[currentPosition], track[stepToTheLeft]);
            //            }
            //        }
            //        else
            //        {
            //            if (stepToTheLeft > 0 && track[stepToTheLeft] == ' ')
            //            {
            //                track = track.Replace(track[stepToTheLeft], track[currentPosition]).Replace(track[currentPosition], emptySpace);
            //            }
            //            //change of direction in case it's the end of the line or the spot to the right is already taken
            //            else if ((stepToTheLeft < 0 || track[stepToTheLeft] != ' ') &&
            //                        track[stepToTheRight] != ' ')
            //            {
            //                this.Direction = "right";
            //                track = track.Replace(track[stepToTheRight], track[currentPosition]).Replace(track[currentPosition], emptySpace);
            //            }
            //        }
            //    }
            //});
        }

        public char Letter
        {
            get
            {
                return this.letter;
            }
            set
            {
                if (value == letter)
                {
                    return;
                }

                if (!char.IsLetter(value))
                {
                    MessageBox.Show("Only letters are allowed.");
                    return;
                }
                else
                {
                    this.letter = value;
                }

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
                if (value < 0 && value > 10)
                {
                    MessageBox.Show("The speed should be between 0 and 10.");
                    return;
                }
                else
                {
                    //the speed is used as an input for a delay function, so inversed logic is needed
                    switch (value)
                    {
                        case 10: this.speed = 0; break;
                        case 9: this.speed = 1; break;
                        case 8: this.speed = 2; break;
                        case 7: this.speed = 3; break;
                        case 6: this.speed = 4; break;
                        case 5: this.speed = 5; break;
                        case 4: this.speed = 6; break;
                        case 3: this.speed = 7; break;
                        case 2: this.speed = 8; break;
                        case 1: this.speed = 9; break;
                        case 0: this.speed = 10; break;
                    }
                }
            }
        }

        private int CurrentPosition
        {
            get
            {
                return this.currentPosition;
            }
            set
            {
                if (value > 61 || value < 0)
                {
                    MessageBox.Show("Index is out of boundaries.");
                    return;
                }

                this.currentPosition = value;
                //PropertyChanged(this, new PropertyChangedEventArgs(nameof(CurrentPosition)));
            }
        }

        private string Direction
        {
            get
            {
                return this.direction;
            }
            set
            {
                if (value != "right" || value != "left")
                {
                    MessageBox.Show("Direction could only be left or rigth.");
                    return;
                }
                else
                {
                    this.direction = value;
                }
            }
        }

        public override string ToString()
        {
            return this.Letter.ToString();
        }

    }
}
