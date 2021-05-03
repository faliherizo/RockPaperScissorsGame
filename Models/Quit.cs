namespace RockPaperScissorsGame.Models
{
    public class Quit : IChoice
    {
        public string Name { get { return "Quit"; } }
        public bool? WinsFrom(IChoice otherChoice)
        {
            return true;
        }
    }
}
