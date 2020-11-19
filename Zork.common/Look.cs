using System;
using System.Text;
using System.Collections.Generic;

namespace Zork
{
    [CommandClass]
    public static class LookCommand
    {
        [Command("LOOK", new string[] { "LOOK", "L" })]
        public static void Look(Game game, CommandContext commandContext) => Console.WriteLine(game.Player.Location.Description);
    }
}
