using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    GameObject player;

    public float horizontalPadding = 3.0f;
    public float verticalPadding = 3.0f;

    float maxHorizontalDistance;
    float maxVerticalDistance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        Camera cam = GetComponent<Camera>();
        float cameraHeight = cam.orthographicSize;
        float cameraWidth = cam.aspect * cameraHeight;

        maxHorizontalDistance = cameraWidth - horizontalPadding;
        maxVerticalDistance = cameraHeight - verticalPadding;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < transform.position.x - maxHorizontalDistance)
        {
            SetX(player.transform.position.x + maxHorizontalDistance);
        }

        if (player.transform.position.x > transform.position.x + maxHorizontalDistance)
        {
            SetX(player.transform.position.x - maxHorizontalDistance);
        }

        if (player.transform.position.y > transform.position.y + maxVerticalDistance)
        {
            SetY(player.transform.position.y - maxVerticalDistance);
        }
        if (player.transform.position.y < transform.position.y - maxVerticalDistance)
        {
            SetY(player.transform.position.y + maxVerticalDistance);
        }
    }

    void SetX(float newX)
    {
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    void SetY(float newY)
    {
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }


}
