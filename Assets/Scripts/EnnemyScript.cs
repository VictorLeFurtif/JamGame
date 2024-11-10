using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyScript : MonoBehaviour
{
    public float vitesse = 3f;  
    public float xMin = -5f;    
    public float xMax = 5f;     
    public Rigidbody2D rb;
    public GameObject canvasGameOver;
    public GameObject VFXexplosion;
   
    private bool seDeplaceVersDroite = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float xPosition = transform.position.x;

        if (seDeplaceVersDroite)
        {
            if (xPosition < xMax)
            {
                rb.velocity = new Vector2(vitesse, rb.velocity.y);
                
                transform.Rotate(0f, 0f, 360f* Time.deltaTime); 
            }
            else
            {
                seDeplaceVersDroite = false;
            }
        }
        else
        {
            if (xPosition > xMin)
            {
                rb.velocity = new Vector2(-vitesse, rb.velocity.y);
                
                transform.Rotate(0f, 0f, -360f * Time.deltaTime); 
            }
            else
            {
                seDeplaceVersDroite = true;
            }
        }
    }


    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector2 deathPlace = new Vector2(other.transform.position.x, other.transform.position.y);
            Destroy(other.gameObject);
            Instantiate(VFXexplosion, deathPlace, Quaternion.identity);
            canvasGameOver.SetActive(true);
            
        }
    }
}

