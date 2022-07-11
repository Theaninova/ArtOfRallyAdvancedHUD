using System.Reflection;
using ArtOfRallyAdvancedHUD.HUD;
using ArtOfRallyAdvancedHUD.Settings;
using HarmonyLib;
using UnityModManagerNet;

namespace ArtOfRallyAdvancedHUD
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Main
    {
        public static HUDSettings Settings = null!;

        public static UnityModManager.ModEntry.ModLogger Logger = null!;
        
        public static UnityModManager.ModEntry ModEntry = null!;

        // ReSharper disable once ArrangeTypeMemberModifiers
        // ReSharper disable once UnusedMember.Local
        static bool Load(UnityModManager.ModEntry modEntry)
        {
            ModEntry = modEntry;
            Logger = modEntry.Logger;
            var harmony = new Harmony(modEntry.Info.Id);
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            Settings = UnityModManager.ModSettings.Load<HUDSettings>(modEntry);
            modEntry.OnGUI = entry => Settings.Draw(entry);
            modEntry.OnSaveGUI = entry => Settings.Save(entry);
            modEntry.OnFixedGUI = InputHUD.Draw;

            return true;
        }
    }
}