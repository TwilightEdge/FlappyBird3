using System;
using UnityEngine;

public abstract class powerup : MonoBehaviour
{
    
    public GameObject cat;
    
    public cat classcat;
    
    public GameObject shop;
    
    public shop classshop;

    public int price;
    
    public bool playerIsTouching; 
    
    public abstract void ApplyEffect();
    
    private void Awake()
    {
        cat = GameObject.FindWithTag("Player");
        classcat = cat.GetComponent<cat>();
        
        shop = GameObject.FindWithTag("shop");
        classshop = shop.GetComponent<shop>();
    }

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
        // Check if the object that entered has the "Player" tag
        if (other.CompareTag("Player"))
        {
            playerIsTouching = true;
            Debug.Log("Player entered the interaction zone. Press E to interact.");
            
        }
    }
    
    
    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the object that left has the "Player" tag
        if (other.CompareTag("Player"))
        {
            playerIsTouching = false;
        }
        
    }
    
 
    
}
