using Synapse.Config;

namespace Example_Plugin
{
    public class PluginConfig : IConfigSection
    {
        public int damagePercent = 10;
        public int damageDelay = 3000;
    }
}