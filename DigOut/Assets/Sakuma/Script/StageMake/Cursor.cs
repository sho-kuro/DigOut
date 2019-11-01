﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    [SerializeField]
    private StageObjNumList stageObjNumList;
    [SerializeField]
    private  SerectPre serectPre;
    [SerializeField]
    private GameObject stageParent;
    [SerializeField]
    private GameObject camera;

    [SerializeField]
    GameObject selectObj;
    public float angle=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown (KeyCode.UpArrow)) { transform.Translate(new Vector3(0, 1, 0)); if (transform.position.y > camera.transform.position.y + 4) { camera.transform.Translate(new Vector3(0, 1, 0)); } }
        if (Input.GetKeyDown(KeyCode.DownArrow )) { transform.Translate(new Vector3(0, -1, 0)); if (transform.position.y < camera.transform.position.y - 4) { camera.transform.Translate(new Vector3(0, -1, 0)); } }
        if (Input.GetKeyDown(KeyCode.RightArrow )) { transform.Translate(new Vector3(1, 0, 0)); if (transform.position.x > camera.transform.position.x + 6) { camera.transform.Translate(new Vector3(1, 0, 0)); } }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { transform.Translate(new Vector3(-1, 0, 0)); if (transform.position.x < camera.transform.position.x - 6) { camera.transform.Translate(new Vector3(-1, 0, 0)); } }

        if (Input.GetKeyDown(KeyCode.C)) { angle += 90;if (angle >= 360) { angle=0; }selectObj.transform.localEulerAngles = new Vector3 (0, 0, angle); }



        if (Input.GetKeyDown(KeyCode.X))
        {

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward);
            if (hit.collider)
            {
                Destroy(hit.collider.gameObject);
            }


        }
        if (Input.GetKeyDown(KeyCode.Z))
        {

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward);
            if (!hit.collider)
            {
                GameObject test= Instantiate(stageObjNumList.PreList[serectPre.serectPreNum], new Vector3 (transform.position .x,transform.position.y,0),Quaternion .Euler (0,0,angle), stageParent.transform );
                //test.transform.localRotation;
            }


        }

    }
}
