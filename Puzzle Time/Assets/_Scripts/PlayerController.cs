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
	[SerializeField]
	private float movementSpeed;
	
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

	transform.position = Vector3.MoveTowards(transform.position, destination, movementSpeed * Time.deltaTime);
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

	    Vector3 mousePos = Input.mousePosition;
	    Debug.Log("Base pos at " + mousePos.x +", " + mousePos.y+", "+mousePos.z);
	    mousePos = cam.ScreenToWorldPoint(mousePos);
	    mousePos.z = 0;
	    Debug.Log("ScreenToWorld pos at " + mousePos.x +", " + mousePos.y+", "+mousePos.z);
	    //Vector3Int gridPosition = Vector3Int.FloorToInt(mousePos);//((int)mousePos.x, (int)mousePos.y, 0);//map.WorldToCell(mousePos);
	    //gridPosition.z = 0;
	    Vector3Int gridPosition = map.WorldToCell(mousePos);
	    gridPosition.x = gridPosition.x + 1;
	    gridPosition.y = gridPosition.y + 1;
	    gridPosition.z = 0;
	    Debug.Log("Vector3Int pos at " + gridPosition.x +", " + gridPosition.y+", "+gridPosition.z);
	    if(map.HasTile(gridPosition)){
		Debug.Log("We hit!");
		destination = map.GetCellCenterWorld(gridPosition);//map.GetTile(gridPosition);//.position;
	    }
   }

}
