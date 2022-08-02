using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int GameLoadSceneTime = 0;
    public bool EndingGame = false;
    public bool WinningGame = false;
    public bool StartGame = false;
    public GameObject player;


    void Awake(){
        if(instance != null){
            Destroy(gameObject);
        }else{
            instance = this;
        }
    }


    public void ToEndGame(){
        if(GameLoadSceneTime == 5){
            PlayerPrefs.SetInt("GameLevel",1);
            GameLoadSceneTime = 0;
            EndingGame = true;
            }else{
            GameLoadSceneTime += 1;
            EndingGame = true;
        }
    }

    public void WinGame()
    {
        WinningGame = true;
        PlayerPrefs.SetInt("GameLevel",PlayerPrefs.GetInt("GameLevel")+1);
        SceneManager.LoadScene(PlayerPrefs.GetInt("GameLevel")); 
    }
}
