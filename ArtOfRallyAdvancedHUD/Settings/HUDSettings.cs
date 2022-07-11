using UnityEngine;
using UnityModManagerNet;

namespace ArtOfRallyAdvancedHUD.Settings
{
    public class HUDSettings : UnityModManager.ModSettings, IDrawable
    {
        [Header("Positioning")] [Draw(DrawType.PopupList)]
        public TextAnchor Anchor = TextAnchor.LowerRight;

        [Draw] public Vector2 Position = new Vector2(100, 20);

        [Header("Sizing")] [Draw] public int Margin = 8;

        [Draw] public int SliderWidth = 70;

        [Draw] public int SliderHeight = 150;

        [Draw] public int ValueSliderWidth = 10;

        [Draw] public int FontSize = 18;

        [Draw] public int TextSectionHeight = 30;

        [Header("Colors")] [Draw] public Color TextColor = new Color(1, 1, 1, 0.9f);

        [Draw] public Color BackgroundColor = new Color(0.55f, 0.55f, 0.55f, 0.8f);

        [Draw] public Color InputColor = new Color(0.2f, 0.5f, 0.8f, 0.9f);

        [Draw] public Color ValueColor = new Color(0.5f, 0.7f, 1, 0.9f);

        [Draw] public Color WarningColor = new Color(1, 0.2f, 0.2f, 0.9f);

        public override void Save(UnityModManager.ModEntry modEntry)
        {
            Save(this, modEntry);
        }

        public void OnChange()
        {
        }
    }
}