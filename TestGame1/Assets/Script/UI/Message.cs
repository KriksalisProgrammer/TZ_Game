using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    public static Message instance { get; private set; }

    [SerializeField] private Text _textMessage;
    public List<string> _message;
    private float timer = 0;
    private string _text;
    public void Awake()
    {
        instance = this;
        _message = new List<string>();
    }
    private void LateUpdate()
    {
        timer+=Time.deltaTime;
        if(timer > 1f)
        {
            _text = null;
            foreach(var text in _message)
            {
               
                _text += text+"\n";
            }
            _message.Clear();
            _textMessage.text = _text;
            timer = 0;
        }
    }
}

