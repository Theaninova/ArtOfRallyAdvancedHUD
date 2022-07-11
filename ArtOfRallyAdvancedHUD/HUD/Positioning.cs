using System;
using UnityEngine;

namespace ArtOfRallyAdvancedHUD.HUD
{
    public class Positioning
    {
        public static Rect Anchor(TextAnchor anchor, Rect position)
        {
            return anchor switch
            {
                TextAnchor.MiddleCenter => new Rect(
                    Screen.width / 2f - position.width / 2f + position.x,
                    Screen.height / 2f - position.height / 2f - position.y,
                    position.width,
                    position.height
                ),
                TextAnchor.UpperRight => new Rect(
                    Screen.width - position.width - position.x,
                    position.y,
                    position.width,
                    position.height
                ),
                TextAnchor.LowerRight => new Rect(
                    Screen.width - position.width - position.x,
                    Screen.height - position.height - position.y,
                    position.width,
                    position.height
                ),
                _ => throw new ArgumentOutOfRangeException(nameof(anchor), anchor, "Unsupported anchor")
            };
        }
    }
}