using TennisScore.Business.Interfaces.Services;
using TennisScore.Business.Models;

namespace TennisScore.Business.Services.MatchManagementDecorator
{
    public class SetChoiceService : IMatchManagement
    {
        public void Process(MatchManagement match)
        {
            Console.WriteLine("Escolha quantos SETS terá a partida:");
            Console.WriteLine("1 - 3 SETS \n2 - 5 SETS");
            var totalSet = Console.ReadLine();

            match.WithSets(Convert.ToInt32(totalSet));

            return;
        }
    }
}
