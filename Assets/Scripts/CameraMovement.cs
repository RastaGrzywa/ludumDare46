using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public List<GameObject> objectsToMoveWithCamera = new List<GameObject>();
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            transform.position += new Vector3(0, 1, 0);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            transform.position += new Vector3(0, -1, 0);
        }
        if (transform.position.y < 4)
        {
            transform.position = new Vector3(transform.position.x, 4, transform.position.z);
        }
        if (transform.position.y > 236)
        {
            transform.position = new Vector3(transform.position.x, 236, transform.position.z);
        }

        foreach (var item in objectsToMoveWithCamera)
        {
            item.transform.position = new Vector3(item.transform.position.x, transform.position.y + 40, item.transform.position.z);
        }
    }


}
