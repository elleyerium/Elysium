using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUI : MonoBehaviour {

	public RectTransform panel;
	public RectTransform Center;
	public GameObject[] Sides;
	bool isDrag;
	private float[] Distance;
	private int DistanceBetweenSides, minNum, newPos;

	void Start()
	{

		Distance = new float[Sides.Length];
		DistanceBetweenSides = (int) Mathf.Abs(Sides[1].GetComponent<RectTransform>().anchoredPosition.x -
		                                       Sides[0].GetComponent<RectTransform>().anchoredPosition.x);
	}

	void Update()
	{
		for (int i = 0; i < Sides.Length; i++)
		{
			Distance[i] = Mathf.Abs(Center.transform.position.x - Sides[i].transform.position.x);
		}
		float MinDist = Mathf.Min(Distance);
	    for(int a = 0; a < Sides.Length; a++)
		{
			if (MinDist == Distance[a])
			{  
				minNum = a;
			}
		}
		if (!isDrag)
		{
			LerpAction(minNum * (-DistanceBetweenSides));
		}
	}

	void LerpAction(int NewPos)	
	{
		float newX = Mathf.Lerp(panel.anchoredPosition.x, NewPos, Time.deltaTime * 2f);
		Vector2 NewPosition = new Vector2(newX, panel.anchoredPosition.y);
		panel.anchoredPosition = NewPosition;
	}
	
	public void OnFingerDown()
	{		
		isDrag = true;
	}
	public void OnFingerUp()
	{
		isDrag = false;
	}
}
