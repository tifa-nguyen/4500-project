using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed = 5.0f;
    public Text clockText;
    private int timeCount;
    private float timer = 0.0f;
    private int seconds;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        clockText.text = "Time: " + timeCount.ToString() + " seconds";
    }

    // Update is called once per frame
    void Update()
    {
        timeCount = 0;
        timer += Time.deltaTime;
        seconds = (int)timer % 60;
        timeCount += seconds;
        clockText.text = "Time: " + timeCount.ToString() + " seconds";
    }

    // FixedUpdate is in sync with physics engine
    void FixedUpdate()
    {
        // Receive input directions from player.
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Convert user input to player movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.velocity = movement * speed;
    }
}
