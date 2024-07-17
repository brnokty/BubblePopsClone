using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Bubble : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private CircleCollider2D _circleCollider;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private TrailRenderer _trailRenderer;

    public void SetBubble(BubbleType bubbleType)
    {
        _text.text = Mathf.Pow(2, ((int) bubbleType + 1)).ToString();
        _spriteRenderer.color = BubbleManager.Instance.GetColorForBubbleType(bubbleType);
    }

    public void ActiveRB()
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        var forge = transform.position.x > 0 ? Vector2.right : Vector2.left;
        _rigidbody2D.AddForce(forge * Random.Range(0.5f, 1.5f), ForceMode2D.Impulse);
    }
}