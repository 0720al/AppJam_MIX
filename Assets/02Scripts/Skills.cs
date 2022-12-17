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

    GameObject semiC;
    bool skill1;
    bool skill2;
    bool skill3;
    bool skill4;
    bool skill5;
    Vector3 mousePos;
    RaycastHit2D hit;
    Vector3 stay;
    BoxCollider2D box;
    bool one = true;
    int layerMask;
    public GameObject UmmYang;
    public ParticleSystem Disappear;
    public PuttingStone stone;
    void Awake()
    {
        box = GetComponent<BoxCollider2D>();
        stone = GameObject.FindGameObjectWithTag("Player").GetComponent<PuttingStone>();
        rule = GameObject.FindGameObjectWithTag("GM").GetComponent<RuleCheck>();
    }

    void Update()
    {
        InputManager();
        //ShowSkills();
        StoneDetecte();
        //Rays();
        if (stone.BlackOrWhite == 0)
        {
            if (stone.blackCnt != 0)
            {
                stone.GoldGee.SetActive(true);
            }
            else
            {
                stone.GoldGee.SetActive(false);
            }

        }
        else if (stone.BlackOrWhite == 1)
        {
            if (stone.WhiteCnt != 0)
            {
                stone.GoldGee.SetActive(true);
            }
            else
            {
                stone.GoldGee.SetActive(false);
            }

        }
    }
    void InputManager()
    {
        rightMouse = Input.GetKeyDown(KeyCode.Mouse1);
        skill1 = Input.GetKeyDown(KeyCode.Alpha1);
        skill2 = Input.GetKeyDown(KeyCode.Alpha2);
        skill3 = Input.GetKeyDown(KeyCode.Alpha3);
        skill4 = Input.GetKeyDown(KeyCode.Alpha4);
        skill5 = Input.GetKeyDown(KeyCode.Alpha5);
    }
    void nextTrun()
    {
        stone.put = true;
        stone.trunOrder.text = stone.trunOrder.text == "검은 돌" ? "흰 돌" : "검은 돌";
        stone.trunOrder.color = stone.BlackOrWhite == 0 ? Color.white : Color.black;
        stone.timeFlow = 30;
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
        if (hit)
        {
            if(stone.BlackOrWhite == 0 && hit.collider.name == "BlackStone(Clone)" || stone.BlackOrWhite == 1 && hit.collider.name == "WhiteStone(Clone)")
            {
                stone.green.SetActive(true);
                stone.green.transform.position = hit.collider.transform.position;
            }

            GameObject.Destroy(stone.stone);
            if (skill1 && hit.collider.gameObject == gameObject)
            {
                RaycastHit2D skill1Hit = Physics2D.Raycast(new Vector2(hit.transform.position.x, hit.transform.position.y + 0.6f), Vector2.up, 0.1f, layerMask);
                Debug.Log(skill1Hit.collider.name);
                if (skill1Hit)
                {
                    StartCoroutine(SKillBlink(0));
                    rule.checkerboard[(int)((int)skill1Hit.collider.transform.position.y + offsetY + 8.5f), (int)((int)skill1Hit.collider.transform.position.x+ offsetX + 8.5f)] = 0;
                    skill1Hit.collider.transform.position = new Vector3(skill1Hit.collider.transform.position.x + 1, skill1Hit.collider.transform.position.y + 1, 0);
                    rule.checkerboard[(int)((int)skill1Hit.collider.transform.position.y + offsetY + 8.5f), (int)((int)skill1Hit.collider.transform.position.x + offsetX + 8.5f)] = skill1Hit.collider.name == "BlackStone(Clone)" ? 1:2;
                    stone.au.clip = stone.skillM[0];
                    stone.au.Play();
                    stone.buildPos = skill1Hit.collider.transform.position;
                    rule.isblack = skill1Hit.collider.name == "BlackStone(Clone)" ? 0 : 1;
                    nextTrun();
                }
                else
                {
                    return;
                }
            }
            if (skill2 && hit.collider.gameObject == gameObject)
            {
                RaycastHit2D skill2Hit = Physics2D.Raycast(new Vector2(hit.transform.position.x, hit.transform.position.y - 0.6f), Vector2.down, 0.1f, layerMask);
                if (skill2Hit)
                {
                    StartCoroutine(SKillBlink(1));
                    rule.checkerboard[(int)((int)skill2Hit.collider.transform.position.y +offsetY + 8.5f), (int)((int)skill2Hit.collider.transform.position.x+ offsetX + 8.5f)] = 0;
                    skill2Hit.collider.transform.position = new Vector3(skill2Hit.collider.transform.position.x, skill2Hit.collider.transform.position.y - 2, 0);
                    rule.checkerboard[(int)((int)skill2Hit.collider.transform.position.y + offsetY  + 8.5f), (int)((int)skill2Hit.collider.transform.position.x+ offsetX + 8.5f)] = skill2Hit.collider.name == "BlackStone(Clone)" ? 1 : 2;
                    stone.au.clip = stone.skillM[1];
                    stone.au.Play();
                    stone.buildPos = skill2Hit.collider.transform.position;
                    rule.isblack = skill2Hit.collider.name == "BlackStone(Clone)" ? 0 : 1;
                    nextTrun();
                }
                else
                {
                    return;
                }
                
            }
            if (skill3 && hit.collider.gameObject == gameObject)
            {
                RaycastHit2D skill3Hit = Physics2D.Raycast(new Vector2(hit.transform.position.x + 0.6f, hit.transform.position.y), Vector2.right, 0.1f, layerMask);
                if (skill3Hit)
                {
                    StartCoroutine(SKillBlink(2));
                    rule.checkerboard[(int)((int)skill3Hit.collider.transform.position.y + offsetY + 8.5f), (int)((int)skill3Hit.collider.transform.position.x + offsetX + 8.5f)] = 0;
                    skill3Hit.collider.transform.position = new Vector3(skill3Hit.collider.transform.position.x - 2, skill3Hit.collider.transform.position.y, 0);
                    rule.checkerboard[(int)((int)skill3Hit.collider.transform.position.y + offsetY + 8.5f), (int)((int)skill3Hit.collider.transform.position.x + offsetX + 8.5f)] = skill3Hit.collider.name == "BlackStone(Clone)" ? 1 : 2;
                    stone.au.clip = stone.skillM[2];
                    stone.au.Play();
                    stone.buildPos = skill3Hit.collider.transform.position;
                    rule.isblack = skill3Hit.collider.name == "BlackStone(Clone)" ? 0 : 1;
                    nextTrun();
                }
                else
                {
                    return;
                }
            }
            if (skill4 && hit.collider.gameObject == gameObject)
            {
                RaycastHit2D skill4Hit = Physics2D.Raycast(new Vector2(hit.transform.position.x , hit.transform.position.y + 0.6f), Vector2.up, 0.1f, layerMask);
                if (skill4Hit)
                {
                    StartCoroutine(SKillBlink(3));
                    rule.checkerboard[(int)((int)skill4Hit.collider.transform.position.y +offsetY + 8.5f), (int)((int)skill4Hit.collider.transform.position.x + offsetX+ 8.5f)] = skill4Hit.collider.name == "BlackStone(Clone)" ? 2 : 1;
                    skill4Hit.collider.transform.position = new Vector3(skill4Hit.collider.transform.position.x, skill4Hit.collider.transform.position.y - 1, 0);
                    hit.collider.transform.position = new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y + 1, 0);
                    rule.checkerboard[(int)((int)skill4Hit.collider.transform.position.y + offsetY + 8.5f), (int)((int)skill4Hit.collider.transform.position.x+ offsetX + 8.5f)] = skill4Hit.collider.name == "BlackStone(Clone)" ? 1 : 2;
                    stone.au.clip = stone.skillM[3];
                    stone.au.Play();
                    stone.buildPos = skill4Hit.collider.transform.position;
                    rule.isblack = skill4Hit.collider.name == "BlackStone(Clone)" ? 0 : 1;
                    nextTrun();
                    stone.buildPos = hit.collider.transform.position;
                    rule.isblack = hit.collider.name == "BlackStone(Clone)" ? 0 : 1;
                    nextTrun();
                }
                else
                {
                    return;
                }
                nextTrun();
            }
            if (skill5 && hit.collider.gameObject == gameObject && stone.blackCnt == 0 && stone.BlackOrWhite == 0 || skill5 && hit.collider.gameObject == gameObject && stone.WhiteCnt == 0 && stone.BlackOrWhite == 1)
            {
                Instantiate(UmmYang,transform.position,UmmYang.transform.rotation);
                stone.au.clip = stone.skillM[4];
                stone.au.Play();
                for (int i = 0; i < 19; i++)
                {
                    RaycastHit2D skill5Hit = Physics2D.Raycast(new Vector2(-8.5f + i, hit.transform.position.y), Vector3.forward, 100f, layerMask);
                    if (skill5Hit && skill5Hit.collider.gameObject != gameObject)
                    {
                        rule.checkerboard[(int)((int)skill5Hit.collider.transform.position.y + 8.5f), (int)((int)skill5Hit.collider.transform.position.x + 8.5f)] = 0;
                        Instantiate(Disappear.gameObject, skill5Hit.transform.position, Disappear.transform.rotation);
                        Destroy(skill5Hit.collider.gameObject);
                    }
                }
                if(stone.BlackOrWhite == 0)
                {
                    stone.blackCnt++;
                }
                else
                {
                    stone.WhiteCnt++;
                }
                stone.GoldGee.SetActive(true);
            }
        }
        else
        {
            stone.green.SetActive(false);
        }
    }
    IEnumerator SKillBlink(int i)
    {
        stone.skillImgs[i].gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        stone.skillImgs[i].gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        stone.skillImgs[i].gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        stone.skillImgs[i].gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        stone.skillImgs[i].gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        stone.skillImgs[i].gameObject.SetActive(false);
    }
}
