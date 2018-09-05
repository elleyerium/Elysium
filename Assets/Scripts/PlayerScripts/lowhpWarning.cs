using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lowhpWarning : MonoBehaviour {
    public GameObject lowhpmessage;
    private float WarningEnd;
    public float Offmessage;

    void Update() {
        if (HealthbarScript.health >= 20)
        {
            lowhpmessage.SetActive(false);
        }
        else
        {
            lowhpmessage.SetActive(true);
            Offmessageclass();

        }

    }
    public void Offmessageclass()
    {
        if (Time.time > Offmessage)
            Offmessage = Time.time + 2.5f;
        lowhpmessage.SetActive(false);
    }
}
