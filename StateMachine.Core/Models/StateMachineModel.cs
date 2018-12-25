using System.Collections.Generic;

namespace StateMachine.Core.Models
{
    public class StateMachineModel
    {
        public IEnumerable<StateModel> States { get; set; }
    }
}