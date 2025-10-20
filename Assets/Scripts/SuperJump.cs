using TMPro;
using UnityEngine;

public class SuperJump : MonoBehaviour
{
    Rigidbody2D rb;
    float yvel;
    float xvel;
    float currentTime = 0;
    public TextMeshProUGUI cooldownText;
    public float cooldownDuration = 5f;
    public int PlayerKilledEnemy;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentTime = 0;
    }

    void Update()
    {
        yvel = rb.linearVelocity.y;
        xvel = rb.linearVelocity.x;

        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            if (currentTime < 0)
                currentTime = 0;
        }

        if (currentTime > 0)
        {
            cooldownText.text = "Super Jump Ready In: " + Mathf.Ceil(currentTime).ToString();
            cooldownText.color = Color.red;
        }
        else
        {
            cooldownText.text = "Super Jump Ready!";
            cooldownText.color = Color.green;
        }

        if (Input.GetKeyDown(KeyCode.W) && currentTime <= 0)
        {
            yvel = 1.6f;
            currentTime = cooldownDuration;
        }

        rb.linearVelocity = new Vector2(xvel, yvel);

        if (PlayerKilledEnemy > 0)
        {
            yvel = 1;
            PlayerKilledEnemy = 0;
        }

        rb.linearVelocity = new Vector2(xvel, yvel);

    }
}