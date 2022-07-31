
using UnityEngine;

public class InputManager : MonoBehaviour
{
    static public InputManager instance;
    void Awake()
    {
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }

    }

    public virtual Vector2 InputKeyBoard(){
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        return new Vector2(x,y);
    }
    public virtual Vector2 InputTouch(){
        return Vector2.zero;
    }
    public virtual bool JumpPress(){
        return Input.GetKeyDown(KeyCode.W);
    }
    public virtual bool DashPress(){
        return Input.GetKeyDown(KeyCode.Q);

    }

    public virtual bool ShootPress(){
        return Input.GetMouseButtonDown(0);
    }   
}
