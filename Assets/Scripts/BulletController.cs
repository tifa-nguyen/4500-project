using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("CheckpointWall"))   // On collision with an enemy or wall barrier, do the following:
        {
            Destroy(gameObject);    // Destroy the laser
        }
/*        if (other.gameObject.tag == "OuterWall")
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>()); // Ignore the outer wall if the above does not destroy the laser and fly off map.
        }*/
    }
}
