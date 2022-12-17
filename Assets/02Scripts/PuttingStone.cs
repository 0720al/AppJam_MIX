using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public bool put;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
=======
        beforeConfirmed();
    }
    void TimeLimit()
    {

    }
    void beforeConfirmed()
    {
>>>>>>> Stashed changes
        layerMask = 1 << LayerMask.NameToLayer("Stone");
        hit = Physics2D.Raycast(new Vector3(mousePos.x, mousePos.y), Vector3.forward, 100, layerMask);
        mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(mousePos);

        if (Input.GetKey(KeyCode.Mouse0) && !hit)
        {
            offsetX = mousePos.x >= 0 ? 0.5f : -0.5f;
            offsetY = mousePos.y >= 0 ? 0.5f : -0.5f;
            Vector3 bulidPos = new Vector3((int)mousePos.x + offsetX, (int)mousePos.y + offsetY);
            //건물 건설
            GameObject structure = Instantiate(BlackOrWhite == 0 ? stone_B : stone_W, bulidPos, stone_B.transform.rotation);
            rule.checkerboard[(int)((int)mousePos.y + offsetY + 8.5f),(int)((int)mousePos.x + offsetX + 8.5f)] = BlackOrWhite + 1;
            put = true;
        }
    }
<<<<<<< Updated upstream
=======
    public void posConfirmed()
    {
        if (putAble) {
            GameObject.Destroy(stone);
            Instantiate(BlackOrWhite == 0 ? stone_B : stone_W, buildPos, stone_B.transform.rotation);
            rule.checkerboard[(int)(buildPos.y + 8.5f), (int)(buildPos.x + 8.5f)] = BlackOrWhite + 1;
            trunOrder.text = trunOrder.text == "검은 돌" ? "흰 돌" : "검은 돌";
            BlackOrWhite = BlackOrWhite == 0 ? 1 : 0;
            putAble = false;
        }

    }
>>>>>>> Stashed changes
}
