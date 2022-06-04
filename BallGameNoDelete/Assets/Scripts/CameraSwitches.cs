using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitches : MonoBehaviour
{
    public Transform camera;
    Quaternion targetAngle;

    // Start is called before the first frame update
    void Start()
    {
        targetAngle = camera.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // dampen towards the target angle
        if (camera.transform.rotation != targetAngle)
            camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, targetAngle, Time.deltaTime * 5f);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "TopDown")
        {
            // set new angle
            targetAngle = Quaternion.Euler(90f, 0, 0);
        }
        else if (collision.gameObject.tag == "Isometric")
        {
            // set new angle
            targetAngle = Quaternion.Euler(35f, 0, 0);
        }
        else if (collision.gameObject.tag == "Sidescroller")
        {
            // set new angle
            targetAngle = Quaternion.Euler(0f, 0, 0);
        }
        else if (collision.gameObject.tag == "SidescrollerFlip")
        {
            // set new angle
            targetAngle = Quaternion.Euler(0f, -180f, 0);
        }
    }
}