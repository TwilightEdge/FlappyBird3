using System;
using UnityEngine;

public abstract class powerup : MonoBehaviour
{
    
    public GameObject cat;
    
    public cat classcat;

    public int price;
    
    public abstract void ApplyEffect();
    
    private void Awake()
    {
        cat = GameObject.FindWithTag("Player");
        classcat = cat.GetComponent<cat>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    
    private void OnTriggerStay2D(Collider2D other) // enemy dealing damage
    {
        
        if (Input.GetKeyDown(KeyCode.E) && other.gameObject.CompareTag("Player"))
        {
            if (classcat.food>=price)
            {
                
                classcat.food-=price;
                
                this.ApplyEffect();
                
                //classcat.PowerUpDamageUp();
                
                //classshop.UnregisterEnemy(this.gameObject);
                
                Destroy(gameObject);
                
            }
            else
            {
                //you do not have enough money
            }

            
        }
        
    }
    
}
