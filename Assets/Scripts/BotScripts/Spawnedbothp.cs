using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawnedbothp: MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _deadClip;
    public Image HealthBarFill;
    public ParticleSystem DestroyParticle;
    public float hp;
    public static byte Countofkilled = 0;
    public float maxbothp = 100f;
    public GameObject bot,source;
    public byte boxdropchance;

    void Start () {
        
        source = new GameObject("AudioSource");
        _audioSource = source.AddComponent(typeof(AudioSource)) as AudioSource;
        hp = maxbothp;
		
	}
	void Update ()
    {
        HealthBarFill.fillAmount = hp / maxbothp;
        if (hp <= 0)
        {
            for (int i = 0; i <= 1; i++)
            {
                _audioSource.PlayOneShot(_deadClip);
                Instantiate(DestroyParticle, bot.transform.position, bot.transform.rotation);
            }
            Countofkilled += 1;
            Bots.botCounter -= 1;
            Destroy(bot);
        }
       

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Rocketmissle")
            hp -= 15;
        if(collider.gameObject.tag == "blaster")      
            hp -= 25;
        if (collider.gameObject.tag == "cannon")
            hp -= 5;
    }

}