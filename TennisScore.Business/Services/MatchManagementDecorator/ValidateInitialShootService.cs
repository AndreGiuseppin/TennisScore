using TennisScore.Business.Interfaces.Services;
using TennisScore.Business.Models;

namespace TennisScore.Business.Services.MatchManagementDecorator
{
    public class ValidateInitialShootService : IMatchManagement
    {
        private readonly IMatchManagement _match;

        public ValidateInitialShootService(IMatchManagement match)
        {
            _match = match ?? throw new ArgumentNullException(nameof(match));
        }

        public void Process(MatchManagement match)
        {
            while (true)
            {
                Console.WriteLine($"\nSaque inicial do {match.CurrentlyPlayer.Name}");

                Console.WriteLine(match.ReturnShootChoice());
                var shootChoice = Console.ReadLine();

                if (shootChoice == "1")
                {
                    _match.Process(match);
                    break;
                }
                else if (shootChoice == "2")
                {
                    if (match.CurrentlyPlayer.CanRetryInitialShoot)
                    {
                        match.CurrentlyPlayer.CannotRetryAnymore();
                        break;
                    }
                    else
                    {
                        match.NextPlayer.AddGameScore();
                        match.ValidatePlayerScore();
                        match.ChangePlayersPosition();
                        match.ValidateGames();
                        match.ValidateSets();
                        break;
                    }
                }
            }
        }
    }
}
