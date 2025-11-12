using System;
using UnityEngine;

public class enemyCat : MonoBehaviour
{
    public int HP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // The core line you need:
        if (other.CompareTag("playerAttack"))
        {
            HP = HP - 3;
            CheckHP();
        }
    
        
    }

    void CheckHP()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
