using BepInEx;
using BepInEx.Logging;
using GameNetcodeStuff;
using HarmonyLib;
using LethalCompanyMods.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ScannablePlayersMod
{
    [BepInPlugin(modGUID, modName, modVersion)]

    public class ModBase : BaseUnityPlugin
    {

        private const string modGUID = "Obsidian.Lithium.ScannablePlayers";
        private const string modName = "Lithium";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static ModBase Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

    }
}
