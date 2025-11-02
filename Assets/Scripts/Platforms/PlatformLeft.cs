using UnityEngine;

public class PlatformLeft : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float xvel = 0.8f;
    float _currentTime;
    public float time = 3;
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
        xvel = rb.linearVelocity.y;
        if (_currentTime <= time)
        {
            xvel = -0.7f;
            GetComponent<SpriteRenderer>().flipX = false;
        }

        rb.linearVelocity = new Vector3(+xvel, 0);

        if (_currentTime <= 0)
        {
            xvel = 0.7f;
            GetComponent<SpriteRenderer>().flipX = true;
        }

        rb.linearVelocity = new Vector3(+xvel, 0);

        if (_currentTime <= -time)
        {
            _currentTime = time;
        }


    }

}
