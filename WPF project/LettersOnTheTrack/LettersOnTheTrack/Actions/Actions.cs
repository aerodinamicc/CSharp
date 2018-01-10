using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LettersOnTheTrack
{
    public static class Actions
    {
        public static void ChangeOfSpeed(ObservableCollection<LetterObject> Letters, char letter, int speed)
        {
            var existingLetter = Letters.FirstOrDefault(l => l.Letter == letter);

            if (existingLetter.Speed == speed)
            {
                return;
            }
            else
            {
                existingLetter.Speed = speed;
            }
        }

        public static void RemoveALetterFromCollection(ObservableCollection<LetterObject> Letters, char letter)
        {
            //ei tuk mirishe
            var letterToRemove = Letters.First(x => (char)x.Letter == letter);
            
            if (letterToRemove != null)
            {
                Letters.Remove(letterToRemove);
            }
        }

        public static void RemoveAFromTrack(ObservableCollection<LetterObject> Letters, char letter, StringBuilder track)
        {
            track.Replace(letter, ' ');
        }
    }
}
