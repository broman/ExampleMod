using System;
using HarmonyLib;
using JetBrains.Annotations;
using UnityEngine;

namespace ValheimRP {
    [HarmonyPatch(typeof(Chat), "OnNewChatMessage")]
    internal class VRPChat {
        /// <summary>
        /// Logs all chat messages and pings.
        /// </summary>
        /// <param name="senderID">ID of the player sending that chat.</param>
        /// <param name="pos">Sender's current position, or ping position if ping.</param>
        /// <param name="type">Channel the chat is being sent through.</param>
        /// <param name="user">Sender's character name.</param>
        /// <param name="text">Content of the chat.</param>
        /// <returns>true always</returns>
        [UsedImplicitly]
        private static bool Prefix(ref long senderID, ref Vector3 pos, ref Talker.Type type,
            ref string user, ref string text) {
            Log.LogInfo($"[Chat] [{Enum.GetName(typeof(Talker.Type), type)}] {user} ({senderID}) {pos}: {text}");
            return true;
        }
    }
}