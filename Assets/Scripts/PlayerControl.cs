using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    
    public float speed = 0.18f;
       public float jumph = 4.01f;
       public float direction;
       public float directionTopToJump;
       public Rigidbody2D rb;
       private bool canJump = false;
       
       void Update ()
       {
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

       private void OnCollisionEnter2D(Collision2D other)
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

