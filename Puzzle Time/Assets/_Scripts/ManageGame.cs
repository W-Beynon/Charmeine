using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageGame : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Q)){
		Debug.Log("Quitted!");
		Application.Quit();
	}
    }
}
