using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private float MoveSpd = 20f;
    private Rigidbody rigidbody;
    private Vector3 MoveDir;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float MoveX = 0;
        float MoveY = 0;

        if (Input.GetKey(KeyCode.W))
        {
            MoveY = +1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveY = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveX = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveX = +1f;
        }

        MoveDir = new Vector3(MoveX,0, MoveY).normalized;
        transform.LookAt(transform.position+ MoveDir);

    }
    private void FixedUpdate()
    {
        rigidbody.velocity = MoveDir * MoveSpd;
    }

}
