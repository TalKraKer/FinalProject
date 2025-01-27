using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManagment : MonoBehaviour
{
    public int CustomerNumber = 0;

    void Start()
    {
        EventManager.LineEnterEvent += CustomerEnterLine;
        EventManager.LineLeaveEvent += CustomerLeaveLine;
    }
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
