using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject slashPrefab;
    public Transform AttackPoint;
    public Camera cam;
    public Rigidbody2D rb;
    public float travelSpeed = 20f;
    Vector2 mousePos;
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void FixedUpdate(){
        Vector2 lookDirection = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x)*Mathf.Rad2Deg-90f;
        rb.rotation = angle;

    }

    void OnFire(){
        Shoot();
    }

    void Shoot(){
        GameObject slash = Instantiate(slashPrefab,AttackPoint.position,AttackPoint.rotation);
        Rigidbody2D rb = slash.GetComponent<Rigidbody2D>();
        rb.AddForce(AttackPoint.up * travelSpeed, ForceMode2D.Impulse);
    }
    // Update is called once per frame

}
