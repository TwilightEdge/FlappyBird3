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
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        classcat = cat.GetComponent<cat>();
    }

    // Update is called once per frame
    void Update()
    {


        if (foodCount > 0 && Input.GetKeyDown(KeyCode.E) && playerIsInside)
        {
            
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
            Debug.Log("Player left the interaction zone.");
            // Optional: Hide the UI prompt here
        }
    }
    
    void timePass()
    {
        timeSinceLastfeed += Time.deltaTime;
        
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
