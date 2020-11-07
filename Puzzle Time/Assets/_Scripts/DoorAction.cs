using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAction : Action
{
    private bool lifted;

    // Start is called before the first frame update
    void Start()
    {
        lifted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void performAction()
    {
        if(lifted)
        {
            // drops door
        }
        else
        {
            // lifts door
        }
    }
}
