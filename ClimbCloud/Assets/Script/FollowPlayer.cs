using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject catGo;
    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        this.catGo = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {
        if(catGo.transform.position.y>0)
        transform.position = new Vector3(0,catGo.transform.position.y,-1);
    }
}
