﻿using BepInEx;

namespace Arys.Escalation
{
    [BepInPlugin("com.Arys.Escalation", "Arys' Escalation", "1.0.0")]
    public class EscalationMod : BaseUnityPlugin
    {
        private void Awake()
        {
            BotHelper.AddCustomBots();
        }
    }
}
