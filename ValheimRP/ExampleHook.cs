using ExampleMod.Util;
using HarmonyLib;

namespace ExampleMod
{
    internal static class ExampleHook
    {
        internal static Harmony HarmonyInstance;

        /// <summary>
        /// Show that you can use either monomod hooks, or harmony patches for hooking game methods.
        /// </summary>
        internal static void Init()
        {
            EnableMonoModHooks();

            EnableHarmonyPatches();
        }

        /// <summary>
        /// Disable the enabled hooks.
        /// </summary>
        internal static void Disable()
        {
            DisableMonoModHooks();

            DisableHarmonyPatches();
        }

        private static void EnableMonoModHooks()
        {
            On.FejdStartup.Awake += OnFejdStartupAwakeMonoModHookShowcase;
        }

        internal static void DisableMonoModHooks()
        {
            On.FejdStartup.Awake -= OnFejdStartupAwakeMonoModHookShowcase;
        }

        private static void EnableHarmonyPatches()
        {
            HarmonyInstance = new Harmony(ExampleMod.ModGuid);
            HarmonyInstance.PatchAll();
        }

        private static void DisableHarmonyPatches()
        {
            HarmonyInstance.UnpatchSelf();
        }

        private static void OnFejdStartupAwakeMonoModHookShowcase(On.FejdStartup.orig_Awake orig, FejdStartup self)
        {
            // calling the original method
            orig(self);
        }
    }

    [HarmonyPatch(typeof(FejdStartup))]
    [HarmonyPatch("Awake")]
    internal class ShowcaseHarmonyPatch
    {
        static bool Prefix(FejdStartup __instance)
        {
            return true; 
        }

        static void Postfix(FejdStartup __instance)
        {
            
        }
    }
}
