using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    bool rightMouse;
    public GameObject semiCircle;
    public RuleCheck rule;
    public float offsetX;
    public float offsetY;
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
    bool one = true;
    int layerMask;
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
            layerMask = 1 << LayerMask.NameToLayer("Stone");
            offsetX = mousePos.x >= 0 ? 0.5f : -0.5f;
            offsetY = mousePos.y >= 0 ? 0.5f : -0.5f;
            hit = Physics2D.Raycast(new Vector2((int)mousePos.x + offsetX, (int)mousePos.y + offsetY), Vector3.forward, 100, layerMask);
 
        }
        if (skill1 && hit.collider.gameObject == gameObject)
        {
            RaycastHit2D skill1Hit = Physics2D.Raycast(new Vector2(hit.transform.position.x , hit.transform.position.y + 0.6f), Vector2.up, 0.1f);
            if (skill1Hit)
            {
                skill1Hit.collider.transform.position = new Vector3(skill1Hit.collider.transform.position.x + 1, skill1Hit.collider.transform.position.y + 1, 0);
            }
        }
        if (skill2 && hit.collider.gameObject == gameObject)
        {
            RaycastHit2D skill2Hit = Physics2D.Raycast(new Vector2(hit.transform.position.x, hit.transform.position.y - 0.6f), Vector2.down, 0.1f);
            if (skill2Hit)
            {
                skill2Hit.collider.transform.position = new Vector3(skill2Hit.collider.transform.position.x, skill2Hit.collider.transform.position.y - 2, 0);
            }
        }
        if (skill3 && hit.collider.gameObject == gameObject)
        {
            RaycastHit2D skill3Hit = Physics2D.Raycast(new Vector2(hit.transform.position.x + 0.6f,hit.transform.position.y), Vector2.right, 0.1f);
            if (skill3Hit)
            {
                skill3Hit.collider.transform.position = new Vector3(skill3Hit.collider.transform.position.x - 2, skill3Hit.collider.transform.position.y, 0);
                Debug.Log(hit.collider.name);
            }   
        }
        if (skill4 && hit.collider.gameObject == gameObject)
        {
            for(int i = 0; i < 19; i++)
            {
                RaycastHit2D skill4Hit = Physics2D.Raycast(new Vector2(-8.5f + i, hit.transform.position.y), Vector3.forward, 100f);
                if (skill4Hit && skill4Hit.collider.gameObject != gameObject)
                {
                    Destroy(skill4Hit.collider.gameObject);
                }
            }
        }
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
