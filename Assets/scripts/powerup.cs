using System;
using UnityEngine;

public abstract class powerup : MonoBehaviour
{
    
    public GameObject cat;
    
    public cat classcat;

    public int price;
    
    //public bool playerIsTouching; 
    
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

    private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("you are in");
                
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("E pushed");

                    if (classcat.food >= price)
                    {
                        Debug.Log("you have the food");

                        classcat.food -= price;

                        this.ApplyEffect();

                        //classcat.PowerUpDamageUp();

                        //classshop.UnregisterEnemy(this.gameObject);

                        Destroy(gameObject);

                    }
                    else
                    {
                        Debug.Log("you do not have enough money");
                        //you do not have enough money
                    }

                }
            }

        }
    
    
    
    
    
    
   
    
}
