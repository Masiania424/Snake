using JustProject.Controller;
using JustProject.Model;

namespace JustProject
{
    class Program
    {
        static void Main(string[] args)
        {
            GameController gameController = new GameController(15, 15);
            while (true)
            {
                gameController.Move(Console.ReadKey().Key);
            }
        }
    }
}
    
