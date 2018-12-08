using System.Collections;
using System.Collections.Generic;
using GooglePlayGames.Native.Cwrapper;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthbarScript : MonoBehaviour
{
    Image Healthbar;
    float maxHealth = 100f;
    public static float health;
    public static GameObject _respawner;
    [SerializeField]private GameObject player;
    public GameObject DeathScreen;
    public void Start()
    {
        _respawner = player;
        Healthbar = GetComponent<Image>();
        health = maxHealth;

    }
    void Update()
    {
                
        if (health < 100 && BotDifficult.noob) //if noob activated - health gonna repair
        {
            health += 1f * Time.deltaTime;
        }

        Healthbar.fillAmount = health / maxHealth;
        if (health <= 0)
        {
            _respawner.SetActive(false);
            DeathScreen.SetActive(true);
        }

    }

}
