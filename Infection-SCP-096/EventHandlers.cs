using System;
using System.Linq;
using Exiled.Events.EventArgs;
using MEC;

namespace Infection_SCP_096
{
    public class EventHandlers
    {

        public void OnDying(DyingEventArgs events)
        {
            Timing.CallDelayed(Plugin.singleton.Config.Delay, () =>
            {
                if (events.Killer.Role != RoleType.Scp096)
                {
                    events.Target.SetRole(RoleType.Scp096);
                }
            });
        }
    }
}