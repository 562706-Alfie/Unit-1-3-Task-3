using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    HelperScript helper;
    Rigidbody2D rb;
    public Animator anim;
    public LayerMask groundLayer;
    public Vector3 pos;
    public GameObject weapon;


    bool IsGrounded()
    {
        Vector2 offsetLeftUp = new Vector2(0, 0.16f);
        Vector2 offsetLeftDown = new Vector2(0, -0.16f);
        Vector2 offsetRightUp = new Vector2(0, 0.16f);
        Vector2 offsetRightDown = new Vector2(0, -0.16f);
        Vector2 offsetDownLeft = new Vector2(-0.16f, 0);
        Vector2 offsetDownRight = new Vector2(0.16f, 0);

        Vector2 positionDown = transform.position;
        Vector2 directionDown = Vector2.down;
        float distanceDown = 0.18f;
        Vector2 positionDownLeft = transform.position;
        Vector2 directionDownLeft = Vector2.down;
        float distanceDownLeft = 0.18f;
        Vector2 positionDownRight = transform.position;
        Vector2 directionDownRight = Vector2.down;
        float distanceDownRight = 0.18f;
        Vector2 positionLeft = transform.position;
        Vector2 directionLeft = Vector2.left;
        float distanceLeft = 0.18f;
        Vector2 positionRight = transform.position;
        Vector2 directionRight = Vector2.right;
        float distanceRight = 0.18f;
        Vector2 positionLeftUp = transform.position;
        Vector2 directionLeftUp = Vector2.left;
        float distanceLeftUp = 0.18f;
        Vector2 positionLeftDown = transform.position;
        Vector2 directionLeftDown = Vector2.left;
        float distanceLeftDown = 0.18f;
        Vector2 positionRightUp = transform.position;
        Vector2 directionRightUp = Vector2.right;
        float distanceRightUp = 0.18f;
        Vector2 positionRightDown = transform.position;
        Vector2 directionRightDown = Vector2.right;
        float distanceRightDown = 0.18f;

        RaycastHit2D hitDown = Physics2D.Raycast(positionDown, directionDown, distanceDown, groundLayer);
        RaycastHit2D hitDownLeft = Physics2D.Raycast(positionDownLeft, directionDownLeft, distanceDownLeft, groundLayer);
        RaycastHit2D hitDownRight = Physics2D.Raycast(positionDownRight, directionDownRight, distanceDownRight, groundLayer);
        RaycastHit2D hitLeft = Physics2D.Raycast(positionLeft, directionLeft, distanceLeft, groundLayer);
        RaycastHit2D hitRight = Physics2D.Raycast(positionRight, directionRight, distanceRight, groundLayer);
        RaycastHit2D hitLeftUp = Physics2D.Raycast(positionLeftUp + offsetLeftUp, directionLeftUp, distanceLeftUp, groundLayer);
        RaycastHit2D hitLeftDown = Physics2D.Raycast(positionLeftDown + offsetLeftDown, directionLeftDown, distanceLeftDown, groundLayer);
        RaycastHit2D hitRightUp = Physics2D.Raycast(positionRightUp + offsetRightUp, directionRightUp, distanceRightUp, groundLayer);
        RaycastHit2D hitRightDown = Physics2D.Raycast(positionRightDown + offsetRightDown, directionRightDown, distanceRightDown, groundLayer);


        if (hitDown.collider != null || hitLeft.collider != null || hitRight.collider != null || hitDownLeft.collider != null || hitDownRight.collider != null || hitLeftDown.collider != null || hitLeftUp.collider != null || hitRightDown.collider != null || hitRightUp.collider != null)
        {
            return true;
        }

        return false;

    }

    bool SuperJump()
    {
        Vector2 positionDownSuper = transform.position;
        Vector2 directionDownSuper = Vector2.down;
        float distanceDownSuper = 999.0f;

        RaycastHit2D hitDownSuper = Physics2D.Raycast(positionDownSuper, directionDownSuper, distanceDownSuper, groundLayer);

        if (hitDownSuper.collider != null)
        {
            return true;
        }

        return false;

    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        helper = gameObject.AddComponent<HelperScript>();
    }

    // Update is called once per frame


    void Update()
    {
        pos = transform.position;

        float xvel, yvel;
        xvel = rb.linearVelocity.x;
        yvel = rb.linearVelocity.y;

        if (xvel >= 0.1f || xvel <= -0.1f)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        rb.linearVelocity = new Vector3(xvel, yvel, 0);

        if (yvel >= 0.1f)
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }

        rb.linearVelocity = new Vector3(xvel, yvel, 0);

        if (yvel <=-0.001f)
        {
            anim.SetBool("isFalling", true);
        }
        else
        {
            anim.SetBool("isFalling", false);
        }

        rb.linearVelocity = new Vector3(xvel, yvel, 0);


        if (xvel >= 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        rb.linearVelocity = new Vector3(xvel, yvel, 0);

        if (Input.GetKey("a"))
        {
            xvel = -0.8f;
        }

        if (Input.GetKey("d"))
        {
            xvel = 0.8f;
        }

        rb.linearVelocity = new Vector3(xvel, yvel, 0);

        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            yvel = 0.8f;
        }
        else
        {
            return;
        }

        rb.linearVelocity = new Vector3(xvel, yvel, 0);

        if (Input.GetMouseButtonDown(1))
        {
            GameObject clone;
            clone = Instantiate(weapon, transform.position, transform.rotation);
            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
            rb.linearVelocity = new Vector2(15, 0);
            rb.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z + 1);
        }

    }
}

