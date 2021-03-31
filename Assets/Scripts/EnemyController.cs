using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //public GameObject explodePrefab;
    private Rigidbody2D rb2d;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))   // On collision with an bullet, do the following:
        {
            GameController.count++;     // Increments the score count
            Destroy(gameObject);    // Destory the enemy
            //Instantiate(explodePrefab, transform.position, transform.rotation); // Play explosion animation
        }
        if (other.gameObject.CompareTag("Player"))   // On collision with an bullet, do the following:
        {
            Destroy(gameObject);    // Destory the enemy
            //Instantiate(explodePrefab, transform.position, transform.rotation); // Play explosion animation
        }
    }
}

