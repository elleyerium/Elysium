using DG.Tweening;
using Game.AI.Data;
using UnityEngine;

namespace Game
{
    public class GameContainer : MonoBehaviour
    {
        public CanvasGroup GameCanvasGroup;
        public GameObject Overlay;

        public Transform EnemiesTransform;
        public GameObject PlayerPrefab;
        public GameObject EnemyPrefab;
        public Bots Bots;

        private void Awake()
        {
            GameCanvasGroup = GameObject.FindWithTag("GameCanvasGroup").GetComponent<CanvasGroup>();
            Overlay = GameObject.FindWithTag("Overlay");
        }
        public void ProvideOfflineContainer()
        {
            Bots.gameObject.SetActive(true);
            Hide(GameCanvasGroup);
            Overlay.gameObject.SetActive(false);
        }

        public void ProvideOnlineContainer()
        {

        }

        public void BackToMenu()
        {
            Show(GameCanvasGroup);
        }

        private void Hide(CanvasGroup canvasGroup)
        {
            DOTween.To(() => canvasGroup.alpha, x => canvasGroup.alpha = x, 0, 0.5f)
                .OnComplete(() => canvasGroup.blocksRaycasts = false)
                .OnComplete(() => canvasGroup.interactable = false);
        }

        public void Show(CanvasGroup canvasGroup)
        {
            Overlay.gameObject.SetActive(true);
            DOTween.To(() => canvasGroup.alpha, x => canvasGroup.alpha = x, 0, 0.5f)
                .OnComplete(() => canvasGroup.blocksRaycasts = true)
                .OnComplete(() => canvasGroup.interactable = true).OnComplete(() => Destroy(gameObject));
        }
    }
}