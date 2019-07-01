using UnityEngine;
using System.Collections;

namespace Game.Graphics.UI.Background
{
	public class FollowUV : MonoBehaviour {

		public float parralax = 2f;
		public static MeshRenderer mr;
		public static Material mat;


		void Update ()
		{

			MeshRenderer mr = GetComponent<MeshRenderer>();
			Material mat = mr.material;
			Vector2 offset = mat.mainTextureOffset;

			offset.x = transform.position.x / transform.localScale.x / parralax;
			offset.y = transform.position.y / transform.localScale.y / parralax;

			mat.mainTextureOffset = offset;
		}
	}
}

