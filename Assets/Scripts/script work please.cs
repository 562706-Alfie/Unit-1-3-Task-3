using System;
using UnityEngine;

public class Script1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //transform.position.x
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xpos = transform.position.x;
        float ypos = transform.position.y;



        if (Input.GetKey("w") == true)
        {
            ypos = ypos + 0.01f;
            print("X position is " + xpos + ", Y position is " + ypos);
        }

        if (Input.GetKey("s") == true)
        {
            ypos = ypos - 0.01f;
            print("X position is " + xpos + ", Y position is " + ypos);
        }

        if (Input.GetKey("a") == true)
        {
            xpos = xpos - 0.01f;
            print("X position is " + xpos + ", Y position is " + ypos);
        }

        if (Input.GetKey("d") == true)
        {
            xpos = xpos + 0.01f;
            print("X position is " + xpos + ", Y position is " + ypos);
        }

        //position limiters

        if (xpos > 10.5)
        {
            xpos = xpos - 0.1f;
        }

        if (xpos < -10.5)
        {
            xpos = xpos + 0.1f;
        }

        if (ypos > 10)
        {
            ypos = ypos - 0.1f;
        }

        if (ypos < -10)
        {
            ypos = ypos + 0.1f;
        }

        transform.position = new Vector3(xpos, ypos, 0);


    }
}
