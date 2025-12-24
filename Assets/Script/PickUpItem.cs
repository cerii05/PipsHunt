using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public bool hasItem = true;
    public GameObject pressEPopup; 
    private bool isPlayerInRange = false;

    void Start()
    {
        if (pressEPopup != null) pressEPopup.SetActive(false);
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            CheckTheBox();
        }
    }

    void CheckTheBox()
    {
        if (hasItem)
        {
            GameManager.instance.CollectItem();
        }
        
        if (pressEPopup != null) pressEPopup.SetActive(false);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
            if (pressEPopup != null) pressEPopup.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            if (pressEPopup != null) pressEPopup.SetActive(false);
        }
    }
}