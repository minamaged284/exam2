using exam.questions;

namespace exam
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }

        private string ExamType { get; set; }

        public Subject()
        {
            
        }
        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        public void createExam()
        {


            do
            {
                Console.WriteLine("Please enter the type of exam (1 for practical | 2 for final)");
                ExamType = Console.ReadLine();
            } while (ExamType == "" || ExamType == null || (ExamType != "1" && ExamType != "2"));

            TimeOfExam();
        }

        public void TimeOfExam()
        {
            int time = 0;
            do
            {

                Console.WriteLine("Please enter the time of exam from (3o min to 180 min)");

            } while (!(int.TryParse(Console.ReadLine(), out time)) || time < 30 || time > 180);
            if (ExamType == "1")
            {
                Exam = new PracticalExam();
                Exam.TimeOfExam = time;
                setNumberOfQuestions(Exam);


            }

            else if (ExamType == "2")
            {
                Exam = new FinallExam();
                Exam.TimeOfExam = time;
                setNumberOfQuestions(Exam);




            }



        }
        public void setNumberOfQuestions(Exam exam)
        {
            int numberOfQuestions = 0;
            do
            {

                Console.WriteLine("Please enter the number of questions");

            } while (!(int.TryParse(Console.ReadLine(), out numberOfQuestions)) || numberOfQuestions <= 0 || numberOfQuestions > 25);

            Exam.NumberOfQuestions = numberOfQuestions;
            Console.Clear();

            createQuestions();
        }

        public void createQuestions()
        {
            Exam.QuestionsArray = new Question[Exam.NumberOfQuestions];

            for (int i = 0; i < Exam.NumberOfQuestions; i++)
            {
                string questionType;
                string questionHeader;
                string questionBody;
                int rightAnswerId = 0;
                int mark = 0;
                int totalMarks;

                //final exam 

                if (ExamType == "2")
                {
                    do
                    {
                        Console.WriteLine("Please enter the type of question (1 MCQ | 2 for true or false)");
                        questionType = Console.ReadLine();
                    } while (questionType == "" || questionType == null || (questionType != "1" && questionType != "2"));

                    //final exam mcq questions header

                    if (questionType == "1")
                    {
                        questionHeader = "MCQ question";
                        //final exam mcq questions body

                        do
                        {
                            Console.WriteLine($"Please enter the body of question number ({i + 1})");
                            questionBody = Console.ReadLine();
                        } while (questionBody == "" || questionBody == null);
                        //final exam mcq question mark 
                        do
                        {
                            Console.WriteLine($"Please enter the mark of question number ({i + 1}) ");

                        } while (!(int.TryParse(Console.ReadLine(), out mark)) || mark > 100 || mark < 1);

                        Exam.TotalMarks+= mark;

                        //final exam mcq questions answers

                        Answer[] mcqAnswers = new Answer[3];
                        for (int j = 0; j < mcqAnswers.Length; j++)
                        {
                            string answerText = "";
                            mcqAnswers[j] = new Answer();

                            mcqAnswers[j].AnswerId = j + 1;

                            do
                            {
                                Console.WriteLine($"Please enter answer number ({j + 1}) ");
                                answerText = Console.ReadLine();
                            } while (answerText == "" || answerText == null);
                            mcqAnswers[j].AnswerText = answerText;
                        }

                        //final exam mcq questions right answer

                        do
                        {
                            Console.WriteLine($"Please enter right answer id for question number ({i + 1}) ");

                        } while (!(int.TryParse(Console.ReadLine(), out rightAnswerId)) || rightAnswerId > mcqAnswers.Length + 1 || rightAnswerId < 1);

                        Answer rightAnswer = new Answer(rightAnswerId, mcqAnswers[rightAnswerId - 1].AnswerText);



                        Exam.QuestionsArray[i]= new MCQQuestion(questionHeader, questionBody, mark, mcqAnswers, rightAnswer);

                        Console.Clear();
                    }
                    //final exam true or false questions
                    //final exam true or false questions header

                    else
                    {
                        questionHeader = "True or false question";

                        //final exam true or false questions body

                        do
                        {
                            Console.WriteLine($"Please enter the body of question number ({i + 1})");
                            questionBody = Console.ReadLine();
                        } while (questionBody == "" || questionBody == null);

                        //final exam true or false questions mark

                        do
                        {
                            Console.WriteLine($"Please enter the mark of question number ({i + 1}) ");

                        } while (!(int.TryParse(Console.ReadLine(), out mark)) || mark > 100 || mark < 1);
                        Exam.TotalMarks += mark;

                        //final exam true or false questions answers

                        Answer[] trueOrFalseAnswers = new Answer[2]
                        {
                            new Answer(1,"true"),
                            new Answer(2,"false"),
                        };



                        //final exam true or false questions right answer

                        do
                        {
                            Console.WriteLine($"Please enter right answer id for question number ({i + 1}) ");

                        } while (!(int.TryParse(Console.ReadLine(), out rightAnswerId)) || rightAnswerId > trueOrFalseAnswers.Length || rightAnswerId < 1);

                        Answer rightAnswer = new Answer(rightAnswerId, trueOrFalseAnswers[rightAnswerId - 1].AnswerText);


                        Exam.QuestionsArray[i] = new TrueOrFalseQuestion(questionHeader, questionBody, mark, trueOrFalseAnswers, rightAnswer);

                        

                    }


                    Console.Clear();

                }

                else
                {

                         questionHeader = "MCQ question";
                        //final exam mcq questions body

                        do
                        {
                            Console.WriteLine($"Please enter the body of question number ({i + 1})");
                            questionBody = Console.ReadLine();
                        } while (questionBody == "" || questionBody == null);
                        //final exam mcq question mark 
                        do
                        {
                            Console.WriteLine($"Please enter the mark of question number ({i + 1}) ");

                        } while (!(int.TryParse(Console.ReadLine(), out mark)) || mark > 100 || mark < 1);
                    Exam.TotalMarks += mark;

                    //final exam mcq questions answers

                    Answer[] mcqAnswers = new Answer[3];
                        for (int j = 0; j < mcqAnswers.Length; j++)
                        {
                            string answerText;
                            mcqAnswers[j] = new Answer();

                            mcqAnswers[j].AnswerId = j + 1;

                            do
                            {
                                Console.WriteLine($"Please enter answer number ({j + 1}) ");
                                answerText = Console.ReadLine();
                            } while (answerText == "" || answerText == null);
                            mcqAnswers[j].AnswerText = answerText;
                        }

                        //final exam mcq questions right answer

                        do
                        {
                            Console.WriteLine($"Please enter right answer id for question number ({i + 1}) ");

                        } while (!(int.TryParse(Console.ReadLine(), out rightAnswerId)) || rightAnswerId > mcqAnswers.Length + 1 || rightAnswerId < 1);

                        Answer rightAnswer = new Answer(rightAnswerId, mcqAnswers[rightAnswerId - 1].AnswerText);



                    Exam.QuestionsArray[i] = new MCQQuestion(questionHeader, questionBody, mark, mcqAnswers, rightAnswer);


                    Console.Clear();
                    
                }
               

            }
            
            Exam.showExam(Exam);

        }
    }
}
