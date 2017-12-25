using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Utils.Contracts;
using Academy.Models.Enums;

namespace Academy.Models.AcademyClasses
{
    public class Student : IStudent
    {
        private Track track;
        private IList<ICourseResult> courseResults;
        private string username;

        public Student(string username, string track)
        {
            this.Username = username;
            Track trackType;
            Enum.TryParse(track, true, out trackType);
            this.Track = trackType;

            //(Track)int.Parse(track)
            this.CourseResults = new List<ICourseResult>();
        }

        public Track Track
        {
            get
            {
                return this.track;
            }
            set
            {
                //obviously on the third test the provided track is not valid 
                if (value == Track.Dev || value == Track.Frontend ||
                    value == Track.None)
                {
                    this.track = value;
                }
                else
                {
                    throw new ArgumentException(
                        "The provided track is not valid!");
                }
            }
        }
        public IList<ICourseResult> CourseResults
        {
            get
            {
                return this.courseResults;
            }
            set
            {
                this.courseResults = value;
            }
        }
        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length > 2 &&
                                    value.Length < 17)
                {
                    this.username = value;
                }
                else
                {
                    throw new ArgumentException(
                        "User's username should be between 3 and 16 symbols long!");
                }
            }
        }

        public override string ToString()
        {
            StringBuilder results = new StringBuilder();
            if (courseResults.Count < 1)
            {
                results.Append("  * User has no course results!");
            }
            else
            {
                foreach (var subject in this.CourseResults)
                {
                    results.Append(subject.ToString() + "\n");
                }
            }

            return $"* Student:\n" +
                   $" - Username: {this.username}\n" +
                   $" - Track: {this.track.ToString()}\n" +
                   $" - Course results:\n" +
                   $"{results}";
                
        }
    }
}
