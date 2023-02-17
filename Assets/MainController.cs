using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class MainController : MonoBehaviour
{
    /// <summary>
    /// 第一题
    /// </summary>
    public Transform startPos; // 起始点
    public Transform endPos;   // 终止点
    public float moveTime = 3.0f; // 移动时间
    public bool loop = true; // 是否循环

    public enum EaseType
    {
        Linear,
        EaseIn,
        EaseOut,
    }
    
    public EaseType easeType = EaseType.Linear;

    IEnumerator Move(GameObject gameObject, Vector3 begin, Vector3 end, float time,bool pingpong, EaseType ease)
    {
        float curTime = 0;
        while (curTime < time)
        {
            float t = curTime / time;
            if (ease == EaseType.EaseIn)
            {
                t = Mathf.Sin((t - 1) * Mathf.PI * 0.5f) + 1;
            }
            else if (ease == EaseType.EaseOut)
            {
                t = Mathf.Sin(t * Mathf.PI * 0.5f);
            }
            //easeInOut暂时没有找到
            
            
            //t（0，1）；
            gameObject.transform.position = Vector3.Lerp(begin, end, t);
            curTime += Time.deltaTime;
            yield return null;
        }
        
        gameObject.transform.position = end;
        //停顿一秒，方便观察效果。
        yield return new WaitForSeconds(1f);   
        
        if (pingpong)
        {
            StartCoroutine(Move(gameObject, end, begin, time, pingpong, ease));
        }
    }

    public void StartMove()
    {
        StartCoroutine(Move(gameObject, startPos.position, endPos.position, moveTime, loop, easeType));
    }
    
    public void Start()
    {
        StartMove();
         List<int?> nodes = new List<int?> { 2,
                                            11, 23,
                                            10, 15, 7, 14,
                                            null, null, null, null,null,12, null, null,
                                            null, null, null, null,null, null, null, null,null, null, 13, null,
         };        
         Tree tree = new Tree(nodes);
         List<int> list = tree.mostLeftNode();
         
         for (int i = 0; i < list.Count; i++)
         {
             Debug.Log(list[i]);
         }
         
    }
    
    
    
}
