using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneRecupTp : MonoBehaviour
{
    private bool isPlayerInZone = false;

    public Transform player;
    public GameObject tpObjPlayer;
    public Animation anim;
    public GameObject tpToDeleate;
    void Update()
    {
        if (isPlayerInZone && Input.GetKeyDown(KeyCode.E))
        {
            tpObjPlayer.SetActive(true);
            anim.Play();
            tpToDeleate.SetActive(false);
        }
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = false;
        }
    }

    // Afficher un message à l'écran
    private void OnGUI()
    {
        if (isPlayerInZone)
        {
            GUI.Label(new Rect(10, 10, 200, 20), "Appuyez sur E pour effectuer l'action.");
        }
    }
}
