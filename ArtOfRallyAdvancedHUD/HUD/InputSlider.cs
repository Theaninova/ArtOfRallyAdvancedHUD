using JetBrains.Annotations;
using UnityEngine;

namespace ArtOfRallyAdvancedHUD.HUD
{
    public struct SliderConfig
    {
        public float Min;
        public float Max;
        public float Value;
    }

    public struct SliderMarkerConfig
    {
        public float Min;
        public float Max;
        public float Value;
        public Color Color;
        public string Label;
    }

    public struct InputSliderConfig
    {
        public string Label;
        public string FeatureLabel;
        public bool Feature;
        public SliderConfig ValueSlider;
        public SliderConfig InputSlider;
        public SliderMarkerConfig[]? POIs;
    }

    public static class InputSlider
    {
        public static readonly GUIStyle LabelStyle = new GUIStyle
        {
            alignment = TextAnchor.MiddleCenter,
        };

        public static void Draw(Vector2 position, InputSliderConfig config)
        {
            GUI.BeginGroup(new Rect(
                position.x,
                position.y,
                Main.Settings.SliderWidth,
                Main.Settings.SliderHeight + 2 * Main.Settings.TextSectionHeight)
            );
            UI.DrawBox(new Rect(
                0, 0,
                Main.Settings.SliderWidth,
                Main.Settings.SliderHeight + 2 * Main.Settings.TextSectionHeight
            ), Main.Settings.BackgroundColor);


            GUI.color = Color.white;
            GUI.backgroundColor = config.Feature ? Main.Settings.WarningColor : Color.clear;
            LabelStyle.fontSize = Main.Settings.FontSize;
            LabelStyle.normal.background = Texture2D.whiteTexture;
            LabelStyle.normal.textColor = Main.Settings.TextColor;

            GUI.Label(new Rect(
                    0, 0,
                    Main.Settings.SliderWidth,
                    Main.Settings.TextSectionHeight
                ),
                config.FeatureLabel,
                LabelStyle
            );

            GUI.backgroundColor = Color.clear;
            GUI.Label(new Rect(
                    0,
                    Main.Settings.SliderHeight + Main.Settings.TextSectionHeight,
                    Main.Settings.SliderWidth,
                    Main.Settings.TextSectionHeight),
                config.Label,
                LabelStyle
            );

            UI.DrawSlider(
                new Rect(
                    0,
                    Main.Settings.TextSectionHeight,
                    Main.Settings.SliderWidth,
                    Main.Settings.SliderHeight),
                Main.Settings.InputColor,
                config.InputSlider.Value,
                config.InputSlider.Min,
                config.InputSlider.Max
            );
            UI.DrawSlider(
                new Rect(
                    Main.Settings.SliderWidth - Main.Settings.ValueSliderWidth,
                    Main.Settings.TextSectionHeight,
                    Main.Settings.ValueSliderWidth,
                    Main.Settings.SliderHeight
                ),
                Main.Settings.ValueColor,
                config.ValueSlider.Value,
                config.ValueSlider.Min,
                config.ValueSlider.Max
            );

            if (config.POIs != null)
            {
                foreach (var poi in config.POIs)
                {
                    GUI.color = poi.Color;
                    var posY = ((poi.Value - poi.Min) / (poi.Max - poi.Min)) * Main.Settings.SliderHeight;
                    GUI.DrawTexture(
                        new Rect(
                            Main.Settings.SliderWidth - Main.Settings.ValueSliderWidth,
                            Main.Settings.TextSectionHeight + Main.Settings.SliderHeight - posY,
                            Main.Settings.ValueSliderWidth,
                            Main.Settings.SliderMarkerHeight
                        ),
                        Texture2D.whiteTexture
                    );
                    GUI.Label(new Rect(
                        Main.Settings.SliderWidth - Main.Settings.ValueSliderWidth -
                        Main.Settings.SliderMarkerLabelOffset.x,
                        Main.Settings.TextSectionHeight + Main.Settings.SliderHeight - posY +
                        Main.Settings.SliderMarkerLabelOffset.y,
                        0,
                        0
                    ), poi.Label, LabelStyle);
                }
            }

            GUI.EndGroup();
        }
    }
}