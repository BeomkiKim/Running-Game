using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject FailUi;
    public float currentSpeed = 0.0f;
    public LevelControl levelControl = null;
    public bool isGround = false;
    GameManager game;


    private void Start()
    {
        Time.timeScale = 1;
        game = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //�÷��̾�����
        if(other.tag == "Dead")
        {
            Dead();
        }

    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
            isGround = false;
    }
    public void Dead()
    {
        game.failGame();
        FailUi.SetActive(true);
    }
    void Update()
    {
        currentSpeed = levelControl.getPlayerSpeed();
        transform.Translate(new Vector3(currentSpeed * Time.deltaTime, 0.0f, 0.0f));
        
        //�÷��̾�����
        if(transform.position.y>10 || transform.position.y<-6)
        {
            Dead();
        }
    }
}
