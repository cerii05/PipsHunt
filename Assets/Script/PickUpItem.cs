using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
<<<<<<< HEAD
    public bool hasItem = true;
    public GameObject pressEPopup; // Tarik UI "Press E" Anda ke sini
    private bool isPlayerInRange = false;

    void Start()
    {
        if (pressEPopup != null) pressEPopup.SetActive(false); // Sembunyikan saat mulai
    }

    void Update()
    {
=======
    [Header("Is this a Real Item?")]
    public bool hasItem = true; // CHECK this box for real items. UNCHECK for empty ones.

    private bool isPlayerInRange = false;

    void Update()
    {
        // Only run if player is close AND presses E
>>>>>>> 1e736a4de4e07d4d3a738a10a0fb2da4da44e9c9
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            CheckTheBox();
        }
    }

    void CheckTheBox()
    {
        if (hasItem)
        {
<<<<<<< HEAD
            GameManager.instance.CollectItem();
        }
        
        if (pressEPopup != null) pressEPopup.SetActive(false); // Sembunyikan setelah box hancur
=======
            // CASE A: It has an item
            Debug.Log(">>> SUCCESS! You found an item!");
            GameManager.instance.CollectItem(); // Tell the manager
        }
        else
        {
            // CASE B: It is empty
            Debug.Log(">>> EMPTY! Nothing here.");
        }

        // FINAL STEP: Make the square disappear (Destroy it)
        // This happens for BOTH empty and real boxes so you can't check them twice.
>>>>>>> 1e736a4de4e07d4d3a738a10a0fb2da4da44e9c9
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
<<<<<<< HEAD
            if (pressEPopup != null) pressEPopup.SetActive(true); // Munculkan "Press E"
=======
            Debug.Log("Press 'E' to search...");
>>>>>>> 1e736a4de4e07d4d3a738a10a0fb2da4da44e9c9
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
<<<<<<< HEAD
            if (pressEPopup != null) pressEPopup.SetActive(false); // Sembunyikan "Press E"
        }
    }
}
=======
        }
    }
}
>>>>>>> 1e736a4de4e07d4d3a738a10a0fb2da4da44e9c9
