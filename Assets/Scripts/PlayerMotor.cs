using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Speed{
    public float run;
    public float walk;
}

public class PlayerMotor : MonoBehaviour
{
    public Speed speed;
    private int _lookAt = 2;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    void Move(){
        float _movX = Input.GetAxisRaw("Horizontal");
        float _movY = Input.GetAxisRaw("Vertical");

        animator.SetBool("walking",(_movX != 0 || _movY != 0));

        float _speed = (Input.GetKey(KeyCode.LeftShift)) ? speed.run : speed.walk;

        Vector3 velocity = new Vector3(_movX, _movY,0) * Time.deltaTime * _speed;


         //0 - Norte, 1 - Oeste, 2 - Sul, 3 - Leste
        if(velocity.y > 0) _lookAt = 0;
        else if(velocity.x > 0) _lookAt = 3;
        else if(velocity.x < 0) _lookAt = 1;
        else if(velocity.y < 0) _lookAt = 2;

        animator.SetInteger("lookAt",_lookAt);

        transform.position += velocity;
    }
}
