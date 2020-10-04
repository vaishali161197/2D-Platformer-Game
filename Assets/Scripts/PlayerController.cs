using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{   
    public Animator animator;
    public ScoreController score;
    public float speed;
    public BoxCollider2D collider;
    public float Jump;
    public bool isCrouch;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        collider = gameObject.GetComponent<BoxCollider2D>();
    }
    public void KillPlayer()
    {
        Debug.Log("player is killed by enemy");
        //Destroy(gameObject);
        //reload the game
        ReloadLevel();
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void PickUpKey()
    {
        Debug.Log("PlayerPickedUpKey");
        score.IncreaseScore(10);
    }

    void Start()
    {
        
    }

    private void Update()
    {
       float horizontal = Input.GetAxisRaw("Horizontal");
       animator.SetFloat("speed",Mathf.Abs(horizontal));
       Vector3 scale = transform.localScale;
       if(horizontal<0)
       {
           scale.x=-1*Mathf.Abs(scale.x);
           Debug.Log("running backward");
       }
       else if(horizontal>0)
       {
           scale.x=Mathf.Abs(scale.x);
           Debug.Log("running forward");
       } 
       transform.localScale= scale;

        double size, offset;
       
       if (Input.GetKey(KeyCode.LeftControl))
       {
            size = 1.188995;
            offset = 0.5657358;
            isCrouch = true;
            collider.size = new Vector2(collider.size.x, (float) size);
            collider.offset = new Vector2(collider.offset.x, (float)offset);
            animator.SetBool("isCrouch", isCrouch);
            Debug.Log("player iscrouch ");
       }
       if(Input.GetKeyUp(KeyCode.LeftControl))
       {    size = 1.97348;
            offset = 0.9579782;
            isCrouch = false;
           
            animator.SetBool("isCrouch", isCrouch);
            Debug.Log("player not crouch");
            collider.size = new Vector2(collider.size.x, (float)size);
            collider.offset = new Vector2(collider.offset.x, (float)offset);
        }



        //code for jump
        float vertical = Input.GetAxisRaw("Jump");
        if(vertical>0)
        {
            
            animator.SetBool("Jump", true);
            Debug.Log("player jumped");

        }
        else if(vertical<=0)
        {
           
            animator.SetBool("Jump", false);
            Debug.Log("jump=false");
        }

        //code for moving character
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        //code for moving character vertically
        if(vertical>0)
        {
            rb2d.AddForce(new Vector2(0f, Jump), ForceMode2D.Force);
        }
    }

       

}
