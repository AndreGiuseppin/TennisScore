using TennisScore.Business.Interfaces;

namespace TennisScore.Business.Services
{
    public class ConsoleWrapper : IConsole
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
