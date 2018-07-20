using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_MouseMove : MonoBehaviour {

    private Rigidbody _rigidBody;
    private bool EnableDrag = true;
    private bool _isDrag = false;
    private Vector2 _oldPos;
    [Range(0, 1)]
    public float Factor = 0.01f;
    [Range(0, 1)]
    public float DecayFactor = 0.8f;
    public float BoundPower = 10.0f;

    public Vector3 StartPos = new Vector3(0, 6, 0);

	// Use this for initialization
	void Start () {
        this._rigidBody = this.gameObject.GetComponent<Rigidbody>();
        this._rigidBody.useGravity = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!this.EnableDrag)
            return;
        if(!this._isDrag && Input.GetMouseButtonDown(0)) //判断鼠标是否点中小球，若点中则可以拖动
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit) && hit.transform == this.transform)  //鼠标点中小球（原理，3D透视）
            {
                this._oldPos = (Vector2)Input.mousePosition;
                this._isDrag = true;
            }
        }

        var dir = (Vector2)Input.mousePosition - _oldPos;
        if(this._isDrag)
        {
            if(dir.magnitude >= 0.1f)
            {
                dir = dir * Factor;
                this.transform.position = this.transform.position + new Vector3(dir.x, 0, dir.y);
                this._oldPos = (Vector2)Input.mousePosition;
            }
            if(Input.GetMouseButtonUp(0))
            {
                _rigidBody.useGravity = true;
                this._isDrag = false;
            }
        }

	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Environment"))  //撞到地面
        {
            if (this.EnableDrag)  //将小球变为不可拖动，并再放置一个小球
            {
                this.EnableDrag = false;
                GameObject newBall = (GameObject)Resources.Load("Prefabs/Ball");
                Instantiate(newBall);
                newBall.transform.position = StartPos;
            }
            this._rigidBody.AddForce(new Vector3(0, BoundPower, 0), ForceMode.Impulse);
            BoundPower *= DecayFactor;
        }
    }
}
