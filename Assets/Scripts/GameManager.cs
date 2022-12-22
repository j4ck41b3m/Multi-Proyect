using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
            PhotonNetwork.Instantiate("Player", new Vector3(1, 0.2f, 0), Quaternion.identity);
        else
            PhotonNetwork.Instantiate("Player2", new Vector3(0.5f, 0.2f, 0), Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
