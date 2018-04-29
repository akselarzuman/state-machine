namespace StateMachine.Models
{
    public class StateModel
    {
        public string Namespace { get; set; }
        public string Name { get; set; }
        public NextState[] NextState { get; set; }
        public string ErrorState { get; set; }
    }

    public class NextState
    {
        public string Condition { get; set; }
        public string State { get; set; }
    }
}