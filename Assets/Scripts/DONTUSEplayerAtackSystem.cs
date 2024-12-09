using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Splines;

public class playerAtackSystem : MonoBehaviour
{
    [SerializeField] InputAction playerRangeAtack;
    public int gunConeRange;
    public int gunConeWidth;
    float timer;
    private void Start()
    {
        playerRangeAtack.Enable();
    }
    private void Update()
    {
        GameObject[] bulletArray = GameObject.FindGameObjectsWithTag("Bullet");
        GameObject[] splineArray = GameObject.FindGameObjectsWithTag("Splines");

        if (playerRangeAtack.WasPressedThisFrame()){
            foreach (GameObject bullet in bulletArray)
            {
                bullet.GetComponent<SplineAnimate>().Play();
            }
            foreach (GameObject splines in splineArray)
            {
                
            }
        }
        if (bulletArray[0].GetComponent<SplineAnimate>().IsPlaying == false)
        {
            foreach (GameObject bullet in bulletArray)
            {
                bullet.GetComponent<SplineAnimate>().Restart(false);
            }
        }
    }
}
