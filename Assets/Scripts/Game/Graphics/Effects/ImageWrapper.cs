using UnityEngine;
using UnityEngine.UI;

using System.Collections;

namespace Game.Graphics.Effects
{
	[RequireComponent(typeof(Image)), DisallowMultipleComponent]
	public class ImageWrapper : MonoBehaviour
	{
		[SerializeField] private float _duration;
		[SerializeField] private Color _color;
		[SerializeField] private AnimationCurve _fadeCurve;
		public bool isFaded;

		private Image _image;
		private IEnumerator Fade(Color color, float duration)
		{
			float elapsed = 0.0f;
			Color startColor = _image.color;
			while (elapsed < duration)
			{
				elapsed = Mathf.Min(elapsed + Time.fixedDeltaTime, duration);

				_image.color = Color.Lerp(startColor, color, _fadeCurve.Evaluate(elapsed / duration));
				if(elapsed >= duration)
					isFaded = true;
				yield return new WaitForFixedUpdate();
			}
		}

		public void Fade() => StartCoroutine(Fade(_color, _duration));

		private void Awake() => _image = GetComponent<Image>();
    }
}