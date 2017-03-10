using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    public AudioClip clip;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CeilingCheck") || other.gameObject.CompareTag("GroundCheck"))
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
        }
    }
}
