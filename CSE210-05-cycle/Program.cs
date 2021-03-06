using Tron.Game.Casting;
using Tron.Game.Directing;
using Tron.Game.Scripting;
using Tron.Game.Services;
using Tron.Game;


namespace Tron
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();
            // cast.AddActor("food", new Food());
            int x1 = Constants.MAX_X / 2;
            int y1 = Constants.MAX_Y / 2;

            int x2 = (Constants.MAX_X / 7);
            int y2 = (Constants.MAX_Y / 7);

            Point startPositionOne = new Point(x1, y1);
            Point startPositionTwo = new Point(x2, y2);
            startPositionTwo = startPositionTwo.Scale(Constants.CELL_SIZE);

            // Point startPositionTwo = new Point(x1, y1);

            cast.AddActor("playerOne", new Player1(startPositionOne, "1"));
            cast.AddActor("playerTwo", new Player2(startPositionTwo, "2"));
            // cast.AddActor("score", new Score());

            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);

            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlPlayerOneAction(keyboardService));
            script.AddAction("input", new ControlPlayerTwoAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}