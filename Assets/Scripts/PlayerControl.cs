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

    [SerializeField] private Sprite jumpSprite1;  // Sprite de saut 1
    [SerializeField] private Sprite jumpSprite2;  // Sprite de saut 2
    [SerializeField] private Sprite jumpSprite3;  // Sprite de saut 3
    private SpriteRenderer spriteRenderer;

    private bool isJumping = false;
    private float jumpTime = 0f;
    private int jumpFrame = 0;

    // Référence au script PlayerAnimation
    private PlayerAnimation playerAnimation;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Récupère le SpriteRenderer
        playerAnimation = GetComponent<PlayerAnimation>(); // Récupère le script PlayerAnimation
    }

    void Update()
    {
        // Gestion de la direction
        direction = Input.GetAxis("Horizontal");
        directionTopToJump = rb.velocity.y;

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

        // Logique de saut
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            directionTopToJump = jumph;
            canJump = false;
            isJumping = true;
            jumpFrame = 0;
            jumpTime = 0f;
        }

        // Déplacement du joueur
        Vector2 dp = new Vector2(direction * speed, directionTopToJump);
        rb.velocity = dp;

        // Gestion de l'animation de saut
        if (isJumping)
        {
            jumpTime += Time.deltaTime;

            if (jumpTime >= 0.2f) // Augmenter le délai à 0.2 secondes pour ralentir l'animation
            {
                jumpTime = 0f;
                jumpFrame++;

                switch (jumpFrame)
                {
                    case 1:
                        spriteRenderer.sprite = jumpSprite1; // Sprite de saut 1
                        break;
                    case 2:
                        spriteRenderer.sprite = jumpSprite2; // Sprite de saut 2
                        break;
                    case 3:
                        spriteRenderer.sprite = jumpSprite3; // Sprite de saut 3
                        break;
                }

                if (jumpFrame >= 3)
                {
                    isJumping = false; // Arrête l'animation de saut après les 3 frames
                    playerAnimation.ChangeSpriteIdle(1);  // Revenir à l'animation de repos ou de marche après le saut
                }
            }
        }
        else if (canJump) // Animation de marche ou de repos lorsque le joueur est au sol
        {
            // Change les sprites de marche en fonction de la direction
            if (direction != 0)
            {
                playerAnimation.ChangeSpriteIdle(1);  // Appelle la méthode de changement de sprite pour la marche
            }
            else
            {
                playerAnimation.ChangeSpriteIdle(2);  // Reviens au sprite idle si le joueur ne bouge pas
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        foreach (ContactPoint2D contact in other.contacts)
        {
            if (contact.normal.y > 0.5f) // Vérifie si le joueur touche le sol
            {
                canJump = true;
                if (!isJumping)
                {
                    jumpFrame = 0; // Réinitialise l'animation de saut
                }
            }
        }
    }
}
