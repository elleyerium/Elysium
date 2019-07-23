using System;
using System.Collections;
using System.Timers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.Graphics.UI.Menu
{
    public class MusicPlayerUi : MonoBehaviour, IDeselectHandler
    {
        private float _delta = 0;
        public Button ShowManager;
        [SerializeField] private Animator _showAnimator;
        public AnimationClip Clip;
        private bool _reversed;
        public GameObject Ui;

        private void Start()
        {
            ShowManager.onClick.AddListener(Animate);
            Animate();
        }

        public void OnDeselect(BaseEventData data)
        {
            Debug.Log("Deselect");
            Animate();
        }
        private void Animate()
        {
            if (_reversed)
            {
                Ui.SetActive(true);
                ShowManager.gameObject.SetActive(false);
                //_showAnimator.speed = 1;
                //_showAnimator.playbackTime = 0;
                _showAnimator.Play("music-ui-show");
                _reversed = false;
                Debug.Log("Playing from 0");
            }
            else if (!_reversed)
            {
                _delta = 0;
                _showAnimator.Play("music-ui-hide");
                _reversed = true;
                ShowManager.gameObject.SetActive(true);
                StartCoroutine(Fading());
                Debug.Log("Playing from 1");

            }
        }

        private IEnumerator Fading()
        {
            while (_delta <= 0.1f)
            {
                _delta += 0.1f * Time.deltaTime;
                //_showAnimator.Play("music-ui-hide");
                //Debug.Log(_delta);
                yield return new WaitForFixedUpdate();
            }

            if (_delta > 0.1f)
            {
                Ui.SetActive(false);
                StopCoroutine(Fading());
            }
        }
    }
}