using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private Transform player;

    [SerializeField]
    private Vector3 cameraPosition;
    [SerializeField]
    private float verticalOffset = 2.2f;
    [SerializeField]
    private float horizontalOffset = 2.2f;
    // Use this for initialization


    private Vector3 targetPosition;
    private Vector3 velocity = Vector3.zero;

    public float smoothTimeX = 0.33f;
    public float smoothTimeY = 0.33f;
    public float maxSpeed = 1.0f;
    public float updateRate = 2.0f;

    public Transform topLimit;
    public Transform bottomLimit;
    public Transform leftLimit;
    public Transform rightLimit;

    public float timeYmodifier = 0.03f;

    void Start()
    {
        player = FindObjectOfType <PlayerController >().transform ;
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);

        topLimit = topLimit.GetComponent<Transform>();
        bottomLimit = bottomLimit.GetComponent<Transform>();
        leftLimit = leftLimit.GetComponent<Transform>();
        rightLimit = rightLimit.GetComponent<Transform>();
    }

    //// Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        float posX = transform.position.x;
        float posY = transform.position.y;

        if (player.rotation == Quaternion .Euler (0,180,0))
        {
            Debug.Log("looking left");
            posX = Mathf.Lerp(transform.position.x, player.position.x - horizontalOffset, smoothTimeX * Time.deltaTime);
            posY = Mathf.Lerp(transform.position.y, player.position.y + verticalOffset, smoothTimeY * Time.deltaTime);
        }

        if (player.rotation == Quaternion.Euler(0, 0, 0))
        {
            Debug.Log("looking right");
            posX = Mathf.Lerp(transform.position.x, player.position.x + horizontalOffset, smoothTimeX * Time.deltaTime);
            posY = Mathf.Lerp(transform.position.y, player.position.y + verticalOffset, smoothTimeY * Time.deltaTime);

        }

        posY = Mathf.Clamp(posY, bottomLimit.position.y, topLimit.position.y);
        posX = Mathf.Clamp(posX, leftLimit.position.x, rightLimit.position.x);
        transform.position = new Vector3(posX, posY, -10);

    }
}
