using System.Collections;
using UnityEngine;

namespace Tests.Visual.UI
{

    public class ImageWrapperTestCase : MonoBehaviour
    {
        public GameObject Instance;
        void Start()
        {
            StartCoroutine(ProfileWrapCase(20));
        }

        private IEnumerator ProfileWrapCase(int Counter)
        {
            var сomponent = Instance.GetComponent<uiClickActions>();
            for (int i = 0; i < Counter; i++)
            {
                сomponent.OnClickProfile();
                Debug.Log("Clicked with bool result : " + сomponent.GetComponent<uiClickActions>().Wrapper.isFaded);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}