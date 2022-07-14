using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars : MonoBehaviour
{

    public GameObject[] cars;
    public float speed;
    


    void Start()
    {
        if (transform.position.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 180f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-speed, -speed + 4f), 0);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(speed - 4f, speed), 0);
        }

        int rand = Random.Range(0, 6);
        switch(rand){
            case 0:
                cars[0].SetActive(true);
                break;
            case 1:
                cars[1].SetActive(true);
                break;
            case 2:
                cars[2].SetActive(true);
                break;
            case 3:
                cars[3].SetActive(true);
                break;                                                
            case 4:
                cars[4].SetActive(true);
                break;
            case 5:
                cars[5].SetActive(true);
                break;            
        }

    }
    private void Update()
    {
        if (transform.position.x < -15f || transform.position.x > 15f)
        {
            Object.Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Car") 
        {
            Object.Destroy(gameObject);        
        
        }
    }
}
