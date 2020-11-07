using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
	public Tilemap map;
	Camera cam;
//	MouseInput msInp;
//
	private Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
	destination = transform.position;
        cam = Camera.main;
//	msInp = gameObject.AddComponent<MouseInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
	{
		mouseGetPos();	
	}
    }

    void mouseGetPos()
    {
/*            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

            if (hit2D.collider != null)
            {
                Debug.Log("We hit " + hit2D.collider.name + " at position " + hit2D.point);
            }*/

	    Vector2 mousePos = Input.mousePosition;
	    mousePos = cam.ScreenToWorldPoint(mousePos);
	    Vector3Int gridPosition = map.WorldToCell(mousePos);
	    if(map.HasTile(gridPosition)){
		destination = gridPosition;//map.GetTile(gridPosition).position;
	    }
   }

}
