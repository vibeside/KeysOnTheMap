using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace KeysOnTheMap.Scripts
{
    public class KeepUpwards : MonoBehaviour
    {
        public void Update()
        {
            gameObject.transform.rotation = Quaternion.Euler(90, -45, 0);
        }
    }
}
