using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Preferences.ClientSettings.Performance
{
    public class FpsTarget: MonoBehaviour
    {
        public int target;
        public float deltaTime;

        void Awake()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = target;
        }

        void Update()
        {
            deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
            float fps = 1.0f / deltaTime;
            if (Application.targetFrameRate != target)
                Application.targetFrameRate = target;
        }
    }
}
