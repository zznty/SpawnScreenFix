using HarmonyLib;
using VRage.Plugins;

namespace SpawnScreenFix
{
    public class Plugin : IPlugin
    {
        public void Dispose()
        {
        }

        public void Init(object gameInstance)
        {
            new Harmony(typeof(Plugin).Namespace).PatchAll(typeof(Plugin).Assembly);
        }

        public void Update()
        {
        }
    }
}