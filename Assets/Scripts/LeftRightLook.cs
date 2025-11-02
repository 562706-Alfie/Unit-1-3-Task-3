using UnityEngine;
using System;

public class LeftRightLook : MonoBehaviour
{

    Rigidbody2D rb;
    public LayerMask groundLayerMask;
    float xvel;
    public PlayerScript playerScript;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xvel = 0.16f;
    }

    void Update()
    {
        Movement();

        print("player pos is " + playerScript.pos);
    }


    void Movement()
    {
        if (xvel > 0)
            {
                xvel = -xvel;
                GetComponent<SpriteRenderer>().flipX = false;
            }



        if (xvel < 0)
            {
                xvel = -xvel;
                GetComponent<SpriteRenderer>().flipX = true;
            }

     

        rb.linearVelocity = new Vector3(xvel, 0, 0);

    }

}
