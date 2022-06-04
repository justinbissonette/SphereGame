﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody rigidbody;
    private float distToGround;
    private bool isGrounded;
    private float jumpTimer;
    public float jumpDuration;
    public float jumpForce;
    bool jumpHeld;

    private void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    void Update()
    {
        // remove jump potential after jump button is lifted
        if (Input.GetButtonUp("Jump")) { jumpTimer = 0f; }

        // is jumping
        if (Input.GetButton("Jump"))
            jumpHeld = true;
        else
            jumpHeld = false;
    }

    private void FixedUpdate()
    {
        // movement
        if (Input.GetAxis("Horizontal") > 0)
        {
            rigidbody.AddForce(Vector3.right * speed * Time.deltaTime);
        }

        else if (Input.GetAxis("Horizontal") < 0)
        {
            rigidbody.AddForce(Vector3.left * speed * Time.deltaTime);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            rigidbody.AddForce(Vector3.forward * speed * Time.deltaTime);
        }

        else if (Input.GetAxis("Vertical") < 0)
        {
            rigidbody.AddForce(Vector3.back * speed * Time.deltaTime);
        }

        // check if grounded
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);

        // jumping
        if (isGrounded == true) { jumpTimer = jumpDuration; }
        
        if (jumpHeld) // jump
        {
            if (jumpTimer > 0f)
            {
                rigidbody.AddForce(Vector3.up * jumpForce * Time.deltaTime);
                //rigidbody.velocity = new Vector3(0f, jumpForce, 0f);
                jumpTimer -= Time.deltaTime;
            }
        }

        // increase fall speed
        if (rigidbody.velocity.y < -0.1)
        {
            rigidbody.velocity += Vector3.up * Physics2D.gravity.y * 5f * Time.deltaTime;
        }
    }
}