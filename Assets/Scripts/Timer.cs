using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    bool timerEnabled = false;
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;

    void Update()
    {
        if (Input.GetKey("a") || Input.GetKey("d") || Input.GetKey(KeyCode.Space))
        {
            timerEnabled = true;
        }

        if (timerEnabled == true)
        {
            currentTime = currentTime + Time.deltaTime;
            timerText.text = "Time: " + currentTime.ToString("0.000");
        }
    }
}