using UnityEngine;

public class exit : powerup
{
    
    public GameObject clock;
    
    public clock classclock;

    void Awake()
    {
        clock = GameObject.FindWithTag("clock");
        
        classclock = clock.GetComponent<clock>();
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && playerIsTouching)
        {
            
            

                this.ApplyEffect();
                
            
            
        }
        
    }

    public override void ApplyEffect()
    {
        
        classclock.Exit();
        
    }
    
}
