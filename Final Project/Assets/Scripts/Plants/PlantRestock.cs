using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantRestock : MonoBehaviour
{
    bool restocked;
    public GameObject[] Plants;
    GameObject PlantHoldPos;
    [SerializeField] GameObject Player;

    [SerializeField] GameObject PlantParent;
    [SerializeField] GameObject PlantPrefab;


    // Start is called before the first frame update
    void Start()
    {
        PlantHoldPos = GameObject.Find("PlayerPlantHoldPos");
        Plants = GameObject.FindGameObjectsWithTag("Plant");
    }

    public void restock()
    {
        restocked = false;
        foreach (GameObject Plant in Plants)
        {
            if (Plant.activeSelf == false)
            {
                Plant.SetActive(true);
                Player.GetComponent<PlayerBehaveior>().PlantYouAreHolding = Plant;
                Player.GetComponent<PlayerBehaveior>().PlantYouAreHolding.GetComponent<PlantHolding>().FollowHolder(PlantHoldPos);
                restocked = true;
                break;
            }
        }
        if (!restocked)
        {
            //create new plant
            Player.GetComponent<PlayerBehaveior>().PlantYouAreHolding = Instantiate(PlantPrefab, PlantHoldPos.transform.position, Quaternion.identity);
            Player.GetComponent<PlayerBehaveior>().PlantYouAreHolding.GetComponent<PlantHolding>().FollowHolder(PlantHoldPos);
        }
    }
}
