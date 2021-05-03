using RockPaperScissorsGame.Models;
using System;
using System.Collections.Generic;

namespace RockPaperScissors.Repositories
{
    public class RPSRepository
    {
        private static readonly Random _random = new Random();
        private static readonly IList<IChoice> choices = new List<IChoice>()
        {
            new Rock(), new Paper(), new Scissors(), new Quit(), new Invalid()
        };

        public enum Outcome
        {
            win,
            loss,
            tie
        }

        public static IChoice GetChoiceFromChar(char input)
        {
            return input switch
            {
                'r' => choices[0],
                'p' => choices[1],
                's' => choices[2],
                'q' => choices[3],
                _ => choices[4],
            };
        }

        public static IChoice GetRandomChoice()
        {
            return choices[_random.Next(0, 3)];
        }

        public static Outcome GetOutcome(IChoice userChoice1, IChoice userChoice2, Users users)
        {
            bool? userWon = userChoice1.WinsFrom(userChoice2);

            if (userWon == null)
            {
                Console.WriteLine($"you both chose {userChoice1.Name}! => It's a tie");
                return Outcome.tie;
            }

            if (Convert.ToBoolean(userWon))
            {
                Console.WriteLine($"{users.Player1} won! {userChoice1.Name} beats {userChoice2.Name}");
                return Outcome.win;
            }
            else
            {
                Console.WriteLine($"{users.Player1} lose.. {userChoice2.Name} beats {userChoice1.Name}");
                return Outcome.loss;
            }
        }
    }
}
