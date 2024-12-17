using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
   public float Speed;
   private Rigidbody2D rig;
   public float JumpForce;
    public bool isJumping;
    public bool doubleJump;
    private Animator anim;
    bool  isBlowing;
    // Start is called before the first frame update
    void Start()
    {
        rig=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
    //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
    //move o personagem em uma posição
    //transform.position += movement * Time.deltaTime * Speed;
    float movement= Input.GetAxis("Horizontal");

    rig.velocity=new Vector2(movement*Speed,rig.velocity.y);

    if(movement >0f){
    anim.SetBool("walk", true);
    transform.eulerAngles=new Vector3(0f,0f,0f);
    }
    if(movement < 0f){
    anim.SetBool("walk", true);
    transform.eulerAngles=new Vector3(0f,180f,0f);
    }
    if(movement == 0f){
    anim.SetBool("walk", false);
    }
    }
    void Jump()
    {
        if(Input.GetButtonDown("Jump") && !isBlowing){
            if(!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump=true;
                anim.SetBool("jump", true);
            }
            else
            {
                if(doubleJump)
                {
                     rig.AddForce(new Vector2(0f, JumpForce *1.2f), ForceMode2D.Impulse);
                    doubleJump=false;
                }
            } 
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer==8)
        {
            isJumping=false;
             anim.SetBool("jump", false);
        }
          if(collision.gameObject.tag=="Spike")
        {
            Destroy(gameObject);
            gamecontroller.instance.ShowGameOver();
        }
         if(collision.gameObject.tag=="Saw")
        {
            Destroy(gameObject);
            gamecontroller.instance.ShowGameOver();
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer==8)
        {
            isJumping=true;
        }
    }

  void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 11)
        {
            isBlowing=true;
        }
    }

     void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 11)
        {
            isBlowing=false;
        }
    }

}
