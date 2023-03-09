using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory : MonoBehaviour
{
    public float second;
    // Start is called before the first frame update
    void Start()
    {
        //second¬í«á©I¥sDestroyGameObject¨ç¼Æ
        Invoke("DestroyGameObject", second);
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
