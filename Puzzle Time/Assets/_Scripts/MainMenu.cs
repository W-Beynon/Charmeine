﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
   public void PlayGame(){
        //SceneManager.LoadScene("This Is Level 1");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
   }
}
