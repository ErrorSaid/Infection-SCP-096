using System;
using Exiled.API.Features;
using Exiled.API.Enums;

namespace Infection_SCP_096
{
    internal class Plugin : Plugin<Config>
    {
        public static Plugin singleton;
        public override string Name { get; } = "infection";
        public override string Author { get; } = "! Said";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(4, 2, 3);

        public static Config SharedConfig { get; set; }
        public static DateTime lastUsed;
        public override PluginPriority Priority => PluginPriority.Medium;

        public EventHandlers _handlers;

        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Player.Dying += _handlers.OnDying;

            _handlers = new EventHandlers();
            singleton = this;

            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.Dying -= _handlers.OnDying;

            _handlers = null;
            singleton = null;

            base.OnDisabled();
        }
    }
}