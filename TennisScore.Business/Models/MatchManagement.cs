namespace TennisScore.Business.Models
{
    public class MatchManagement
    {
        public int TotalSets { get; private set; }

        public void WithSets(int set) => TotalSets = set;
    }
}
