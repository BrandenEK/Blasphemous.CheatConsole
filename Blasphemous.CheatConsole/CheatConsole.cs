using Blasphemous.ModdingAPI;
using System.Collections.Generic;
using UnityEngine;

namespace Blasphemous.CheatConsole;

/// <summary>
/// Handles opening the console and registering custom commands
/// </summary>
public class CheatConsole : BlasMod
{
    internal CheatConsole() : base(ModInfo.MOD_ID, ModInfo.MOD_NAME, ModInfo.MOD_AUTHOR, ModInfo.MOD_VERSION) { }

    /// <summary>
    /// Register handlers
    /// </summary>
    protected override void OnInitialize()
    {
        InputHandler.RegisterDefaultKeybindings(new Dictionary<string, KeyCode>()
        {
            { "Console", KeyCode.Backslash }
        });
    }
}
