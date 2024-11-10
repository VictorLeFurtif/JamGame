using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightScript : MonoBehaviour
{
    public GameObject fightZone;  
    public float fightZoneDuration = 0.5f;  
    [SerializeField] private Sprite idleFight; 
     
    [SerializeField] private SpriteRenderer spriteRenderer;

    private bool isFighting = false;  

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isFighting)
        {
            StartFight();
        }
    }

    
    private void StartFight()
    {
        
        spriteRenderer.sprite = idleFight;

       
        fightZone.SetActive(true);

       
        isFighting = true;

        
        Debug.Log("Tu tapes");

        
        StartCoroutine(DeactivateFightZoneAfterDelay());
    }

    
    private IEnumerator DeactivateFightZoneAfterDelay()
    {
        yield return new WaitForSeconds(fightZoneDuration);  

    
        fightZone.SetActive(false);

      
       

        
        isFighting = false;

     
        Debug.Log("Fin du combat");
    }

   
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ennemy"))
        {
           
            other.gameObject.SetActive(false);

           
            Debug.Log("L'ennemi a été frappé !");
        }
    }
}
