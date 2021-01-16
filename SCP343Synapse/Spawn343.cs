using MEC;
using Synapse;
using Synapse.Api;
using Synapse.Command;
using System.Linq;

namespace SCP343Synapse
{
    [CommandInformation(
    Name = "spawn343",
    Aliases = new[] { "s343" },
    Description = ":bonkcat:",
    Permission = "spawn343",
    Platforms = new[] { Platform.ClientConsole, Platform.RemoteAdmin },
    Usage = ".spawn343"
    )]
    class Spawn343 : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            var result = new CommandResult();
            Player p = context.Player;
            if (!p.HasPermission("spawn343"))
            {
                result.Message = "You do not have the permission spawn343!";
                result.State = CommandResultState.NoPermission;
                return result;
            }
            if (EventHandlers.scp343.Count != 0)
            {
                result.Message = "There already is a living SCP-343!";
                result.State = CommandResultState.Error;
                return result;
            }
            if (context.Arguments.Count < 1)
            {
                context.Player.RoleID = 1;
                Timing.CallDelayed(1f, () =>
                {
                    EventHandlers.Spawn343(context.Player);
                });
                result.Message = "You are now SCP-343!";
                result.State = CommandResultState.Ok;
                return result;
            }
            if(context.Arguments.Count <= 1)
            {
                Player target = Server.Get.GetPlayer(context.Arguments.At(0));
                if (target == null)
                {
                    result.Message = $"The player {context.Arguments.At(0)} is invalid";
                    result.State = CommandResultState.Error;
                }
                context.Player.RoleID = 1;
                Timing.CallDelayed(1f, () =>
                {
                    EventHandlers.Spawn343(context.Player);
                });
                result.Message = "You are now SCP-343!";
                result.State = CommandResultState.Ok;
                return result;
            }
            result.Message = "Usage: Spawn343";
            result.State = CommandResultState.Error;
            return result;
        }
    }
}
