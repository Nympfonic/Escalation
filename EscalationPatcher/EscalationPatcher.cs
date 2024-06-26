﻿using BepInEx.Logging;
using Mono.Cecil;
using System.Collections.Generic;

namespace Arys.Escalation
{
    public static class EscalationPatcher
    {
        public static IEnumerable<string> TargetDLLs { get; } = new[] { "Assembly-CSharp.dll" };

        internal static readonly ManualLogSource LogSource = Logger.CreateLogSource("Arys-EscalationPatcher");

        public static void Patch(ref AssemblyDefinition assembly)
        {
            AddPmcBots(ref assembly);
        }

        private static void AddPmcBots(ref AssemblyDefinition assembly)
        {
            TypeDefinition wildSpawnType = assembly.MainModule.GetType("EFT.WildSpawnType");

            PatcherHelper.AddEnumValues(ref wildSpawnType, 
                EscalationData.BOSS_FROST,
                EscalationData.FOLLOWER_BANSHEE,
                EscalationData.FOLLOWER_CRIMSON,
                EscalationData.FOLLOWER_RHINO,
                EscalationData.FOLLOWER_MIDNIGHT
            );
        }
    }
}
