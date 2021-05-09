using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Duoshooter
{
    public class EnemyController : MonoBehaviour
    {
        public GameObject explodePrefab;
        private GameObject player1;
        private GameObject player2;
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
        }

        // Update is called once per frame
        void Update()
        {
            player1 = GameObject.FindGameObjectWithTag("Player 1");
            if (PhotonNetwork.CountOfPlayers == 2)
            {
                player2 = GameObject.FindGameObjectWithTag("Player 2");
            }
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
            int rand = Random.Range(0, 10);
            //AudioSource[] sounds = GetComponents<AudioSource>();
            Rigidbody2D bulletPre = Instantiate(bullet) as Rigidbody2D;  // Spawn laser
            bulletPre.transform.position = gun.transform.position;  // Set laser position
            bulletPre.transform.rotation = transform.rotation;      // Set laser rotation
            if (PhotonNetwork.CountOfPlayers == 1)
            {
                Vector2 direction = (player1.transform.position - transform.position);
                bulletPre.AddForce(direction * shotForce);   // Shoot laser up from the direction the player is facing.
            }
            if (PhotonNetwork.CountOfPlayers == 2)
            {
                if (rand % 2 == 0)
                {
                    Vector2 direction = (player1.transform.position - transform.position);
                    bulletPre.AddForce(direction * shotForce);   // Shoot laser up from the direction the player is facing.
                }
                if (rand % 2 == 1)
                {
                    Vector2 direction = (player2.transform.position - transform.position);
                    bulletPre.AddForce(direction * shotForce);   // Shoot laser up from the direction the player is facing.
                }
            }
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
            if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Player 1") || other.gameObject.CompareTag("Player 2"))   // On collision with the player, do the following:
            {
                GameController.count++;     // Increments the score count
                Destroy(gameObject);    // Destory the enemy
                Instantiate(explodePrefab, transform.position, transform.rotation); // Play explosion animation
            }
        }
    }
}