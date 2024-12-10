using UnityEngine;

public class Movable : MonoBehaviour
{
  [SerializeField] GameObject centerObject;

    void Start()
    {
     // TODO: Dodać request obiektu do dodania to movable 
      Transform currTransform = transform;
      centerObject.GetComponent<PlayerMovement>().MovableListAdd(currTransform);
      Debug.Log("added object to MovableList");

        
    }
    public void AddToMovableList() {
        centerObject.GetComponent<PlayerMovement>().MovableListAdd(transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCenterObject(GameObject newObject)
    {
        centerObject = newObject;
    }
}
