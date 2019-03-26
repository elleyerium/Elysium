using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;
using UnityEngine.UI;

public class TouchCursor : MonoBehaviour
{
	
    [SerializeField]
	private Image _touchCursor;
	private Camera cam;
	private Vector3 _lastposition;
	public Vector2 startPos;
	public Vector2 direction;
	public bool directionChosen;
	public Touch touch;

	private void Start()
	{
		cam = Camera.main;
	}

	private void Update()
	{
		Vector3 point = new Vector3();
		Event   currentEvent = Event.current;
		Vector2 mousePos = new Vector2();
		if (Input.touchCount > 0)
		{
			
			touch = Input.GetTouch(0);
			switch (touch.phase)
			{
				case TouchPhase.Began:
					startPos = touch.position;
					directionChosen = false;
					break;
				case TouchPhase.Moved:
					direction = touch.position - startPos;
					break;
				case TouchPhase.Ended:
					directionChosen = true;
					break;

			}

		}
		var x = touch.position.x;
		var y = touch.position.y;
		point = cam.ScreenToWorldPoint(new Vector3 (x,y, cam.nearClipPlane));
		_touchCursor.transform.position = new Vector2(x,y);
		
	}


}
