using BepInEx;

namespace Blasphemous.CheatConsole;

[BepInPlugin(ModInfo.MOD_ID, ModInfo.MOD_NAME, ModInfo.MOD_VERSION)]
[BepInDependency("Blasphemous.ModdingAPI", "3.0.0")]
internal class Main : BaseUnityPlugin
{
    public static CheatConsole CheatConsole { get; private set; }

    private void Start()
    {
        CheatConsole = new CheatConsole();
    }
}
