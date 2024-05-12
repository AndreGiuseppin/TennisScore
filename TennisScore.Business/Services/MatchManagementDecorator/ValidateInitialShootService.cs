using TennisScore.Business.Interfaces;
using TennisScore.Business.Interfaces.Services;
using TennisScore.Business.Models;

namespace TennisScore.Business.Services.MatchManagementDecorator
{
    public class ValidateInitialShootService : IMatchManagement
    {
        private readonly IMatchManagement _match;
        private readonly IConsole _console;

        public ValidateInitialShootService(IMatchManagement match, IConsole console)
        {
            _match = match ?? throw new ArgumentNullException(nameof(match));
            _console = console ?? throw new ArgumentNullException(nameof(console));
        }

        public void Process(MatchManagement match)
        {
            while (true)
            {
                Console.WriteLine($"\nSaque inicial do {match.CurrentlyPlayer.Name}");

                Console.WriteLine(match.ReturnShootChoice());
                var shootChoice = _console.ReadLine();

                if (shootChoice == "1")
                {
                    _match.Process(match);
                    break;
                }
                else if (shootChoice == "2" || shootChoice == "3" || shootChoice == "4" || shootChoice == "5")
                {
                    if (match.CurrentlyPlayer.CanRetryInitialShoot)
                    {
                        match.CurrentlyPlayer.CannotRetryAnymore();
                        break;
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
}
