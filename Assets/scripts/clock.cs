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
    
    public GameObject spawner;
    
    public spawner classspawner;

    public GameObject[] allHumans;
    
    public GameObject[] allbg;
    
    Color nightColor;
    
    Color dayColor;
    
    Color eveColor;
    
    public GameObject shop;
    
    public shop classshop;
    
    
    public GameObject bin;

    private GameObject binSpawn1;
    private GameObject binSpawn2;
    private GameObject binSpawn3;
    private GameObject binSpawn4;

    void Awake()
    {
        shop = GameObject.FindWithTag("shop");
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        allHumans = GameObject.FindGameObjectsWithTag("human");
        
        allbg = GameObject.FindGameObjectsWithTag("bg");
        
        spawner = GameObject.FindWithTag("spawner");
        
        classspawner = spawner.GetComponent<spawner>();
        
        classshop = shop.GetComponent<shop>();
        
        
    }
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        MakeBGDay();
        
        timepassed = 0;
        isNight = false;
        isDay = true;
        
        MakeHumansActive();

        MakeShopDeActive();

        BinDeSpawn();
        
        spriteRenderer.sprite = day;
        
        // all remaining enemies sleep
        
        // humans spawn
        
    }
    
    public void StartEve()
    {
        MakeBGEve();

        
        
        timepassed = 0;
        isDay = false;
        isEve = true;
        
        MakeShopActive();
        
        classshop.ShuffleShop();
        
        classshop.OpenShop();
        
        MakeHumansDeActive();
        
        spriteRenderer.sprite = eve;
        
        // humans disapear
        
    }
    
    public void StartNight()
    {
        MakeBGNight();
        
        classshop.CloseShop();
        
        MakeShopDeActive();

        BinSpawn();
        
        timepassed = 0;
        isEve = false;
        isNight = true;
        
        spriteRenderer.sprite = night;

        classspawner.ResetTimer();
        
        

        // we dont need to spawn new enemies when night begins but we can:

        //classspawner.spawn();

        //classspawner.Invoke("spawn", 5f);


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
    
    
    public void MakeHumansActive()
    {
        
        foreach (GameObject target in allHumans)
        {
            // The single line of code to set the active/inactive state of the object:
            target.SetActive(true); // Or target.SetActive(false);
        }
        
    }
    
    public void MakeHumansDeActive()
    {
        
        foreach (GameObject target in allHumans)
        {
            // The single line of code to set the active/inactive state of the object:
            target.SetActive(false); // Or target.SetActive(false);
        }
        
    }
    
    public void MakeShopActive()
    {
        shop.SetActive(true);
    }
    public void MakeShopDeActive()
    {
        shop.SetActive(false);
    }
    
    
    
    
    public void MakeBGNight()
    {
        
        ColorUtility.TryParseHtmlString("#7674BF", out nightColor);
        
        foreach (GameObject target in allbg)
        {
            
            target.GetComponent<SpriteRenderer>().color = nightColor;
            
        }
        
    }
    
    
    public void MakeBGDay()
    {
        ColorUtility.TryParseHtmlString("#FFFFFF", out dayColor);
        
        foreach (GameObject target in allbg)
        {
            
            target.GetComponent<SpriteRenderer>().color = dayColor;
            
        }
        
    }
    
        
    public void MakeBGEve()
    {
        
        ColorUtility.TryParseHtmlString("#D28D66", out eveColor);
        
        foreach (GameObject target in allbg)
        {
            
            target.GetComponent<SpriteRenderer>().color = eveColor;
            
        }
        
    }
    
    
    public void BinSpawn()
    {
        
        binSpawn1 = Instantiate(bin);
        binSpawn1.transform.position = new Vector3(-36f,-2.8f , 0.94f);
        
        binSpawn2 = Instantiate(bin);
        binSpawn2.transform.position = new Vector3(3.5f,10f , 0.94f);
        
        binSpawn3 = Instantiate(bin);
        binSpawn3.transform.position = new Vector3(3.7f,-37f , 0.94f);
        
        binSpawn4 = Instantiate(bin);
        binSpawn4.transform.position = new Vector3(-4.5f, 57f , 0.94f);
        
    }
    
    public void BinDeSpawn()
    {
        Destroy(binSpawn1);
        Destroy(binSpawn2);
        Destroy(binSpawn3);
        Destroy(binSpawn4);
        
        
    }

}
