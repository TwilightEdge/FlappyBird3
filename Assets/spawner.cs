using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;


public class spawner : MonoBehaviour
{
    
    public GameObject enemy1;

    private GameObject enemySpawn1;

    public float area1MinX;
    public float area1MaxX;
    public float area1MinY;
    public float area1MaxY;

    public List<GameObject> enemyList;
    
    public GameObject clock;
    
    public clock classclock;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyList = new List<GameObject>();
        
        clock = GameObject.FindWithTag("clock");
        
        classclock = clock.GetComponent<clock>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (enemyList.Count == 0 && classclock.isNight)
        {
            spawn();
        }
        
    }

    public void spawn()
    {
        
        enemySpawn1 = Instantiate(enemy1);

        enemySpawn1.transform.position = new Vector3(Random.Range(area1MinX, area1MaxX), Random.Range(area1MinY, area1MaxY), 0.95f);
        
        enemyList.Add(enemySpawn1);

    }
    
    public void UnregisterEnemy(GameObject enemyToRemove)
    {
        enemyList.Remove(enemyToRemove);
    }
    
}
