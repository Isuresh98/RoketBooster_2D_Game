using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroiScript : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject,0.5f);
           // Destroy(GameObject.FindWithTag("HelthFVX"), _particalDesroyTime);
        }
    }
}
