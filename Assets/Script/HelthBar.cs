using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelthBar : MonoBehaviour
{
    public Slider SliderComponent;

    public Gradient ColorGradiyant;
    public Image Fill;
   

    // Start is called before the first frame update
    void Start()
    {
        SliderComponent = GetComponent<Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MaxHelth(float Helth)
    {
        SliderComponent.maxValue = Helth;
        SliderComponent.value = Helth;
        Fill.color = ColorGradiyant.Evaluate(1f);
    }


    public void SetHelth(float Helth)
    {
        SliderComponent.value = Helth;
        Fill.color = ColorGradiyant.Evaluate(SliderComponent.normalizedValue);
    }


}
