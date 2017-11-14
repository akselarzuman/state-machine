using System.Linq;
using System.Xml.Linq;
using StateMachine.Entities;
using StateMachine.Fremework.Interfaces;

namespace StateMachine.Fremework.Impls
{
    public class StateMachineBuilder : IStateMachineBuilder
    {
        public XDocument LoadXml(string path)
        {
            return XDocument.Load(path);
        }

        public Entities.StateMachine BuildStateMachine(XDocument document)
        {
            var stateMachine = new Entities.StateMachine();

            var states = document.Element("StateMachine").Elements("State");

            if (states.Any())
            {
                stateMachine.States = new System.Collections.Generic.List<State>();

                foreach (var state in states)
                {
                    stateMachine.States.Add(new State
                    {
                        Namespace = state.Attribute("namespace")?.Value,
                        Name = state.Attribute("name")?.Value,
                        ErrorState = state.Attribute("errorState")?.Value,
                        NextState = state.Attribute("nextState")?.Value
                    });
                }
            }

            return stateMachine;
        }
    }
}