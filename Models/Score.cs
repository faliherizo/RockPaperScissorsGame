namespace RockPaperScissorsGame.Models
{
    public class Score
    {
        private Users Users;
        public Score(Users users)
        {
            Users = users;
        }
        public int myScore { get; set; }
        public int otherScore { get; set; }

        public override string ToString()
        {
            return $"{Users.Player1} : {myScore} - {Users.Player2} : {otherScore}";
        }
    }
}
