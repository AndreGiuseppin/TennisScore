using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;

namespace TennisScore.Tests.Attributes
{
    public class AutoNSubstituteDataAttribute : AutoDataAttribute
    {
        public AutoNSubstituteDataAttribute()
            : base(() => new Fixture().Customize(new AutoNSubstituteCustomization
            {
                ConfigureMembers = true
            }))
        {
        }
    }
}
