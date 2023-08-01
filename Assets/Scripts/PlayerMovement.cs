using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private bool onGround = true;
    private Rigidbody playerRb;
    [Header("Gravity force on player and height of his jump")]
    [SerializeField] float gravitation = 30.0f;
    [SerializeField] int height = 800;
    [System.NonSerialized] public Animator Nanny;
    BackgroundMove bgSc;
    [SerializeField] GameObject panelRestart;
    [SerializeField] ParticleSystem particlesRun;
    [SerializeField] ParticleSystem particlesBird;
    
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -gravitation, 0);
        Nanny = gameObject.GetComponentInChildren<Animator>();
        bgSc = GameObject.Find("Manager").GetComponent<BackgroundMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && onGround && bgSc.gameOn)
        {
            onGround = false;
            Nanny.SetBool("onGround", false);
            playerRb.AddForce(Vector3.up*height,ForceMode.Force);
            particlesRun.Stop();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && bgSc.gameOn)
        {
            onGround = true;
            Nanny.SetBool("onGround", true);
            particlesRun.Play();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Nanny.SetBool("crashed", true);
        bgSc.gameOn = false;
        particlesBird.Play();
        particlesRun.Stop();
        panelRestart.SetActive(true);
    }
}
