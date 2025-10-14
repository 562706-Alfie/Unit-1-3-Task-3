using UnityEngine;
using Unity.VisualScripting;


public class PLatformUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float yvel = -5;
    float _currentTime;
    float time = 3;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _currentTime = time;
    }

    // Update is called once per frame
    void Update()
    {
        _currentTime = _currentTime - Time.deltaTime;
        yvel = rb.linearVelocity.y;
        if (_currentTime <= time)
        {
            yvel = -5f;
        }

        rb.linearVelocity = new Vector3(0, +yvel);

        if (_currentTime <= 0)
        {
            yvel = 4.65f;
        }

        rb.linearVelocity = new Vector3(0, -yvel);

        if (_currentTime <= -3)
        {
            _currentTime = time;
        }


    }

}
