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
  
    
    

    public HelthBar HelthBarScript;

    public ParticleSystem HelthVFX;
    public ParticleSystem BoosterVFX;
    // Start is called before the first frame update

    enum Stats { ALIVE,DYING,TRANCENDING}
    Stats states = Stats.ALIVE;

    void Start()
    {
        _rBody = GetComponent<Rigidbody>();
        _boostSound = GetComponent<AudioSource>();
        HelthBarScript.MaxHelth(_boostHelth);
        HelthVFX.Stop();
        BoosterVFX.Stop();
       
       
    
      




    }//Start

    // Update is called once per frame
    void Update()
    {
        

        
        

        HelthBarScript.SetHelth(_boostHelth);
        if (states == Stats.ALIVE)
        {
            BoosterInput();
            RotetInput();
        }
        
      

        Invoke("HelthCounter", 12f);
        

    }//Update

    private void HelthCounter()
    {
        
        if (_boostHelth == 0)
        {
           
            _boostHelth = 0;
            states = Stats.DYING;
            print("Game Over!");
            _boostSound.Stop();
            BoosterVFX.Stop();


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


        }
        else
        {
            HelthVFX.Stop();
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            print("Game Winnig!");
            _boostSound.Stop();
            BoosterVFX.Stop();
            states = Stats.TRANCENDING;
           
        }
        if (other.gameObject.CompareTag("Ball"))
        {
            _boostHelth -= 10;
        }

    }//OnTriggerEnter


   
}//Class
