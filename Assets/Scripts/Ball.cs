using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Rigidbody ballRigid;
    public float jumpSpeed;
    public MeshRenderer ballColor;
    public GameObject cubeController;
    // Start is called before the first frame update
    void Start()
    {
        // ballColor.material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
            
    }
    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag.ToString() == "RaketRed")
        {
            ballRigid.velocity = Vector3.zero;
            ballRigid.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            ballColor.material.color = Color.red;
        }
        if (other.tag.ToString() == "RaketBlue")
        {
            ballRigid.velocity = Vector3.zero;
            ballRigid.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            ballColor.material.color = Color.blue;
        }
        
        

    }
}
