using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    bool rightMouse;
    public GameObject semiCircle;
    public RuleCheck rule;
    public PuttingStone stone;
    int curX;
    int curY;
    public int cnt;
    GameObject semiC;
    public RaycastHit hit;
    bool skill1;
    bool skill2;
    bool skill3;
    bool skill4;
    public Camera cam;
    
    void Start()
    {
        
    }

    void Update()
    {
        InputManager();
        //ShowSkills();
        //Rays();
        Skill();
    }
    void InputManager()
    {
        rightMouse = Input.GetKeyDown(KeyCode.Mouse1);
        skill1 = Input.GetKeyDown(KeyCode.Alpha1);
        skill2 = Input.GetKeyDown(KeyCode.Alpha2);
        skill3 = Input.GetKeyDown(KeyCode.Alpha3);
        skill4 = Input.GetKeyDown(KeyCode.Alpha3);
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
    void Rays()
    {
        Debug.DrawRay(transform.position, Vector2.up, Color.red);
        Debug.DrawRay(transform.position, Vector2.down, Color.red);
        Debug.DrawRay(transform.position, Vector2.left, Color.red);
        Debug.DrawRay(transform.position, Vector2.right, Color.red);
        Ray selectStone = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;
        if(Physics.Raycast(selectStone, out hit, 100))
        {

        }
    }
    void Skill()
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
    }   
}
