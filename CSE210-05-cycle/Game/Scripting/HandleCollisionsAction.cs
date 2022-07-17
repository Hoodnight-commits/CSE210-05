using System;
using System.Collections.Generic;
using System.Data;
using Tron.Game.Casting;
using Tron.Game.Services;


namespace Tron.Game.Scripting
{

    public class HandleCollisionsAction : Action
    {
        private bool isGameOver = false;
        private string gameOverMsg = "";

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                HandleSegmentCollisions(cast);
                HandleGameOver(cast);
            }
        }


        private void HandleSegmentCollisions(Cast cast)
        {
            Player1 playerOne = (Player1)cast.GetFirstActor("playerOne");
            Player2 playerTwo = (Player2)cast.GetFirstActor("playerTwo");
            Actor headOne = playerOne.GetHead();
            Actor headTwo = playerTwo.GetHead();
            List<Actor> bodyOne = playerOne.GetBody();
            List<Actor> bodyTwo = playerTwo.GetBody();

            

            foreach (Actor segment in bodyOne)
            {
                if (headTwo.getPosition().Equals(segment.getPosition()))
                {
                    isGameOver = true;
                    gameOverMsg = "Player Two Loses";
                }
                if (segment.getPosition().Equals(headOne.getPosition()))
                {
                    isGameOver = true;
                    gameOverMsg = "You ran into yourself! Player One Loses!";
                }
            }
            foreach (Actor segment in bodyTwo)
            {
                if (headOne.getPosition().Equals(segment.getPosition()))
                {
                    isGameOver = true;
                    gameOverMsg = "Player One Loses";
                }
                if (segment.getPosition().Equals(headTwo.getPosition()))
                {
                    isGameOver = true;
                    gameOverMsg = "You ran into yourself! Player Two Loses!";
                }
            }
        }

        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                Player1 playerOne = (Player1)cast.GetFirstActor("playerOne");
                Player2 playerTwo = (Player2)cast.GetFirstActor("playerTwo");
                List<Actor> segmentsOne = playerOne.GetSegments();
                List<Actor> segmentsTwo = playerTwo.GetSegments();
                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.placeText($"Game Over!\n{gameOverMsg}");
                message.placePosition(position);
                cast.AddActor("messages", message);

                // make everything white
                foreach (Actor segment in segmentsOne)
                {
                    segment.placeColor(Constants.WHITE);
                }
                foreach (Actor segment in segmentsTwo)
                {
                    segment.placeColor(Constants.WHITE);
                }
            }
        }

    }
}