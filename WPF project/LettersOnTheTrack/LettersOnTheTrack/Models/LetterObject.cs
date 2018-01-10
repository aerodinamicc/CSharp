using System.Windows;

namespace LettersOnTheTrack
{
    public class LetterObject
    {
        private char letter;
        private int speed;
        private int currentPosition;
        private string direction;

        public LetterObject()
        {
            this.currentPosition = 0;
            this.direction = "right";
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
                        case 10: this.speed = 1; break;
                        case 9: this.speed = 2; break;
                        case 8: this.speed = 3; break;
                        case 7: this.speed = 4; break;
                        case 6: this.speed = 5; break;
                        case 5: this.speed = 6; break;
                        case 4: this.speed = 7; break;
                        case 3: this.speed = 8; break;
                        case 2: this.speed = 9; break;
                        case 1: this.speed = 10; break;
                        case 0: this.speed = 0; break;
                    }
                }
            }
        }

        public int CurrentPosition
        {
            get
            {
                return this.currentPosition;
            }
            set
            {
                if (value > 130 || value < 0)
                {
                    MessageBox.Show("Index is out of boundaries.");
                    return;
                }

                this.currentPosition = value;
            }
        }

        public string Direction
        {
            get
            {
                return this.direction;
            }
            set
            {
                if (value != "right" && value != "left")
                {
                    MessageBox.Show("Direction could only be left or right.");
                    return;
                }
                else
                {
                    this.direction = value;
                }
            }
        }
    }
}
