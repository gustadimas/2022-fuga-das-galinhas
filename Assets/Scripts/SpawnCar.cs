using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    public GameObject prefabCar;
    public float timeMax;
    public float timeMin;

    void Start()
    {
        //Invoke("SpawnTheCar", Random.Range(timeMin, timeMax));
        Invoke("SpawnTheCar", Random.Range(0.1f, 0.9f));
    }

    void SpawnTheCar()
    {
        int flipCar = 1;
        if (Random.Range(0,2) == 0)
        {
            flipCar = -1;
        }
        //Debug.Log(flipCar);
        Instantiate(prefabCar, new Vector3(flipCar*transform.position.x, transform.position.y, 0), Quaternion.identity);
        Invoke("SpawnTheCar", Random.Range(timeMin, timeMax));
    }
}
