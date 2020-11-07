using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public void mouseGetPos(Camera cam)
    {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

            if (hit2D.collider != null)
            {
                Debug.Log("We hit " + hit2D.collider.name + " at position " + hit2D.point);
            }
   }
}
