using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleCheck : MonoBehaviour
{
    public PuttingStone putting;
    public int Win = 2; //��ҿ��� 2��
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
        //    //�ǹ� �Ǽ�
        //    rule.checkerboard[(int)((int)mousePos.y + offsetY + 8.5f), (int)((int)mousePos.x + offsetX + 8.5f)] = BlackOrWhite + 1;
        //}
        

        if(putting.put)
        {   
            int j;
            for (int i = 4; i >= 0; i--) // �������� �밢��(��������)
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
                    Win = putting.BlackOrWhite; // Win�� 0�̸� �� ��, 1�̸� �� ��
                    Debug.Log(Win);
                    break;
                }
            }

            for (int i = 4; i >= 0; i--) //�밢��(������)
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
                    Win = putting.BlackOrWhite; // Win�� 0�̸� �� ��, 1�̸� �� ��
                    Debug.Log(Win);
                    break;
                }
            }

            for (int i = 4; i >= 0; i--) // ���� ����
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
                    Win = putting.BlackOrWhite; // Win�� 0�̸� �� ��, 1�̸� �� ��
                    Debug.Log(Win);
                    break;
                }
            }

            for (int i = 4; i >= 0; i--) //���� ����
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
                    Win = putting.BlackOrWhite; // Win�� 0�̸� �� ��, 1�̸� �� ��
                    Debug.Log(Win);
                    break;
                }
            }

            putting.put = false;
            putting.BlackOrWhite = putting.BlackOrWhite == 0 ? 1 : 0;
        }
        
    }
}
