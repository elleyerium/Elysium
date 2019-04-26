using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FPSTarget: MonoBehaviour
{
    [SerializeField]
    private Text FPS;
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
        FPS.text = Mathf.Ceil(fps).ToString()+ " FPS ";
        if (Application.targetFrameRate != target)
            Application.targetFrameRate = target;
    }
}