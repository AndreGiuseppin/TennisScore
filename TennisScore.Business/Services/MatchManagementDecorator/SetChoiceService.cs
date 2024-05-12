using TennisScore.Business.Interfaces;
using TennisScore.Business.Interfaces.Services;
using TennisScore.Business.Models;

namespace TennisScore.Business.Services.MatchManagementDecorator
{
    public class SetChoiceService : IMatchManagement
    {
        private readonly IMatchManagement _match;
        private readonly IConsole _console;

        public SetChoiceService(IMatchManagement match, IConsole console)
        {
            _match = match ?? throw new ArgumentNullException(nameof(match));
            _console = console ?? throw new ArgumentNullException(nameof(console));
        }

        public void Process(MatchManagement match)
        {
            while (true)
            {
                Console.WriteLine("\nEscolha quantos SETS terá a partida:");
                Console.WriteLine(match.ReturnSetsChoice());
                var totalSet = _console.ReadLine();

                match.WithSets(Convert.ToInt32(totalSet));

                _match.Process(match);

                if (match.ReplayMatch)
                    continue;

                break;
            }
        }
    }
}
