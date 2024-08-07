﻿using Blasphemous.ModdingAPI;
using System.Collections.Generic;
using System.Linq;

namespace Blasphemous.CheatConsole;

/// <summary> Registers a new console command </summary>
public static class CommandRegister
{
    private static readonly List<ModCommand> _commands = new();
    internal static IEnumerable<ModCommand> Commands => _commands;

    /// <summary> Registers a new console command </summary>
    public static void RegisterCommand(this ModServiceProvider provider, ModCommand command)
    {
        if (provider == null)
            return;

        if (_commands.Any(cmd => cmd.CommandName == command.CommandName))
            return;

        _commands.Add(command);
        ModLog.Info($"Registered custom command: {command.CommandName}");
    }
}
