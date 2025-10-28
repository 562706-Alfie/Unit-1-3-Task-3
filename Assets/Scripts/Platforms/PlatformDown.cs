using UnityEngine;


public class PlatformDown : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float yvel = 0.8f;
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
        yvel = rb.linearVelocity.y;
        if (_currentTime >= 0)
        {
            yvel = 0.8f;
        }
                
        rb.linearVelocity = new Vector3(0, +yvel);

        if (_currentTime <= 0)
        {
            yvel = -0.8f;
        }

        rb.linearVelocity = new Vector3(0, -yvel);

        if (_currentTime <= -time)
        {
            _currentTime = time;
        }          


    }

}
