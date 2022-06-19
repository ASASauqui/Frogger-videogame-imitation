using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    // ------------------Variables------------------
        public float timeToDestroy = 0f;


    // ------------------Updates------------------
        void FixedUpdate()
        {
            Destroy(gameObject, timeToDestroy);
        }
}