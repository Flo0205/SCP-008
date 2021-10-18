using Synapse.Translation;

namespace SCP008
{
    public class PluginTranslation : IPluginTranslation
    {
        public string Infected { get; set; } = "You have been infected, try to heal yourself quickly!";
        public string Zombification { get; set; } = "You became a zombie!";
        public string Heal { get; set; } = "You could heal yourself!";
    }
}