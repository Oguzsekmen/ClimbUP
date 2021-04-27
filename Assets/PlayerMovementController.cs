//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerMovementController : MonoBehaviour
//{
//    PlayerInputController inputController;
//    Rigidbody _rigidbody;
//    [SerializeField] float speed = 3f;
//    [Space]
//    [SerializeField]
//    private float angularSpeed = 1f;
//    private void Awake()
//    {
//        inputController = GetComponent<PlayerInputController>();
//        _rigidbody = GetComponent<Rigidbody>();
//    }
//    void Update()
//    {
//        Movement();
//    }
//    private void Movement()
//    {
//        _rigidbody.velocity = new Vector3(transform.forward.x*inputController.VerticalInput, 0f, transform.forward.z * inputController.VerticalInput) *speed;
//        _rigidbody.angularVelocity = new Vector3(0f, inputController.HorizontalInput * angularSpeed, 0f);
//    }
//}
