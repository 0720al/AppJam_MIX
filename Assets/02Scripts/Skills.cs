using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    bool rightMouse;
    public GameObject semiCircle;
    public RuleCheck rule;
    public PuttingStone stone;
    public int cnt;
    GameObject semiC;
    bool skill1;
    bool skill2;
    bool skill3;
    bool skill4;
    Vector3 mousePos;
    RaycastHit2D hit;
    Vector3 stay;
    BoxCollider2D box;

    void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        InputManager();
        //ShowSkills();
        StoneDetecte();
        //Rays();
    }
    void InputManager()
    {
        rightMouse = Input.GetKeyDown(KeyCode.Mouse1);
        skill1 = Input.GetKeyDown(KeyCode.Alpha1);
        skill2 = Input.GetKeyDown(KeyCode.Alpha2);
        skill3 = Input.GetKeyDown(KeyCode.Alpha3);
        skill4 = Input.GetKeyDown(KeyCode.Alpha4);
    }
    void ShowSkills()
    {
        Vector3 semiCirclePos = transform.position + new Vector3(0, 1f, 0);
        if (cnt == 0)
        {
            if (rightMouse)
            {
                semiC = Instantiate(semiCircle, semiCirclePos, transform.rotation);
                cnt++;
            }
        }
        else if (cnt == 1)
        {
            if (rightMouse)
            {
                Destroy(semiC);
                cnt--;
            }
        }
    }
    void StoneDetecte()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            hit = Physics2D.Raycast(mousePos, transform.forward, 15);
            Debug.DrawRay(mousePos, transform.forward * 10, Color.red, 0.3f);
            if(hit)
            {
                //hit.transform.GetComponent<SpriteRenderer>().color = Color.green;
                Debug.Log("hit " + hit.transform.position);

            }
        }
        if (skill1)
        {
            Debug.Log("hit.transform.position : " + hit.transform.position);
            RaycastHit2D skill1Hit = Physics2D.Raycast(hit.transform.position, Vector2.up, 1);
            if (skill1Hit)
            {
                skill1Hit.collider.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y + 1, 0);
                Debug.Log("skill1Hit.collider.transform.position : " + skill1Hit.collider.transform.position);
            }
        }
        if (skill2)
        {
            RaycastHit2D skill2Hit = Physics2D.Raycast(transform.position, Vector2.down, 1);
            Debug.Log("2 " + hit.transform.position);
            if (skill2Hit)
            {
                skill2Hit.collider.transform.position += new Vector3(0, -1, 0);
                Debug.Log("222 " + skill2Hit.transform.position);
            }
        }
        if (skill3)
        {
            RaycastHit2D skill3Hit = Physics2D.Raycast(transform.position, Vector2.right, 1);
            Debug.Log("3 " + hit.transform.position);
            if (skill3Hit)
            {
                skill3Hit.collider.transform.position += new Vector3(-2, 0, 0);
                Debug.Log("333 " + skill3Hit.transform.position);
            }
        }
        if (skill4)
        {
            RaycastHit2D skill4Hit = Physics2D.Raycast(transform.position, Vector2.up, 1);
            Debug.Log("4 " + hit.transform.position);
            if (skill4Hit)
            {
                skill4Hit.collider.transform.position += new Vector3(0, -2, 0);
                Debug.Log("444 " + skill4Hit.transform.position);
            }
        }
    }
    void Rays()
    {
        Debug.DrawRay(transform.position, Vector2.up, Color.red);
        Debug.DrawRay(transform.position, Vector2.down, Color.red);
        Debug.DrawRay(transform.position, Vector2.left, Color.red);
        Debug.DrawRay(transform.position, Vector2.right, Color.red);
    }
    /*void Skill()
    {
        if(skill1)
        {
            Debug.Log("1");
            if(Physics.Raycast(transform.position, Vector2.up, out hit, 1))
            {
                hit.collider.transform.position += new Vector3(0, 1, 0);
                Debug.Log("111");
            }
        }
        if(skill2)
        {
            Debug.Log("2");
            if(Physics.Raycast(transform.position, Vector2.down, out hit, 1))
            {
                hit.collider.transform.position += new Vector3(0, -1, 0);
                Debug.Log("222");
            }    
        }
        if(skill3)
        {
            Debug.Log("3");
            if(Physics.Raycast(transform.position, Vector2.right, out hit, 1))
            {
                hit.collider.transform.position += new Vector3(-2, 0, 0);
                Debug.Log("333");
            }
        }
        if (skill4)
        {
            Debug.Log("4");
            if (Physics.Raycast(transform.position, Vector2.up, out hit, 1))
            {
                hit.collider.transform.position += new Vector3(0, -2, 0);
                Debug.Log("444");
            }
        }
    }*/
}
