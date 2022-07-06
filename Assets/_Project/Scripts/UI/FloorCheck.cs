using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorCheck : MonoBehaviour
{
    [SerializeField] private int _floor;
    [SerializeField] private Text _floorText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _floorText.text = _floor.ToString() + " FLOOR";
        }
    }
}
