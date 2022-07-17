using System;
using System.Collections.Generic;
using System.Linq;

namespace Tron.Game.Casting
{
    /// <summary>
    /// <para>A long limbless reptile.</para>
    /// <para>The responsibility of Player2 is to move itself.</para>
    /// </summary>
    public class Player2 : Actor
    {
        private List<Actor> segments = new List<Actor>();
        private Point direction = new Point(0, -Constants.CELL_SIZE);
        private Point startPosition = new Point(0,0);
        private string head = "";

        /// <summary>
        /// Constructs a new instance of a Player.
        /// </summary>
        public Player2(Point startPosition, string head)
        {
            this.startPosition = startPosition;
            this.head = head;
            PrepareBody();
        }

        /// <summary>
        /// Gets the Player's body segments.
        /// </summary>
        /// <returns>The body segments in a List.</returns>
        public List<Actor> GetBody()
        {
            return new List<Actor>(segments.Skip(1).ToArray());
        }

        /// <summary>
        /// Gets the Player's head segment.
        /// </summary>
        /// <returns>The head segment as an instance of Actor.</returns>
        public Actor GetHead()
        {
            return segments[0];
        }

        /// <summary>
        /// Gets the Player's segments (including the head).
        /// </summary>
        /// <returns>A list of Player segments as instances of Actors.</returns>
        public List<Actor> GetSegments()
        {
            return segments;
        }

        /// <summary>
        /// Grows the Player's tail by the given number of segments.
        /// </summary>
        /// <param name="numberOfSegments">The number of segments to grow.</param>
        public void GrowTail(int numberOfSegments)
        {
            for (int i = 0; i < numberOfSegments; i++)
            {
                Actor tail = segments.Last<Actor>();
                Point velocity = tail.getVelocity();
                Point offset = velocity.Reverse();
                Point position = tail.getPosition().Add(offset);

                Actor segment = new Actor();
                segment.placePosition(position);
                segment.placeVelocity(velocity);
                segment.placeText("=");
                segment.placeColor(Constants.RED);
                segments.Add(segment);
            }
        }

        /// <inheritdoc/>
        public override void moveNext()
        {
            foreach (Actor segment in segments)
            {
                segment.moveNext();
            }

            for (int i = segments.Count - 1; i > 0; i--)
            {
                Actor trailing = segments[i];
                Actor previous = segments[i - 1];
                Point velocity = previous.getVelocity();
                trailing.placeVelocity(velocity);
            }
        }

        /// <summary>
        /// Turns the head of the Player in the given direction.
        /// </summary>
        /// <param name="velocity">The given direction.</param>
        public void TurnHead(Point direction)
        {
            segments[0].placeVelocity(direction);
            this.direction = direction;
        }

        public Point GetDirection()
        {
            return direction;
        }

        /// <summary>
        /// Prepares the Player body for moving.
        /// </summary>
        private void PrepareBody()
        {
            int x = startPosition.getX();
            int y = startPosition.getY();

            for (int i = 0; i < Constants.PLAYER_LENGTH; i++)
            {
                Point position = new Point(x - i * Constants.CELL_SIZE, y);
                // position.Scale(Constants.CELL_SIZE);
                Point velocity = new Point(1 * Constants.CELL_SIZE, 0);
                string text = i == 0 ? head : "=";
                Color color = i == 0 ? Constants.YELLOW : Constants.RED;

                Actor segment = new Actor();
                segment.placePosition(position);
                segment.placeVelocity(velocity);
                segment.placeText(text);
                segment.placeColor(color);
                segments.Add(segment);
            }
        }
    }
}