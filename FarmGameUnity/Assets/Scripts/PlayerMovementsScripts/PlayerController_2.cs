using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_2 : MonoBehaviour
{

    private Vector3 targetPosition;
    private Vector3 lookAtTarget;
    private Quaternion playerRotation;
    private bool isMoving = false;

    [SerializeField]
    private float rotationSpeed = 4;
    [SerializeField]
    private float movementSpeed = 5;
    [SerializeField]
    private LayerMask walkable;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SetTargetPosition();
        }
        if (isMoving)
        {
            Move();
        }
        
    }

    private void SetTargetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 1000, walkable))
        {
            targetPosition = hit.point;
            // this.transform.LookAt(targetPosition);

            lookAtTarget = new Vector3(targetPosition.x - transform.position.x,
                0,
                targetPosition.z - transform.position.z);
            playerRotation = Quaternion.LookRotation(lookAtTarget);
            isMoving = true;
        }
    }

    private void Move()
    {
        // rotate the player
        transform.rotation = Quaternion.Slerp(transform.rotation, playerRotation, rotationSpeed * Time.deltaTime);

        // move position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

        if(transform.position == targetPosition)
        {
            isMoving = false;
        }
    }
}
