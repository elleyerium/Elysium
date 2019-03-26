using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class StickGenerator : MonoBehaviour
{
	public Transform Place;
	public Image Stick;
	public static Vector3 Position;
	
	
	public void OnPointerDown()
	{	
		Stick.transform.position = Input.mousePosition;
		Debug.Log(Stick.transform.position);
		Stick.enabled = true;
		Position = Stick.transform.position;
	}
	public void UnpressedEvent()
	{
		Stick.enabled = false;
		Joystick.OnPointerExit();
	}
}
