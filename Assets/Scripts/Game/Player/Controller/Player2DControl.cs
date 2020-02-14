using Game.Difficult;
using Game.Player.Weapon;
using Preferences;
using UnityAssets.Standard_Assets.CrossPlatformInput.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Player.Controller
{
    public class Player2DControl : MonoBehaviour
  {
    public float MoveForce = 5, _firstammo, reloadRate, sensitivityRate;
    [SerializeField]
    public GameObject shot, Zero_ammo;
    private string ammo;
    public Transform rPos01;
    public GameObject shot1;
    public Transform rPos02;
    public static float nextFire;
    public AudioSource BotRocketHit;
    public AudioClip BotHitClip;
    [SerializeField]
    private Image Fill;
    private Rigidbody2D myBody;
    private bool IsPressed, IsReloading;

    void Start()
    {
        if (!PlayerPrefs.HasKey("Sensitivity"))
            sensitivityRate = Settings.SensitivityValue;
        else
            sensitivityRate = PlayerPrefs.GetFloat("Sensitivity");

        _firstammo = AmmoCounter.AmmodownRocket;
        myBody = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (IsPressed)
            shoot();
        else if (!IsPressed &&  AmmoCounter.AmmodownRocket < _firstammo)
        {
            ammo = (AmmoCounter.AmmodownRocket += 0.1f * Time.deltaTime).ToString("F3");
            AmmoCounter.AmmodownRocket = float.Parse(ammo);
        }

        if (IsReloading)
            Fill.fillAmount += ((Time.deltaTime /  reloadRate)) ;
    }

    void FixedUpdate()
    {
        Vector3 moveVec = new Vector3((CrossPlatformInputManager.GetAxis("Horizontal") * MoveForce * 10),
                  (CrossPlatformInputManager.GetAxis("Vertical"))
                  * MoveForce * 10);
        Vector3 lookVec = new Vector3(
            (CrossPlatformInputManager.GetAxis("Horizontal"))
            ,
            (CrossPlatformInputManager.GetAxis("Vertical"))
            , 4096);
        if (lookVec.x != 0 && lookVec.y != 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(lookVec, Vector3.back);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, sensitivityRate /2);
        }

        myBody.AddForce(moveVec);
    }

    public void IsClicked()
    {
        IsPressed = true;
    }

    public void UnClicked()
    {
        IsPressed = false;
    }
    public void shoot()
    {
        if (Time.time >= nextFire && AmmoCounter.AmmodownRocket > 0)
        {
            /*IsReloading = true;
            if(BotDifficult.noob)
                nextFire = Time.time + 3;
            if (BotDifficult.abitharder)
                nextFire = Time.time + 4;
            if (BotDifficult.impossible)
                nextFire = Time.time + 5;
            reloadRate = nextFire - Time.time;*/

            GameObject clone = Instantiate(shot, rPos01.position, rPos01.rotation);
            GameObject clone2 = Instantiate(shot1, rPos02.position, rPos02.rotation);
            clone.SetActive(true);
            clone2.SetActive(true);
            Destroy(clone, 5f);
            Destroy(clone2, 5f);
            AmmoCounter.AmmodownRocket -= 1;
            Fill.fillAmount = 0;
        }
        if(AmmoCounter.AmmodownRocket <= 0)
        {

            Zero_ammo.SetActive(true);

        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "botrocket")
        {
            BotRocketHit.PlayOneShot(BotHitClip);
        }
    }
  }
}

