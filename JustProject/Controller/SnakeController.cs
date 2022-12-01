using JustProject.Model;
using System.ComponentModel.DataAnnotations;

namespace JustProject.Controller
{
    class GameController
    {
        private ConsoleKey? Direct = null;
        public Snake Snake { get; }
        public FoodController FoodController { get; }
        public MapModel Map { get; }
        public GameController() : this(5, 5)
        {
        }
        public GameController(int mapWeight, int mapHeight)
        {
            Snake = new Snake();
            Map = new MapModel(mapWeight, mapHeight);
            FoodController = new FoodController(Map);
            Map[1, 1] = '0';
            ShowMap();
        }
        public void Move(ConsoleKey key)
        {
            Console.Clear();
            switch (key)
            {
                case ConsoleKey.W:
                    if (Snake.Head.Y == 1 || (Snake.Head.Y == Map.Height - 2 && Snake.Count > 1 && Direct == ConsoleKey.S)) throw new ArgumentOutOfRangeException("End of map.", nameof(key));
                    if (Snake.Count > 1 && Direct == ConsoleKey.S) { MoveBodyPart(ConsoleKey.S); ShowMap(); return; }
                    break;
                case ConsoleKey.A:
                    if (Snake.Head.X == 1 || (Snake.Head.X == Map.Weight - 2 && Snake.Count > 1 && Direct == ConsoleKey.D)) throw new ArgumentOutOfRangeException("End of map.", nameof(key));
                    if (Snake.Count > 1 && Direct == ConsoleKey.D) { MoveBodyPart(ConsoleKey.D); ShowMap(); return; }
                    break;
                case ConsoleKey.S:
                    if (Snake.Head.Y == Map.Height - 2 || (Snake.Head.Y == 1 && Snake.Count > 1 && Direct == ConsoleKey.W)) throw new ArgumentOutOfRangeException("End of map.", nameof(key));
                    if (Snake.Count > 1 && Direct == ConsoleKey.W) { MoveBodyPart(ConsoleKey.W); ShowMap(); return; }
                    break;
                case ConsoleKey.D:
                    if (Snake.Head.X == Map.Weight - 2 || (Snake.Head.X == 1 && Snake.Count > 1 && Direct == ConsoleKey.A)) throw new ArgumentOutOfRangeException("End of map.", nameof(key));
                    if (Snake.Count > 1 && Direct == ConsoleKey.A) { MoveBodyPart(ConsoleKey.A); ShowMap(); return; }
                    break;
                default:
                    break;
            }
            MoveBodyPart(key);
            ShowMap();
        }
        public void CheckCollision()
        {
            var temp = Snake.Tail;
            while (temp != Snake.Head)
            {
                if (temp.X == Snake.Head.X && temp.Y == Snake.Head.Y)
                {
                    throw new InvalidOperationException("Overturning the head of the tail");
                }
                temp = temp.Previous;
            }
        }
        private void MoveBodyPart(ConsoleKey info)
        {
            bool isAdded = false;
            if (Snake.Tail.IsAte)
            {
                Snake.Tail.IsAte = false;
                Snake.Add(Snake.Head.X, Snake.Head.Y);\
                isAdded = true;
            }
            var coordinates = Snake.Tail;
            while (coordinates != null)
            {
                if (coordinates.Next == null && !isAdded)
                {
                    Map[coordinates.Y, coordinates.X] = ' ';
                }
                else
                {
                    Map[coordinates.Y, coordinates.X] = '0';
                }
                if (coordinates.Previous != null)
                {
                    coordinates.X = coordinates.Previous.X;
                    coordinates.Y = coordinates.Previous.Y;
                    coordinates.IsAte = coordinates.Previous.IsAte;
                }
                if (coordinates.Previous == null)
                { Snake.Head.IsAte = false; }
                coordinates = coordinates.Previous;
            }
            switch (info)
            {
                case ConsoleKey.W:
                    Snake.Head.Y--;
                    break;
                case ConsoleKey.A:
                    Snake.Head.X--;
                    break;
                case ConsoleKey.S:
                    Snake.Head.Y++;
                    break;
                case ConsoleKey.D:
                    Snake.Head.X++;
                    break;
            }
            CheckCollision();
            if (Map[Snake.Head.Y, Snake.Head.X] == 'o')
            {
                Snake.Head.IsAte = true;
                FoodController.Generate();
            }
            Map[Snake.Head.Y, Snake.Head.X] = '0';
            Direct = info;
        }
        private void ShowMap()
        {
            foreach(var part in Map)
            {
                Console.WriteLine(part);
            }
        }
    }
}
