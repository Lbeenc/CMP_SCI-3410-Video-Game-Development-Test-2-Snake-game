// Author: Curtis Been
// Date: 2025-05-18
// Handles UI interactions

using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void OnRestartClicked()
    {
        GameManager.Instance.RestartGame();
    }
}
