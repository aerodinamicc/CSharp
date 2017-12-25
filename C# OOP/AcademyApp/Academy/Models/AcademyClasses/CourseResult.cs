using Academy.Models.Utils.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Contracts;
using Academy.Models.Enums;

namespace Academy.Models.AcademyClasses
{
    public class CourseResult : ICourseResult
    {
        private ICourse course;
        private float examPoints;
        private float coursePoints;
        private Grade grade;


        //The Student must be signed up for that course in order to
        //create a CourseResult.

        public CourseResult(ICourse course, string examPoints, string coursePoints)
        {
            this.Course = course;
            this.ExamPoints = int.Parse(examPoints);
            this.CoursePoints = int.Parse(coursePoints);
        }

        public ICourse Course
        {
            get
            {
                return this.course;
            }
            set
            {
                this.course = value;
            }
            //valid course?
        }

        public float ExamPoints
        {
            get
            {
                return this.examPoints;
            }
            set
            {
                if (value < 0 || value > 1000)
                {
                    throw new ArgumentException(
                        "Course result's exam points should be between 0 and 1000!");
                }
                this.examPoints = value;
            }
        }

        public float CoursePoints
        {
            get
            {
                return this.coursePoints;
            }
            set
            {
                if (value < 0 || value > 125)
                {
                    throw new ArgumentException(
                        "Course result's course points should be between 0 and 125!");
                }
                this.coursePoints = value;
            }
        }
        public Grade Grade
        {
            get
            {
                return this.grade;
            }
            set
            {
                if (this.ExamPoints >= 65 && this.CoursePoints > 75)
                {
                    this.grade = Grade.Excellent;
                }
                else if (this.ExamPoints >= 30 && this.ExamPoints < 60 &&
                    this.CoursePoints < 75 && this.CoursePoints >= 45)
                {
                    this.grade = Grade.Passed;
                }
                else if (this.ExamPoints < 30 && this.CoursePoints < 45)
                {
                    this.grade = Grade.Failed;
                }
            }

        }

        public override string ToString()
        {
            return $"  * {this.Course.Name.ToString()}: Points - {this.CoursePoints}, " +
                $"Grade - {this.Grade.ToString()}";
        }
    }
}
