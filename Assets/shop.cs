using System;
using UnityEngine;
using System.Collections.Generic;

public class shop : MonoBehaviour
{
    
    public GameObject powerup;

    private GameObject powerupSpawn;
    
    public List<GameObject> powerupList;

    private void Awake()
    {
        powerupList = new List<GameObject>(GameObject.FindGameObjectsWithTag("powerup"));
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
