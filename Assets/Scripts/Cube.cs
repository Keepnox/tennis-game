using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class Cube : MonoBehaviour
{
    private int selectColor;
    public MeshRenderer cubeMesh;
    private MeshRenderer ballColor;
    private Rigidbody ballRigid;

    // Start is called before the first frame update
    void Awake()
    {
        print("NEW CUBE INSTIANTE");
        ballRigid = GameObject.Find("Ball").GetComponent<Rigidbody>(); 
        ballColor = GameObject.Find("Ball").GetComponent<MeshRenderer>();
        selectColor = Random.Range(0, 1);
        cubeMesh.material.color = selectColor == 0 ? Color.red : Color.blue;
    }

    private void OnDestroy()
    {
        
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.ToString() == "Ball")
        {
            if (ballColor.material.color == cubeMesh.material.color)
            {
                print("TOP RENGI: " + ballColor.material.color );
                print("KUP RENGI: " + cubeMesh.material.color );
                ballRigid.velocity = Vector3.zero;
                GameManager.Instance.decreaseCurrentBoxScore();
                ballRigid.AddForce(Vector3.down * GameManager.Instance.GAMESPEED / 2, ForceMode.Impulse);
                if (GameManager.Instance.currentBoxScore == 0)
                {
                    GameManager.Instance.DestroyAndSpawnCube(this);
                }
            } else
            {
         
                ballRigid.isKinematic = true;
                GameManager.gameOver();
            }
        }
    }
}
