using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RuleCheck : MonoBehaviour
{
    public PuttingStone putting;
    public int Win = 2; //평소에는 2다
    bool check = false;

    
    public int[,] checkerboard = new int[19,19];
    public int isblack;
    void Start()
    {
           
    }
    void Update()
    {


        if(putting.put)
        {
            int j;
            for (int i = 4; i >= 0; i--) // 왼쪽으로 대각선(역슬래쉬)
            {
                for (j = 0; j < 5; j++)
                {
                    if ((int)((int)putting.buildPos.x + putting.offsetX + 8.5f - i + j) >= 0 && (int)((int)putting.buildPos.y + putting.offsetY + 8.5f + i - j) <= 18
                        && (int)((int)putting.buildPos.x + putting.offsetX + 8.5f - i + j) <= 18 && (int)((int)putting.buildPos.y + putting.offsetY + 8.5f + i - j) >= 0)
                    {
                        if (checkerboard[(int)((int)putting.buildPos.y + putting.offsetY + 8.5f + i - j), (int)((int)putting.buildPos.x + putting.offsetX + 8.5f - i + j)] != isblack + 1)
                        {
                            break;
                        }
                    }
                    
                    else
                    {
                        break;
                    }
                    
                }
                if(j >= 5)
                {
                    Debug.Log("aa");
                    Win = isblack; // Win이 0이면 흑 승, 1이면 백 승
                    if (Win == 0)
                    {
                        SceneManager.LoadScene("BlackWin");
                    }
                    else if (Win == 1)
                    {
                        SceneManager.LoadScene("WhiteWin");
                    }
                    break;
                }
            }

            for (int i = 4; i >= 0; i--) //대각선(슬래쉬)
            {
                for (j = 0; j < 5; j++)
                {
                    if ((int)((int)putting.buildPos.x + putting.offsetX + 8.5f + i - j) >= 0 && (int)((int)putting.buildPos.y + putting.offsetY + 8.5f + i - j) <= 18
                        && (int)((int)putting.buildPos.x + putting.offsetX + 8.5f + i - j) <= 18 && (int)((int)putting.buildPos.y + putting.offsetY + 8.5f + i - j) >= 0)
                    {
                        if (checkerboard[(int)((int)putting.buildPos.y + putting.offsetY + 8.5f + i - j), (int)((int)putting.buildPos.x + putting.offsetX + 8.5f + i - j)] != isblack + 1)
                        {
                            break;
                        }
                    }

                    else
                    {
                        break;
                    }

                }
                if (j >= 5)
                {
                    Win = isblack; // Win이 0이면 흑 승, 1이면 백 승
                    if (Win == 0)
                    {
                        SceneManager.LoadScene("BlackWin");
                    }
                    else if (Win == 1)
                    {
                        SceneManager.LoadScene("WhiteWin");
                    }
                    break;
                }
            }

            for (int i = 4; i >= 0; i--) // 세로 직진
            {
                for (j = 0; j < 5; j++)
                {
                    if ((int)((int)putting.buildPos.x + putting.offsetX + 8.5f) >= 0 && (int)((int)putting.buildPos.y + putting.offsetY + 8.5f + i - j) <= 18
                        && (int)((int)putting.buildPos.x + putting.offsetX + 8.5f) <= 18 && (int)((int)putting.buildPos.y + putting.offsetY + 8.5f + i - j) >= 0)
                    {
                        if (checkerboard[(int)((int)putting.buildPos.y + putting.offsetY + 8.5f + i - j), (int)((int)putting.buildPos.x + putting.offsetX + 8.5f)] != isblack + 1)
                        {
                            break;
                        }
                    }

                    else
                    {
                        break;
                    }

                }
                if (j >= 5)
                {
                    Win = isblack; // Win이 0이면 흑 승, 1이면 백 승
                    if (Win == 0)
                    {
                        SceneManager.LoadScene("BlackWin");
                    }
                    else if (Win == 1)
                    {
                        SceneManager.LoadScene("WhiteWin");
                    }
                    break;
                }
            }

            for (int i = 4; i >= 0; i--) //가로 직진
            {
                for (j = 0; j < 5; j++)
                {
                    if ((int)((int)putting.buildPos.x + putting.offsetX + 8.5f - i + j) >= 0 && (int)((int)putting.buildPos.y + putting.offsetY + 8.5f) <= 18
                        && (int)((int)putting.buildPos.x + putting.offsetX + 8.5f - i + j) <= 18 && (int)((int)putting.buildPos.y + putting.offsetY + 8.5f) >= 0)
                    {
                        if (checkerboard[(int)((int)putting.buildPos.y + putting.offsetY + 8.5f), (int)((int)putting.buildPos.x + putting.offsetX + 8.5f - i + j)] != isblack + 1)
                        {
                            break;
                        }
                    }

                    else
                    {
                        break;
                    }

                }
                if (j >= 5)
                {
                    Win = isblack; // Win이 0이면 흑 승, 1이면 백 승
                    if(Win == 0)
                    {
                        SceneManager.LoadScene("BlackWin");
                    }
                    else if(Win == 1)
                    {
                        SceneManager.LoadScene("WhiteWin");
                    }
                    break;
                }
            }

            putting.put = false;
            putting.BlackOrWhite = putting.BlackOrWhite == 0 ? 1 : 0;
        }
        
    }
}
