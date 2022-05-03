using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public GameObject tama;
    float setime= 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter(Collider other)
    {
        var name = other.gameObject.name;
        //Destroy(other.gameObject);
        //Instantiate(tama, new Vector3(Random.Range(-3,7), Random.Range(-3, 7), Random.Range(-3, 7)), Quaternion.identity);
    }
     void OnTriggerStay(Collider other)
    {
        setime += Time.deltaTime;
       other.GetComponent<Renderer>().material.color　+=new Color32(10,0,0,0);
        other.GetComponent<Renderer>().material.color -= new Color32(0, 10, 0, 0);

        print(other.GetComponent<Renderer>().material.color);
        other.GetComponent<Transform>().position += new Vector3(Random.Range(-1, 3) * 0.1f, Random.Range(-1, 3) * 0.1f, Random.Range(-1, 3) * 0.1f);
        if (other.GetComponent<Renderer>().material.color.r>1)
        {
            Destroy(other.gameObject);
        }
    }
     void OnTriggerExit(Collider other)
    {
        setime = 0;
        print(setime);
    }
}
