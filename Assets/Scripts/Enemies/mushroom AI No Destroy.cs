using UnityEngine;
using System;

public class mushroomAINoRespawn : MonoBehaviour
{

    Rigidbody2D rb;
    public LayerMask groundLayerMask;
    public LayerMask MushroomLayerMask;
    public float Speed;
    float xvel;
    float yvel;
    public PlayerScript PlayerScript;
    public SuperJump SJ;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xvel = Speed;
    }

    void Update()
    {
        Movement();

        print("player pos is " + PlayerScript.pos);
    }

    void OnTriggerEnter2D(Collider2D Player)
    {
        SJ.PlayerKilledEnemy++;
    }


    void Movement()
    {
        if (xvel > 0)
        {
            if (ExtendedRayCollisionCheck(0.16f, 0) == false)
            {
                xvel = -xvel;
                GetComponent<SpriteRenderer>().flipX = false;
            }

        }

        if (xvel < 0)
        {
            if (ExtendedRayCollisionCheck(-0.16f, 0) == false)
            {
                xvel = -xvel;
                GetComponent<SpriteRenderer>().flipX = true;
            }

        }

        rb.linearVelocity = new Vector3(xvel, 0, 0);

    }

    public bool ExtendedRayCollisionCheck(float xoffs, float yoffs)
    {
        float rayLength = 0.112f;
        bool hitSomething = false;

        Vector3 offset = new Vector3(xoffs, yoffs, 0);
        RaycastHit2D hit;


        hit = Physics2D.Raycast(transform.position + offset, -Vector2.up, rayLength, groundLayerMask);
        Color hitColor = Color.white;

        if (hit.collider != null)
        {
            print("Player has collided with Ground layer");
            hitColor = Color.green;
            hitSomething = true;
        }

        Debug.DrawRay(transform.position + offset, -Vector3.up * rayLength, hitColor);

        return hitSomething;

    }


}
