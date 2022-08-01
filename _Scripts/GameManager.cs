
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject _canvas;

    void Awake(){
        if(instance != null){
            Destroy(gameObject);
        }else{
            instance = this;
        }
    }


    public void ToEndGame(){
        Time.timeScale = 0;
        _canvas.SetActive(true);
        GameObject.Find("Player").GetComponent<Movement>().enabled = false;
    }

  

}
