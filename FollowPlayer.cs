using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject target;

    private Vector3 pos;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pos = target.transform.position;

        transform.position = new Vector3(pos.x, pos.y + 1f, (pos.z - 33f));
    }
}