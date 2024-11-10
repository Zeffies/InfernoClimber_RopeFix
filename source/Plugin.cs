using System.Diagnostics;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using HarmonyLib.Tools;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace RopeKeyboardFix;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;
        
    private void Awake()
    {
        // Plugin startup logic
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

        var harmony = new Harmony("com.Zeffies.RopeKeyboardFix");
        harmony.PatchAll();

    }
}
[HarmonyPatch]
public class UltimateRope_Update
{
    [HarmonyPrefix]
    [HarmonyPatch(typeof(UltimateRope), "Update")]
    public static bool FixRopeBug()
    {
        return false;
    }
}   
