using System.Collections.Generic;

namespace JasonState.Models
{
    public class StateMachineModel
    {
        public IEnumerable<StateModel> States { get; set; }
    }
}