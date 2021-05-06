using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Duoshooter
{
    public class BossController : MonoBehaviour
    {
        public GameObject player;
        public Rigidbody2D bullet;
        public GameObject gun;
        public GameObject explodePrefab;
        private Rigidbody2D rb2d;
        private static int bossHealth = 20;
        public float speed = 3f;
        public float shotForce = 100f;
        private float timer = 0.0f;

        // Start is called before the first frame update
        void Start()
        {
            rb2d = this.GetComponent<Rigidbody2D>();
            timer = 0.0f;
        }

        // Update is called once per frame
        void Update()
        {
            if (true)
            {
                timer += Time.deltaTime;
                int seconds = (int)timer % 60;
                if (seconds >= 1)
                {
                    bossFire();
                    timer = 0;
                }
            }
        }

        public void bossFire()
        {
            //AudioSource[] sounds = GetComponents<AudioSource>();
            Rigidbody2D bulletPre = Instantiate(bullet) as Rigidbody2D;  // Spawn laser
            bulletPre.transform.position = gun.transform.position;  // Set laser position
            bulletPre.transform.rotation = transform.rotation;      // Set laser rotation
            Vector2 direction = (player.transform.position - transform.position);
            bulletPre.AddForce(direction * shotForce);   // Shoot laser up from the direction the player is facing.
            //sounds[0].Play();       // Play laser sound effect.
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Bullet"))   // On collision with an bullet, do the following:
            {
                bossHealth--;     // Increments the score count
                if (bossHealth == 0)
                {
                    Destroy(gameObject);    // Destory the enemy
                    Instantiate(explodePrefab, transform.position, transform.rotation); // Play explosion animation
                    GameController.isGameWin = true;
                }
            }
        }
    }
}