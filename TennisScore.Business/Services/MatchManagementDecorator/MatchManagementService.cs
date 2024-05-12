using TennisScore.Business.Interfaces;
using TennisScore.Business.Interfaces.Services;
using TennisScore.Business.Models;

namespace TennisScore.Business.Services.MatchManagementDecorator
{
    public class MatchManagementService : IMatchManagement
    {
        private readonly IMatchManagement _match;
        private readonly IConsole _console;

        public MatchManagementService(IMatchManagement match, IConsole console)
        {
            _match = match ?? throw new ArgumentNullException(nameof(match));
            _console = console ?? throw new ArgumentNullException(nameof(console));
        }

        public void Process(MatchManagement match)
        {
            while (true)
            {
                if (match.MatchWinner is { })
                {
                    Console.WriteLine($"\nVencedor da partida: {match.MatchWinner.Name}");
                    Console.WriteLine("Deseja jogar novamente?");
                    Console.WriteLine("1 - Sim \n2 - Não");
                    var playAgain = _console.ReadLine();

                    if (playAgain == "1")
                    {
                        match.ResetMatch();
                        match.SetReplayMatch();
                        break;
                    }
                    if (playAgain == "2")
                    {
                        match.ResetMatch();
                        break;
                    }
                }

                Console.WriteLine($"\nNome: {match.PlayerOne.Name}. Sets: {match.PlayerOne.Sets}. Games: {match.PlayerOne.Games}. Score: {match.PlayerOne.GameScore}. AdvantageScore: {match.PlayerOne.AdvantageScore}. Is Tie-Break: {match.IsTieBreak}");
                Console.WriteLine($"Nome: {match.PlayerTwo.Name}. Sets: {match.PlayerTwo.Sets}. Games: {match.PlayerTwo.Games}. Score: {match.PlayerTwo.GameScore}. AdvantageScore: {match.PlayerTwo.AdvantageScore}. Is Tie-Break: {match.IsTieBreak}");

                _match.Process(match);
            }
        }
    }
}
