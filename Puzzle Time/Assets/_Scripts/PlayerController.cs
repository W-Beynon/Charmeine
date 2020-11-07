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
	private Vector3 currDest;

    // Start is called before the first frame update
    void Start()
    {
	destination = transform.position;
	currDest = transform.position;
        cam = Camera.main;
//	msInp = gameObject.AddComponent<MouseInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
	{
		//mouseGetPos();
		mouseGetPosAdjacent();	
	}
	
	if(transform.position == currDest && currDest != destination){
		getNextPos();
	}

	transform.position = Vector3.MoveTowards(transform.position, currDest, movementSpeed * Time.deltaTime);
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
	    //Debug.Log("Base pos at " + mousePos.x +", " + mousePos.y+", "+mousePos.z);
	    mousePos = cam.ScreenToWorldPoint(mousePos);
	    mousePos.z = 0;
	   // Debug.Log("ScreenToWorld pos at " + mousePos.x +", " + mousePos.y+", "+mousePos.z);
	    //Vector3Int gridPosition = Vector3Int.FloorToInt(mousePos);//((int)mousePos.x, (int)mousePos.y, 0);//map.WorldToCell(mousePos);
	    //gridPosition.z = 0;
	    Vector3Int gridPosition = map.WorldToCell(mousePos);
	    gridPosition.x = gridPosition.x + 1;
	    gridPosition.y = gridPosition.y + 1;
	    gridPosition.z = 0;
	    //Debug.Log("Vector3Int pos at " + gridPosition.x +", " + gridPosition.y+", "+gridPosition.z);
	    if(map.HasTile(gridPosition)){
		//Debug.Log("We hit!");
		currDest = transform.position;
		destination = map.GetCellCenterWorld(gridPosition);//map.GetTile(gridPosition);//.position;
	    }
   }

    void mouseGetPosAdjacent()
    {
/*            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

            if (hit2D.collider != null)
            {
                Debug.Log("We hit " + hit2D.collider.name + " at position " + hit2D.point);
            }*/

	    Vector3 mousePos = Input.mousePosition;
	    //Debug.Log("Base pos at " + mousePos.x +", " + mousePos.y+", "+mousePos.z);
	    mousePos = cam.ScreenToWorldPoint(mousePos);
	    mousePos.z = 0;
	   // Debug.Log("ScreenToWorld pos at " + mousePos.x +", " + mousePos.y+", "+mousePos.z);
	    //Vector3Int gridPosition = Vector3Int.FloorToInt(mousePos);//((int)mousePos.x, (int)mousePos.y, 0);//map.WorldToCell(mousePos);
	    //gridPosition.z = 0;
	    Vector3Int gridPosition = map.WorldToCell(mousePos);
	    gridPosition.x = gridPosition.x + 1;
	    gridPosition.y = gridPosition.y + 1;
	    gridPosition.z = 0;
	    Vector3Int currPosition = map.WorldToCell(transform.position);
	    //Debug.Log("Vector3Int pos at " + gridPosition.x +", " + gridPosition.y+", "+gridPosition.z);
	    if(map.HasTile(gridPosition) && (gridPosition.x >= (currPosition.x - 1)) && (gridPosition.x <= (currPosition.x + 1))
			     && (gridPosition.y >= (currPosition.y - 1)) && (gridPosition.y <= (currPosition.y + 1))){
		//Debug.Log("We hit!");
		currDest = transform.position;
		destination = map.GetCellCenterWorld(gridPosition);//map.GetTile(gridPosition);//.position;
	    }
   }


    void getNextPos(){
	//dist = getDistance();
	int minDist = 1000;
	int tempDist;
	Vector3Int currTile = map.WorldToCell(transform.position);
	Vector3Int tempTile;
	Vector3Int newDest = currTile;
	for(int i = -1; i <= 1; i++){
		for(int j = -1; j <= 1; j++){
			tempTile = currTile;
			tempTile.x = tempTile.x+i;
			tempTile.y = tempTile.y+j;
			Debug.Log("Tested pos: x = " + tempTile.x + ", y = " + tempTile.y);
			tempDist = (Mathf.Abs(map.WorldToCell(destination).x - tempTile.x) 
						+ Mathf.Abs(map.WorldToCell(destination).y - tempTile.y));
			if(map.HasTile(tempTile) && tempDist < minDist){
				
				Debug.Log("Distance: x = " + (Mathf.Abs(map.WorldToCell(destination).x - tempTile.x))
						       	+ ", y = " + (Mathf.Abs(map.WorldToCell(destination).y - tempTile.y)) 
								+", Total = " + tempDist);
				minDist = tempDist;
				newDest = tempTile;	
			}
		}
	}
	//if(newDest != null)
	Debug.Log("Final pos: x = " + newDest.x + ", y = " + newDest.y + ", Dest: x = " + map.WorldToCell(destination).x + ", y = " + map.WorldToCell(destination).y);
		currDest = map.GetCellCenterWorld(newDest);
    }

   /* int getDistance(){
	return Math.Abs(map.WorldToCell(destination).x - map.WorldToCell(transform.position).x) 
		+ Math.Abs(map.WorldToCell(destination).y - map.WorldToCell(transform.position).y);
    }*/

}
