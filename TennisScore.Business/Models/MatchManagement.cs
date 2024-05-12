namespace TennisScore.Business.Models
{
    public class MatchManagement
    {
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }
        public Player CurrentlyPlayer { get; set; }
        public Player NextPlayer { get; set; }
        public Player? MatchWinner { get; set; }
        public int TotalSets { get; private set; }
        public string ShootChoice { get; private set; } = string.Empty;
        public string SetChoice { get; private set; } = string.Empty;
        public bool IsTieBreak { get; set; } = false;
        public bool ReplayMatch { get; set; } = false;

        public void SetReplayMatch() => ReplayMatch = true;

        public void WithSets(int set)
        {
            if (set == 1) TotalSets = 3;
            if (set == 2) TotalSets = 5;
        }

        public string ReturnSetsChoice()
        {
            var choices = new List<string>
            {
                "1 - 3 SETS",
                "2 - 5 SETS"
            };

            return SetChoice = string.Join("\n", choices);
        }

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

        public void ValidatePlayerScore()
        {
            if (PlayerOne.AdvantageScore == 1 && PlayerTwo.AdvantageScore == 1)
            {
                PlayerOne.AdvantageScore = 0;
                PlayerTwo.AdvantageScore = 0;
            }

            if (PlayerOne.AdvantageScore == 2 && PlayerTwo.AdvantageScore == 0)
            {
                PlayerOne.Games += 1;
                ResetPlayer();
            }

            if (PlayerTwo.AdvantageScore == 2 && PlayerOne.AdvantageScore == 0)
            {
                PlayerTwo.Games += 1;
                ResetPlayer();
            }
        }

        public void ValidateGames()
        {
            if (IsTieBreak)
            {
                if (PlayerOne.Games >= 7 && PlayerTwo.Games <= PlayerOne.Games - 2)
                {
                    PlayerOne.Sets += 1;
                    ResetPlayer();
                    ResetGames();
                }

                if (PlayerTwo.Games >= 7 && PlayerOne.Games <= PlayerTwo.Games - 2)
                {
                    PlayerTwo.Sets += 1;
                    ResetPlayer();
                    ResetGames();
                }

                return;
            }

            if (PlayerOne.Games == 6 && PlayerTwo.Games <= PlayerOne.Games - 2)
            {
                PlayerOne.Sets += 1;
                ResetPlayer();
                ResetGames();
            }

            if (PlayerTwo.Games == 6 && PlayerOne.Games <= PlayerTwo.Games - 2)
            {
                PlayerTwo.Sets += 1;
                ResetPlayer();
                ResetGames();
            }

            if (PlayerOne.Games == 6 && PlayerTwo.Games == 6)
            {
                ResetPlayer();
                ResetGames();
                IsTieBreak = true;
            }

            if (PlayerOne.Games == 7 && PlayerTwo.Games <= PlayerOne.Games - 2)
            {
                PlayerOne.Sets += 1;
                ResetPlayer();
                ResetGames();
            }

            if (PlayerTwo.Games == 7 && PlayerOne.Games <= PlayerTwo.Games - 2)
            {
                PlayerTwo.Sets += 1;
                ResetPlayer();
                ResetGames();
            }
        }

        public void ValidateSets()
        {
            if (TotalSets == 3)
            {
                if (PlayerOne.Sets == 2)
                {
                    MatchWinner = PlayerOne;
                }

                if (PlayerTwo.Sets == 2)
                {
                    MatchWinner = PlayerTwo;
                }
            }

            if (TotalSets == 5)
            {
                if (PlayerOne.Sets == 3)
                {
                    MatchWinner = PlayerOne;
                }

                if (PlayerTwo.Sets == 3)
                {
                    MatchWinner = PlayerTwo;
                }
            }
        }

        public void ResetPlayer()
        {
            PlayerOne.AdvantageScore = 0;
            PlayerOne.GameScore = 0;
            PlayerTwo.AdvantageScore = 0;
            PlayerTwo.GameScore = 0;
        }

        public void ResetGames()
        {
            PlayerOne.Games = 0;
            PlayerTwo.Games = 0;
            IsTieBreak = false;
        }

        public void ResetMatch()
        {
            ResetPlayer();
            ResetGames();
            PlayerOne.Sets = 0;
            PlayerTwo.Sets = 0;
            MatchWinner = null;
            IsTieBreak = false;
            ReplayMatch = false;
        }

        public void SetGameWinner()
        {
            NextPlayer.AddGameScore();
            ValidatePlayerScore();
            ChangePlayersPosition();
            ValidateGames();
            ValidateSets();
        }
    }
}
