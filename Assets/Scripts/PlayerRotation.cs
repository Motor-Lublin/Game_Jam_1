using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerRotation : MonoBehaviour
{
 public float rotationSpeed = 25f; // Speed of rotation
 public LayerMask groundLayer;   // Layer to detect the ground or target plane

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

            Vector3 direction = (targetPosition - transform.position).normalized;

            direction.y = 0;

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

}
