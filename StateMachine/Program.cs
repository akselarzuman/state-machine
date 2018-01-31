using System.IO;
using StateMachine.Fremework.Impls;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), @"Files/StateMachine.json");
            var smb = new StateMachineBuilder();
            var sm = smb.Load(path);
            var machine = smb.BuildMachine(sm);

            var sme = new StateMachineExecutor();
            sme.Execute(machine);

            System.Console.ReadLine();
        }
    }
}