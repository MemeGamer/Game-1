using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour
{
    public float movespeed =1f;
    private Rigidbody2D myBody;
    private Animator anim;
    public LayerMask playerlayer;

    private bool moveLeft;
    private bool canmove;
    private bool stunned;

    public Transform leftcol,rightcol,topcol,downcol;
     private Vector2 leftcol_pos,rightcol_pos;

    // Start is called before the first frame update
     void Awake() {

        myBody= GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();   

        leftcol_pos = leftcol.position;
        rightcol_pos = rightcol.position; 
    }
    void Start()
    {
        moveLeft=true;
        canmove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canmove){
            if(moveLeft)
            {
             myBody.velocity = new Vector2(-movespeed, myBody.velocity.y);
            }
            else{
             myBody.velocity = new Vector2(movespeed, myBody.velocity.y);
             }
         CheckCollision();
         }
    }
    void CheckCollision()
    {
        RaycastHit2D lefthit = Physics2D.Raycast (leftcol.position,Vector2.left, 0.1f, playerlayer);
         RaycastHit2D righthit = Physics2D.Raycast (rightcol.position,Vector2.right, 0.1f, playerlayer);
         
         Collider2D tophit = Physics2D.OverlapCircle (topcol.position,0.2f,playerlayer);

         if(tophit!=null)
         {
             if(tophit.gameObject.tag == "Player")
             {
                 if(!stunned)
                 {
                     tophit.gameObject.GetComponent<Rigidbody2D>().velocity= new Vector2(tophit.gameObject.GetComponent<Rigidbody2D>().velocity.x,7f);
                     canmove=false;
                     myBody.velocity=new Vector2(0,0);
                     stunned=true;
                     anim.Play("stunned1");
                     if(stunned)
                     {
                     StartCoroutine(Dead (6f));
                     }
                     //b
                     if(gameObject.tag == "Beetal")
                     {
                         anim.Play("Stunned");
                         StartCoroutine(Dead (0.5f));
                     }
                 }
             }
         }

        if(lefthit){
            if(lefthit.collider.gameObject.tag == "Player")
            {
                if(!stunned){
                    lefthit.collider.gameObject.GetComponent<PlayerDamage>().DealDamage();
                }
            }
        }

        if(righthit){
            if(righthit.collider.gameObject.tag == "Player")
            {
                if(!stunned){
                   righthit.collider.gameObject.GetComponent<PlayerDamage>().DealDamage();
                }
            }
        }

        if(!Physics2D.Raycast(downcol.position,Vector2.down, 0.1f))
        {
           
            changeDirection();
        }
    }
    void changeDirection()
    {
         moveLeft = !moveLeft;

        Vector3 tempScale = transform.localScale;

        if(moveLeft)
        {
            tempScale.x = Mathf.Abs (tempScale.x);
        }
        else
        {
            tempScale.x = -Mathf.Abs (tempScale.x);
        }
        transform.localScale = tempScale;
    }
    IEnumerator Dead(float timer) {
        {
            yield return new WaitForSeconds(timer);
            gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D target) {
         if(target.tag == "Bullet")
        {
            if(tag == "Beetal")
            {
            anim.Play("Stunned");
            canmove = false;
            myBody.velocity = new Vector2(0,0);
            StartCoroutine(Dead(0.4f));
            }
            if(tag == "snail")
            {
                if(!stunned)
                {
                    anim.Play("stunned1");
                    stunned = true;
                    canmove = false;
                    myBody.velocity = new Vector2(0,0);
                }
                else{
                    gameObject.SetActive(false);
                }
            }
        }
    }
}//class
