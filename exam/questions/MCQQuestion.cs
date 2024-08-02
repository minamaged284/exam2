namespace exam.questions
{
    public class MCQQuestion : Question
    {

        public Answer[] Answers { get; set; }
        public Answer RightAnswer { get; set; }

        public MCQQuestion()
        {
            
        }

        public MCQQuestion(string header, string body, int mark, Answer[] answers, Answer rightAnswer) : base(header, body, mark,answers,rightAnswer)
        {


        }

    }

}

