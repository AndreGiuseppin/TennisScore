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
            var teste = true;
            while (teste)
            {
                Console.WriteLine($"Nome: {match.PlayerOne.Name}. Sets: {match.PlayerOne.Sets}. Games: {match.PlayerOne.Games}. Score: {match.PlayerOne.GameScore}");
                Console.WriteLine($"Nome: {match.PlayerTwo.Name}. Sets: {match.PlayerTwo.Sets}. Games: {match.PlayerTwo.Games}. Score: {match.PlayerTwo.GameScore}");

                Console.WriteLine($"Saque inicial do {match.CurrentlyPlayer.Name}");

                Console.WriteLine(match.ReturnShootChoice());
                var shootChoice = Console.ReadLine();

                if (shootChoice == "1")
                {
                    _match.Process(match);
                    continue;
                }
                else if (shootChoice == "2")
                {
                    if (match.CurrentlyPlayer.CanRetryInitialShoot)
                    {
                        match.CurrentlyPlayer.CannotRetryAnymore();
                        continue;
                    }
                    else
                    {
                        match.NextPlayer.AddGameScore();
                        match.ChangePlayersPosition();
                        continue;
                    }
                }
            }
        }
    }
}
