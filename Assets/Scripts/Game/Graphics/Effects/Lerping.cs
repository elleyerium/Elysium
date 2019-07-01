using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Graphics.Effects
{
	public class Lerping : MonoBehaviour {
		public bool Lerped;

		public IEnumerator LerpAction(Transform basicScaleTransform, float reqScaleX,float reqScaleY, float time)
		{
			float Basic = basicScaleTransform.localScale.x;
			Debug.Log("Entered again");
			while (basicScaleTransform.localScale.x > 0.001f)
			{
				Lerped = false;
				Basic += basicScaleTransform.localScale.x;
				basicScaleTransform.localScale = Vector2.Lerp(basicScaleTransform.localScale, new Vector2(reqScaleX,reqScaleY),
					(time+Basic)*Time.fixedDeltaTime);
				yield return new WaitForFixedUpdate();
			}
			if (basicScaleTransform.localScale.x <= 0.001f)
			{
				Lerped = true;
				Destroy(basicScaleTransform.transform.gameObject);
			}
		}
	}
}
