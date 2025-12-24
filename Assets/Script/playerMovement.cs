using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))] 
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))] // Added this so we can flip the sprite
>>>>>>> 1e736a4de4e07d4d3a738a10a0fb2da4da44e9c9
public class playerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector2 moveInput;
    private bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
<<<<<<< HEAD
        spriteRenderer = GetComponent<SpriteRenderer>(); 

        // 1. Matikan gravitasi agar tidak jatuh (karena ini game top-down/2D bebas)
        rb.gravityScale = 0f; 
        
        // 2. Kunci rotasi agar karakter tidak berputar saat menabrak benda
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        // 3. Pastikan rotasi awal tegak lurus
=======
        spriteRenderer = GetComponent<SpriteRenderer>(); // Grab the sprite component

        // 1. Turn off gravity
        rb.gravityScale = 0f; 
        
        // 2. Lock Physics Rotation (Prevents spinning on collision)
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        // 3. Force rotation to zero on start (Ensures she stands straight up)
>>>>>>> 1e736a4de4e07d4d3a738a10a0fb2da4da44e9c9
        transform.rotation = Quaternion.identity;
    }

    void Update()
    {
<<<<<<< HEAD
        // CEK PAUSE: Jika game sedang berhenti, jangan baca input gerakan
        if (Time.timeScale == 0f) return; 

        if (!canMove) return;

        // Ambil Input dari Keyboard (WASD / Arrow Keys)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Normalisasi agar gerak diagonal tidak lebih cepat dari gerak lurus
        moveInput = new Vector2(moveX, moveY).normalized;

        // FLIP SPRITE: Mengubah arah hadap karakter berdasarkan input kiri/kanan
        if (moveX < 0)
        {
            spriteRenderer.flipX = true; // Hadap Kiri
        }
        else if (moveX > 0)
        {
            spriteRenderer.flipX = false; // Hadap Kanan
=======
        if (!canMove) return;

        // Get Input
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Normalize vector
        moveInput = new Vector2(moveX, moveY).normalized;

        // --- REPLACED ROTATION WITH FLIPPING ---
        // This keeps the character upright (Static) but changes facing direction
        
        if (moveX < 0)
        {
            spriteRenderer.flipX = true; // Face Left
        }
        else if (moveX > 0)
        {
            spriteRenderer.flipX = false; // Face Right
>>>>>>> 1e736a4de4e07d4d3a738a10a0fb2da4da44e9c9
        }
    }

    void FixedUpdate()
    {
<<<<<<< HEAD
        // Jika sedang pause atau canMove false, pastikan velocity nol
        if (!canMove || Time.timeScale == 0f) 
        {
            rb.velocity = Vector2.zero;
            return;
        }

        // Terapkan gerakan ke Rigidbody2D
=======
        if (!canMove) return;
        // Apply Movement
>>>>>>> 1e736a4de4e07d4d3a738a10a0fb2da4da44e9c9
        rb.velocity = moveInput * moveSpeed;
    }

    public void StopMoving()
    {
        canMove = false;
<<<<<<< HEAD
        rb.velocity = Vector2.zero; 
    }
}
=======
        rb.velocity = Vector2.zero; // Force stop immediately
    }
}

>>>>>>> 1e736a4de4e07d4d3a738a10a0fb2da4da44e9c9
