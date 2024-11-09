using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float rotationSpeed = 180f;
    public float speed = 0.18f;
       public float jumph = 4.01f;
       public float direction;
       public float directionTopToJump;
       public Rigidbody2D rb;
       private bool canJump = false;
       private float lastDirection = 1f;
       
       void Update ()
       {
           if (direction < 0 && lastDirection >= 0)
           {
               transform.Rotate(0f, 180f, 0f, Space.Self);
               lastDirection = -1;
           }
           else if (direction > 0 && lastDirection <= 0)
           {
               transform.Rotate(0f, 180f, 0f, Space.Self);
               lastDirection = 1; 
           }
           
           direction = Input.GetAxis("Horizontal");
           directionTopToJump = rb.velocity.y;
           if (Input.GetKeyDown(KeyCode.Space) && canJump)
           {
               directionTopToJump = jumph;
               canJump = false;
           }
           
           Vector2 dp = new Vector2(direction*speed,directionTopToJump);
           rb.velocity = dp;
       }

       private void OnCollisionStay2D(Collision2D other)
       {
           foreach (ContactPoint2D contact in other.contacts)
           {
               if (contact.normal.y > 0.5f)
               {
                   canJump = true;
               }
           }
       }
}

