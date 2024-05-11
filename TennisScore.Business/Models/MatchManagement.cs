namespace TennisScore.Business.Models
{
    public class MatchManagement
    {
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }
        public int TotalSets { get; private set; }
        public string ShootChoice { get; private set; } = string.Empty;
        public Player CurrentlyPlayer { get; set; }
        public Player NextPlayer { get; set; }


        public void WithSets(int set) => TotalSets = set;
        public string ReturnShootChoice()
        {
            var choices = new List<string>
            {
                "1 - Saque na area oposta",
                "2 - Saque na mesma area",
                "3 - Saque na rede",
                "4 - Saque pra fora",
                "5 - Saque pisando na linha de base ou na linha central"
            };

            return ShootChoice = string.Join("\n", choices);
        }

        public void ResetPlayersInitialShootRetry()
        {
            CurrentlyPlayer.CanRetryInitialShoot = true;
            NextPlayer.CanRetryInitialShoot = true;
        }

        public void ChangePlayersPosition()
        {
            var currentlyPlayer = CurrentlyPlayer;
            CurrentlyPlayer = NextPlayer;
            NextPlayer = currentlyPlayer;

            ResetPlayersInitialShootRetry();
        }
    }
}
