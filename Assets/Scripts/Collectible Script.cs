using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    public CoinManager cm;
    public Animator anim;

    void OnTriggerEnter2D(Collider2D Melons)
    {
        Destroy(gameObject);
        cm.melonCount++;
    }
}
