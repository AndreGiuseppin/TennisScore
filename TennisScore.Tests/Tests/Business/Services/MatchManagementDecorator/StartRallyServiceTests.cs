using AutoFixture.Idioms;
using AutoFixture.Xunit2;
using FluentAssertions;
using NSubstitute;
using TennisScore.Business.Interfaces;
using TennisScore.Business.Models;
using TennisScore.Business.Services.MatchManagementDecorator;
using TennisScore.Tests.Attributes;

namespace TennisScore.Tests.Tests.Business.Services.MatchManagementDecorator
{
    public class StartRallyServiceTests
    {
        [Theory]
        [AutoNSubstituteData]
        public void StartRallyServiceTests_GuardClause(
            GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(StartRallyService).GetConstructors());
        }

        [Theory]
        [AutoNSubstituteData]
        public void Process_WhenRallyFail_ShouldSetGameWinner(
            [Frozen] IConsole console,
            StartRallyService sut,
            MatchManagement matchManagement
            )
        {
            matchManagement.CurrentlyPlayer.GameScore = 0;
            console.ReadLine().Returns("2");

            sut.Process(matchManagement);

            matchManagement.CurrentlyPlayer.GameScore.Should().Be(15);
        }
    }
}
