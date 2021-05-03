namespace RockPaperScissorsGame.Models
{
    public interface IChoice
    {
        public string Name { get; }
        public bool? WinsFrom(IChoice otherChoice);
    }
}
