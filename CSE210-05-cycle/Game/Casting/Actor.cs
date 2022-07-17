using System;


namespace Tron.Game.Casting
{


    public class Actor
    {
        private string text = "";
        private int fontSize = 15;
        private Color color = Constants.WHITE;
        private Point position = new Point(0, 0);
        private Point velocity = new Point(0, 0);

        
        private int score;


        public Actor()
        {

        }


        public Color getColor()
        {
            return color;
        }

        public int getFontSize()
        {
            return fontSize;
        }

        public Point getPosition()
        {
            return position;
        }

        public string getText()
        {
            return text;
        }

        public Point getVelocity()
        {
            return velocity;
        }

        public virtual void moveNext()
        {
            int x = ((position.getX() + velocity.getX()) + Constants.MAX_X) % Constants.MAX_X;
            int y = ((position.getY() + velocity.getY()) + Constants.MAX_Y) % Constants.MAX_Y;
            position = new Point(x, y);
        }


        public void placeColor(Color color)
        {
            if (color == null)
            {
                throw new ArgumentException("Color can't be null");
            }
            this.color = color;
        }

        public void placeFontSize( int fontSize)
        {
            if (fontSize <=0)
            {
                throw new ArgumentException("Fontsize must be greater than zero");
            }
            this.fontSize = fontSize;
        }

        public void placePosition(Point position)
        {
            if (position == null)
            {
                throw new ArgumentException("Position can't be null");
            }
            this.position = position;
        }

        public void placeText(string text)
        {
            if (text == null)
            {
                throw new ArgumentException("text can't be null");
            }
            this.text = text;
        }    

        public void placeVelocity(Point velocity)
        {
            if (velocity == null)
            {
                throw new ArgumentException("velocity can't be null");
            }
            this.velocity = velocity;
        }
    }
}