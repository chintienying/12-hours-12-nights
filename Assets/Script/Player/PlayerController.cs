using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Animator animator;
    private Rigidbody2D rbody2D;
    public float speed = 3;
    public AimPoint aimPoint;

    //=---------------------------------
    public GameObject[] Bullet;
    public GameObject BulletPosition;
    public float power = 1000;
    private int bulletNum;
    public float destroyTime = 1f;
    float time = 0f;
    //----------------------------------







    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rbody2D = gameObject.GetComponent<Rigidbody2D>();
        aimPoint = gameObject.GetComponent<AimPoint>();
        //Bullet[0].SetActive(true);



    }

    // Update is called once per frame
    void Update()
    {

        float dirx = Input.GetAxisRaw("Vertical");
        float dirx_2 = Input.GetAxisRaw("Horizontal");

        rbody2D.velocity = new Vector2(dirx_2 * speed, rbody2D.velocity.y);
        rbody2D.velocity = new Vector2(rbody2D.velocity.x, dirx * speed);

        time += Time.deltaTime;

        // if (Input.GetMouseButtonDown(0))
        // {
        //     if (time > 0.5f)
        //     {
        //         GameObject BulletClone = Instantiate(Bullet[bulletNum], BulletPosition.transform.position, BulletPosition.transform.rotation);
        //         BulletClone.GetComponent<Rigidbody2D>().AddForce(Vector2.left * power);
        //         time = 0;
        //     }

        // }

        if (dirx != 0)
        {
            animator.SetInteger("state", 1);
        }
        else if (dirx_2 != 0)
        {
            animator.SetInteger("state", 1);
        }
        else
        {
            animator.SetInteger("state", 0);
            
        }
    }




    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     Bullet[bulletNum].SetActive(false);
    // }


}
