using HarmonyLib;
using UnityEngine;

// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace ArtOfRallyAdvancedHUD.Data
{
    [HarmonyPatch(typeof(CarController), "FixedUpdate")]
    public static class CarData
    {
        public static CarController? CarController;

        public static Drivetrain? Drivetrain;
        
        public static Rigidbody? CarRigidbody;
        
        public static CarDynamics? CarDynamics;
        
        public static void Postfix(
            CarController? __instance,
            Drivetrain? ___drivetrain,
            Rigidbody? ___body,
            CarDynamics? ___cardynamics)
        {
            CarController = __instance;
            Drivetrain = ___drivetrain;
            CarRigidbody = ___body;
            CarDynamics = ___cardynamics;
        }
    }
}