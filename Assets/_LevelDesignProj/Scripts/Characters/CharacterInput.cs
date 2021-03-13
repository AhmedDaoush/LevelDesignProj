using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterInput : MonoBehaviour
{
    [SerializeField]
    float Speed = 10;
    bool bInput = true;
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
        if(bInput)
        {
            Velocity = Vector3.zero;
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
            characterController.SimpleMove(Velocity);
            if(Velocity.sqrMagnitude > 0)
                Character.forward = Velocity;
            Anim.SetFloat("Speed", Velocity.magnitude);
        }
    }
}
