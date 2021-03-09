using System;
using System.Collections;
using UnityEngine;

namespace ValheimRP.Util {
    internal static class CoroutineExtensions {
        /// <summary>
        /// Calls a method after a delay.
        /// </summary>
        /// <param name="seconds">The amount of time to wait in seconds.</param>
        /// <param name="method">The method to call after <c>seconds</c> seconds.</param>
        internal static void DelayedMethod(float seconds, Action method) {
            ValheimRP.Instance.StartCoroutine(InternalDelayedMethod(seconds, method));
        }
        
        private static IEnumerator InternalDelayedMethod(float seconds, Action method) {
            yield return new WaitForSeconds(seconds);

            method();
        }
    }
}