namespace IllusionsPerception.Model
{
    public class Experiment1Result
    {
        public int Id { get; set; }
        public int Id_User { get; set; }
        public int AbsoluteValue { get; set; }
        public string Sign { get; set; }
        public int NumberDisplay { get; set; }
        public int AllNumberDisplay { get; set; }

        public virtual User User { get; set; }
    }
}
