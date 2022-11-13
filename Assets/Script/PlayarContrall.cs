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

    [SerializeField]
    private float _particalDesroyTime = 2f;


    private AudioSource _boostSound;
    [SerializeField]
    private float _boosterTimer;
    [SerializeField]
    

    public HelthBar HelthBarScript;

    public ParticleSystem HelthVFX;
    public ParticleSystem BoosterVFX;
    // Start is called before the first frame update
    void Start()
    {
        _rBody = GetComponent<Rigidbody>();
        _boostSound = GetComponent<AudioSource>();
        HelthBarScript.MaxHelth(_boostHelth);
        HelthVFX.Stop();
        BoosterVFX.Stop();
        _boosterTimer = 50f;
    
        //HelthVFX = ParticleSystem.FindObjectOfType("HelthFVX");
        // HelthVFX = GameObject.FindWithTag("HelthFVX");




    }//Start

    // Update is called once per frame
    void Update()
    {
        

        //_boosterTimer -= Time.deltaTime;
        

        HelthBarScript.SetHelth(_boostHelth);

        BoosterInput();
        RotetInput();
        HelthCounter();
        

    }//Update

    private void HelthCounter()
    {
        
        if (_boostHelth == 0)
        {
            Timer();
            _boostHelth = 0;

           
            if (_boosterTimer == 0)
            {
                print("game over!");
            }
           
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
            BoosterVFX.Play();

            if (!_boostSound.isPlaying)
            {
                _boostSound.Play();
            }

        }
        else
        {
            _boostSound.Stop();
            BoosterVFX.Stop();
        }
    }//BoosterInput


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Helth"))
        {
            HelthVFX.Play();
            _boostHelth += 100f;
            _boosterTimer = 50f;
            Destroy(GameObject.FindWithTag("Helth"));
            Destroy(GameObject.FindWithTag("HelthFVX"), _particalDesroyTime);

        }
        if (other.gameObject.CompareTag("Finish"))
        {
            print("Game Winnig!");
           
        }
        if (other.gameObject.CompareTag("Ball"))
        {
            _boostHelth -= 10;
        }

    }//OnTriggerEnter


    private void Timer()
    {
       
        if (_boostHelth == 0)
        {
            
            _boosterTimer--;
        }
        
    }
}//Class
