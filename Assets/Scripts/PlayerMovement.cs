using UnityEngine;
using System.Collections.Generic;
public class PlayerMovement : MonoBehaviour
{
  //Movement
  [SerializeField] private float playerSpeed = 30f;
  
  private List<Transform> movables;
  private float move_X;
  private float move_Y;
    void Start(){

    }

    void movableListAdd(Transform transform){

      if(transform.CompareTag("Movable")){
        movables.Add(transform);
      }

    }

    void movableListDel(Transform transform){
      movables.Remove(transform);
    }
    
    Vector2 getMovementVector(){
      return new Vector2(move_X, move_Y);
    }
    
    // Update is called once per frame
    void Update(){
      move_X = Input.GetAxis("Horizontal") * playerSpeed;
      move_Y = Input.GetAxis("Vertical") * playerSpeed;
      move_X *= Time.deltaTime;
      move_Y *= Time.deltaTime;
      foreach(Transform transform in movables)
        transform.Translate(move_X, move_Y, 0);
        
    }

}
