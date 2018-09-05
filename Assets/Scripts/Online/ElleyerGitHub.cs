using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElleyerGitHub : MonoBehaviour
{
    public Text elleyer;

    void OnMouseDown()
    {
        GetComponent<Text>().color = Color.green;
        Debug.Log("Color changed");
    }
    void OnMouseUp()
    {
        GetComponent<Text>().color = Color.cyan;
    }
   void OnMouseUpAsButton()
    {
        Application.OpenURL("https://github.com/elleyerium");
    }
}
