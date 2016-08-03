﻿using UnityEngine;
using System.Collections;

public class CrystalExplosionTrigger : MonoBehaviour {

    public bool shouldDissolveShield = false;

    private Renderer dissolveRenderer;
    public GameObject dissolveShield;

    public float dissolveAmount = 0;
    public float dissolveSpeed = .05f;

    //Charges up a light then when it hits max, swaps from the whole Crystal to the broke Crystal, which then proceeds to explode everywhere.
    public bool shouldExplode = false;
    public Light chargeLight;
    public GameObject wholeCrystal;
    public GameObject brokeCrystal;

    //These variables control how long the light shines up before it explodes
    public float chargeAmount;
    public float chargeMax;
    public float chargeSpeed;

    public GenericDissolver[] dissArr;

	// Use this for initialization
	void Start () {
        dissolveRenderer = dissolveShield.GetComponent<Renderer>();
        chargeLight.intensity = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (shouldDissolveShield)//Start Dissolving
        {
            
            //If we aren't done yet
            if (dissolveAmount <= 1)
            {
                //Keep going
                dissolveRenderer.material.SetFloat("_SliceAmount", dissolveAmount);
                dissolveAmount += dissolveSpeed;
            }
            else
            {
                //We're done and we don't need this thing any more.
                Destroy(dissolveShield.gameObject);
            }

            //If we're done dissolving and we should start exploding, let's start exploding.
            if (shouldExplode)
            {

                if(chargeAmount < chargeMax)
                {
                    chargeAmount += chargeSpeed;
                    chargeLight.intensity = chargeAmount;
                }
                else
                {
                    wholeCrystal.SetActive(false);
                    brokeCrystal.SetActive(true);

                    foreach(GenericDissolver i in dissArr)
                    {
                        i.shouldDissolveObject = true;
                        i.gameObject.transform.SetParent(null);
                    }
                    //Destroy(this.gameObject);
                }
            }
        }
	}
}
