using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
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
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Mines") || other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("Border") || other.gameObject.CompareTag("CheckpointWall"))   // On collision with an enemy or wall barrier, do the following:
        {
            Destroy(gameObject);    // Destroy the laser
        }
    }
}
