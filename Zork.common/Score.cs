using System;


namespace Zork
{
    [CommandClass]
    public static class ScoreCommand
    {
        [Command("SCORE", new string[] { "SCORE", "S" })]
        public static void Score(Game game, CommandContext commandContext)
        {
            Game.Instance.Output.WriteLine($"Your score is {game.Player.Score}, in {game.Player.Moves} moves(s).");
        }
    }
}
