using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuttingStone : MonoBehaviour
{
    Vector3 mousePos;
    float offsetX;
    float offsetY;
    public GameObject stone_B,stone_W;
    public Camera cam;
    RaycastHit2D hit;
    int layerMask;
    int BlackOrWhite;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
            GameObject structure = Instantiate(BlackOrWhite == 0? stone_B : stone_W, bulidPos, stone_B.transform.rotation);
            BlackOrWhite = BlackOrWhite == 0 ? 1 : 0;
        }
    }
}
