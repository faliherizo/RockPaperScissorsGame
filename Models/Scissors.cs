namespace RockPaperScissorsGame.Models
{
    public class Scissors : IChoice
    {
        public string Name { get { return "Scissors"; } }
        public bool? WinsFrom(IChoice otherChoice)
        {
            return otherChoice.Name switch
            {
                "Rock" => false,
                "Paper" => true,
                "Scissors" => null,
                _ => null
            };
        }
    }
}
