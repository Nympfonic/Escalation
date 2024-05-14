using EFT;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Arys.Escalation
{
    internal static class BotHelper
    {
        internal const string
            BOSS_FROST = "bossFrost",
            FOLLOWER_BANSHEE = "followerBanshee",
            FOLLOWER_CRIMSON = "followerCrimson",
            FOLLOWER_RHINO = "followerRhino",
            FOLLOWER_MIDNIGHT = "followerMidnight";

        private static readonly Dictionary<string, BotSettingsValuesClass> botSettings = new() {
            [BOSS_FROST] = new(true, false, true, "ScavRole/Boss"),
            [FOLLOWER_BANSHEE] = new(false, true, true, "ScavRole/Boss"),
            [FOLLOWER_CRIMSON] = new(false, true, true, "ScavRole/Boss"),
            [FOLLOWER_RHINO] = new(false, true, true, "ScavRole/Boss"),
            [FOLLOWER_MIDNIGHT] = new(false, true, true, "ScavRole/Boss")
        };

        internal static void AddCustomBots()
        {
            var botDictionary = Traverse
                .Create<BotSettingsRepoClass>()
                .Field<Dictionary<Enum, BotSettingsValuesClass>>("dictionary_0")
                .Value;

            Type wildSpawnType = typeof(WildSpawnType);

            string[] wildSpawnNames = Enum.GetNames(wildSpawnType);

            foreach (string name in botSettings.Keys.Where(wildSpawnNames.Contains).ToArray())
            {
                var enumKey = (WildSpawnType)Enum.Parse(wildSpawnType, name);
                var settingsValue = botSettings[name];

                botDictionary.Add(enumKey, settingsValue);
            }
        }
    }
}
