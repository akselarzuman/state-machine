using System.Collections.Generic;

namespace JasonState.Models
{
    internal class StateMachineModel
    {
        public IEnumerable<StateModel> States { get; set; }
    }
}