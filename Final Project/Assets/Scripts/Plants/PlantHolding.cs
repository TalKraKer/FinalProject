using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantHolding : MonoBehaviour
{
    bool follow = false;
    public GameObject holder = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
    }
}
