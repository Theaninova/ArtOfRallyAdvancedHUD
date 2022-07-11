using UnityEngine;

namespace ArtOfRallyAdvancedHUD.HUD
{
    public static class UI
    {
        public static void DrawSlider(Rect position, Color color, float value, float min, float max)
        {
            GUI.color = color;
            var height = ((value - min) / (max - min)) * position.height;
            GUI.DrawTexture(
                new Rect(position.x, position.y + position.height - height, position.width, height),
                Texture2D.whiteTexture
            );
        }

        public static void DrawBox(Rect position, Color color)
        {
            GUI.color = color;
            GUI.DrawTexture(position, Texture2D.whiteTexture);
        }
    }
}