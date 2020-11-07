using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : Action
{
    public GameObject attachedObject;
    private bool pressed;

    // Start is called before the first frame update
    void Start()
    {
        pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed)
        {
            attachedObject.GetComponent<Action>().performAction();
        }
    }

    public override void performAction()
    {
        pressed = true;
    }
}
