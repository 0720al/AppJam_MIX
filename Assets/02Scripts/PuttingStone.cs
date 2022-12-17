using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    GameObject stone;
    public Text trunOrder;
    public Vector3 buildPos;
    public bool put;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        beforeConfirmed();
    }
    void TimeLimit()
    {

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
            
            putAble = false;
        }

    }
}
