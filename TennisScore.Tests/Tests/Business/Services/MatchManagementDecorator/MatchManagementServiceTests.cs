using AutoFixture.Idioms;
using AutoFixture.Xunit2;
using FluentAssertions;
using NSubstitute;
using TennisScore.Business.Interfaces;
using TennisScore.Business.Interfaces.Services;
using TennisScore.Business.Models;
using TennisScore.Business.Services.MatchManagementDecorator;
using TennisScore.Tests.Attributes;

namespace TennisScore.Tests.Tests.Business.Services.MatchManagementDecorator
{
    public class MatchManagementServiceTests
    {
        [Theory]
        [AutoNSubstituteData]
        public void MatchManagementServiceTests_GuardClause(
            GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(MatchManagementService).GetConstructors());
        }

        [Theory]
        [AutoNSubstituteData]
        public void Process_WhenExistMatchWinnerAndPlayAgain_ShouldSetReplayMatch(
            [Frozen] IConsole console,
            MatchManagementService sut,
            MatchManagement matchManagement
            )
        {
            matchManagement.MatchWinner = new Player("Player");

            console.ReadLine().Returns("1");

            sut.Process(matchManagement);

            matchManagement.ReplayMatch.Should().Be(true);
        }

        [Theory]
        [AutoNSubstituteData]
        public void Process_WhenExistMatchWinnerAndNotPlayAgain_ShouldNotSetReplayMatchAndNotCallNext(
            [Frozen] IMatchManagement match,
            [Frozen] IConsole console,
            MatchManagementService sut,
            MatchManagement matchManagement
            )
        {
            matchManagement.MatchWinner = new Player("Player");

            console.ReadLine().Returns("2");

            sut.Process(matchManagement);

            matchManagement.ReplayMatch.Should().Be(false);
            match.DidNotReceive().Process(matchManagement);
        }
    }
}
