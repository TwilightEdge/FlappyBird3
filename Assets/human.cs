using System;
using UnityEngine;

public class human : MonoBehaviour
{
    
    public GameObject cat;
    public bool playerIsInside;
    
    public cat classcat;

    public int foodCount;
    public int food;
    public int foodTimer; //each food timer seconds the foodcount goes down
    public int cutenessReq; // cuteness req for getting the food
    public int cutenessIncrease;

    private float timeSinceLastfeed = 0;

    public int mewPlusCuteness;
    public int mewMaxStacks;
    public int mewCounter;
    
    public int eyePlusCuteness;
    public int eyeMaxStacks;
    public int eyeCounter;
    
    public int rubPlusCuteness;
    public int rubMaxStacks;
    public int rubCounter;
    
    public float emoteCD = 2;
    
    float timeSinceLastEmote = 2;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        classcat = cat.GetComponent<cat>();
    }

    // Update is called once per frame
    void Update()
    {


        if (foodCount > 0 && Input.GetKeyDown(KeyCode.E) && playerIsInside && timeSinceLastEmote > emoteCD) // MEW
        {
            timeSinceLastEmote = 0;

            if (mewCounter < mewMaxStacks)
            {
                classcat.cuteness += mewPlusCuteness;
                mewCounter++;
            }
            else
            {
                // you cant gain more cuteness with meowing
            }

            if (cutenessReq <= classcat.cuteness)
            { 
                foodCount--;
                cutenessReq += cutenessIncrease;
                classcat.getFood(food);
            }
            else Debug.Log("you are not cute enough");
        }else
        if (foodCount == 0 && Input.GetKeyDown(KeyCode.E) && playerIsInside)
        {
            Debug.Log("go away I dont have anymore food");
        }
        
        
        
        if (foodCount > 0 && Input.GetKeyDown(KeyCode.R) && playerIsInside && timeSinceLastEmote > emoteCD) // CAT EYE
        {
            timeSinceLastEmote = 0;

            if (eyeCounter < eyeMaxStacks)
            {
                classcat.cuteness += eyePlusCuteness;
                eyeCounter++;
            }
            else
            {
                // you cant gain more cuteness with cat eyes
            }

            if (cutenessReq <= classcat.cuteness)
            { 
                foodCount--;
                cutenessReq += cutenessIncrease;
                classcat.getFood(food);
            }
            else Debug.Log("you are not cute enough");
        }else
        if (foodCount == 0 && Input.GetKeyDown(KeyCode.R) && playerIsInside)
        {
            Debug.Log("go away I dont have anymore food");
        }
        
        
        
        if (foodCount > 0 && Input.GetKeyDown(KeyCode.T) && playerIsInside && timeSinceLastEmote > emoteCD) // RUB
        {
            timeSinceLastEmote = 0;
            
            if (rubCounter < rubMaxStacks)
            {
                classcat.cuteness += rubPlusCuteness;
                rubCounter++;
            }
            else
            {
                // you cant gain more cuteness with rubbing
            }

            if (cutenessReq <= classcat.cuteness)
            { 
                foodCount--;
                cutenessReq += cutenessIncrease;
                classcat.getFood(food);
            }
            else Debug.Log("you are not cute enough");
        }else
        if (foodCount == 0 && Input.GetKeyDown(KeyCode.T) && playerIsInside)
        {
            Debug.Log("go away I dont have anymore food");
        }




    }

    void FixedUpdate()
    {
        timePass();
        FeedingTime();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that entered has the "Player" tag
        if (other.CompareTag("Player"))
        {
            playerIsInside = true;
            Debug.Log("Player entered the interaction zone. Press E to interact.");
            // Optional: Show a UI prompt here
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the object that left has the "Player" tag
        if (other.CompareTag("Player"))
        {
            playerIsInside = false;
            
            classcat.cutenessReset();

            mewCounter = 0;
            eyeCounter = 0;
            rubCounter = 0;
            
            Debug.Log("Player left the interaction zone.");
            // Optional: Hide the UI prompt here
        }
    }
    
    void timePass()
    {
        timeSinceLastfeed += Time.deltaTime;
        
        timeSinceLastEmote += Time.deltaTime;
        
    }
    
    void FeedingTime()
    {
        if ( foodCount > 0 && timeSinceLastfeed >= foodTimer)
        {
            timeSinceLastfeed = 0;
            foodCount--;
        }
    }
    
}
