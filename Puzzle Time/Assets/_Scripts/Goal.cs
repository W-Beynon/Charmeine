using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
	public GameObject winScreen;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ((SpriteRenderer)gameObject.GetComponent(typeof(SpriteRenderer))).sprite = null;
	winScreen.SetActive(true);
        //SceneManager.LoadScene("Level Select");
    }
}
