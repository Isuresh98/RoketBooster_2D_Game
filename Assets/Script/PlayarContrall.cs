using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayarContrall : MonoBehaviour
{
    private Rigidbody _rBody;
    [SerializeField]
    private float _trusterPower =50f;
    [SerializeField]
    private float _rotetPower = 10f;
    [SerializeField]
    private float _boostHelth=100f;
    

    private AudioSource _boostSound;
    [SerializeField]
    private float _boosterTimer;
    [SerializeField]
    

    public HelthBar HelthBarScript;

    // Start is called before the first frame update
    void Start()
    {
        _rBody = GetComponent<Rigidbody>();
        _boostSound = GetComponent<AudioSource>();
        HelthBarScript.MaxHelth(_boostHelth);
       
        


    }//Start

    // Update is called once per frame
    void Update()
    {
        

        _boosterTimer -= Time.deltaTime;
        

        HelthBarScript.SetHelth(_boostHelth);

        BoosterInput();
        RotetInput();
        HelthCounter();

    }//Update

    private void HelthCounter()
    {
        if (_boostHelth == 0)
        {
            _boostHelth = 0;
            print("game over!");
        }
    }

   

    private void RotetInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * _rotetPower * Time.deltaTime);


        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * _rotetPower * Time.deltaTime);

        }
    }//RotetInput

    private void BoosterInput()
    {
        // trust Apply
        if (Input.GetKey(KeyCode.Space) && _boostHelth > 0)
        {
            _rBody.AddRelativeForce(Vector3.up * _trusterPower);

            _boostHelth--;


            if (!_boostSound.isPlaying)
            {
                _boostSound.Play();
            }

        }
        else
        {
            _boostSound.Stop();
        }
    }//BoosterInput


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Helth"))
        {
            
            _boostHelth += 100f;
            Destroy(GameObject.FindWithTag("Helth"));
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            print("Game Winnig!");
            _boostHelth = 0f;
        }
        if (other.gameObject.CompareTag("Ball"))
        {
            _boostHelth -= 10;
        }

    }//OnTriggerEnter
}
