using System.Collections;

namespace JustProject.Model
{
    class Snake 
    {
        public PartOfSnake Head { get; set; }
        public PartOfSnake Tail { get; set; }
        public int Count = 0;
        public Snake()
        {
            Head = new PartOfSnake(1, 1);
            Tail = Head;
            Count++;
        }
        public void Add(int x, int y)
        {
            var temp = new PartOfSnake(x, y);
            temp.Previous = Tail;
            Tail.Next = temp;
            Tail = temp;
            Count++;
        }
    }
}
