using JustProject.Model;

namespace JustProject.Controller
{
    class FoodController
    {
        public Food Food { get; set; }
        public MapModel Map { get; set; }
        public FoodController(MapModel map)
        {
            Map = map;
            Generate();
        }
        public void Generate()
        {
            Random rnd = new Random();
            List<(int, int)> temp = new List<(int, int)>();
            for (int i = 0; i < Map.Height; i++)
            {
                for (int j = 0; j < Map.Weight; j++)
                {
                    if (Map[i, j] == ' ') temp.Add((i, j));
                }
            }
            (int x, int y) = temp[rnd.Next(temp.Count)];
            Food = new Food(x, y);
            Map[x, y] = 'o';
        }
    }
}
