using System;

namespace Zork
{
    [CommandClass]
    public static class RewardCommand
    {
        [Command("REWARD", new string[] { "REWARD", "R" })]
        public static void Reward(Game game, CommandContext commandContext)
        {
            Game.Instance.Player.Score += 5;
        }
    }
}
