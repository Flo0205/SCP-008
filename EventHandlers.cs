using System.Collections.Generic;
using MEC;
using Synapse;

namespace SCP008
{
    public class EventHandlers
    {
        private static readonly Dictionary<string, Damager> Damagers = new Dictionary<string, Damager>();
        
        public EventHandlers()
        {
            Server.Get.Events.Round.WaitingForPlayersEvent += OnWait;
            Server.Get.Events.Player.PlayerDamageEvent += OnDamage;
            Server.Get.Events.Player.PlayerHealEvent += OnHeal;
            Server.Get.Events.Player.PlayerDeathEvent += OnDeath;
            Server.Get.Events.Player.PlayerSetClassEvent += OnSetClass;
        }
        
        private void OnDamage(Synapse.Api.Events.SynapseEventArguments.PlayerDamageEventArgs ev)
        {
            if (ev.Killer.RoleType == RoleType.Scp0492 && ev.Victim.RoleType != RoleType.Scp0492)
            {
                foreach (string key in Damagers.Keys)
                {
                    SynapseController.Server.Logger.Warn(key);
                }

                if (!Damagers.ContainsKey(ev.Victim.UserId) && ev.Killer != ev.Victim)
                {
                    Damagers.Add(ev.Victim.UserId, new Damager(ev.Victim));
                }
            }
        }
        
        private void OnHeal(Synapse.Api.Events.SynapseEventArguments.PlayerHealEventArgs ev)
        {
            if (Damagers.ContainsKey(ev.Player.UserId))
            {
                ev.Player.GiveTextHint(PluginClass.Translation.ActiveTranslation.Heal);
                Damagers[ev.Player.UserId].DamagePlayer = false;
                Damagers.Remove(ev.Player.UserId);
            }
        }

        private void OnDeath(Synapse.Api.Events.SynapseEventArguments.PlayerDeathEventArgs ev)
        {
            Timing.CallDelayed(0.1f, () =>
            {
                if (Damagers.ContainsKey(ev.Victim.UserId))
                {
                    Damagers[ev.Victim.UserId].DamagePlayer = false;
                    Timing.CallDelayed(0.2f, () => Damagers.Remove(ev.Victim.UserId));
                }
            });
        }
        
        private void OnSetClass(Synapse.Api.Events.SynapseEventArguments.PlayerSetClassEventArgs ev)
        {
            if (Damagers.ContainsKey(ev.Player.UserId))
            {
                Damagers[ev.Player.UserId].DamagePlayer = false;
                Timing.CallDelayed(0.2f, () => Damagers.Remove(ev.Player.UserId));
                
            }
        }

        private void OnWait()
        {
            Damagers.Clear();
        }
    }
}