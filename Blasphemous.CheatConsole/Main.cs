using BepInEx;

namespace Blasphemous.CheatConsole;

[BepInPlugin(ModInfo.MOD_ID, ModInfo.MOD_NAME, ModInfo.MOD_VERSION)]
[BepInDependency("Blasphemous.ModdingAPI", "2.4.1")]
internal class Main : BaseUnityPlugin
{
    public static CheatConsole CheatConsole { get; private set; }

    private void Start()
    {
        CheatConsole = new CheatConsole();
    }
}
