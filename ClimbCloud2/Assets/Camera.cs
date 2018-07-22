using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    GameObject palyer;

	// Use this for initialization
	void Start () {
        this.palyer = GameObject.Find("cat");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPos = this.palyer.transform.position;
        transform.position = new Vector3(
            transform.position.x, playerPos.y, transform.position.z);
	}
}
