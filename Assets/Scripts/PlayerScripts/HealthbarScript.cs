using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthbarScript : MonoBehaviour
{
    Image Healthbar;
    float maxHealth = 100f;
    public static float health;
    public GameObject player;
    public GameObject DeathScreen;
    public void Start()
    {
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
            Destroy(player);

        if (health <= 0)
        {
            DeathScreen.SetActive(true);

        }


    }

}
