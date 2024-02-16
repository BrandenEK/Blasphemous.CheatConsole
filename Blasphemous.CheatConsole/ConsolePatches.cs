using Framework.Managers;
using Gameplay.UI.Console;
using Gameplay.UI.Others;
using Gameplay.UI.Widgets;
using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Blasphemous.CheatConsole;

// Allow access to console
[HarmonyPatch(typeof(ConsoleWidget), "Update")]
class Console_Enable_Patch
{
    public static void Postfix(ConsoleWidget __instance, bool ___isEnabled)
    {
        if (Main.CheatConsole.InputHandler.GetKeyDown("Console"))
        {
            __instance.SetEnabled(!___isEnabled);
        }
    }
}

// Allow console commands on the main menu
[HarmonyPatch(typeof(KeepFocus), "Update")]
class KeepFocusMain_Patch
{
    public static bool Prefix()
    {
        return ConsoleWidget.Instance == null || !ConsoleWidget.Instance.IsEnabled();
    }
}
[HarmonyPatch(typeof(ConsoleWidget), "SetEnabled")]
class Console_Disable_Patch
{
    public static void Postfix(bool enabled)
    {
        if (!enabled && Core.LevelManager.currentLevel.LevelName == "MainMenu")
        {
            Button[] buttons = Object.FindObjectsOfType<Button>();
            foreach (Button b in buttons)
            {
                if (b.name == "Continue")
                {
                    EventSystem.current.SetSelectedGameObject(b.gameObject);
                    return;
                }
            }
        }
    }
}

// Add custom mod commands to the console
[HarmonyPatch(typeof(ConsoleWidget), "InitializeCommands")]
class Console_Initialize_Patch
{
    public static void Postfix(List<ConsoleCommand> ___commands)
    {
        ___commands.AddRange(CommandRegister.Commands.Select(cmd => new ModCommandSystem(cmd) as ConsoleCommand));
    }
}
