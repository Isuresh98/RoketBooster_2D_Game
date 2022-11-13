using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFallow : MonoBehaviour
{
    [SerializeField] private float fallowSpeed = 2f;
    private GameObject taget;

    [SerializeField] private float _zoffset = -15f;
    [SerializeField] private float _yoffset = 1f;
    [SerializeField] private float _xoffset = 1f;

    // Start is called before the first frame update
    void Start()
    {
        taget = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(taget.transform.position.x+_xoffset, taget.transform.position.y+_yoffset, _zoffset);
        transform.position = Vector3.Slerp(transform.position, newPos, fallowSpeed * Time.deltaTime);
    }
}
