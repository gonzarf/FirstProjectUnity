using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float maxTime;
    public GameObject objToSpawn;
    private float currenTime;

    // Start is called before the first frame update
    void Start()
    {
        currenTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currenTime += Time.deltaTime;

        if (currenTime >= maxTime) 
        {
            // El tiempo ha pasado
            currenTime = 0;

            // Nos devuelve  el objeto que ha spawneado
            GameObject objt = Instantiate(objToSpawn, transform.position, Quaternion.identity);

            // Con GetComponent cogemos el color y lo cambiamos utilizando un random
            //objt.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }
}
