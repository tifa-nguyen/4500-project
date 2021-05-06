using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Duoshooter
{
    public class ShooterController : MonoBehaviour
    {
        public Rigidbody2D bullet;
        public GameObject gun;
        public float shotForce = 300f;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Fire1"))   // When Fire1 is pushed down, do the following:
            {
                //AudioSource[] sounds = GetComponents<AudioSource>();
                Rigidbody2D bulletPre = Instantiate(bullet) as Rigidbody2D;  // Spawn laser
                bulletPre.transform.position = gun.transform.position;  // Set laser position
                bulletPre.transform.rotation = transform.rotation;      // Set laser rotation
                bulletPre.AddForce(transform.up * shotForce);   // Shoot laser up from the direction the player is facing.
                                                                //sounds[0].Play();       // Play laser sound effect.
            }
        }
    }
}