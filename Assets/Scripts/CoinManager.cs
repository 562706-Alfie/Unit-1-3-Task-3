using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public FinishPoint cm;
    public int melonCount;
    public Text melonText;
    public int melonsNeeded;

    void Start()
    {

    }

    void Update()
    {
        melonText.text = "Melons Collected: " + melonCount.ToString() + "/" + melonsNeeded;
    }
}



