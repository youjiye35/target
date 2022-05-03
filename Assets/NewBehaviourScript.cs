using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Vector3 position;
    // スクリーン座標をワールド座標に変換した位置座標
    private Vector3 screenToWorldPointPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        position = Input.mousePosition;
        // Z軸修正
        position.z = 10f;
        // マウス位置座標をスクリーン座標からワールド座標に変換する
        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
        // ワールド座標に変換されたマウス座標を代入
        var kakudoy = Mathf.Atan(screenToWorldPointPosition.y / 10)*90;
        var kakudox = Mathf.Atan(screenToWorldPointPosition.x/ 10) * 90;
        GameObject.Find("Cubetarget").transform.rotation = Quaternion.Euler(-kakudoy,kakudox,0);
        GameObject.Find("Plane").transform.position = screenToWorldPointPosition;
        GameObject.Find("target").transform.rotation = GameObject.Find("Cubetarget").transform.rotation;
        
    }
}
