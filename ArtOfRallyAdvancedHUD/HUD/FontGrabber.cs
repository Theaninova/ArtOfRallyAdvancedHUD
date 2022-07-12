using HarmonyLib;

namespace ArtOfRallyAdvancedHUD.HUD
{
    [HarmonyPatch(typeof(HudManager), "Update")]
    public static class FontGrabber
    {
        public static void Postfix(HudManager __instance)
        {
            if (__instance.SpeedoText == null) return;
            
            var font = __instance.SpeedoText.font;
            GearHUD.GearStyle.font = font;
            InputSlider.LabelStyle.font = font;
        }
    }
}