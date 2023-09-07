using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RuleCheck : MonoBehaviour
{
    public PuttingStone putting;
    public int Win = 2; //��ҿ��� 2��
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
            for (int i = 4; i >= 0; i--) // �������� �밢��(��������)
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
                    Win = isblack; // Win�� 0�̸� �� ��, 1�̸� �� ��
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

            for (int i = 4; i >= 0; i--) //�밢��(������)
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
                    Win = isblack; // Win�� 0�̸� �� ��, 1�̸� �� ��
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

            for (int i = 4; i >= 0; i--) // ���� ����
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
                    Win = isblack; // Win�� 0�̸� �� ��, 1�̸� �� ��
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

            for (int i = 4; i >= 0; i--) //���� ����
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
                    Win = isblack; // Win�� 0�̸� �� ��, 1�̸� �� ��
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
