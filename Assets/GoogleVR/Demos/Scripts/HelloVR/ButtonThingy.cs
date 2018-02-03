using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonThingy : MonoBehaviour
{


    public float timerAmount = 2f;
    private float tmpTime;
    public bool isStaring, colorChanged;
    private ParticleSystem particleSystem;
    private ParticleSystem.MinMaxCurve emissionRateOrig;
    private Color colorOrig;

    // private float timer = 0;


    private void Start()
    {
        isStaring = false;
        colorChanged = false;
        tmpTime = timerAmount;
        particleSystem = GetComponent<ParticleSystem>();
        var emission = particleSystem.emission;
        emissionRateOrig = emission.rateOverTime;
        colorOrig = GetComponent<MeshRenderer>().material.color;

    }
    public void OnStare()
    {
        Debug.Log("Hewwo");
        isStaring = true;

    }

    public void OnOffStare()
    {
        Debug.Log("Bwye");
        isStaring = false;
    }

    public void ChangeColour()
    {
        if (!colorChanged)
        {
            Debug.Log("Color chnaged");
            GetComponent<MeshRenderer>().material.color = Color.red;

        }
        else if (colorChanged)
        {
            Debug.Log("Color changed to original");
            GetComponent<MeshRenderer>().material.color = Color.yellow;

        }
    }

    void Update()
    {



        if (isStaring && timerAmount >= 0)
        {
            Debug.Log("Is staring");
            timerAmount -= Time.deltaTime;



            var emission = particleSystem.emission;
            emission.rateOverTime = timerAmount;


        }
        if (timerAmount <= 0)
        {
            var emission = particleSystem.emission;
            emission.rateOverTime = 0;
            ChangeColour();
            //timerAmount = tmpTime;
        }



        else if (!isStaring)
        {
            Debug.Log("Is no longer staring");
            timerAmount = tmpTime;
            var emission = particleSystem.emission;
            emission.rateOverTime = emissionRateOrig;
            GetComponent<MeshRenderer>().material.color = colorOrig;
            
        }


    }
}
