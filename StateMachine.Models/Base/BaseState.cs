namespace StateMachine.Models.Base
{
    public abstract class BaseState
    {
        public string Namespace { get; set; }
        
        public string Name { get; set; }
        
        public string NextState { get; set; }
        
        public string ErrorState { get; set; }
        
        public abstract void Execute();
    }
}