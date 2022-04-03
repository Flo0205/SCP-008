using Synapse.Api.Plugin;
using Synapse.Translation;

namespace SCP008
{
    [PluginInformation(
        Author = "Flo0205",
        LoadPriority = 0,
        Name = "SCP008",
        Description = "Let the zombies have fun too!",
        SynapseMajor = 2,
        SynapseMinor = 10,
        SynapsePatch = 0,
        Version = "1.0.2"
    )]
    public class PluginClass : AbstractPlugin
    {
        [Config(section = "SCP008")]
        public static readonly PluginConfig Config;

        [SynapseTranslation]        
        public new static SynapseTranslation<PluginTranslation> Translation { get; set; }
        
        public override void Load()
        {
            SynapseController.Server.Logger.Info("SCP008 Load");

            //Translations
            Translation.AddTranslation(new PluginTranslation());
            Translation.AddTranslation(new PluginTranslation
            {
                Infected = "Du wurdest infiziert, versuch dich schnell zu heilen!",
                Zombification = "Du wurdest zu einem Zombie!",
                Heal = "Du konntest dich heilen!"
            }, "GERMAN");
            Translation.AddTranslation(new PluginTranslation
            {
                Infected = "あなたは感染しています、すぐに自分を癒してみてください！",
                Zombification = "あなたはゾンビになりました！",
                Heal = "あなたは自分自身を癒すことができます！"
            }, "JAPANESE");
            Translation.AddTranslation(new PluginTranslation
            {
                Infected = "¡Has sido infectado, trata de curarte rápidamente!",
                Zombification = "¡Te convertiste en un zombi!",
                Heal = "¡Podrías curarte a ti mismo!"
            }, "SPANISH");
            
            //Eventhandlers
            _ = new EventHandlers();
        }
    }
}