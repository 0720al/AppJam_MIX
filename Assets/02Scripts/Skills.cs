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
    RaycastHit hit;
    void Start()
    {
        
    }

    void Update()
    {
        InputManager();
        ShowSkills();
        CurPos();
    }
    void InputManager()
    {
        rightMouse = Input.GetKeyDown(KeyCode.Mouse1);
    }
    void ShowSkills()
    {
        Vector3 semiCirclePos = transform.position + new Vector3(0, 1.5f, 0);
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
    void CurPos()
    {
        Debug.DrawRay(transform.position, Vector2.up, Color.red);
        Debug.DrawRay(transform.position, Vector2.down, Color.red);
        Debug.DrawRay(transform.position, Vector2.left, Color.red);
        Debug.DrawRay(transform.position, Vector2.right, Color.red);
        curX = (int)((int)stone.mousePos.x + stone.offsetX + 8.5f);
        curY = (int)((int)stone.mousePos.y + stone.offsetY + 8.5f);
    }
    public void Skill1()
    {
        if(Physics.Raycast(transform.position, Vector2.up, out hit, 1))
        {
            hit.transform.position += new Vector3(0, 1, 0);
        }
        Destroy(semiCircle);
    }
    public void Skill2()
    {

    }
    public void Skill3()
    {

    }
    public void Skill4()
    {

    }
}
