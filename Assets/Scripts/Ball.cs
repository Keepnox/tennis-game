using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Rigidbody ballRigid;
    public bool isTopRed;
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
        if (other.gameObject.CompareTag("Raket"))
        {
            if (GameManager.Instance.isRaketRed)
            {
                isTopRed = true;
                GameManager.Instance.isBallRed = true;
                ballRigid.velocity = Vector3.zero;
                ballRigid.AddForce(Vector3.up * GameManager.Instance.GAMESPEED, ForceMode.Impulse);
                ballColor.material.color = Color.red;
            }
            else
            {
                isTopRed = false;
                GameManager.Instance.isBallRed = false;
                ballRigid.velocity = Vector3.zero;
                ballRigid.AddForce(Vector3.up * GameManager.Instance.GAMESPEED, ForceMode.Impulse);
                ballColor.material.color = Color.blue;    
            }
        }
        
        
        
        
        
        

    }
}
