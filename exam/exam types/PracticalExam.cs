using exam.questions;

namespace exam
{
    public class PracticalExam : Exam
    {
        public MCQQuestion MultipleChoice { get; set; }

        public PracticalExam()
        {
            
        }
        public PracticalExam(int timeOfExam, int numberOfQuestions,MCQQuestion mCQQuestion) :base(timeOfExam, numberOfQuestions) 
        {
                MultipleChoice = mCQQuestion;
        }



        override public void showExam(Exam exam)
        {
            TimeSpan appTime = TimeSpan.FromMinutes(exam.TimeOfExam);
            System.Timers.Timer timer = new System.Timers.Timer(appTime);
            string startExam;


            do
            {
                Console.WriteLine("do you want to start the exam (y/n)");


                startExam = Console.ReadLine().ToLower();
            } while (startExam == "" || startExam == null || (startExam != "y" && startExam != "n"));
            if (startExam == "n")
            {

                return;
            }
            else
            {

                Console.WriteLine(exam.ToString());
            }
            showQuestions(exam);

        }

        public void showQuestions(Exam exam)
        {
            exam.Start = DateTime.Now;
            for (int i = 0; i < exam.NumberOfQuestions; i++)
            {
                int useranswer = 0;

                Console.WriteLine($"{exam.QuestionsArray[i].Header}\t Marks ={exam.QuestionsArray[i].Mark}");
                Console.WriteLine($"\n{exam.QuestionsArray[i].Body}");

                foreach (var answer in exam.QuestionsArray[i].Answers)
                {
                    Console.WriteLine($"{answer.AnswerId}. {answer.AnswerText}");
                }

                    do
                    {
                        Console.WriteLine("enter the right answer id  ");

                    } while (!(int.TryParse(Console.ReadLine(), out useranswer)) || useranswer < 1 || useranswer > 2);


                
                exam.QuestionsArray[i].UserAnswer = new Answer(useranswer, exam.QuestionsArray[i].Answers[useranswer - 1].AnswerText);
                if (exam.QuestionsArray[i].UserAnswer.Equals(exam.QuestionsArray[i].RightAnswer))
                {
                    exam.Grade += exam.QuestionsArray[i].Mark;
                }
            }
            exam.Finish = DateTime.Now;
            showResult(exam);

        }
        public void showResult(Exam exam)
        {
            for (int i = 0; i < exam.NumberOfQuestions; i++)
            {
                Console.WriteLine($"question {i + 1}: {exam.QuestionsArray[i].Body}");
                Console.WriteLine($"right answer => {exam.QuestionsArray[i].RightAnswer.AnswerText}");


            }
            Console.WriteLine($"time = {exam.Start - exam.Finish}");

            Console.WriteLine("thank you");
        }
    }
}
