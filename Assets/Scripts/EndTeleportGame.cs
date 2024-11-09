using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTeleportGame : MonoBehaviour
{
    private bool isPlayerInZone = false;

    public Transform player;
    public Animation animationEnd;
    public ZoneRecupTp ztR;
    public GameObject orbv2;
    public GameObject orbv1;
    void Update()
    {
        if (isPlayerInZone)
        {
            ztR.anim.Stop();
            orbv1.SetActive(false);
            orbv2.SetActive(true);
            animationEnd.Play();
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
}
