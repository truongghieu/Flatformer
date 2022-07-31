using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speedOffset = 2f;
    [SerializeField] private float _DashForce = 20f;
    [SerializeField] private float DashTime = 0.5f;

    [SerializeField] private float _JumpForce = 2f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject _ef;
    private Rigidbody2D _rb;

    //Dash
    private TrailRenderer _tr;
    private bool IsDashing = false;
    //

    private bool firstCheck = true;
    private bool highJump = true;
    private Transform _gc;
    void Start(){
        _rb = GetComponent<Rigidbody2D>();
        _gc = transform.GetChild(1);
        _tr = GetComponent<TrailRenderer>();
        
    }

    void Update()
    {
        if(IsDashing) return;
        Move();
        Jump();
        Groundcheck();
        HightJump();
    }



    protected virtual void Move(){
        if(InputManager.instance.InputKeyBoard().x>0){
            transform.localScale = new Vector3(1,1,1);
            transform.GetChild(4).rotation = Quaternion.Euler(0f,0f,0f);
        }else if(InputManager.instance.InputKeyBoard().x<0){
            transform.localScale = new Vector3(-1,1,1);
            transform.GetChild(4).rotation = Quaternion.Euler(0f,180f,0f);

        }
        _rb.velocity = new Vector2(InputManager.instance.InputKeyBoard().x * _speedOffset * Time.deltaTime,_rb.velocity.y); 

        if(InputManager.instance.DashPress()){
            StartCoroutine(dash());
        }
    }
    protected virtual void Jump(){
        if(InputManager.instance.JumpPress() && Groundcheck()){
            _rb.velocity = new Vector2(_rb.velocity.x, _JumpForce * 5 * Time.deltaTime);
            Vector3 pos =transform.GetChild(2).position;
            GameObject t = Instantiate(_ef,pos,Quaternion.identity);
            Destroy(t,1);
        }
    }

    protected virtual void HightJump(){
        if(!Groundcheck() && InputManager.instance.JumpPress() && highJump){
            highJump = false;
            _rb.velocity = new Vector2(_rb.velocity.x, _JumpForce * 5 * Time.deltaTime);
            Vector3 pos =transform.GetChild(2).position;
            GameObject t = Instantiate(_ef,pos,Quaternion.identity);
            Destroy(t,1);
        }
    }



    IEnumerator dash(){
        IsDashing = true;
        Vector3 pos =transform.GetChild(2).position;
        GameObject t = Instantiate(_ef,pos,Quaternion.identity);
        Destroy(t,DashTime);        
        float gravity = _rb.gravityScale;
        _rb.gravityScale = 0;
        _rb.velocity = new Vector2(_DashForce*transform.localScale.x, 0);
        yield return new WaitForSeconds(DashTime);
        IsDashing = false;
        _rb.gravityScale = gravity;
    }


    bool Groundcheck(){
        if(Physics2D.OverlapCircle(_gc.position,0.05f,groundLayer) != null ){
            highJump = true;
            if(firstCheck){
                firstCheck = false;
                Vector3 pos =transform.GetChild(2).position;
                GameObject t = Instantiate(_ef,pos,Quaternion.identity);
                Destroy(t,1);
            }
            firstCheck = false;
            return true;
            
        }
        firstCheck = true;
        return false;
    }
}
