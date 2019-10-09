namespace JasonState.Models
{
    public abstract class BaseState<T> where T : class, new()
    {
        public string Namespace { get; set; }

        public string Name { get; set; }

        public NextState[] NextState { get; set; }

        public string ErrorState { get; set; }

        public abstract void Execute(T context);
    }
}