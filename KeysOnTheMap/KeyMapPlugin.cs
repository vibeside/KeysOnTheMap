using BepInEx;
using KeysOnTheMap.Scripts;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using TMPro;
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
                    GameObject KeyIcon = new GameObject();
                    KeyIcon.transform.SetParent(self.transform, false);
                    KeyIcon.transform.SetLocalPositionAndRotation(new Vector3(0, 0.5f, 0), Quaternion.Euler(new Vector3(90, 0, 0)));
                    KeyIcon.transform.localScale = new Vector3(5f, 5f, 5f);
                    KeyIcon.layer = StartOfRound.Instance.itemRadarIconPrefab.layer;
                    KeyIcon.name = "keyicon :3";
                    KeyIcon.AddComponent<KeepUpwards>();
                    TextMeshPro tmpro = KeyIcon.AddComponent<TextMeshPro>();
                    tmpro.alignment = TextAlignmentOptions.Center;
                    tmpro.text = "🔑";
                } 
                //self.radarIcon = Instantiate(StartOfRound.Instance.itemRadarIconPrefab, RoundManager.Instance.mapPropsContainer.transform).transform;
                original(self);
            });
        }

    }
}
