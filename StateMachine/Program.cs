using StateMachine;
using StateMachine.Fremework.Impls;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), @"Files/StateMachine.xml");

            var smb = new StateMachineBuilder();
            var xml = smb.LoadXml(path);
            var sm = smb.BuildStateMachine(xml);

            Constant.States = sm.States;

            var sme = new StateMachineExecutor();
            sme.Run(sm);

            System.Console.ReadLine();
        }
    }
}