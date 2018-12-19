using System.Collections.Generic;

namespace StateMachine.Models
{
    public class StateMachine
    {
        public IEnumerable<State> States { get; set; }
    }
}