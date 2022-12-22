using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Photon.Pun;

public class CtrlPlayer : MonoBehaviour
{
    public float speed, jumpforce;
    private Rigidbody2D rig;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<PhotonView>().IsMine)
        {
            rig = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            Camera.main.transform.SetParent(transform);
            Camera.main.transform.position = transform.position + (Vector3.back * 6)+ (Vector3.up * 0.5f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GetComponent<PhotonView>().IsMine)
        {
            // Movimiento izquierda  y derecha.
            rig.velocity = (transform.right * speed * Input.GetAxis("Horizontal")) +
                     (transform.up * rig.velocity.y);

            // Movimiento salto
            if (Input.GetButtonDown("Jump") && ((rig.velocity.y < 0.2) && (rig.velocity.y > -0.2)))
            {
                rig.AddForce(transform.up * jumpforce);
            }

            if (rig.velocity.x > 0.1f)
                GetComponent<SpriteRenderer>().flipX = false;
            else if (rig.velocity.x < -0.1f)
                GetComponent<SpriteRenderer>().flipX = true;


            anim.SetFloat("velocityX", Mathf.Abs(rig.velocity.x));
            anim.SetFloat("velocityY", rig.velocity.y);
        }
            

    }
}
