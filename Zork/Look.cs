using System;


namespace Zork
{
    //[CommandClass]
    public static class LookCommand
    {
        [CommandClass("LOOK", new string[] { "LOOK", "L" })]
        public static void Look(Game game, CommandContext commandContext) => Console.WriteLine(game.Player.Location.Description);
    }
}
