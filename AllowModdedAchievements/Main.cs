using HarmonyLib;
using Kingmaker;
using UnityModManagerNet;
using Kingmaker.Modding;
using System.Reflection;

namespace AllowModdedAchievements
{
    public class AllowModdedAchievements
    {
        public static UnityModManager.ModEntry.ModLogger Logger;

        public static bool Load(UnityModManager.ModEntry modEntry)
        {
            Logger = modEntry.Logger;
            Harmony harmony = new Harmony(modEntry.Info.Id);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            return true;
        }
    }

    [HarmonyPatch(typeof(Player), nameof(Player.ModsUser), MethodType.Getter)]
    public static class Player_ModsUser
    {
        [HarmonyPrefix]
        public static bool Prefix(ref bool __result)
        {
            __result = false;
            return false;
        }
    }

    [HarmonyPatch(typeof(OwlcatModificationsManager), nameof(OwlcatModificationsManager.IsAnyModActive), MethodType.Getter)]
    public static class OwlcatModificationsManager_IsAnyModActive
    {
        [HarmonyPrefix]
        public static bool Prefix(ref bool __result)
        {
            __result = false;
            return false;
        }
    }
}
