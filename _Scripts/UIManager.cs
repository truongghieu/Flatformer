using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static bool pauseGame = false;
    public GameObject canvas;


    void Update(){
        EndGame();
    }

    public void PlayAgain(){
        if(PlayerPrefs.GetInt("GameLevel") == 0 ){
            PlayerPrefs.SetInt("GameLevel",1);
        }
        pauseGame = false;
        SceneManager.LoadScene(PlayerPrefs.GetInt("GameLevel"));
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

    void EndGame(){
        if(GameManager.instance.EndingGame == true){
        Time.timeScale = 0;
        canvas.SetActive(true);
        GameObject.Find("Player").GetComponent<Movement>().enabled = false;
    }
    }

    public void QuitGame(){
        Application.Quit();
    }

}
