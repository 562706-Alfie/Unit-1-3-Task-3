using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;

    void Update()
    {
        currentTime = currentTime + Time.deltaTime;
        timerText.text = currentTime.ToString("0.000");
    }
}
