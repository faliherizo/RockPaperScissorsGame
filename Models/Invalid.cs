namespace RockPaperScissorsGame.Models
{
    public class Invalid : IChoice
    {
        public string Name { get { return "Invalid"; } }
        public bool? WinsFrom(IChoice otherChoice)
        {
            return true;
        }
    }
}
