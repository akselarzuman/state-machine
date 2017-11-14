using System.Xml.Linq;

namespace StateMachine.Fremework.Interfaces
{
    public interface IStateMachineBuilder
    {
        XDocument LoadXml(string path);
        Entities.StateMachine BuildStateMachine(XDocument document);
    }
}