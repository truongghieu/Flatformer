using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static bool pauseGame = false;
    public GameObject canvas;

    public void PlayAgain(){
        pauseGame = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToHome(){
        SceneManager.LoadScene(0);
    }

    public void Resume(){
        if(pauseGame == false) return;
        Time.timeScale = 1;
        pauseGame = false;
        canvas.SetActive(false);

        
    }
    public void PauseGame(){
        if(pauseGame == true ) return;
        pauseGame = true;
        Time.timeScale = 0;
        canvas.SetActive(true);
    }
}
