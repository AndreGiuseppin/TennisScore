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
                match.ValidateSets();
                match.ValidateGames();
                Console.WriteLine($"Nome: {match.PlayerOne.Name}. Sets: {match.PlayerOne.Sets}. Games: {match.PlayerOne.Games}. Score: {match.PlayerOne.GameScore}. AdvantageScore: {match.PlayerOne.AdvantageScore}. Is Tie-Break: {match.IsTieBreak}");
                Console.WriteLine($"Nome: {match.PlayerTwo.Name}. Sets: {match.PlayerTwo.Sets}. Games: {match.PlayerTwo.Games}. Score: {match.PlayerTwo.GameScore}. AdvantageScore: {match.PlayerTwo.AdvantageScore}. Is Tie-Break: {match.IsTieBreak}");

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
                        match.ValidatePlayerScore();
                        match.ChangePlayersPosition();
                        continue;
                    }
                }
            }
        }
    }
}
