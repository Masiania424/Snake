namespace JustProject.Model
{
    class PartOfSnake
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsAte { get; set; }
        public PartOfSnake Next { get; set; }
        public PartOfSnake Previous { get; set; }
        public PartOfSnake(int x, int y)
        {
            X = x; Y = y; 
            Next = null;
            Previous = null;
            IsAte = false;
        }
    }
}
