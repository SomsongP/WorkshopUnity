using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonComp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnPressStartButton()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
