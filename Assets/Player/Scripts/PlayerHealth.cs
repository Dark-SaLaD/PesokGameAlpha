using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float value;

    public GameObject aim;
    public GameObject youDeadScreen;
    public SandBallCaster sandBallCaster;

    public Image healthValue1;
    public Image healthValue2;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;
    public Sprite sprite7;
    public Sprite sprite8;
    public Sprite sprite9;
    public Sprite sprite0;

    public void DealDamage(float damage) {
        //damage player
        value -= damage;

        //health UI
        healthValue2.gameObject.SetActive(false);
        //health 10 UI
        if (value > 90) {
            healthValue1.sprite = sprite1;
            healthValue2.gameObject.SetActive(true);
        }
        //health 9 UI
        if (value <= 90 && value > 80) {
            healthValue1.sprite = sprite9;
        }
        //health 8 UI
        if (value <= 80 && value > 70) {
            healthValue1.sprite = sprite8;
        }
        //health 7 UI
        if (value <= 70 && value > 60) {
            healthValue1.sprite = sprite7;
        }
        //health 6 UI
        if (value <= 60 && value > 50) {
            healthValue1.sprite = sprite6;
        }
        //health 5 UI
        if (value <= 50 && value > 40) {
            healthValue1.sprite = sprite5;
        }
        //health 4 UI
        if (value <= 40 && value > 30) {
            healthValue1.sprite = sprite4;
        }
        //health 3 UI
        if (value <= 30 && value > 20) {
            healthValue1.sprite = sprite3;
        }
        //health 2 UI
        if (value <= 20 && value > 10) {
            healthValue1.sprite = sprite2;
        }
        //health 1 UI
        if (value <= 10 && value > 0) {
            healthValue1.sprite = sprite1;
        }
        //"you dead screen" and health 0 UI
        if (value <= 0) {
            //"you dead screen" (screen)
            youDeadScreen.gameObject.SetActive(true);
            aim.gameObject.SetActive(false);
            //"you dead screen" (disabled control)
            GetComponent<PlayerController>().enabled = false;
            GetComponent<CameraRotation>().enabled = false;
            sandBallCaster.GetComponent<SandBallCaster>().enabled = false;

            //health 0 UI
            healthValue1.sprite = sprite0;
        }
    }
}
