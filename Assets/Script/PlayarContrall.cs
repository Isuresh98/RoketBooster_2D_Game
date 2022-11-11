using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayarContrall : MonoBehaviour
{
    private Rigidbody _rBody;
    [SerializeField]
    private float _trusterPower =50f;
    [SerializeField]
    private float _rotetPower = 10f;

    private AudioSource _boostSound;

    // Start is called before the first frame update
    void Start()
    {
        _rBody = GetComponent<Rigidbody>();
        _boostSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        InputPrograss();
    }

    private void InputPrograss()
    {
        // trust Apply
        if (Input.GetKey(KeyCode.Space))
        {
            _rBody.AddRelativeForce(Vector3.up * _trusterPower);
            if (!_boostSound.isPlaying)
            {
                _boostSound.Play();
            }
            
        }
        else
        {
            _boostSound.Stop();
        }



        _rBody.freezeRotation = true;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * _rotetPower * Time.deltaTime);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * _rotetPower * Time.deltaTime);
        }
        _rBody.freezeRotation = false;



    }
}
