using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostSpawnCloud : MonoBehaviour
{

    public CloudEnemy cloud;
    public Transform postCloud;
    public bool isActive;


    void Update()
    {
        if (IsObjectInCameraView(Camera.main, transform.position))
        {
            if(!isActive)
            {
                var temp = Instantiate(cloud);
                temp.transform.position = postCloud.position;
                isActive = true;
            }
         
           // Debug.Log(gameObject.name + " đang trong camera.");

        }
        else
        {
        //    Debug.Log(gameObject.name + " đã ra khỏi camera.");

        }
    }

    bool IsObjectInCameraView(Camera camera, Vector3 worldPosition)
    {
        Vector3 viewportPoint = camera.WorldToViewportPoint(worldPosition);
        return viewportPoint.x >= 0 && viewportPoint.x <= 1 &&
               viewportPoint.y >= 0 && viewportPoint.y <= 1 &&
               viewportPoint.z > 0; // Kiểm tra xem có nằm trước camera không
    }
}
