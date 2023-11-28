using BepInEx;
using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Windows;

namespace LethalCompanyMods.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]

    internal class PlayerControllerBPatch
    {

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void ScannablePlayers()
        {

            List<int> playerIds = new List<int>();

            foreach (UnityEngine.GameObject player in UnityEngine.GameObject.FindGameObjectsWithTag("Player"))
            {
                if (!player.GetComponent<ScanNodeProperties>())
                {
                    player.AddComponent<ScanNodeProperties>();
                    UnityEngine.GameObject.Instantiate(UnityEngine.GameObject.Find("ScanNode")).transform.parent = player.transform;
                    player.GetComponent<ScanNodeProperties>().headerText = player.name;
                    player.GetComponent<ScanNodeProperties>().scrapValue = 0;
                    player.GetComponent<ScanNodeProperties>().requiresLineOfSight = false;
                    player.GetComponent<ScanNodeProperties>().subText = player.name;
                    player.GetComponent<ScanNodeProperties>().maxRange = 999;
                    player.GetComponent<ScanNodeProperties>().minRange = 0;
                    playerIds.Add(player.GetInstanceID());
                    //player.GetComponent<ScanNodeProperties>().creatureScanID = null;
                }
            }
        }

    }
}
