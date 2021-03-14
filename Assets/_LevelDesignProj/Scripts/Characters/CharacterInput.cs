using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterInput : MonoBehaviour
{
    [SerializeField]
    float Speed = 10;
    bool bInput = false;
    CharacterController characterController;
    Animator Anim;
    Vector3 Velocity = Vector3.zero;
    [SerializeField]
    Transform Character;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            Velocity = Vector3.zero;
        if(bInput)
        {
            if(Input.GetKey(KeyCode.W))
            {
                Velocity += transform.forward;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Velocity -= transform.forward;
            }
            if (Input.GetKey(KeyCode.D))
            {
                Velocity += transform.right;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                Velocity -= transform.right;
            }
            Velocity *= Speed;
            if(Velocity.sqrMagnitude > 0)
                Character.forward = Velocity;
        }
            Anim.SetFloat("Speed", Velocity.magnitude);
            characterController.SimpleMove(Velocity);
    }
    public void StopInput()
    {
        bInput = false;
    }
    public void ResumeInput()
    {
        bInput = true;
    }
}
