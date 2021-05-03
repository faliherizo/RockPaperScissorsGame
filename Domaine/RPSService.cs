using System;
using RockPaperScissors.Repositories;
using RockPaperScissorsGame.Exceptions;
using RockPaperScissorsGame.Models;
using System.Collections.Generic;

namespace RockPaperScissors.Domaine
{
    public class RPSService:IRPSService
    {
        private IList<String> _players = new List<string>();
        private bool _giveName = false;
        private Score score;
        private Users users;
        public void ExecuteVsComputer()
        {
            users = new Users("You", "Computer");
            score = new Score(users);
            while (true)
            {
                Console.WriteLine("\nRock [r] Paper [p] Scissors [s] Quit [q]");
                string userInput = Console.ReadLine();
                try
                {
                    var userChoice = GetUserChoise(userInput);
                    if (userChoice.Name.Equals("Quit")) break;
                    if (userChoice.Name.Equals("Invalid"))
                    {
                        continue;
                    }
                    IChoice randomChoice = RPSRepository.GetRandomChoice();
                    RPSRepository.Outcome outcome = RPSRepository.GetOutcome(userChoice, randomChoice, users);
                    GiveScore(outcome, score);
                }
                catch (Exception ex)
                {
                    throw new RPSException("Invalid input" + ex);
                }
            }
        }
        private void GiveScore(RPSRepository.Outcome outcome, Score score)
        {
            if (outcome.Equals(RPSRepository.Outcome.loss)) score.otherScore++;
            if (outcome.Equals(RPSRepository.Outcome.win)) score.myScore++;
            Console.WriteLine(score);
        }
        private IChoice GetUserChoise(string userInput)
        {
            char userChar = Convert.ToChar(userInput);
            IChoice userChoice = RPSRepository.GetChoiceFromChar(userChar);
            return userChoice;
        }
        private void ExecuteVsTwoPlayers()
        {
            int i = 1;
            while (true)
            {
                try
                {
                    if(_giveName != true){
                        GetPlayer(1);
                        GetPlayer(2);
                        users = new Users(_players[0], _players[1]);
                        score = new Score(users);
                    }
                    Console.WriteLine("-------------"+i+"em--------------");
                    _giveName = true;
                    var userChoice1 = GetPlayerChoice(_players[0], 0);
                    var userChoice2 = GetPlayerChoice(_players[1], 1);
                    RPSRepository.Outcome outcome = RPSRepository.GetOutcome(userChoice1, userChoice2, users);
                    GiveScore(outcome, score);
                } catch(Exception ex)
                {
                    throw new RPSException("Invalid input" + ex);
                }
               i++;
            }

        }

        private IChoice GetPlayerChoice(string player, int number)
        {
            Console.WriteLine("Choice for "+player + ":");
            Console.WriteLine("\nRock [r] Paper [p] Scissors [s] Quit [q]");
            string userInput = Console.ReadLine();
            char userChar = Convert.ToChar(userInput); 
            var userChoice = RPSRepository.GetChoiceFromChar(userChar);
            if (userChoice.Name.Equals("Invalid"))
            {
                Console.WriteLine("Character '"+userInput+"' is not valid"); 
                GetPlayerChoice(player, number);
            }
            return userChoice;
        }
        private void GetPlayer(int numPlayer)
        { 
            Console.WriteLine("Name of player "+numPlayer+": ");
            string userInput = Console.ReadLine();
            if(String.IsNullOrEmpty(userInput))
            {
                GetPlayer(numPlayer);
            }
            _players.Add(userInput);
        }
        public void Run()
        {
            Console.WriteLine("Number of players? Type 2 or 1 if you like to play with Computers");
            string userInput = Console.ReadLine();
            switch(userInput)
            {
                case "1" :
                    ExecuteVsComputer();
                    break;
                case "2" : 
                    ExecuteVsTwoPlayers();
                    break;
                default:
                    ReRun(userInput);
                    break;
            };
        }
        private void ReRun(string userInput)
        {
            Console.WriteLine("Character '"+userInput+"' is not valid"); 
            this.Run();
        }
        
    }
    
}
