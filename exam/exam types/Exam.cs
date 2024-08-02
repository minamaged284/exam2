using exam.questions;

namespace exam
{
    public class Exam
    {
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public int TimeOfExam { get; set; }
        public int NumberOfQuestions { get; set; }
        public int TotalMarks { get; set; }
        public int Grade { get; set; }


        public Question[] QuestionsArray { get; set; }
        public Exam()
        {
            
        }

        public Exam(int timeOfExam , int numberOfQuestions)
        {
            TimeOfExam = timeOfExam;
            NumberOfQuestions = numberOfQuestions;
        }

        virtual public void  showExam(Exam exam)
        {

        }

        public override string ToString()
        {
            return $"time of exam = {TimeOfExam},total marks = {TotalMarks},number of questions {NumberOfQuestions} ";
        }
    }


}
