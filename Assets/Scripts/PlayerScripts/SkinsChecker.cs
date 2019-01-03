using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsChecker : MonoBehaviour
{

    private SpriteRenderer spriteRenderer ;
    [SerializeField] private Sprite _default;
	[SerializeField] private Sprite _materialship;
	[SerializeField] private Sprite _bloodydarkness;
	[SerializeField] private Sprite _void;
	[SerializeField] private Sprite _auron;
	[SerializeField] private Sprite _remaker;
	[SerializeField] private Color _color, _enginecolor;
	void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		if (PlayerPrefs.GetString("CurrentlySkin") == "default")
			spriteRenderer.sprite = _default;
		if (PlayerPrefs.GetString("CurrentlySkin") == "materialship")
			spriteRenderer.sprite = _materialship;
		if (PlayerPrefs.GetString("CurrentlySkin") == "darkness")
			spriteRenderer.sprite = _bloodydarkness;
		if (PlayerPrefs.GetString("CurrentlySkin") == "void")
		    spriteRenderer.sprite = _void;
		if (PlayerPrefs.GetString("CurrentlySkin") == "auron")	
			spriteRenderer.sprite = _auron;
		if (PlayerPrefs.GetString("CurrentlySkin") == "remaker")	
			spriteRenderer.sprite = _remaker;
		Debug.Log(PlayerPrefs.GetString("CurrentlySkin"));
		

	}
}
