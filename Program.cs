using System;
using RockPaperScissors.Domaine;

namespace RockPaperScissorsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IRPSService rPSService = new RPSService();  
                rPSService.Run();
            } catch (Exception ex) {
                Console.WriteLine("Error ..."+ex);
            }
        }
    }
}
