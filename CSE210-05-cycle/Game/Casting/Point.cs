namespace Tron.Game.Casting
{
    public class Point
    {
        private int x = 0;
        private int y = 0;



        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Point Add(Point other)
        {
            int x = this.x + other.getX();
            int y = this.y + other.getY();
            return new Point(x, y);
        }

        public bool Equals(Point other)
        {
            return this.x == other.getX() && this.y == other.getY();
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }
        public Point Reverse()
        {
            int x = this.x * -1;
            int y = this.y * -1;
            return new Point(x, y);
        }
        public Point Scale(int factor)
        {
            int x = this.x * factor;
            int y = this.y * factor;
            return new Point(x, y);
        }
    }
}