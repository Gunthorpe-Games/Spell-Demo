using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject otherPortal;
    public bool onXAxis;
    public Transform player;
    Vector3 cameraAngle;
    public Transform otherCamera;
    float viewAngle;

    void Start()
    {
        cameraAngle = otherPortal.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (onXAxis)
        {
            viewAngle = (180 / Mathf.PI) * Mathf.Atan(Mathf.Abs(player.position.x - transform.position.x) / (player.position.z - transform.position.z));
            otherCamera.transform.eulerAngles = cameraAngle + new Vector3(0, viewAngle - 90, 180);
            if (player.position.z > transform.position.z)
            {
                otherCamera.transform.eulerAngles = cameraAngle + new Vector3(0, viewAngle + 90, 180);
            }
        }
        else
        {
            viewAngle = (180 / Mathf.PI) * Mathf.Atan(Mathf.Abs(player.position.z - transform.position.z) / (player.position.x - transform.position.x));
            if (player.position.x > transform.position.x)
            otherCamera.transform.eulerAngles = cameraAngle + new Vector3(0, viewAngle - 90, 180);
            {
                otherCamera.transform.eulerAngles = cameraAngle + new Vector3(0, viewAngle + 90, 180);
            }
        }
        
        
    }
}
