using UnityEngine;

public class GroundManager : MonoBehaviour
{
    [SerializeField] Renderer groundMaterialRenderer;
    public float groundScrollSpeed = 0.1f;
    public static GroundManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void ChangeMaterialTilt(float add_x, float add_y)
    {
        groundMaterialRenderer.material.mainTextureOffset += new Vector2(add_x, add_y) * groundScrollSpeed;
    }
}
