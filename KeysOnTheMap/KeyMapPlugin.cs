using BepInEx;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KeysOnTheMap
{
    [BepInPlugin(modGUID,modName,"9.28.0.5")]
    public class KeyMapPlugin : BaseUnityPlugin
    {
        public const string modGUID = "grug.lethalcompany.KeysOnMap";
        public const string modName = "Keys On Map";
        public void Awake()
        {
            Hook KeyHook = new(
            typeof(GrabbableObject).GetMethod(nameof(GrabbableObject.Start), (BindingFlags)int.MaxValue),
            (Action<GrabbableObject> original, GrabbableObject self) =>
            {
                if (self.itemProperties.itemName == "Key")
                {

                }
                //self.radarIcon = Instantiate(StartOfRound.Instance.itemRadarIconPrefab, RoundManager.Instance.mapPropsContainer.transform).transform;
                original(self);
            });
        }

    }
}
