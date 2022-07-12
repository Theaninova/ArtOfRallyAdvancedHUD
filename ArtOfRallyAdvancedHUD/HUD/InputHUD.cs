using ArtOfRallyAdvancedHUD.Data;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityModManagerNet;

namespace ArtOfRallyAdvancedHUD.HUD
{
    public static class InputHUD
    {
        public static void Draw(UnityModManager.ModEntry modEntry)
        {
            if (CarData.Drivetrain == null ||
                CarData.CarController == null ||
                CarData.CarDynamics == null ||
                CarData.CarRigidbody == null) return;

            var position = Positioning.Anchor(Main.Settings.Anchor, new Rect(
                Main.Settings.Position.x,
                Main.Settings.Position.y,
                3 * Main.Settings.SliderWidth + 2 * Main.Settings.Margin,
                Main.Settings.SliderHeight + 2 * Main.Settings.TextSectionHeight
            ));

            InputSlider.Draw(position.position, new InputSliderConfig
            {
                FeatureLabel = $"{Mathf.RoundToInt(CarData.Drivetrain.rpm):D4}",
                Label = $"{Mathf.RoundToInt(CarData.Drivetrain.differentialSpeed):D}",
                Feature = CarData.Drivetrain.revLimiterTriggered,
                InputSlider =
                {
                    Value = CarData.CarController.throttle,
                    Min = 0,
                    Max = 1,
                },
                ValueSlider =
                {
                    Value = CarData.Drivetrain.rpm,
                    Min = CarData.Drivetrain.minRPM,
                    Max = CarData.Drivetrain.maxRPM
                }
            });
            position.x += Main.Settings.SliderWidth;
            GearHUD.Draw(position, CarData.Drivetrain);
            position.x += Main.Settings.GearWidth + Main.Settings.Margin;
            
            InputSlider.Draw(position.position, new InputSliderConfig
            {
                Label = "Brake",
                FeatureLabel = "ABS",
                Feature = CarData.CarController.ABSTriggered,
                InputSlider =
                {
                    Value = CarData.CarController.brake,
                    Min = 0,
                    Max = 1,
                },
                ValueSlider =
                {
                    Value = CarData.CarController.handbrakeInput,
                    Min = 0,
                    Max = 1,
                }
            });
            position.x += Main.Settings.SliderWidth + Main.Settings.Margin;
            InputSlider.Draw(position.position, new InputSliderConfig
            {
                Label = "Clutch",
                FeatureLabel = "",
                Feature = CarData.CarController.ESPTriggered,
                InputSlider =
                {
                    Value = CarData.CarController.clutchInput,
                    Min = 0,
                    Max = 1,
                }
            });
        }
    }
}