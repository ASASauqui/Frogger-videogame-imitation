using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // ------------------Variables------------------
        public Rigidbody2D rb;
        public float speed = 1;


    // ------------------Updates------------------
        void FixedUpdate()
        {
            Vector2 direction = new Vector2(transform.right.x, transform.right.y);
            rb.MovePosition(rb.position + direction * Time.fixedDeltaTime * speed);
        }
}