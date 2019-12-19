using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Exercises.Classes
{
    public class HomeworkAssignment
    {
        private int earnedMarks = 0;
        private int possibleMarks = 0;
        private string submitterName = "";
        private string letterGrade = "";

        public HomeworkAssignment(int PossMarks, string SubName)
        {
            possibleMarks = PossMarks;
            submitterName = SubmitterName;
        }
        public int EarnedMarks
        {
            get
            {
                return earnedMarks;
            }
            set
            {
                earnedMarks = value;
            }
        }
        public int PossibleMarks
        {
            get
            {
                return possibleMarks;
            }
        }
        public string SubmitterName
        {
            get
            {
                return submitterName;
            }
        }

        public string LetterGrade
        {
            get
            {
                if (EarnedMarks > 90)
                {
                    return "A";
                }

                else if (EarnedMarks < 90 && EarnedMarks >= 80)
                {
                    return "B";
                }
                else if (EarnedMarks >= 70 && EarnedMarks < 80)
                {
                    return "C";
                }
                else if (EarnedMarks < 70 && EarnedMarks >= 60)
                {
                    return "D";
                }
                else
                {
                    return "F";
                }
            }
        }
    }
}


