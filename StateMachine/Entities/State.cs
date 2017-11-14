namespace StateMachine.Entities
{
    public class State
    {
        public string Namespace { get; set; }
        public string Name { get; set; }
        public string NextState { get; set; }
        public string ErrorState { get; set; }
    }
}