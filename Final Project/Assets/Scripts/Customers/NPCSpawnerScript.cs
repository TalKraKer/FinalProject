using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawnerScript : MonoBehaviour
{

    public GameObject CustomerPrefab;
    public int spawnTimer;
    public int customerSprite=0;
    public int timer=0;
    public Sprite[] CustomerList;
    public int minSpawnTime = 1400;
    public int maxSpawnTime = 3400;

    private void Start()
    {
        spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if (timer > spawnTimer)
        {
            GameObject c = Instantiate(CustomerPrefab, transform.position, Quaternion.identity);
            c.GetComponent<SpriteRenderer>().sprite = CustomerList[customerSprite];
            customerSprite = Random.Range(0, CustomerList.Length);
            spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);
            timer = 0;
        }
    }
}
