using TennisScore.Business.Interfaces;
using TennisScore.Business.Interfaces.Services;
using TennisScore.Business.Models;

namespace TennisScore.Business.Services.MatchManagementDecorator
{
    public class StartRallyService : IMatchManagement
    {
        private readonly IConsole _console;

        public StartRallyService(IConsole console)
        {
            _console = console ?? throw new ArgumentNullException(nameof(console));
        }

        public void Process(MatchManagement match)
        {
            match.ChangePlayersPosition();

            while (true)
            {
                Console.WriteLine($"\nProxima jogada do {match.CurrentlyPlayer.Name}");
                Console.WriteLine("1 - Rebatida com sucesso \n2 - Rebatida sem sucesso");
                var choice = _console.ReadLine();

                if (choice == "1")
                {
                    match.ChangePlayersPosition();
                    continue;
                }
                else
                {
                    match.SetGameWinner();
                    break;
                }
            }
        }
    }
}
