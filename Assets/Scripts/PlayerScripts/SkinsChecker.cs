using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsChecker : MonoBehaviour
{

    private SpriteRenderer spriteRenderer ;
    [SerializeField] private Sprite _default;
	[SerializeField] private Sprite _materialship;
	[SerializeField] private Sprite _bloodydarkness;
	void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		if (PlayerPrefs.GetString("CurrentlySkin") == "default")
			spriteRenderer.sprite = _default;
		if (PlayerPrefs.GetString("CurrentlySkin") == "materialship")
			spriteRenderer.sprite = _materialship;
		if (PlayerPrefs.GetString("CurrentlySkin") == "darkness")
			spriteRenderer.sprite = _bloodydarkness;
		Debug.Log(PlayerPrefs.GetString("CurrentlySkin"));
		

	}
}
