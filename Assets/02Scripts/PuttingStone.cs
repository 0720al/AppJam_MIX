using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PuttingStone : MonoBehaviour
{
    public Vector3 mousePos;
    public float offsetX;
    public float offsetY;
    public GameObject stone_B,stone_W;
    public Camera cam;
    RaycastHit2D hit;
    int layerMask;
    public int BlackOrWhite;
    public RuleCheck rule;
    public bool putAble;
    public GameObject stone;
    public Text trunOrder;
    public Vector3 buildPos;
    public bool put;
    public Slider timeLimit;
    public float timeFlow = 30;
    public AudioClip[] skillM;
    public AudioSource au;
    public GameObject GoldGee;
    public GameObject green;
    public int blackCnt;
    public int WhiteCnt;
    public GameObject[] skillImgs;

    public GameObject[] skillGuide;
    GraphicRaycaster gr;
    GameObject pastSkillGuide;

    void Start()
    {
        gr = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<GraphicRaycaster>();
    }

    // Update is called once per frame
    void Update()
    {
        visibleGuide();
        beforeConfirmed();
        TimeLimit();
        EnterSkip();

    }
    void visibleGuide()
    {
        var ped = new PointerEventData(null);
        ped.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(ped, results);
        if (results.Count <= 0)
        {
            for (int i = 0; i < skillGuide.Length; i++)
            {
                skillGuide[i].gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }
            return;
        }
        if (pastSkillGuide != null && results[0].gameObject != pastSkillGuide)
        {
            pastSkillGuide.transform.GetChild(1).gameObject.SetActive(false);
            pastSkillGuide = null;
        }
        for (int i = 0; i < skillGuide.Length; i++)
        {
            if (results[0].gameObject == skillGuide[i])
            {
                pastSkillGuide = skillGuide[i].gameObject;

                skillGuide[i].gameObject.transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }
    void TimeLimit()
    {
        timeLimit.transform.GetChild(0).GetComponent<Image>().color = BlackOrWhite == 0 ? Color.white : Color.black;
        timeLimit.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = BlackOrWhite == 0 ? Color.black : Color.white;
        timeFlow -= Time.deltaTime;
        timeLimit.value =  1 - ((30 - timeFlow) / 30);
        if (timeLimit.value <= 0)
        {
            timeLimit.transform.GetChild(1).gameObject.SetActive(false);
            if (BlackOrWhite == 1)
            {
                SceneManager.LoadScene("BlackWin");
            }
            else if (BlackOrWhite == 0)
            {
                SceneManager.LoadScene("WhiteWin");
            }
        }
        else
            timeLimit.transform.GetChild(1).gameObject.SetActive(true);
    }
    void beforeConfirmed()
    {
        layerMask = 1 << LayerMask.NameToLayer("Stone");
        hit = Physics2D.Raycast(new Vector3(mousePos.x, mousePos.y), Vector3.forward, 100, layerMask);
        mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(mousePos);

        if (!(mousePos.x > 9.5f || mousePos.x < -8.5f || mousePos.y > 9.5f || mousePos.y < -8.5f) && Input.GetKey(KeyCode.Mouse0) && !hit)
        {
            GameObject.Destroy(stone);
            offsetX = mousePos.x >= 0 ? 0.5f : -0.5f;
            offsetY = mousePos.y >= 0 ? 0.5f : -0.5f;
            buildPos = new Vector3((int)mousePos.x + offsetX, (int)mousePos.y + offsetY);
            //건물 건설
            stone = Instantiate(BlackOrWhite == 0 ? stone_B : stone_W, buildPos, stone_B.transform.rotation);

            putAble = true;
            stone.layer = 0;
            stone.GetComponent<SpriteRenderer>().color = new Color(stone.GetComponent<SpriteRenderer>().color.r, stone.GetComponent<SpriteRenderer>().color.g, stone.GetComponent<SpriteRenderer>().color.b, 0.3f);
        }
    }
    public void posConfirmed()
    {
        if (putAble) {
            put = true;
            GameObject.Destroy(stone);
            Instantiate(BlackOrWhite == 0 ? stone_B : stone_W, buildPos, stone_B.transform.rotation);
            rule.checkerboard[(int)(buildPos.y + 8.5f), (int)(buildPos.x + 8.5f)] = BlackOrWhite + 1;
            trunOrder.text = trunOrder.text == "검은 돌" ? "흰 돌" : "검은 돌";
            trunOrder.color = BlackOrWhite == 0 ? Color.white : Color.black;
            timeFlow = 30;
            putAble = false;
            rule.isblack = BlackOrWhite;
        }

    }
    void EnterSkip()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (putAble)
            {
                put = true;
                GameObject.Destroy(stone);
                Instantiate(BlackOrWhite == 0 ? stone_B : stone_W, buildPos, stone_B.transform.rotation);
                rule.checkerboard[(int)(buildPos.y + 8.5f), (int)(buildPos.x + 8.5f)] = BlackOrWhite + 1;
                trunOrder.text = trunOrder.text == "검은 돌" ? "흰 돌" : "검은 돌";
                trunOrder.color = BlackOrWhite == 0 ? Color.white : Color.black;
                timeFlow = 30;
                putAble = false;
                rule.isblack = BlackOrWhite;
            }
        }
    }
}
