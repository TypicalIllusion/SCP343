using Synapse;
using Synapse.Api.Plugin;

namespace SCP343Synapse
{
    [PluginInformation(
       Author = "TypicalIllusion",
       Description = "SCP343",
       LoadPriority = 0,
       Name = "SCP343",
       SynapseMajor = 2,
       SynapseMinor = 4,
       SynapsePatch = 2,
       Version = "1.2.1"
   )]
    class Plugin : AbstractPlugin
    {
        [Synapse.Api.Plugin.Config(section = "SCP343")]
        public static Config Config;
        public override void Load()
        {
            Server.Get.RoleManager.RegisterCustomRole<SCP343PlayerScript>();
            SynapseController.Server.Logger.Info("SCP343 Loaded");
            new EventHandlers();
        }
    }
}
