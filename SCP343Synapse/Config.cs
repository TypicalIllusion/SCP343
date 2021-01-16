using Synapse.Config;
using System.ComponentModel;

namespace SCP343Synapse
{
    public class Config : AbstractConfigSection
    {
        [Description("What is the spawn chance?")]
        public int SpawnChance { get; set; } = 100;
        [Description("What is the broadcast message?")]
        public string Message { get; set; } = "You are now SCP-343";
    }
}
