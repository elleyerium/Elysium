using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Graphics.Effects
{
	public class Scroll : MonoBehaviour {

		public float speed = 2f;

		void Update ()
		{
			var mr = GetComponent<MeshRenderer>();
			var mat = mr.material;
			var offset = mat.mainTextureOffset;
			offset.x += Time.deltaTime / speed;
			mat.mainTextureOffset = offset;
		}
	}
}
