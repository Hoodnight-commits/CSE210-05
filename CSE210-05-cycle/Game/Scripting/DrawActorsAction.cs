using System.Collections.Generic;
using Tron.Game.Casting;
using Tron.Game.Services;


namespace Tron.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {

            Player1 playerOne = (Player1)cast.GetFirstActor("playerOne");
            Player2 playerTwo = (Player2)cast.GetFirstActor("playerTwo");
            // playerTwo.SetPosition();
            List<Actor> segmentsOne = playerOne.GetSegments();
            List<Actor> segmentsTwo = playerTwo.GetSegments();
            List<Actor> messages = cast.GetActors("messages");
            
            videoService.ClearBuffer();
            videoService.DrawActors(segmentsOne);
            videoService.DrawActors(segmentsTwo);
            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}