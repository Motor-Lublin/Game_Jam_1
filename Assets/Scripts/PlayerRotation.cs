using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerRotation : MonoBehaviour
{
 public float rotationSpeed = 0.07f; // Speed of rotation
 public LayerMask groundLayer;   // Layer to detect the ground or target plane
 private float lastRotationUpdate;
 [SerializeField] private float  rotationUpdateInterveal = 0.09f;
 [SerializeField] private float  closeProximityRadius = 5f;
 public float neutralFacingAngle = 90f; 
 private Vector3 lastValidDirection;  
 private Vector3 lastTargetPosition;  
 private Vector3 direction;


    void Start(){

    }

    void Update()
    {
        RotateCharacterTowardsMouse();
    }

    void RotateCharacterTowardsMouse()
    {
        Vector3 mousePosition = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, groundLayer))
        {
            Vector3 targetPosition = hitInfo.point;

            float distance = Vector3.Distance(transform.position, targetPosition);
            
            if (Vector3.Distance(lastTargetPosition, targetPosition) < 0.1f) 
        {
            return; 
        }

            lastTargetPosition = targetPosition;



            // if (distance < closeProximityRadius)
            // {
            //     Quaternion neutralRotation = Quaternion.Euler(0, neutralFacingAngle, 0);
            //     transform.rotation = Quaternion.Slerp(transform.rotation, neutralRotation, rotationSpeed * Time.deltaTime);
            //     return;
            // }

            Vector3 direction = (targetPosition - transform.position).normalized;

            direction.y = 0;

            lastValidDirection = direction;

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else if (lastValidDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(lastValidDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
