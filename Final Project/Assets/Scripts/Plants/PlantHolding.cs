using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class PlantHolding : MonoBehaviour
{
    public bool follow = false;
    public GameObject holder = null;


    // Update is called once per frame
    void Update()
    {
        if (follow == true)
        {
            transform.position = holder.transform.position;
        }
    }

    public void FollowHolder(GameObject Holding)
    {
        holder = Holding;
        follow = true;
    }

    public void StopFollowHolder()
    {
        follow = false;
        holder = null;
    }
}
