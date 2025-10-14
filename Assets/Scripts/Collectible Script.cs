using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    public CoinManager cm;
    public Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D Melons)
    {
        Destroy(gameObject );
        cm.melonCount++;
    }
}
