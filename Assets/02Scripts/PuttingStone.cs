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
    int BlackOrWhite;
    public RuleCheck rule;
    GameObject stone;
    Vector3 buildPos;
    public Text trunOrder;
    void Start()
    {
        
    }
    void Update()
    {
        beforeConfirmed();
    }
    void beforeConfirmed()
    {
        layerMask = 1 << LayerMask.NameToLayer("Stone");
        hit = Physics2D.Raycast(new Vector3(mousePos.x, mousePos.y), Vector3.forward, 100, layerMask);
        mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(mousePos);

        if (Input.GetKey(KeyCode.Mouse0) && !hit && !(mousePos.x > 9.5f || mousePos.x < -8.5 || mousePos.y > 9.5 || mousePos.y < -8.5))
        {
            GameObject.Destroy(stone);
            offsetX = mousePos.x >= 0 ? 0.5f : -0.5f;
            offsetY = mousePos.y >= 0 ? 0.5f : -0.5f;
            buildPos = new Vector3((int)mousePos.x + offsetX, (int)mousePos.y + offsetY);
            stone = Instantiate(BlackOrWhite == 0 ? stone_B : stone_W, buildPos, stone_B.transform.rotation);

            stone.GetComponent<SpriteRenderer>().color = new Color(stone.GetComponent<SpriteRenderer>().color.r, stone.GetComponent<SpriteRenderer>().color.g, stone.GetComponent<SpriteRenderer>().color.b, 0.2f);
            //BlackOrWhite = BlackOrWhite == 0 ? 1 : 0;
        }
    }
    public void posConfirmed()
    {
        GameObject.Destroy(stone);
        Instantiate(BlackOrWhite == 0 ? stone_B : stone_W, buildPos, stone_B.transform.rotation);
        rule.checkerboard[(int)(buildPos.y + 8.5f), (int)(buildPos.x + 8.5f)] = BlackOrWhite + 1;
        trunOrder.text = trunOrder.text == "Black" ? "White" : "Black";
        BlackOrWhite = BlackOrWhite == 0 ? 1 : 0;
    }
}
