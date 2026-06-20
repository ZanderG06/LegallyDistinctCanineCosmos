using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject controlsUI;

    private bool isPaused = false;

    private void Start()
    {
        pauseUI.SetActive(false);
        controlsUI.SetActive(false);
    }

    public void TogglePauseUI()
    {
        isPaused = !isPaused;
        pauseUI.SetActive(isPaused);

        if(isPaused) Time.timeScale = 0f;
        if(!isPaused) Time.timeScale = 1f;
    }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1f;
    }

    public void ToggleControlsUI()
    {
        controlsUI.SetActive(!controlsUI.activeSelf);
        pauseUI.SetActive(!pauseUI.activeSelf);
    }
}
