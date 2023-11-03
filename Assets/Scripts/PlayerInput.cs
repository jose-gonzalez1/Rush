 using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D coll;

    [SerializeField] private LayerMask jumpableGround;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float Xdir = Input.GetAxisRaw("Horizontal");
        rb.velocity = new UnityEngine.Vector2(Xdir * 3f, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new UnityEngine.Vector2(0, 7f);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, UnityEngine.Vector2.down, .1f, jumpableGround);
    }
}
