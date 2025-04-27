using System;
using UnityEngine;

public class NPCSpawnerScript : MonoBehaviour
{

    public GameObject CustomerPrefab;
    public int spawnTimer;
    public int customerSprite=0;
    public float timer=0;
    public Sprite[] CustomerList;
    public int minSpawnTime = 500;
    public int maxSpawnTime = 1500;

    public static event Action OnCustomerSpawnedEvent;

    private void Start()
    {
        spawnTimer = UnityEngine.Random.Range(minSpawnTime, maxSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if (timer > spawnTimer)
        {
            GameObject c = Instantiate(CustomerPrefab, transform.position, Quaternion.identity);
            c.GetComponent<SpriteRenderer>().sprite = CustomerList[customerSprite];
            customerSprite = UnityEngine.Random.Range(0, CustomerList.Length);
            spawnTimer = UnityEngine.Random.Range(minSpawnTime, maxSpawnTime);
            timer = 0;
        }
    }
}
