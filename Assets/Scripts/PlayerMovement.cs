using UnityEngine;
using System.Collections.Generic;
public class PlayerMovement : MonoBehaviour
{
  //Movement
  [SerializeField] private float playerSpeed = 10f;
  
  private List<Transform> movables = new List<Transform>();
  private float move_X;
  private float move_Y;
    void OnAwake(){
    }
    void Start(){

    }

    public void MovableListAdd(Transform t){
       if(t.gameObject.CompareTag("Movable")){
         movables.Add(t);
         Debug.Log("Object added successfuly");
       } else {
         Debug.LogWarning("Object rejected");
       }

    }

    public void MovableListDel(Transform transform){
      movables.Remove(transform);
    }
    
    public Vector3 GetMovementVector(){
        return new Vector3(-move_X, 0, -move_Y);
    }
    
    // Update is called once per frame
    void Update(){
      move_X = Input.GetAxis("Horizontal") * playerSpeed;
      move_Y = Input.GetAxis("Vertical") * playerSpeed;
      move_X *= Time.deltaTime;
      move_Y *= Time.deltaTime;
     foreach(Transform t in movables){ 
        t.Translate(move_X, 0, move_Y);
    }
  }
}
