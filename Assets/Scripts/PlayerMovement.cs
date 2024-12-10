using UnityEngine;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    //Movement
    [SerializeField] private float playerSpeed = 10f;

    private List<Transform> movables = new List<Transform>();
    private float move_X;
    private float move_Y;
    private bool _blockPostiveX;
    private bool _blockNegativeX;
    private bool _blockPostiveY;
    private bool _blockNegativeY;

    void OnAwake()
    {
    }

    void Start()
    {
    }

    public void MovableListAdd(Transform t)
    {
        if (t.gameObject.tag.Contains("Movable"))
        {
            movables.Add(t);
            Debug.Log("Object added successfuly");
        }
        else
        {
            Debug.LogWarning("Object rejected");
        }
    }

    public void MovableListDel(Transform transform)
    {
        movables.Remove(transform);
    }

    public Vector3 GetMovementVector()
    {
        return new Vector3(-move_X, 0, -move_Y);
    }

    // Update is called once per frame
    void Update()
    {
        move_X = Input.GetAxis("Horizontal") * playerSpeed;
        if (_blockNegativeX && move_X < 0) move_X = 0;
        if (_blockPostiveX && move_X > 0) move_X = 0;
        move_Y = Input.GetAxis("Vertical") * playerSpeed;
        if (_blockNegativeY && move_Y < 0) move_Y = 0;
        if (_blockPostiveY && move_Y > 0) move_Y = 0;
        move_X *= Time.deltaTime;
        move_Y *= Time.deltaTime;

        if (new Vector2(move_X, move_Y).magnitude > 0f)
        {
            PlayerAnimations.Instance.Run();
        }
        else
        {
            PlayerAnimations.Instance.Idle();
        }

        foreach (Transform t in movables)
        {
            if(t != null)
                t.Translate(move_X, 0, move_Y, Space.World);
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if(collider.GetType() != typeof(CapsuleCollider)) return;
        if (Vector3.Distance(collider.transform.position, transform.position) > 10f) return;
        switch (collider.transform.position.x)
        {
            case > 0:
                _blockNegativeX = true; 
                break;
            case < 0:
                _blockPostiveX = true;
                break;
            default: break;
        }

        switch (collider.transform.position.z)
        {
            case > 0:
                _blockNegativeY = true;
                break;
            case < 0:
                _blockPostiveY = true;
                break;
            default: break;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.GetType() != typeof(CapsuleCollider)) return;
        _blockNegativeX = false;
        _blockPostiveX = false;
        _blockNegativeY = false;
        _blockPostiveY = false;
    }

}