using System;
using UnityEngine;
using System.Collections.Generic;
using Random = System.Random;

public class shop : MonoBehaviour
{
    
    //public GameObject powerup;

    //private GameObject powerupSpawn;
    
    public List<GameObject> powerupList;

    private int randomIndex = 0;

    private int numberOfItemsShown = 3;

    private void Awake()
    {
        powerupList = new List<GameObject>(GameObject.FindGameObjectsWithTag("powerup"));
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CloseShop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShuffleShop()
    {
        for (int i = 0; i < powerupList.Count; i++)
        {
            randomIndex = UnityEngine.Random.Range(0, powerupList.Count);
            
            GameObject temp = powerupList[i];
            powerupList[i] = powerupList[randomIndex];
            powerupList[randomIndex] = temp;
        }
    }

    public void CloseShop()
    {

        foreach (GameObject obj in powerupList)
        {
            // IMPORTANT: Check if the object is null (destroyed) before accessing it
            if (obj != null)
            {
                // The line you asked for: sets the active state to false
                obj.SetActive(false); 
            }
        }


    }
    
    public void OpenShop()
    {

        if (numberOfItemsShown > powerupList.Count)
        {
            numberOfItemsShown = powerupList.Count;
        }
        
        for (int i = 0; i < numberOfItemsShown; i++)
        {
            
            powerupList[i].SetActive(true); 
            
            powerupList[i].transform.localPosition = new Vector2(i * 10f, 0);
            
        }

    }
    
    
    
    public void UnregisterPowerup(GameObject powerupToRemove)
    {
        powerupList.Remove(powerupToRemove);
    }
    

}
