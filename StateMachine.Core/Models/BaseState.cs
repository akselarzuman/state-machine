namespace StateMachine.Core.Models
{
    public abstract class BaseState
    {
        public string Namespace { get; set; }
        
        public string Name { get; set; }
        
        public NextState[] NextState { get; set; }
        
        public string ErrorState { get; set; }
        
        public abstract void Execute();
    }
}