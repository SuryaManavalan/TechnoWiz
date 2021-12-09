using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiTouch : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 screenCenter;
    public GameObject prefab;
    List<GameObject> nodes = new List<GameObject>();

    void Start()
    {
        screenCenter = new Vector2(Screen.width/2, Screen.height/2);
    }

    // Update is called once per frame
    void Update()
    {
        int tapCount = Input.touchCount;
        while(nodes.Count != tapCount){
            if(nodes.Count < tapCount){
                nodes.Add(Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity));
            }else{
                GameObject vic = nodes[0];
                nodes.Remove(nodes[0]);
                Destroy(vic);
            }
        }

        for ( var i = 0 ; i < nodes.Count ; i++ ) {
            UnityEngine.Touch touch = Input.touches[i];
            Vector2 unitVec = (touch.position - screenCenter);
            unitVec = unitVec/unitVec.magnitude;
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(convert(screenCenter + unitVec*200));
            nodes[i].transform.position = objPosition;
            }
    }

    Vector3 convert (Vector2 v) {
        return new Vector3 (v.x, v.y, 10.0f);
        }
}
