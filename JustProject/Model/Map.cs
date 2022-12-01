using System.Collections;
using System.Runtime.CompilerServices;

namespace JustProject.Model
{
    class MapModel : IEnumerable
    {
        public int Weight { get; }
        public int Height { get; }
        public char[][] Map { get; private set; }
        public char this[int index1, int index2]
        {
            get { return Map[index1][index2]; }
            set { Map[index1][index2] = value; }
        }
        public MapModel(int weight, int height)
        {
            // TODO: Check map size.
            Weight = weight + 2;
            Height = height + 2;
            CreateMap();
        }
        
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Map.Length; i++)
            {
                yield return string.Join("", Map[i]);
            }
        }

        private void CreateMap()
        {
            Map = new char[Height][];
            Map[0] = Enumerable.Repeat('.', Weight).ToArray();
            for (int j = 1; j < Height - 1; j++)
            {
                Map[j] = new char[] { '.' }.Concat(Enumerable.Repeat(' ', Weight - 2)).Concat(new char[] { '.' }).ToArray();
            }
            Map[^1] = Enumerable.Repeat('.', Weight).ToArray();
        }
    }
}
