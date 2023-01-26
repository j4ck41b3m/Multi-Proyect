using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class flagdetector : MonoBehaviourPun
{
    public GameObject señal;
    public bool bandera;
    public float tiempobandera;
    public Rigidbody2D jugador;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempobandera += Time.deltaTime;

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (tiempobandera > 1)
            {

                if (bandera)
                {
                    bandera = false;
                    señal.SetActive(false);
                    tiempobandera = 0;

                }
                else
                {
                    bandera = true;
                    señal.SetActive(true);
                    tiempobandera = 0;

                }
                tiempobandera = 0;

            }

        }
    }
}
