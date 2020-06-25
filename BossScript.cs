using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
   public GameObject Stone;
   public Transform attackInstantiate;
   private Animator anim;
   private string coroutine_Name = "StartAttack";
   void Awake() {
       anim = GetComponent<Animator>();
   }
    void Start()
    {
         StartCoroutine(coroutine_Name);
    }

    void Attack()
    {
        GameObject obj = Instantiate(Stone, attackInstantiate.position, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-308f, -700),0f));
  }

    void BackToIdel()
    {
        anim.Play("BossAnimation");
    }


    public void DeactivateBossScript()
    {
        StopCoroutine(coroutine_Name);
        enabled = false;
    }

    IEnumerator  StartAttack()
    {
        
        yield return new WaitForSeconds(Random.Range(2f , 5f));

        anim.Play("AttackAnimation");
        StartCoroutine(coroutine_Name);

    }
}
