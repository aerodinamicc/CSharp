using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace LettersOnTheTrack
{
    public static class Actions
    {
        public static void ChangeOfSpeed(ObservableCollection<MovingLetter> Letters, char letter, int speed)
        {
            var existingLetter = Letters.FirstOrDefault(l => l.Letter == letter);

            if (existingLetter.Speed == speed)
            {
                return;
            }
            else
            {
                Letters.Remove(existingLetter);
                existingLetter.Speed = speed;
                Letters.Add(existingLetter);
            }
        }

        public static void AddingANewLetter(ObservableCollection<MovingLetter> Letters, char letter, int speed)
        {
            Letters.Add(new MovingLetter()
            {
                Letter = letter,
                Speed = speed,
            });
        }

        public static void RemoveALetterFromCollection(ObservableCollection<MovingLetter> Letters, char letter)
        {
            MovingLetter letterToRemove = Letters.FirstOrDefault(l => l.Letter == letter);

            if (letterToRemove != null)
            {
                Letters.Remove(letterToRemove);
            }
        }

        public static void RemoveAFromTrack(char letter, StringBuilder track)
        {
            var line = track.ToString();
            var position = line.IndexOf(letter);

            if (position != -1)
            {
                track[position] = ' ';
            }
        }
    }
}
