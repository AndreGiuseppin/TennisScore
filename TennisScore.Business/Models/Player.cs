namespace TennisScore.Business.Models
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; set; } = string.Empty;
        public int Sets { get; set; }
        public int Games { get; set; }
        public int GameScore { get; set; }
        public int AdvantageScore { get; set; }
        public bool CanRetryInitialShoot { get; set; } = true;

        public void CannotRetryAnymore() => CanRetryInitialShoot = false;
        public void AddGameScore()
        {
            var scores = new List<int>
            {
                0, 15, 30, 40
            };

            var indexScore = scores.IndexOf(GameScore);

            if (indexScore == scores.Count() - 1)
            {
                AdvantageScore += 1;
                return;
            }

            GameScore = scores[indexScore + 1];
        }
    }
}
