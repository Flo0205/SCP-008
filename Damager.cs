using Synapse.Api;
using System.Threading.Tasks;
using Example_Plugin;

namespace ZombieVampire
{
    public class Damager
    {
        public bool DamagePlayer { get; set; } = true;
        public Damager(Player player)
        {
            player.GiveTextHint(PluginClass.Translation.ActiveTranslation.Infected);
            var _ = DamagePlayerAsync(player);
        }

        private async Task DamagePlayerAsync(Player player)
        {
            while (DamagePlayer)
            {
                await Task.Delay(PluginClass.Config.damageDelay);
                int newHealth = (int) player.Health - player.MaxHealth / 100 * PluginClass.Config.damagePercent;
                if (newHealth <= 0)
                {
                    player.Inventory.DropAll();
                    player.ChangeRoleAtPosition(RoleType.Scp0492);
                    player.Health = player.MaxHealth;
                    player.GiveTextHint(PluginClass.Translation.ActiveTranslation.Zombification);
                    DamagePlayer = false;
                }
                else
                {
                    player.Health = newHealth;
                }
            }
        }
    }
}