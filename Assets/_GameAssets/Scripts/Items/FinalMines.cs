using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FinalMines : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float screenY;
    void OnEnable()
    {
        StartCoroutine(MineTranslate());
    }
    IEnumerator MineTranslate()
    {
        while (transform.position.y > screenY)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            yield return null;
        }
        FinalLevelStageController.Instance.OnStageCleared();
    }
}
