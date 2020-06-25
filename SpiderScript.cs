using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScript : MonoBehaviour
{
   private Animator anim;
   private Rigidbody2D myBody;
   private Vector3 moveDirection = Vector3.down;
   private Vector3 originPosition;
    private Vector3 movePosition;

   void Awake() {
       anim = GetComponent<Animator>();
       myBody = GetComponent<Rigidbody2D>();

   }
    void Start()
    {
        originPosition = transform.position;
        originPosition.y += 1f;
        movePosition = transform.position;
        movePosition.y -= 1f;
    }

    // Update is called once per frame
    void Update()
    {
        MoveSpider();
    }

    void MoveSpider()
    {
        transform.Translate (moveDirection * Time.smoothDeltaTime);
        if(transform.position.y >= originPosition.y)
            {
                moveDirection = Vector3.down;

                ChangeDirection(2.5f);
            }
            else if(transform.position.y <= movePosition.y)
            {
                moveDirection = Vector3.up;

                ChangeDirection(-2.5f);
            }
    }

    void ChangeDirection(float direction)
    {
        Vector3 tempScale = transform.localScale;
        tempScale.y = direction;
        transform.localScale = tempScale;
    }

    IEnumerator SpiderDead()
    {
        yield return new WaitForSeconds (3f);
        gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Bullet")
        {
            GetComponent<BoxCollider2D>().isTrigger = true; 
            anim.Play("SpiderDead");
            myBody.bodyType = RigidbodyType2D.Dynamic;
            StartCoroutine(SpiderDead());
        }
        if(target.tag== "Player")
        {
            target.GetComponent<PlayerDamage>().DealDamage();
        }
    }
}
