using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManagment : MonoBehaviour
{
    public int CustomerNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.LineEnterEvent += CustomerEnterLine;
        EventManager.LineLeaveEvent += CustomerLeaveLine;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CustomerEnterLine()
    {
        CustomerNumber++;
    }

    private void CustomerLeaveLine()
    {
        CustomerNumber--;
    }
}
