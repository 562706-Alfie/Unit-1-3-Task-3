using UnityEngine;
using System;

public class EnemyAI : MonoBehaviour
{

    Rigidbody2D rb;
    public LayerMask groundLayerMask;
    float xvel;
    public PlayerScript playerScript;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xvel = 1;
    }

    void Update()
    {
        Movement();

        print("player pos is " + playerScript.pos);
    }


    void Movement()
    {
        if( xvel > 0 )
        {
            if(ExtendedRayCollisionCheck(1,0) == false )
            {
                xvel = -xvel;
                GetComponent<SpriteRenderer>().flipX = true;
            }

        }

        if (xvel < 0)
        {
            if (ExtendedRayCollisionCheck(-1, 0) == false)
            {
                xvel = -xvel;
                GetComponent<SpriteRenderer>().flipX = false;
            }

        }

        rb.linearVelocity = new Vector3(xvel, 0, 0);

    }

    public bool ExtendedRayCollisionCheck(float xoffs, float yoffs)
    {
        float rayLength = 0.7f; // length of raycast
        bool hitSomething = false;

        // convert x and y offset into a Vector3 
        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        //cast a ray downward 
        RaycastHit2D hit;


        hit = Physics2D.Raycast(transform.position + offset, -Vector2.up, rayLength, groundLayerMask);

        Color hitColor = Color.white;


        if (hit.collider != null)
        {
            print("Player has collided with Ground layer");
            hitColor = Color.green;
            hitSomething = true;
        }
        // draw a debug ray to show ray position
        // You need to enable gizmos in the editor to see these
        Debug.DrawRay(transform.position + offset, -Vector3.up * rayLength, hitColor);

        return hitSomething;

    }


}
