using System.Threading.Tasks;

namespace JasonState.Models
{
    public abstract class AsyncBaseState<T>
    {
        public string Namespace { get; set; }

        public string Name { get; set; }

        public NextState[] NextState { get; set; }

        public string ErrorState { get; set; }

        public abstract Task ExecuteAsync(T context);
    }
}