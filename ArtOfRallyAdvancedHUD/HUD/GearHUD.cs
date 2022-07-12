using HarmonyLib;
using UnityEngine;

namespace ArtOfRallyAdvancedHUD.HUD
{
    public static class GearHUD
    {
        private static readonly string[] Gears =
        {
            "R", "N", "1", "2", "3", "4", "5"
        };

        public static readonly GUIStyle GearStyle = new GUIStyle
        {
            alignment = TextAnchor.MiddleCenter,
        };

        public static void Draw(Rect position, Drivetrain drivetrain)
        {
            var totalHeight = Main.Settings.SliderHeight + 2 * Main.Settings.TextSectionHeight;
            var gearHeight = totalHeight / Gears.Length;

            var yPos = position.y;
            GearStyle.normal.textColor = Main.Settings.TextColor;
            GearStyle.fontSize = Main.Settings.GearFontSize;

            for (var i = Gears.Length - 1; i >= 0; i--)
            {
                var currentPosition = new Rect(position.x, yPos, Main.Settings.GearWidth, gearHeight);
                var backgroundColor = drivetrain.gear == i
                    ? drivetrain.changingGear
                        ? Main.Settings.WarningColor
                        : Main.Settings.InputColor
                    : Main.Settings.BackgroundColor;
                UI.DrawBox(currentPosition, backgroundColor);
                GUI.color = Color.white;
                GUI.Label(currentPosition, Gears[i], GearStyle);

                yPos += gearHeight;
            }
        }
    }
}