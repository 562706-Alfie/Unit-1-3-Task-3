using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    public CoinManager cm;
    public Animator anim;
    float waitForDestroy;


    private void Start()
    {
        waitForDestroy = 0;
    }
    void Update()
    { 
        if( waitForDestroy > 0 )
        {
            waitForDestroy -= Time.deltaTime;
            if (waitForDestroy < 0f)
            {
                Destroy(gameObject);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D Melons)
    {
        anim.SetBool("Collected", true);
        cm.melonCount++;
        waitForDestroy = 0.3f;
    }


}
