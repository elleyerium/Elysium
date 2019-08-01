using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Graphics.UI.Menu.Animations
{
    public class WindowAnimations : MonoBehaviour
    {
        private float _startValue = 150f;
        /// <summary>
        /// Animate windows by 4 sides by canvas group and playback speed.
        /// </summary>
        /// <param name="from">First canvas group we should start from.</param>
        /// <param name="to">Second canvas group we should move to.</param>
        /// <param name="pbSpeed">Playback speed.</param>

        public IEnumerator Animate(CanvasGroup from, CanvasGroup to, float pbSpeed)
        {
            var timer = 0f;
            var tempPos = to.transform.position;
            var randomNum = (Direction)Random.Range(0,4);
            Debug.Log(randomNum);

            while (timer <= pbSpeed)
            {
                timer += pbSpeed * Time.deltaTime;
                from.alpha = Mathf.Lerp(1, 0, pbSpeed * 1.1f * timer);

                if (from.alpha <= 0.1f)
                    from.gameObject.SetActive(false);

                to.alpha =Mathf.Lerp(0,1,pbSpeed * timer);
                to.gameObject.SetActive(true);
                to.transform.localScale = new Vector3(Mathf.Lerp(0.8f, 1, pbSpeed * 1.2f * timer),Mathf.Lerp(0.8f, 1, pbSpeed * 1.2f * timer),0);

                switch (randomNum)
                {
                    case Direction.Down:
                        Debug.Log("Now we are moving to down!");
                        to.transform.position = new Vector3(tempPos.x,Mathf.Lerp(tempPos.y + _startValue, tempPos.y, pbSpeed * timer),0);
                        Debug.Log(to.transform.position);
                        break;
                    case Direction.Up:
                        Debug.Log("Now we are moving to up!");
                        to.transform.position = new Vector3(tempPos.x,Mathf.Lerp(tempPos.y - _startValue, tempPos.y, pbSpeed * timer),0);
                        break;
                    case Direction.Left:
                        Debug.Log("Now we are moving to left!");
                        to.transform.position= new Vector3(Mathf.Lerp(tempPos.x + _startValue, tempPos.x, pbSpeed * timer), tempPos.y, 0);
                        Debug.Log(to.transform.position);
                        break;
                    case Direction.Right:
                        Debug.Log("Now we are moving to right!");
                        to.transform.position = new Vector3(Mathf.Lerp(tempPos.x -_startValue, tempPos.x, pbSpeed * timer), tempPos.y, 0);
                        break;
                    default:
                        throw new Exception("Invalid direction. Only Right/Left/Up/Down acceptable.");
                }
                yield return new WaitForFixedUpdate();
                if(to.transform.position == tempPos)
                    StopCoroutine("Animate");
            }
        }
    }
}