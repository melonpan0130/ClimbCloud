﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    Rigidbody2D rigid2D;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;

	// Use this for initialization
	void Start () {
        this.rigid2D = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
        // 점프한다.
        if (Input.GetKeyDown(KeyCode.Space)&&this.rigid2D.velocity.y==0){
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        //좌우 이동
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        //플레이어 속도
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        if (speedx < this.maxWalkSpeed)
            this.rigid2D.AddForce(transform.right * key * this.walkForce);

        // 움직이는 방향에 따라 이미지 반전
        if (key != 0)
            transform.localScale = new Vector3(key, 1, 1);

        // 플레이어가 화면 밖으로 나가면 처음부터
        if (transform.position.y < -10)
            SceneManager.LoadScene("GameScene");
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("ClearScene");
    }
}
