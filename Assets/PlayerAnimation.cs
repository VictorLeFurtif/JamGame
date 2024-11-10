using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Sprite idle1;
    [SerializeField] private Sprite idle2;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    public void ChangeSpriteIdle(int idleState)
    {
        Debug.Log("fils de pu");
        spriteRenderer.sprite = idleState == 1 ? idle1 : idle2;
    }
}
