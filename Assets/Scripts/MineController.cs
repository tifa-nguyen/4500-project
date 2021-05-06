using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Duoshooter
{
    public class MineController : MonoBehaviour
    {
        public GameObject explodePrefab;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Bullet"))   // On collision with an bullet, do the following:
            {
                GameController.timer += 5;     // Increase time by 5 seconds.
                Destroy(gameObject);    // Destory the mine
                Instantiate(explodePrefab, transform.position, transform.rotation); // Play explosion animation
            }
        }
    }
}