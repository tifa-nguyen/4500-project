using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Duoshooter
{
    public class ExplosionController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, 0.5f);   // Self-destruct in 0.5 seconds after object creation.

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}