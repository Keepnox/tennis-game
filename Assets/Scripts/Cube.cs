using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cube : MonoBehaviour
{
    private int selectColor;
    private MeshRenderer cubeMesh;
    private MeshRenderer ballColor;
    private Rigidbody ballRigid;
    public int jumpSpeed;
    
    // Start is called before the first frame update
    void Awake()
    {
        print("NEW CUBE INSTIANTE");
        ballRigid = GameObject.Find("Ball").GetComponent<Rigidbody>(); 
        cubeMesh = GameObject.Find("CubeMesh").GetComponent<MeshRenderer>();
        ballColor = GameObject.Find("Ball").GetComponent<MeshRenderer>();
        selectColor = Random.Range(0, 1);
        ballColor.material.color = Color.red;
        cubeMesh.material.color = selectColor == 0 ? Color.red : Color.blue;
    }

    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.ToString() == "Ball")
        {
            if (ballColor.material.color == cubeMesh.material.color)
            {
                GameManager.decreaseCurrentBoxScore();
                ballRigid.velocity = Vector3.zero;

            } else
            {
                print("TOP YA YANLIS CARPTI YA HIC");
                ballRigid.isKinematic = true;
                GameManager.gameOver();
            }
        }
        


    }
}
