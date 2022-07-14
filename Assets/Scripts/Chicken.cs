using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chicken : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private Vector3 positionStart;
    private bool lostGame = false;
    public float chickenVelocity;
    private float chickenPoints;
    public TMPro.TextMeshProUGUI textScore;
    public TMPro.TextMeshProUGUI textGoodJob;
    public TMPro.TextMeshProUGUI textLose;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        positionStart = transform.position;
               
    }

    // Update is called once per frame
    void Update()
    {
        float velocity_horizontal = 0;
        float velocity_vertical = 0;
        
        if (Input.GetKey(KeyCode.A)) 
        {
            velocity_horizontal -= chickenVelocity;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity_horizontal += chickenVelocity;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }          
        if (Input.GetKey(KeyCode.W)) 
        {
            velocity_vertical += chickenVelocity;         
        }   
        if (Input.GetKey(KeyCode.S)) 
        {
            velocity_vertical -= chickenVelocity;         
        }
        velocity_horizontal *= 1.5f;
        
        if (lostGame)
        {
            velocity_horizontal = 0; 
            velocity_vertical = 0;
        }

        rb.velocity = new Vector2(velocity_horizontal, velocity_vertical);

        animator.SetBool("Running", Mathf.Abs(rb.velocity.x) > 0.1f || Mathf.Abs(rb.velocity.y) > 0.1f);

        textScore.text = "Score: " + chickenPoints.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            lostGame = true;
            transform.position = positionStart;
            Invoke("LostGameReset", 1f);
            
            if(chickenPoints > 0)
            {
                chickenPoints--;
            }
        }
        
        if (collision.gameObject.tag == "SideWalkPoints")
        {
            lostGame = true;
            transform.position = positionStart;
            Invoke("LostGameReset", 1f);
            chickenPoints++;
        }

        textGoodJob.gameObject.SetActive(chickenPoints % 5 == 0 && chickenPoints != 0);
        textLose.gameObject.SetActive(chickenPoints == 0);
    }

    void LostGameReset()
    {
        lostGame = false;
    }

}
