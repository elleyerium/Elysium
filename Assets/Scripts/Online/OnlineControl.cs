using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityStandardAssets.CrossPlatformInput;

public class OnlineControl : Photon.MonoBehaviour
{
    public float MoveForce = 5, _firstammo, reloadRate, sensitivityRate;
    [SerializeField]
    public GameObject shot, shot1, Zero_ammo;
    private string ammo;
    public Transform rPos01,rPos02;
    public static float nextFire;
    public AudioSource BotRocketHit;
    public AudioClip BotHitClip;
    [SerializeField]
    private Image Fill;
    private Rigidbody2D myBody;
    private bool IsPressed, IsReloading;   
    static Socket socket;
    private static IPEndPoint remotePoint;
    void Start()
    {
        if (!PlayerPrefs.HasKey("Sensitivity"))
            sensitivityRate = Settings.SensitivityValue;
        else 
            sensitivityRate = PlayerPrefs.GetFloat("Sensitivity");
        
        _firstammo = AmmoCounter.AmmodownRocket;
        myBody = this.GetComponent<Rigidbody2D>();
        
        Task listeningTask = new Task(ListenTask);
        listeningTask.Start();
        
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        remotePoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 39999 );
        string message = "controlled";
        try
        {
            byte[] buffer = Encoding.Unicode.GetBytes(message);
            socket.SendTo(buffer, remotePoint);
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
        finally
        {
            Debug.Log("Done");
        }
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
            Fill.fillAmount += ((Time.deltaTime /  reloadRate));
        
        string WorldPosition = ("Xpos = " + myBody.transform.localPosition.x + " Ypos = " + myBody.transform.localPosition.y);
        try
        {
            byte[] buffer = Encoding.Unicode.GetBytes(WorldPosition);
            socket.SendTo(buffer, remotePoint);
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
        finally
        {
            Debug.Log("Done");
        }
    }

    void FixedUpdate()
    {
        

        Vector3 moveVec = new Vector3((CrossPlatformInputManager.GetAxis("Horizontal") * MoveForce * 10), //TODO: Sensitivity Changer
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
            IsReloading = true;
            if(BotDifficult.noob)
                nextFire = Time.time + 3;
            if (BotDifficult.abitharder)
                nextFire = Time.time + 4;
            if (BotDifficult.impossible)
                nextFire = Time.time + 5;
            reloadRate = nextFire - Time.time;

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
    private static void ListenTask()
    {
        IPEndPoint Server = new IPEndPoint(IPAddress.Any, 39999);
        socket.Bind(Server);
        try
        {
            while (true)
            {
                StringBuilder GetDataFrom = new StringBuilder();
                int count = 0;
                byte[] bytesdata = new byte[1024];
                EndPoint ServerAdress = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 27016);
                do
                {
                    count = socket.ReceiveFrom(bytesdata, ref ServerAdress);
                    GetDataFrom.Append(Encoding.Unicode.GetString(bytesdata, 0, count));
                } while (socket.Available > 0);

                GetDataFrom.ToString();

            }
        }

        catch (Exception ex)
        {
            Debug.Log(ex);
        }
        finally
        {
            Debug.Log("Done");
        }
    }

}
