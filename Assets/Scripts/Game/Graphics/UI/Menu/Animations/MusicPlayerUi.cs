using System;
using System.Collections;
using System.Timers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.Graphics.UI.Menu.Animations
{
    public class MusicPlayerUi : MonoBehaviour
    {
        private float _delta = 0;
        public Button ShowManager;
        [SerializeField] private Animator _showAnimator;
        public AnimationClip Clip;
        private bool _reversed;
        private bool _hidden = true;
        public GameObject Ui;
        [SerializeField] private EventSystem _evSys;

        private void Start()
        {
            _evSys = EventSystem.current;
            ShowManager.onClick.AddListener(Animate);
            Animate();
        }

        private void Update()
        {

            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                try
                {
                    if (_evSys.currentSelectedGameObject == null && !_hidden ||
                        _evSys.currentSelectedGameObject != Ui &&
                        !_evSys.currentSelectedGameObject.transform.IsChildOf(Ui.transform) && !_hidden)
                    {
                        Debug.Log("Outside!");
                        Animate();
                    }
                }
                catch (NullReferenceException ex)
                {
                    Debug.Log(ex.ToString());
                }
            }
        }
        public void OnClick()
        {
            try
            {
                Animate();
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
            }
        }
        private void Animate()
        {
            if (_hidden)
            {
                _delta = 0;
                Ui.SetActive(true);
                ShowManager.gameObject.SetActive(false);
                _showAnimator.Play("music-ui-show");
                _hidden = false;
            }
            else if (!_hidden)
            {
                _delta = 0;
                _showAnimator.Play("music-ui-hide");
                _hidden = true;
                ShowManager.gameObject.SetActive(true);
                StartCoroutine(Fading());
            }
        }

        private IEnumerator Fading()
        {
            while (_delta <= 2f)
            {
                _delta += 2f * Time.deltaTime;
                yield return new WaitForFixedUpdate();
            }
            if (_delta > 2f)
            {
                Ui.SetActive(false);
                StopCoroutine(Fading());
            }
        }
    }
}