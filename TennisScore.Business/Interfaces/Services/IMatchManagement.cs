using TennisScore.Business.Models;

namespace TennisScore.Business.Interfaces.Services
{
    public interface IMatchManagement
    {
        void Process(MatchManagement match);
    }
}
