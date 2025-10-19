using System;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log($"On Awake + {gameObject.name}");
    }

    private void OnEnable()
    {
        Debug.Log($"On OnEnable + {gameObject.name}");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log($"On Start + {gameObject.name}");
    }

    private void FixedUpdate()
    {
        Debug.Log($"On FixedUpdate + {gameObject.name}");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"On Update + {gameObject.name}");
    }

    private void LateUpdate()
    {
        Debug.Log($"On LateUpdate + {gameObject.name}");
    }

    private void OnApplicationQuit()
    {
        Debug.Log($"On ApplicationQuit + {gameObject.name}");
    }

    private void OnDisable()
    {
        Debug.Log($"On Disable + {gameObject.name}");
    }

    private void OnDestroy()
    {
        Debug.Log($"On Destroy + {gameObject.name}");
    }
}
