﻿using TennisScore.Business.Interfaces.Services;
using TennisScore.Business.Models;

namespace TennisScore.Business.Services.MatchManagementDecorator
{
    public class SetChoiceService : IMatchManagement
    {
        private readonly IMatchManagement _match;

        public SetChoiceService(IMatchManagement match)
        {
            _match = match ?? throw new ArgumentNullException(nameof(match));
        }

        public void Process(MatchManagement match)
        {
            while (true)
            {
                Console.WriteLine("\nEscolha quantos SETS terá a partida:");
                Console.WriteLine(match.ReturnSetsChoice());
                var totalSet = Console.ReadLine();

                match.WithSets(Convert.ToInt32(totalSet));

                _match.Process(match);

                if (match.ReplayMatch)
                    continue;

                break;
            }
        }
    }
}
