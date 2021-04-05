using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float mainRotateThrust = 100f;

    Rigidbody rigbody;
    // Start is called before the first frame update
    void Start()
    {
        rigbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Key pressed for thrust");
            
            rigbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
    }

    private void Rotate()
    {
        if (Input.GetKey(KeyCode.A) ^ Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.A))
            {
                ApplyRotation(mainRotateThrust);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                ApplyRotation(-mainRotateThrust);

            }
        }
    }

    private void ApplyRotation(float mainRotateThrust){
        rigbody.freezeRotation = true; // freeze rigidbody (physics) rotation
        transform.Rotate(Vector3.forward * mainRotateThrust * Time.deltaTime);
        rigbody.freezeRotation = false; // resume rigidbody (physics) rotation
    }
}
