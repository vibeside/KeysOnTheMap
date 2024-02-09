using BepInEx;
using JetBrains.Annotations;
using KeysOnTheMap.Scripts;
using MonoMod.RuntimeDetour;
using System;
using System.IO;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace KeysOnTheMap
{
    [BepInPlugin(modGUID,modName,"9.28.0.5")]
    public class KeyMapPlugin : BaseUnityPlugin
    {
        public const string modGUID = "grug.lethalcompany.KeysOnMap";
        public const string modName = "Keys On Map";
        public static AssetBundle? assetbundle;
        public void Awake()
        {
            string sAssemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            assetbundle = AssetBundle.LoadFromFile(Path.Combine(sAssemblyLocation, "keysonmap"));
            Texture2D bruh = assetbundle.LoadAsset<Texture2D>("Assets/KeyOnMap/key.png");
            GameObject iconPrefab = assetbundle.LoadAsset<GameObject>("Assets/KeyOnMap/Canvas.prefab");
            Hook KeyHook = new(
            typeof(GrabbableObject).GetMethod(nameof(GrabbableObject.Start), (BindingFlags)int.MaxValue),
            (Action<GrabbableObject> original, GrabbableObject self) =>
            {
                if (self.itemProperties.itemName == "Key")
                {
                    GameObject KeyIcon = Instantiate(iconPrefab);
                    KeyIcon.transform.SetParent(self.transform, false);
                    KeyIcon.transform.SetLocalPositionAndRotation(new Vector3(0, 0.5f, 0), Quaternion.Euler(new Vector3(90, 0, 0)));
                    KeyIcon.transform.localScale = new Vector3(25f, 25f, 25f);
                    KeyIcon.layer = StartOfRound.Instance.itemRadarIconPrefab.layer;
                    KeyIcon.name = "keyicon :3";
                    KeyIcon.AddComponent<KeepUpwards>();
                } 
                //self.radarIcon = Instantiate(StartOfRound.Instance.itemRadarIconPrefab, RoundManager.Instance.mapPropsContainer.transform).transform;
                original(self);
            });
        }

    }
}
