using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatController : MonoBehaviour
{
    private Rigidbody2D rBody2D;
    public float jumpForce = 650f;
    private float moveForce = 30f;
    private Animator anim;
    private int jumpCount=0;
    private float yVelocity;
    // Start is called before the first frame update
    void Start()
    {
        this.rBody2D = this.GetComponent<Rigidbody2D>();
        this.anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        yVelocity = rBody2D.velocity.y * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (yVelocity > 0)
            {
            }

            else if (yVelocity == 0) {
                this.rBody2D.AddForce(Vector2.up * this.jumpForce, ForceMode2D.Impulse);
                this.jumpCount = 1;
            }

        }

        int drX = 0;

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            drX = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            drX = 1;
        }

        float speedX = Mathf.Abs(this.rBody2D.velocity.x);

        if (speedX < 2f)
        {
            this.rBody2D.AddForce(new Vector2(drX, 0) * this.moveForce);
        }

        if(drX != 0)
        {
            this.transform.localScale = new Vector3(drX, 1, 1);
        }

        this.anim.speed = speedX / 2.0f;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogFormat("{0}", collision.name);
        Debug.LogFormat("Game Clear¾ÀÀ¸·Î ÀüÈ¯!");
        SceneManager.LoadScene("ClearScene");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.LogFormat("{0}", collision.name);
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    Debug.LogFormat("{0}", collision.name);
    //}


}
