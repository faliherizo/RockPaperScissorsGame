namespace RockPaperScissorsGame.Models
{
    public class Rock : IChoice
    {
        public string Name { get { return "Rock"; } }
        public bool? WinsFrom(IChoice otherChoice)
        {
            return otherChoice.Name switch
            {
                "Rock" => null,
                "Paper" => false,
                "Scissors" => true,
                _ => null
            };
        }
    }
}
