using Synapse.Api.Plugin;
using Synapse.Translation;

namespace Example_Plugin
{
    [PluginInformation(
        Author = "Flo0205",
        LoadPriority = 0,
        Name = "SCP008",
        Description = "Let the zombies have fun too!",
        SynapseMajor = 2,
        SynapseMinor = 7,
        SynapsePatch = 1,
        Version = "1.0.0"
    )]
    public class PluginClass : AbstractPlugin
    {
        [Config(section = "SCP008")]
        public static readonly PluginConfig Config;

        [SynapseTranslation]        
        public new static SynapseTranslation<Translation> Translation { get; set; }
        
        public override void Load()
        {
            SynapseController.Server.Logger.Info("SCP008 Load");

            //Translations
            Translation.AddTranslation(new Translation());
            Translation.AddTranslation(new Translation
            {
                Infected = "Du wurdest infiziert, versuch dich schnell zu heilen!",
                Zombification = "Du wurdest zu einem Zombie!",
                Heal = "Du konntest dich heilen!"
            }, "GERMAN");
            Translation.AddTranslation(new Translation
            {
                Infected = "あなたは感染しています、すぐに自分を癒してみてください！",
                Zombification = "あなたはゾンビになりました！",
                Heal = "あなたは自分自身を癒すことができます！"
            }, "JAPANESE");
            Translation.AddTranslation(new Translation
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