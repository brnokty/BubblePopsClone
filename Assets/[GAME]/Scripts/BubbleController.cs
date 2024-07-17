using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using DG.Tweening;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    [SerializeField] private Bubble _bubble;
    [SerializeField] private Transform bubbleParent;
    [SerializeField] private float lastLineYpos = 0f;

    private List<Bubble> bubbleList = new List<Bubble>();

    void Start()
    {
        CreateBubblesLine(50);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            LineDown();
        }
    }


    public void CreateBubblesLine(int lineCount)
    {
        for (int i = 0; i < lineCount; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                var bubble = Instantiate(_bubble, bubbleParent);
                bubbleList.Add(bubble);
                bubble.transform.localPosition =
                    new Vector3(j * 0.75f - 2.03f + (i % 2 == 0 ? 0.375f : 0), lastLineYpos, 0f);
            }

            lastLineYpos += 0.68f;
        }
    }

    public void LineDown()
    {
        bubbleParent.DOMoveY(bubbleParent.localPosition.y - 0.68f, 0.1f);
        ActiveFirstLine();
    }


    public void ActiveFirstLine()
    {
        for (int j = 0; j < 6; j++)
        {
            var bubble = bubbleList[0];
            bubble.ActiveRB();
            bubbleList.RemoveAt(0);
        }
    }
}