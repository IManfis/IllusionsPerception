namespace IllusionsPerception.Model
{
    public class Experiment2Result
    {
        public int Id { get; set; }
        public int Id_User { get; set; }
        public string TesteeResponse { get; set; }
        public string CorrectAnswer { get; set; }
        public int Confidence { get; set; }
        public int NumberDisplay { get; set; }
        public int AllNumberDisplay { get; set; }
    
        public virtual User User { get; set; }
    }
}