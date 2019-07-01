using Game.Graphics.Effects;
using UnityEngine;

namespace Game.Graphics.UI
{
	public class uiClickActions : MonoBehaviour
	{

		public GameObject Panel, Exp;
		private bool isActive;
		public ImageWrapper Wrapper;

		void Start()
		{
			Wrapper = Panel.GetComponent<ImageWrapper>();
		}
		public void OnClickProfile()
		{
			if (!isActive)
			{
				Panel.SetActive(true);
				isActive = true;
				Wrapper.Fade();
			}
			else
			{
				if (Wrapper.isFaded)
				{
					Panel.SetActive(false);
					isActive = false;
					Wrapper.isFaded = false;
				}
				else
				{
					Debug.Log(Wrapper.isFaded + " ");
					Debug.Log("Should be wrapped!");
				}
			}
		}
	}
}
