using UnityEngine;

public class WhenBossDies : MonoBehaviour
{
    private void OnDestroy()
    {
        GameManager.Instance.WinGame();
    }
}
