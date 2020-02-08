using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Graphics.UI.Screen
{
    public class Cursor : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        public void Update()
        {
            var converted = _camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            transform.position = new Vector3(converted.x, converted.y, 0f);
            //Debug.Log(transform.position);
        }

    }
}