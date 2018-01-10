using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LettersOnTheTrack
{
    public static class MovementOfLetters
    {
        public static void MakeAStep(LetterObject letter, StringBuilder track)
        {
            var currentPosition = letter.CurrentPosition;

            int stepToTheRight = currentPosition + 1;
            int stepToTheLeft = currentPosition - 1;

            if (letter.Direction == "right")
            {
                if (stepToTheRight < track.Length && track[stepToTheRight] == ' ')
                {
                    SwapPosition(currentPosition, stepToTheRight, track, letter.Letter);
                    letter.CurrentPosition = stepToTheRight;
                }
                //change of direction in case it's the end of the line or the spot to the right is already taken
                else if ((stepToTheRight >= track.Length || track[stepToTheRight] != ' ') &&
                            track[stepToTheLeft] == ' ')
                {
                    letter.Direction = "left";
                    SwapPosition(currentPosition, stepToTheLeft, track, letter.Letter);
                    letter.CurrentPosition = stepToTheLeft;
                }
            }
            else
            {
                if (stepToTheLeft > -1 && track[stepToTheLeft] == ' ')
                {
                    SwapPosition(currentPosition, stepToTheLeft, track, letter.Letter);
                    letter.CurrentPosition = stepToTheLeft;
                }
                //change of direction in case it's the end of the line or the spot to the right is already taken
                else if ((stepToTheLeft < 0 || track[stepToTheLeft] != ' ') &&
                            track[stepToTheRight] == ' ')
                {
                    letter.Direction = "right";
                    SwapPosition(currentPosition, stepToTheRight, track, letter.Letter);
                    letter.CurrentPosition = stepToTheRight;
                }
            }
        }

        private static void SwapPosition(int oldPosition, int newPosition, StringBuilder track, char letter)
        {
            track[oldPosition] = ' ';
            track[newPosition] = letter;
        }
    }
}
