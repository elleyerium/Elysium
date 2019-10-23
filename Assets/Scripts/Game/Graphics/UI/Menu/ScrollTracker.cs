﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
 using Game.Graphics.UI.Buttons;
 using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityScript.Lang;
using Array = System.Array;

namespace Game.Graphics.UI.Menu
{
    public class ScrollTracker : MonoBehaviour
    {
        private float _localTimer = 0f;
        [SerializeField]
        private GameObject[] _buttons;

        [Range(0f, 20f)]
        public float SnapSpeed;
        [Range(0f, 20f)]
        public float ScaleSpeed;

        [SerializeField]
        private RectTransform _contentRect;

        [SerializeField]
        private ScrollRect _scrollRect;

        [SerializeField]
        private Vector3 _contentVector;

        [SerializeField]
        private ButtonSystemParams _buttonSystemParams;
        private bool _isScrolling, _canScrollWithoutQueue;
        private GameObject _nearestObj;
        private float _lastValue;

        public UnityEngine.UI.Text Text;
        public int _main, _checkerValue;


        private int _selectedId;

        private void Start()
        {
            _main = 1122464;
            _checkerValue = _main * 3;
            _contentRect = GetComponent<RectTransform>();
        }

        private void FixedUpdate()
        {
            if (_main != _checkerValue / 3)
            {
                Debug.Log("You are cheater.");
                Text.text = _main.ToString();
            }
            if (!_canScrollWithoutQueue)
            {
                var nearestPos = float.MaxValue;
                for (var i = 0; i < 4; i++)
                {
                    var currDist = Mathf.Abs(_contentRect.anchoredPosition.x - _buttons[i].transform.localPosition.x);
                    if (currDist < nearestPos)
                    {
                        nearestPos = currDist;
                        _selectedId = i;
                    }

                    ScaleObject(currDist, 0.5f, _buttons[i]);
                    _buttonSystemParams.ShowButtonDescription((MenuButtonsEnum)i);
                }
            }
            else
            {
                var val = (int)_buttonSystemParams.GetButtonWithActiveFocus().Type;
                ScaleObject(250, 0.5f, _buttons[val]);
                _buttonSystemParams.ShowButtonDescription((MenuButtonsEnum)val);

                _localTimer += Time.deltaTime;

                if (_localTimer > 0.1f && _canScrollWithoutQueue)
                {
                    _canScrollWithoutQueue = false;
                    _localTimer = 0;
                }
            }

            var scrollVelocity = Mathf.Abs(_scrollRect.velocity.x);
            if (scrollVelocity < 400 && !_isScrolling) _scrollRect.inertia = false;
            if (_isScrolling || scrollVelocity > 400) return;
            _contentVector.x = Mathf.SmoothStep(_contentRect.anchoredPosition.x , _buttons[_selectedId].transform.localPosition.x, SnapSpeed * Time.deltaTime);
            _contentRect.anchoredPosition = new Vector2(_contentVector.x, 0f);
        }

        private static void ScaleObject(float distance, float scaleFactor, GameObject obj)
        {
            var scale = Mathf.Clamp(1 - (distance / 100f), 0.5f, 1f);
            obj.transform.localScale = new Vector3(scale, scale, 1);
        }

        public void IsScrolling(bool scroll)
        {
            _isScrolling = scroll;
            //_canScrollWithoutQueue = false;
        }

        public void ScrollWithoutQueue(MenuButtonsEnum type)
        {
            Debug.Log($"We are scrolling without any queue to {(int)type}!");
            _selectedId = (int)type;
            _canScrollWithoutQueue = true;
        }
    }
}
