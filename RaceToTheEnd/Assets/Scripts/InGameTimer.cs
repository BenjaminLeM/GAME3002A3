using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UI;

public static class CleanseFloat
{
    public static float ToFixed(this float number, uint count)
    {
        return float.Parse(number.ToString("N" + count.ToString(), System.Globalization.CultureInfo.InvariantCulture), System.Globalization.CultureInfo.InvariantCulture);
    }

}
public class InGameTimer : MonoBehaviour
{
    [SerializeField]
    private Text TimerDisplay;
    public float Timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        TimerDisplay.text = " Time: " + Timer.ToFixed(1);
    }

    private void Update()
    {
        TimerDisplay.text = " Time: " + Timer.ToFixed(1);
    }
    private void FixedUpdate()
    {
        float dt = Time.deltaTime;
        if (Timer >= 2000.0f)
        {
            GetComponent<PlayerControls>().isDead = true;
        }
        else 
        {
            Timer += dt;
        }
    }
}
