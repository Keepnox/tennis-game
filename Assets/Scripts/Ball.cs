using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Rigidbody ballRigid;

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
    
    private void OnCollisionEnter(Collision other)
    {   
        print("SELAM");
        print(other.gameObject.tag.ToString() + "SELAAAM");

        
        if (other.gameObject.tag.ToString() == "RaketRed")
        {
            ballRigid.velocity = Vector3.zero;
            ballRigid.AddForce(Vector3.up * GameManager.GAMESPEED, ForceMode.Impulse);
            ballColor.material.color = Color.red;
        }
        if (other.gameObject.tag.ToString() == "RaketBlue")
        {
            ballRigid.velocity = Vector3.zero;
            ballRigid.AddForce(Vector3.up * GameManager.GAMESPEED, ForceMode.Impulse);
            ballColor.material.color = Color.blue;
        }
        
        

    }
}
