using System.Xml.Linq;

namespace StateMachine.Framework.Interfaces
{
    public interface IStateMachineBuilder
    {
        XDocument LoadXml(string path);
        Entities.StateMachine BuildStateMachine(XDocument document);
    }
}