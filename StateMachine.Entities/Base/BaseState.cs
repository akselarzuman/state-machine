namespace StateMachine.Entities.Base
{
    public abstract class BaseState
    {
        public string Name { get; set; }
        public string Namespace { get; set; }
        public BaseState NextState { get; set; }
        public BaseState ErrorState { get; set; }        
        public abstract void Execute();
    }
}