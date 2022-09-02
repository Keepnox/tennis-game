using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class Cube : MonoBehaviour
{
    public MeshRenderer cubeMesh;
    private MeshRenderer ballColor;
    private Rigidbody ballRigid;
    public Material[] materials;
    private bool selectColor;
    public TextMeshPro scoreText;
    
    // Start is called before the first frame update
    void Awake()
    {
        ballRigid = GameObject.Find("Ball").GetComponent<Rigidbody>(); 
        ballColor = GameObject.Find("Ball").GetComponent<MeshRenderer>();
        selectColor = Random.value < 0.5f;
        cubeMesh.material = selectColor ? materials[0] : materials[1];
        scoreText.text = GameManager.Instance.currentBoxScore.ToString();
        scoreText.color = selectColor ? new Color(4, 85, 191, 70) : new Color(242, 5, 5, 70);
    }

    private void OnDestroy()
    {
        
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.ToString() == "Ball")
        {
            cubeMesh.material.SetFloat("_Glossiness", 0.6f);
            GameManager.Instance.currentCubeIsRed = selectColor;
            if (other.gameObject.GetComponent<Ball>().isTopRed == selectColor) 
            {
                ballRigid.velocity = Vector3.zero;
                float effect = 0.6f;
                DOTween.To( () => effect, ( _effect ) => effect = _effect, 0f, 0.7f ).OnUpdate(() =>cubeMesh.material.SetFloat("_Glossiness", effect));
                GameManager.Instance.decreaseCurrentBoxScore();
                ballRigid.AddForce(Vector3.down * GameManager.Instance.GAMESPEED / 2, ForceMode.Impulse);
                scoreText.text = GameManager.Instance.currentBoxScore.ToString();
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