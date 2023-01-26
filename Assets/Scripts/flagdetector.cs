using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class flagdetector : MonoBehaviourPun
{
    public GameObject señal, lienzo, j1,j2;
    public bool bandera;
    public float tiempobandera;
    public Rigidbody2D jugador;

    public Canvas canvas;
    private ControlHud hud;

    // Start is called before the first frame update
    /*private void Awake()
    {
        if (PhotonNetwork.IsMasterClient && photonView.IsMine)
        {
            bandera = true;
            señal.SetActive(true);
        }
        else
        {
            bandera = false;
            señal.SetActive(false);
        }

        if (PhotonNetwork.IsMasterClient && !photonView.IsMine)
        {
            bandera = true;
            señal.SetActive(true);
        }
        
    }*/
    void Start()
    {
        jugador = GetComponent<Rigidbody2D>();
        lienzo = GameObject.Find("Canvas");
        canvas = lienzo.GetComponent<Canvas>();
        hud = canvas.GetComponent<ControlHud>();
        flagging();
    }

    // Update is called once per frame
    void Update()
    {
        tiempobandera += Time.deltaTime;
        if (PhotonNetwork.IsMasterClient)
        {
            if (photonView.IsMine)
            {
                j1.SetActive(true);
                j2.SetActive(false);
            }
            else if (!photonView.IsMine)
            {
                j1.SetActive(false);
                j2.SetActive(true);
            }
            
        }
        else if (!PhotonNetwork.IsMasterClient)
        {
            if (photonView.IsMine)
            {
                j1.SetActive(false);
                j2.SetActive(true);
            }
            else if (!photonView.IsMine)
            {
               
                j1.SetActive(true);
                j2.SetActive(false);
            }
        }

       
       
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            flagging();

        }
    }

    public void flagging()
    {
        if (tiempobandera > 1)
        {

            if (bandera)
            {
                bandera = false;
                señal.SetActive(false);
                tiempobandera = 0;
                hud.SetBall(true);

            }
            else
            {
                bandera = true;
                señal.SetActive(true);
                tiempobandera = 0;
                hud.SetBall(false);
            }
            tiempobandera = 0;

        }
    }
}
