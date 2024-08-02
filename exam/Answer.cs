namespace exam
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public Answer()
        {
            
        }
        public Answer(int answerId, string answerText)
        {
            AnswerId = answerId;
            AnswerText= answerText;
        }

        public override bool Equals(object? obj)
        {
            Answer objAnswer = obj as Answer;
            return objAnswer.AnswerText == this.AnswerText && objAnswer.AnswerId == this.AnswerId;
        }
    }
}
