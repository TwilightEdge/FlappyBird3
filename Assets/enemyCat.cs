using System;
using UnityEngine;

public class enemyCat : MonoBehaviour
{
    public int HP;
    
    public GameObject cat;
    
    public cat classcat;

    public float timeSinceLastAttack;
    
    public float attackCD;

    public int damage;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        classcat = cat.GetComponent<cat>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
        timePass();
        
    }

    
    private void OnCollisionStay2D(Collision2D collision) // enemy dealing damage
    {
        
        if (collision.gameObject.CompareTag("Player") && timeSinceLastAttack >= attackCD)
        {
            timeSinceLastAttack = 0;
            classcat.takeDamage(damage);
        }
        
    }


    private void OnTriggerEnter2D(Collider2D other) // enemy taking damage
    {
        
        if (other.CompareTag("playerAttack"))
        {
            
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
    
    void timePass()
    {
        timeSinceLastAttack += Time.deltaTime;
        
    }
    
    
}
