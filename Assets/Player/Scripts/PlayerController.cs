using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float speed;

    private float _fallVelocity = 0f;
    private float _gravity = 9.8f;
    private Vector3 _moveVector;
    private CharacterController _characterController;

    public Animator animatorBack;
    public Animator animatorFront;

    void Start() {
        _characterController = GetComponent<CharacterController>();
    }

    void Update() {
        //move
        _moveVector = Vector3.zero;
        animatorBack.SetBool("PlayerMove", false);
        animatorFront.SetBool("PlayerMove", false);
        if (Input.GetKey(KeyCode.W)) {
            _moveVector += transform.forward;
            animatorBack.SetBool("PlayerMove", true);
            animatorFront.SetBool("PlayerMove", true);
        }
        if (Input.GetKey(KeyCode.S)) {
            _moveVector -= transform.forward;
            animatorBack.SetBool("PlayerMove", true);
            animatorFront.SetBool("PlayerMove", true);
        }
        if (Input.GetKey(KeyCode.D)) {
            _moveVector += transform.right;
            animatorBack.SetBool("PlayerMove", true);
            animatorFront.SetBool("PlayerMove", true);
        }
        if (Input.GetKey(KeyCode.A)) {
            _moveVector -= transform.right;
            animatorBack.SetBool("PlayerMove", true);
            animatorFront.SetBool("PlayerMove", true);
        }

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded) {
            _fallVelocity = -jumpForce;
        }
    }

    void FixedUpdate() {
        //move
        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);

        //fall and jump
        _fallVelocity += _gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
        if (_characterController.isGrounded) {
            _fallVelocity = 0;
        }
    }
}
