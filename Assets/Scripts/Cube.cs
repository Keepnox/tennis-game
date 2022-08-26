using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cube : MonoBehaviour
{
    public int targetPower;
    private int selectColor;
    public MeshRenderer cubeMesh;
    public MeshRenderer ballColor;
    public Rigidbody ballRigid;
    public int jumpSpeed;
    // Start is called before the first frame update
    void Awake()
    {
        //targetPower = Random.Range(1, 4);
        targetPower = 8;
        selectColor = Random.Range(0, 2);
        //cubeMesh.material.color = selectColor == 0 ? Color.red : Color.blue;
        cubeMesh.material.color = Color.red;
    }

    
    
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.tag.ToString() == "Ball")
        {
            if (ballColor.material.color == cubeMesh.material.color)
            {
                targetPower -= 1;
                ballRigid.velocity = Vector3.zero;
                ballRigid.AddForce(Vector3.down * jumpSpeed, ForceMode.Impulse);
            } else
            {
                //gameOver();
                ballRigid.velocity = Vector3.zero;
            }
        }
        


    }
}
