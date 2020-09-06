using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voltear : MonoBehaviour {

    Vector3 characterScale;
    float characterScaleX;

    void Start()
    {
        characterScale = transform.localScale;
        characterScaleX = characterScale.x;
    }

    void Update () {

        // Move the Character:
      //  transform.Translate(Input.GetAxis("Horizontal") * 15f * Time.deltaTime, 0f, 0f);

        // Flip the Character:
        if (Input.GetAxis("Horizontal") < 0) {
            characterScale.y = -characterScaleX;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.y = characterScaleX;
        }
        transform.localScale = characterScale;

    }
}
