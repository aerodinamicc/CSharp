using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models.AcademyClasses
{
    public class Course : ICourse
    {
        private string name;
        private int lecturesPerWeek;
        private DateTime startingDate;
        private DateTime endingDate;
        private IList<IStudent> onsiteStudents;
        private IList<IStudent> onlineStudents;
        private IList<ILecture> lectures;

        public Course(string courseName, string lecturesPerWeek,
            string startingDate)
        {
            this.Name = courseName;
            this.LecturesPerWeek = int.Parse(lecturesPerWeek);
            this.StartingDate = DateTime.Parse(startingDate);
            this.EndingDate = StartingDate.AddDays(30d);
            this.OnsiteStudents = new List<IStudent>();
            this.OnlineStudents = new List<IStudent>();
            this.Lectures = new List<ILecture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length > 2 &&
                    value.Length < 46)
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException(
                        "The name of the course must be between 3 and 45 symbols!");
                }
            }
        }
        public int LecturesPerWeek
        {
            get
            {
                return this.lecturesPerWeek;
            }
            set
            {
                if (value > 0 && value < 8)
                {
                    this.lecturesPerWeek = value;
                }
                else
                {
                    throw new ArgumentException(
                        "The number of lectures per week must be between 1 and 7!");
                }
            }
        }
        public DateTime StartingDate
        {
            get
            {
                return this.startingDate;
            }
            set
            {
                this.startingDate = value;
            }
        }
        public DateTime EndingDate
        {
            get
            {
                return this.endingDate;
            }
            set
            {
                this.endingDate = value;
            }
        }


        public IList<IStudent> OnsiteStudents
        {
            get
            {
                return this.onsiteStudents;
            }
            set
            {
                this.onsiteStudents = value;
            }
        }

        public IList<IStudent> OnlineStudents
        {
            get
            {
                return this.onlineStudents;
            }
            set
            {
                this.onlineStudents = value;
            }
        }

        public IList<ILecture> Lectures
        {
            get
            {
                return this.lectures;
            }
            set
            {
                this.lectures = value;
            }
        }

        public override string ToString()
        {
            StringBuilder classes = new StringBuilder();
            if (Lectures.Count < 1)
            {
                classes.Append("  * There are no lectures in this course!");
            }
            else
            {
                foreach (var lecture in this.Lectures)
                {
                    classes.Append(lecture.ToString() + "\n");
                }
                classes.Length -= 1;
            }
            return $"* Course:\n" +
                   $" - Name: {this.name}\n" +
                   $" - Lectures per week: {this.lecturesPerWeek}\n" +
                   $" - Starting date: {this.startingDate.ToString()}\n" +
                   $" - Ending date: {this.endingDate.ToString()}\n" +
                   $" - Onsite students: {this.OnsiteStudents.Count}\n" +
                   $" - Online students: {this.OnlineStudents.Count}\n" +
                   $" - Lectures:\n" +
                   $"{classes}";

            //the last line might be changed

        }
    }
}
