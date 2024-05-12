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
    public class ValidateInitialShootServiceTests
    {
        [Theory]
        [AutoNSubstituteData]
        public void ValidateInitialShootServiceTests_GuardClause(
            GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(ValidateInitialShootService).GetConstructors());
        }

        [Theory]
        [AutoNSubstituteData]
        public void Process_WhenInitialShootIsTwoAndPlayerCanRetry_ShouldBreak(
            [Frozen] IConsole console,
            ValidateInitialShootService sut,
            MatchManagement matchManagement
            )
        {
            matchManagement.CurrentlyPlayer.CanRetryInitialShoot = true;
            console.ReadLine().Returns("2");

            sut.Process(matchManagement);

            matchManagement.CurrentlyPlayer.CanRetryInitialShoot.Should().Be(false);
        }

        [Theory]
        [AutoNSubstituteData]
        public void Process_WhenInitialShootIsThreeAndPlayerCanRetry_ShouldBreak(
            [Frozen] IConsole console,
            ValidateInitialShootService sut,
            MatchManagement matchManagement
            )
        {
            matchManagement.CurrentlyPlayer.CanRetryInitialShoot = true;
            console.ReadLine().Returns("3");

            sut.Process(matchManagement);

            matchManagement.CurrentlyPlayer.CanRetryInitialShoot.Should().Be(false);
        }

        [Theory]
        [AutoNSubstituteData]
        public void Process_WhenInitialShootIsFourAndPlayerCanRetry_ShouldBreak(
            [Frozen] IConsole console,
            ValidateInitialShootService sut,
            MatchManagement matchManagement
            )
        {
            matchManagement.CurrentlyPlayer.CanRetryInitialShoot = true;
            console.ReadLine().Returns("4");

            sut.Process(matchManagement);

            matchManagement.CurrentlyPlayer.CanRetryInitialShoot.Should().Be(false);
        }

        [Theory]
        [AutoNSubstituteData]
        public void Process_WhenInitialShootIsFiveAndPlayerCanRetry_ShouldBreak(
            [Frozen] IConsole console,
            ValidateInitialShootService sut,
            MatchManagement matchManagement
            )
        {
            matchManagement.CurrentlyPlayer.CanRetryInitialShoot = true;
            console.ReadLine().Returns("5");

            sut.Process(matchManagement);

            matchManagement.CurrentlyPlayer.CanRetryInitialShoot.Should().Be(false);
        }

        [Theory]
        [AutoNSubstituteData]
        public void Process_WhenInitialShootFailAndPlayerCantRetry_ShouldSetGameWinner(
            [Frozen] IConsole console,
            ValidateInitialShootService sut,
            MatchManagement matchManagement
            )
        {
            matchManagement.CurrentlyPlayer.CanRetryInitialShoot = false;
            matchManagement.NextPlayer.GameScore = 0;
            console.ReadLine().Returns("2");

            sut.Process(matchManagement);

            matchManagement.CurrentlyPlayer.GameScore.Should().Be(15);
        }

        [Theory]
        [AutoNSubstituteData]
        public void Process_WhenInitialShootSuccess_ShouldCallNext(
            [Frozen] IConsole console,
            [Frozen] IMatchManagement match,
            ValidateInitialShootService sut,
            MatchManagement matchManagement
            )
        {
            console.ReadLine().Returns("1");

            sut.Process(matchManagement);

            match.Received(1).Process(matchManagement);
        }
    }
}
