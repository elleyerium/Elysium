using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class OnlineControl : Photon.MonoBehaviour
{
    public float MoveForce = 5;
    PhotonView pv;
    public GameObject shot;
    public Transform rPos01;
    public GameObject shot1;
    public Transform rPos02;
    private static float nextFire;
    private float lastSynchronizationTime = 0f;
    private float syncDelay;
    private float syncTime;
    private Vector3 TargetPosition;
    private Quaternion TargetRotation;
    [SerializeField]
    Rigidbody2D myBody;
    void Start()
    {
        pv = GetComponent<PhotonView>();

        myBody = this.GetComponent<Rigidbody2D>();
    }
   

    void Input()
    {
        Vector3 moveVec = new Vector3((CrossPlatformInputManager.GetAxis("Horizontal") * MoveForce * 10),
                  (CrossPlatformInputManager.GetAxis("Vertical"))
                  * MoveForce * 10);
        Vector3 lookVec = new Vector3((CrossPlatformInputManager.GetAxis("Horizontal")),
            (CrossPlatformInputManager.GetAxis("Vertical")), 4096);
        if (lookVec.x != 0 && lookVec.y != 0)
            transform.rotation = Quaternion.LookRotation(lookVec, Vector3.back);
        myBody.AddForce(moveVec);
        myBody.AddForce(lookVec);

    }
    public void shoot()
    {
        if (Time.time >= nextFire && AmmoCounter.AmmodownRocket > 0)
        {
            nextFire = Time.time + 5;
            GameObject clone = Instantiate(shot, rPos01.position, rPos01.rotation);
            GameObject clone2 = Instantiate(shot1, rPos02.position, rPos02.rotation);
            clone.SetActive(true);
            clone2.SetActive(true);
            Destroy(clone, 5f);
            Destroy(clone2, 5f);
            AmmoCounter.AmmodownRocket -= 1;
        }
    }
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isReading)
        {
            if (!pv.isMine)
                this.TargetPosition = (Vector3)stream.ReceiveNext();
                this.TargetRotation = (Quaternion)stream.ReceiveNext();
        }
        else
        { if (pv.isMine)
                stream.SendNext(transform.position);
                stream.SendNext(transform.rotation);
        }
    
    }
    void Update()
    {     if (!pv.isMine)
            {
                transform.position = Vector3.Lerp(transform.position, TargetPosition, Time.deltaTime * 5);
                transform.rotation = Quaternion.Lerp(transform.rotation, TargetRotation, Time.deltaTime * 5);
            }
        
        if (photonView.isMine)
        {
            Input();
        }
        else
        {
            SyncedMovement();
        }
    }
    private void SyncedMovement()
    {
          transform.position = Vector3.Lerp(transform.position, TargetPosition, Time.deltaTime * 5);
          transform.rotation = Quaternion.RotateTowards(transform.rotation, TargetRotation, 0.25f);

    }

}
