using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleCheck : MonoBehaviour
{
    public PuttingStone putting;
    public int Win = 2; //평소에는 2다
    bool check = false;

    public int[,] checkerboard = new int[19,19];
    void Start()
    {
           
    }
    void Update()
    {
        //if (Input.GetKey(KeyCode.Mouse0))
        //{
        //    offsetX = mousePos.x >= 0 ? 0.5f : -0.5f;
        //    offsetY = mousePos.y >= 0 ? 0.5f : -0.5f;
        //    Vector3 bulidPos = new Vector3((int)mousePos.x + offsetX, (int)mousePos.y + offsetY);
        //    //건물 건설
        //    rule.checkerboard[(int)((int)mousePos.y + offsetY + 8.5f), (int)((int)mousePos.x + offsetX + 8.5f)] = BlackOrWhite + 1;
        //}
        

        if(putting.put)
        {   
            int j;
            for (int i = 4; i >= 0; i--) // 왼쪽으로 대각선(역슬래쉬)
            {
                for (j = 0; j < 5; j++)
                {
                    if ((int)((int)putting.mousePos.x + putting.offsetX + 8.5f - i + j) >= 0 && (int)((int)putting.mousePos.y + putting.offsetY + 8.5f + i - j) <= 18
                        && (int)((int)putting.mousePos.x + putting.offsetX + 8.5f - i + j) <= 18 && (int)((int)putting.mousePos.y + putting.offsetY + 8.5f + i - j) >= 0)
                    {
                        if (checkerboard[(int)((int)putting.mousePos.y + putting.offsetY + 8.5f + i - j), (int)((int)putting.mousePos.x + putting.offsetX + 8.5f - i + j)] != putting.BlackOrWhite + 1)
                        {
                            break;
                        }
                    }
                    
                    else
                    {
                        break;
                    }
                    
                }
                if(j == 5)
                {
                    Win = putting.BlackOrWhite; // Win이 0이면 흑 승, 1이면 백 승
                    Debug.Log(Win);
                    break;
                }
            }

            for (int i = 4; i >= 0; i--) //대각선(슬래쉬)
            {
                for (j = 0; j < 5; j++)
                {
                    if ((int)((int)putting.mousePos.x + putting.offsetX + 8.5f + i - j) >= 0 && (int)((int)putting.mousePos.y + putting.offsetY + 8.5f + i - j) <= 18
                        && (int)((int)putting.mousePos.x + putting.offsetX + 8.5f + i - j) <= 18 && (int)((int)putting.mousePos.y + putting.offsetY + 8.5f + i - j) >= 0)
                    {
                        if (checkerboard[(int)((int)putting.mousePos.y + putting.offsetY + 8.5f + i - j), (int)((int)putting.mousePos.x + putting.offsetX + 8.5f + i - j)] != putting.BlackOrWhite + 1)
                        {
                            break;
                        }
                    }

                    else
                    {
                        break;
                    }

                }
                if (j == 5)
                {
                    Win = putting.BlackOrWhite; // Win이 0이면 흑 승, 1이면 백 승
                    Debug.Log(Win);
                    break;
                }
            }

            for (int i = 4; i >= 0; i--) // 세로 직진
            {
                for (j = 0; j < 5; j++)
                {
                    if ((int)((int)putting.mousePos.x + putting.offsetX + 8.5f) >= 0 && (int)((int)putting.mousePos.y + putting.offsetY + 8.5f + i - j) <= 18
                        && (int)((int)putting.mousePos.x + putting.offsetX + 8.5f) <= 18 && (int)((int)putting.mousePos.y + putting.offsetY + 8.5f + i - j) >= 0)
                    {
                        if (checkerboard[(int)((int)putting.mousePos.y + putting.offsetY + 8.5f + i - j), (int)((int)putting.mousePos.x + putting.offsetX + 8.5f)] != putting.BlackOrWhite + 1)
                        {
                            break;
                        }
                    }

                    else
                    {
                        break;
                    }

                }
                if (j == 5)
                {
                    Win = putting.BlackOrWhite; // Win이 0이면 흑 승, 1이면 백 승
                    Debug.Log(Win);
                    break;
                }
            }

            for (int i = 4; i >= 0; i--) //가로 직진
            {
                for (j = 0; j < 5; j++)
                {
                    if ((int)((int)putting.mousePos.x + putting.offsetX + 8.5f - i + j) >= 0 && (int)((int)putting.mousePos.y + putting.offsetY + 8.5f) <= 18
                        && (int)((int)putting.mousePos.x + putting.offsetX + 8.5f - i + j) <= 18 && (int)((int)putting.mousePos.y + putting.offsetY + 8.5f) >= 0)
                    {
                        if (checkerboard[(int)((int)putting.mousePos.y + putting.offsetY + 8.5f), (int)((int)putting.mousePos.x + putting.offsetX + 8.5f - i + j)] != putting.BlackOrWhite + 1)
                        {
                            break;
                        }
                    }

                    else
                    {
                        break;
                    }

                }
                if (j == 5)
                {
                    Win = putting.BlackOrWhite; // Win이 0이면 흑 승, 1이면 백 승
                    Debug.Log(Win);
                    break;
                }
            }

            putting.put = false;
            putting.BlackOrWhite = putting.BlackOrWhite == 0 ? 1 : 0;
        }
        
    }
}
