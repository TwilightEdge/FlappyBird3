using UnityEngine;

public class clock : MonoBehaviour
{
    public bool isDay;
    public bool isEve;
    public bool isNight;

    public float timepassed;
    
    public float dayDuration;
    
    public float nightDuration;
    
    private SpriteRenderer spriteRenderer;

    public Sprite day;
    public Sprite eve;
    public Sprite night;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        StartDay();
    }

    // Update is called once per frame
    void Update()
    {
        
        checkForChangeTime();
        
    }

    void FixedUpdate()
    {
        timePass();
        
        
    }

    public void StartDay()
    {
        timepassed = 0;
        isNight = false;
        isDay = true;
        
        spriteRenderer.sprite = day;
        
        // all the things that need to happen once in the day time
        
    }
    
    public void StartEve()
    {
        timepassed = 0;
        isDay = false;
        isEve = true;
        
        spriteRenderer.sprite = eve;
        
    }
    
    public void StartNight()
    {
        timepassed = 0;
        isEve = false;
        isNight = true;
        
        spriteRenderer.sprite = night;
        
    }


    void timePass()
    {
        timepassed += Time.deltaTime;
    }

    void checkForChangeTime()
    {
        if (isEve)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                StartNight();
            }
            
            
        }
        else
        if(isDay)
        {
            if (timepassed >= dayDuration)
            {
                StartEve();
            }
            
            
        }
        else
        if(isNight)
        {
            if (timepassed >= nightDuration)
            {
                StartDay();
            }
            
            
        }
        
    }

}
