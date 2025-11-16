using UnityEngine;

public class cuteup : powerup
{
    public int cuteUp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && playerIsTouching)
        {
            
            if (classcat.food >= price)
            {
                Debug.Log("you have the food");

                classcat.food -= price;

                this.ApplyEffect();

                

                classshop.UnregisterPowerup(this.gameObject);

                Destroy(gameObject);

            }
            else
            {
                Debug.Log("you do not have enough money");
                //you do not have enough money
            }
            
            
        }
        
    }

    public override void ApplyEffect()
    {
        classcat.passiveCuteness += cuteUp;
        
        classcat.cuteness += cuteUp;

    }
    
}
