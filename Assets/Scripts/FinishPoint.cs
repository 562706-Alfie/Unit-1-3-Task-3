using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using Unity.VisualScripting;

public class FinishPoint : MonoBehaviour
{
    public CoinManager cm;
    public int melonsNeeded;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && cm.melonCount == melonsNeeded)
        {
            // go to next level
            SceneController.instance.NextLevel();
        }
    }
}
