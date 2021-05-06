using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Duoshooter
{
    public class EnemyController : MonoBehaviour
    {
        public GameObject explodePrefab;
        private GameObject player;
        private Rigidbody2D rb2d;
        public Rigidbody2D bullet;
        public GameObject gun;
        public float speed = 3f;
        public float shotForce = 100f;
        private float timer = 0.0f;

        // Start is called before the first frame update
        void Start()
        {
            rb2d = this.GetComponent<Rigidbody2D>();
            player = GameObject.FindGameObjectWithTag("Player");
        }

        // Update is called once per frame
        void Update()
        {
            if (true)
            {
                timer += Time.deltaTime;
                int seconds = (int)timer % 60;
                if (seconds >= 2)
                {
                    shoot();
                    timer = 0;
                }
            }
        }

        public void shoot()
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
            if (other.gameObject.CompareTag("Bullet"))   // On collision with a bullet, do the following:
            {
                GameController.count++;     // Increments the score count
                Destroy(gameObject);    // Destory the enemy
                Instantiate(explodePrefab, transform.position, transform.rotation); // Play explosion animation
            }
            if (other.gameObject.CompareTag("Player"))   // On collision with the player, do the following:
            {
                GameController.count++;     // Increments the score count
                Destroy(gameObject);    // Destory the enemy
                Instantiate(explodePrefab, transform.position, transform.rotation); // Play explosion animation
            }
        }
    }
}