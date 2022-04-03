using Synapse.Api;
using System.Threading.Tasks;

namespace SCP008
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
            while (DamagePlayer && player != null)
            {
                await Task.Delay(PluginClass.Config.DamageDelay);
                if (!DamagePlayer || player == null) return;
                int newHealth = (int) (player.Health - player.MaxHealth / 100 * PluginClass.Config.DamagePercent);
                if (newHealth <= 0)
                {
                    player.Inventory.DropAll();
                    player.ChangeRoleAtPosition(RoleType.Scp0492);
                    player.Health = player.MaxHealth;
                    player.GiveTextHint(PluginClass.Translation.ActiveTranslation.Zombification, 10);
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