using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Duoshooter
{
    public class BulletController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, 3f);   // Self-destruct in 3 seconds after object creation.
        }

        // Update is called once per frame
        void Update()
        {

        }


        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Player 1") || other.gameObject.CompareTag("Player 2") || other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Boss") || other.gameObject.CompareTag("Mines") || other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("EnemyBullet") || other.gameObject.CompareTag("Border") || other.gameObject.CompareTag("CheckpointWall"))   // On collision with an enemy or wall barrier, do the following:
            {
                Destroy(gameObject);    // Destroy the laser
            }
        }
    }
}