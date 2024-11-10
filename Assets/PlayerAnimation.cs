using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Sprite idle1;  // Sprite de repos/marche 1
    [SerializeField] private Sprite idle2;  // Sprite de repos/marche 2
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void ChangeSpriteIdle(int idleState)
    {
        // Choisit l'animation de repos/marche selon le paramètre
        if (idleState == 1)
        {
            spriteRenderer.sprite = idle1; // Animation de marche
        }
        else
        {
            spriteRenderer.sprite = idle2; // Animation de repos
        }
    }
}