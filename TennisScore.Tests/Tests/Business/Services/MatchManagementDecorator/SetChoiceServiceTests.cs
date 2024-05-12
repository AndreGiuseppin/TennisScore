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
    public class SetChoiceServiceTests
    {
        [Theory]
        [AutoNSubstituteData]
        public void SetChoiceServiceTests_GuardClause(
            GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(SetChoiceService).GetConstructors());
        }

        [Theory]
        [AutoNSubstituteData]
        public void Process_WhenChoiceOneIsChosen_ShouldSetThree(
            [Frozen] IConsole console,
            SetChoiceService sut,
            MatchManagement matchManagement
            )
        {
            matchManagement.ReplayMatch = false;
            console.ReadLine().Returns("1");

            sut.Process(matchManagement);

            matchManagement.TotalSets.Should().Be(3);
        }

        [Theory]
        [AutoNSubstituteData]
        public void Process_WhenChoiceTwoIsChosen_ShouldSetFive(
            [Frozen] IConsole console,
            SetChoiceService sut,
            MatchManagement matchManagement
            )
        {
            matchManagement.ReplayMatch = false;
            console.ReadLine().Returns("2");

            sut.Process(matchManagement);

            matchManagement.TotalSets.Should().Be(5);
        }
    }
}
