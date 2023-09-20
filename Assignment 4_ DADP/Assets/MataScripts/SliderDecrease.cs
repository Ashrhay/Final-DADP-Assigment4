using UnityEngine;
using UnityEngine.UI;

public class SliderDecrease : MonoBehaviour
{
    public Slider slider1; 
    public Slider slider2; 

    private float decreaseAmount1 = 2f; 
    private float decreaseAmount2 = 3f; 

    private float decreaseInterval1 = 5f;
    private float decreaseInterval2 = 4f; 

    private float timer1 = 0f; 
    private float timer2 = 0f; 

    private void Start()
    {
        
        timer1 = decreaseInterval1;
        timer2 = decreaseInterval2;
    }

    private void Update()
    {
        // Update the timers
        timer1 -= Time.deltaTime;
        timer2 -= Time.deltaTime;

       
        if (timer1 <= 0f)
        {
            
            DecreaseSlider1();

            
            timer1 = decreaseInterval1;
        }

        
        if (timer2 <= 0f)
        {
            
            DecreaseSlider2();

           
            timer2 = decreaseInterval2;
        }
    }

    private void DecreaseSlider1()
    {
       
        slider1.value -= decreaseAmount1;

       
        slider1.value = Mathf.Max(slider1.value, slider1.minValue);
    }

    private void DecreaseSlider2()
    {
      
        slider2.value -= decreaseAmount2;

       
        slider2.value = Mathf.Max(slider2.value, slider2.minValue);
    }
}
