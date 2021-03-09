using System;
using HarmonyLib;
using JetBrains.Annotations;

namespace ValheimRP {
    [HarmonyPatch(typeof(Player), "OnDamaged")]
    internal class VRPPlayer {
        /// <summary>
        /// Logs any damage done to the player.
        /// </summary>
        /// <param name="__instance">Player instance being damaged.</param>
        /// <param name="hit">Context of the hit being performed.</param>
        /// <returns>true always</returns>
        [UsedImplicitly]
        private static bool Prefix(Player __instance, HitData hit) {
            var attacker = hit.GetAttacker();
            var attackerName = "enemy or environment";
            if (attacker)
                attackerName = attacker.m_name;
            
            var damage = hit.GetTotalDamage();
            
            Log.LogInfo($"[Hit] {__instance.GetPlayerName()} hit by {attackerName} for {damage}dmg");
            return true;
        }
    }
}