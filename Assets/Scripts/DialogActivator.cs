﻿using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    public string[] lines;
    private bool canActivate;

    void Start()
    {

    }

    void Update()
    {
        if (canActivate && Input.GetButtonDown("Fire1"))
        {
            DialogManager.instance.ShowDialog(lines);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canActivate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canActivate = false;
        }
    }
}
