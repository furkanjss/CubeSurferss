using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float MoveSpeedZAxis;
    [SerializeField] private float MoveSpeedXAxis;
    [SerializeField] private Joystick _joystick;
   

    // Update is called once per frame
    void Update()
    {
        float horizontal = _joystick.Horizontal * MoveSpeedXAxis * Time.deltaTime;
        this.transform.Translate(horizontal,0,MoveSpeedZAxis*Time.deltaTime);
    }
}
