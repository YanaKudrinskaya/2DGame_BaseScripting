using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndPoint : MonoBehaviour
{
   
    [SerializeField] private UnityEvent _reached;
    

    public event UnityAction Reached
    {
        add => _reached.AddListener(value);
        remove => _reached.RemoveListener(value);
    }
    public bool IsReached { get; private set; }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsReached)
        {
            return;
        }
        if(collision.TryGetComponent<Player>(out Player player))
        {
            IsReached = true;
            _reached.Invoke();
        }
    }
}
