using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LazerShot : MonoBehaviour
{
    public static float lazernextFire, delay;
    public static int Timer;
    [SerializeField] public Transform lazer1;
    public GameObject lazer, Zero_ammo;
    private float _lazerfirstammo;
    [SerializeField]
    public SpriteRenderer ION_Cannon;
    [SerializeField] public Transform transform;
    private Sprite _cannonSprite;
    private bool pointerDown;
    private Vector3 temp;
    private string ammo;
<<<<<<< HEAD
    public Image LaserFill;
=======
>>>>>>> 46f6557c006040dbc335ccb9f08f0d9b60ad214f
    [SerializeField] public AudioSource _publicSource, _loopSource;
    public AudioClip _startAudio, _shotAudio, _endAudio;
    [SerializeField] private GameObject particles,cannon;
    void Start()
    {
        _loopSource.loop = true;
          _loopSource.clip = _shotAudio;
             temp.x = 0;
             temp.y = 0.884f;
          ION_Cannon.size = temp;
        _cannonSprite= ION_Cannon.GetComponent<Sprite>();
        _lazerfirstammo = Blastercount.Ammodownlazer;
    }

void Update()
{
    delay  += 1*Time.deltaTime;
        if (pointerDown && delay > 0.85f)
        {
            cannon.SetActive(true);
            particles.SetActive(true);
            
            if (temp.x <=3.28f)  // Animation function for laser.
<<<<<<< HEAD
            {
               temp.x = (ION_Cannon.size.x) + (18f * Time.deltaTime);
               ION_Cannon.size = temp;
            }
            Blastercount.Ammodownlazer -= 10 * Time.deltaTime;
            LaserFill.fillAmount = Blastercount.Ammodownlazer/_lazerfirstammo;

            /*if (Time.time > lazernextFire && Blastercount.Ammodownlazer > 0) //TODO:LaserFix
            {
=======
            {
               temp.x = (ION_Cannon.size.x) + (18f * Time.deltaTime);
               ION_Cannon.size = temp;
            }
            Blastercount.Ammodownlazer -= 10 * Time.deltaTime;
            /*if (Time.time > lazernextFire && Blastercount.Ammodownlazer > 0)
            {
>>>>>>> 46f6557c006040dbc335ccb9f08f0d9b60ad214f
                lazernextFire = Time.time + 0.5f;
                GameObject clonelazer = Instantiate(lazer, lazer1.position, lazer1.rotation);
                clonelazer.SetActive(true);
                Destroy(clonelazer, 4f);
                Blastercount.Ammodownlazer -= 1;
                Debug.Log("Lazer count -1");
                
                if (Blastercount.Ammodownlazer <= 0)
                {
                    Zero_ammo.SetActive(true);
                }
            }*/
        }
        else if (Blastercount.Ammodownlazer < _lazerfirstammo && pointerDown == false )
        {
            
            if (BotDifficult.noob)
                ammo = (Blastercount.Ammodownlazer += 2 * Time.deltaTime).ToString("F2");
            if (BotDifficult.abitharder)
                ammo = (Blastercount.Ammodownlazer += 3 * Time.deltaTime).ToString("F2");
            if (BotDifficult.impossible)
                ammo = (Blastercount.Ammodownlazer += 4 * Time.deltaTime).ToString("F2");

            Blastercount.Ammodownlazer = float.Parse(ammo);
<<<<<<< HEAD
            LaserFill.fillAmount = (Blastercount.Ammodownlazer) / _lazerfirstammo;
=======
>>>>>>> 46f6557c006040dbc335ccb9f08f0d9b60ad214f
        }

        if (!pointerDown || Blastercount.Ammodownlazer <=0)
          {
            _loopSource.Stop();
            pointerDown = false;
            temp.x = 0;
            ION_Cannon.size = temp;
                particles.SetActive(false);
                cannon.SetActive(false);
          }
    }

    public void IsPressed()
    {
        _loopSource.Play();
        
        for (int i = 0; i <=1 ; i++)
        {
            delay = 0;
            _publicSource.PlayOneShot(_startAudio);
        }
        pointerDown = true;
            
    }

    public void IsUnPressed()
    {
        _publicSource.PlayOneShot(_endAudio);
        _loopSource.Stop();
        pointerDown = false;
    }

    public void OnlineBlaster()
    {
        if(Time.time > lazernextFire)
        {
            lazernextFire = Time.time + 1;
            GameObject lazer = PhotonNetwork.Instantiate("PlayerBlaster", lazer1.position, lazer1.rotation, 0);
            lazer.SetActive(true);
            
        }
    }
}
