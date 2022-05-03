using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class target : MonoBehaviour
{
    public GameObject tama;
    float setime= 0;
    List<string> ugo = new List<string>();
    // Start is called before the first frame update
    float kakudo = 0;
    int score = 0;
    int ballnum = 0;
    public GameObject bakuha;
    void Start()
    {
        
    }

    // Update is called once per frame
    //

    void Update()
    {
        kakudo += 0.01F;
        
            if (ugo.Count != 0)
            {
            for (int i = 0; i < ugo.Count; i++)
            {
                if (i%3==0)
                {
                    GameObject.Find(ugo[i]).GetComponent<Transform>().position += new Vector3(0.07F * Mathf.Sin(kakudo), 0, 0);

                }
                else if (i%3==1)
                {
                    GameObject.Find(ugo[i]).GetComponent<Transform>().position += new Vector3(0,0.05F * Mathf.Sin(kakudo), 0);
                }
                else if (i%3==2)
                {
                    GameObject.Find(ugo[i]).GetComponent<Transform>().position += new Vector3(0, 0,0.07F * Mathf.Sin(kakudo));

                }
            }
          }
        
        
    }
     void OnTriggerEnter(Collider other)//物体とターゲットがぶつかった瞬間一回だけ実行される
    {
        if (!ugo.Contains(other.name))
        {
            ugo.Add(other.name);
        }
        print(string.Join(",", ugo));
        //Destroy(other.gameObject);
        //Instantiate(tama, new Vector3(Random.Range(-3,7), Random.Range(-3, 7), Random.Range(-3, 7)), Quaternion.identity);
    }
     void OnTriggerStay(Collider other)//物体とターゲットがぶつかっている間実行される
    {
        setime += Time.deltaTime;
       other.GetComponent<Renderer>().material.color　+=new Color32(10,0,0,0);
        other.GetComponent<Renderer>().material.color -= new Color32(0, 10, 0, 0);
        
        //other.GetComponent<Transform>().position += new Vector3(Random.Range(-1, 3) * 0.1f, Random.Range(-1, 3) * 0.1f, Random.Range(-1, 3) * 0.1f);
        if (other.GetComponent<Renderer>().material.color.r>1)
        {
            Instantiate(bakuha, new Vector3(0, 0, 0), Quaternion.identity);
            bakuha.GetComponent<Rigidbody>().AddForce(100, 0, 0);
            Destroy(other.gameObject);
            var ball=Instantiate(tama, new Vector3(Random.Range(-3, 7), Random.Range(-3, 7), Random.Range(-3, 7)), Quaternion.identity);
            ballnum++;
            ball.name = "ball"+ballnum.ToString();
            score += 10;
            GameObject.Find("tenn").GetComponent<TextMesh>().text = score.ToString();
            var banme = ugo.IndexOf(other.name);
            ugo.RemoveAt(banme);
        }
    }
     void OnTriggerExit(Collider other)//物体とターゲットがぶつかっているのが終わった瞬間実行される
    {

        setime = 0;
        print(setime);
    }
}
