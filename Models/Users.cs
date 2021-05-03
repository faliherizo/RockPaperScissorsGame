namespace RockPaperScissorsGame.Models
{
    public class Users
    {
        public string Player1 { get; set; }
        public string Player2 { get; set; }
        public Users(string player1, string player2)
        {
            Player1 = player1;
            Player2 = player2;
        }
    }
}