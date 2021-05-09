using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Duoshooter
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D rb2d;
        public float speed = 5.0f;
        public int maxHealth = 10;
        //private int health;


        // Start is called before the first frame update
        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
            //health = 10;

        }

        // Update is called once per frame
        void Update()
        {

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

        /*private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemy") && health > 0 || other.gameObject.CompareTag("Bullet") && health > 0) // If health is greater than 0, lower current health.
            {
                health--;
            }
        }*/
    }
}