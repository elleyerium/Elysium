//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;


//public class fill : MonoBehaviour {
//    public Image Rocketbackground;
//    public Image LazerBackground;
//    public float waittimerocket = 5f;
//    public float waittimelazer = 1f;


//	void Start () {
//        Rocketbackground.fillAmount = 1f;
//        LazerBackground.fillAmount = 1f;

//    }

//    public void Update()
//    {
//        if (Player2DControl.waspressed == true && Player2DControl.reloading == true)
//        {
//            Fill();
//        }

//        if (Rocketbackground.fillAmount >= 1.0f && Player2DControl.waspressed == true && Player2DControl.reloading == false)
//        {
//            Rocketbackground.fillAmount = 0f;
//           // Fill();
//        }
//        if (LazerShot.isblaster)
//        {
//            Lazerfill();
//        }
//        if (LazerBackground.fillAmount >= 1.0f && LazerShot.isblaster)
//        {
//            LazerBackground.fillAmount = 0f;
//        }

//    }
//    public void Fill()
//    {
//        Rocketbackground.fillAmount += 1.0f / waittimerocket * Time.deltaTime;
//    }
//    public void Lazerfill()
//    {
//        LazerBackground.fillAmount += 1.0f / waittimelazer * Time.deltaTime;
//    }
//}
