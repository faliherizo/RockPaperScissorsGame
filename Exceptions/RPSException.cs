using System;

namespace RockPaperScissorsGame.Exceptions
{
    public class RPSException : Exception
    {
        public RPSException(string message) : base(message)
        {
        }
    }
}