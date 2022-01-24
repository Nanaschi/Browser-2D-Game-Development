using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace PlatformerMVC.View
{
    [RequireComponent(typeof(Transform))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class LevelObjectView : MonoBehaviour
    {
        
        
       public Transform PlayerTransform { get; private set; }
       public SpriteRenderer SpriteRenderer { get; private set; }
       public Rigidbody2D _rigidbody2D { get; private set; }
       public Collider2D _collider2D { get; private set; }

       public void Initialize()
       {
           PlayerTransform = GetComponent<Transform>();
           SpriteRenderer = GetComponent<SpriteRenderer>();
       }
    }
}
