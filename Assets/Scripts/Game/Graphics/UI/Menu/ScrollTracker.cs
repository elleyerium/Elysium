﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
 using DG.Tweening;
 using Game.Graphics.UI.Buttons;
 using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityScript.Lang;
using Array = System.Array;

namespace Game.Graphics.UI.Menu
{
    public class ScrollTracker : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
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


        private int _selectedId;

        private void Start()
        {
            _contentRect = GetComponent<RectTransform>();
        }

        private void FixedUpdate()
        {
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

                    //ScaleObject(currDist, _buttons[i]);
                    _buttonSystemParams.ShowButtonDescription((MenuButtonsEnum)i);
                }
            }
            else
            {
                var val = (int)_buttonSystemParams.GetButtonWithActiveFocus().Type;
                ScaleObject(250, _buttons[val]);
                _buttonSystemParams.ShowButtonDescription((MenuButtonsEnum)val);

                _localTimer += Time.deltaTime;

                if (_localTimer > 0.1f && _canScrollWithoutQueue)
                {
                    _canScrollWithoutQueue = false;
                    _localTimer = 0;
                }
            }
        }

        private void ScaleObject(float distance, GameObject obj)
        {
            var scale = Mathf.Clamp(1 - (distance / 100f), 0.5f, 1f);
            DOTween.To(() => (Vector2)obj.transform.localScale, x => obj.transform.localScale = x,
                new Vector2(scale, scale), 0.1f);
        }

        public void ScrollWithoutQueue(MenuButtonsEnum type)
        {
            Debug.Log($"We are scrolling without any queue to {(int)type}!");
            _selectedId = (int)type;
            _canScrollWithoutQueue = true;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            //throw new NotImplementedException();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            var pos = _buttons[_selectedId].transform.position;
            Debug.Log($"up to {pos}");
            DOTween.To(() => _contentRect.anchoredPosition, x => _contentRect.anchoredPosition = x,
                new Vector2(pos.x, 0), 0.3f);
        }
    }
}
