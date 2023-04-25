using System.Collections;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // For Gettting a single touch
        // if(Input.touchCount > 0){
        //     Touch touch = Input.GetTouch(0);
        //     Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        //     touchPosition.z = 0f;
        //     transform.position = touchPosition;
        // }

        // for getting touches with multiples fingers
        for (int i = 0; i < Input.touchCount; i++)
        {
           Vector3 touchPosition =  Camera.main.ScreenToWorldPoint(Input.touches[i].position);
           touchPosition.z = 0f;
           transform.position = touchPosition;
        }
    }
}
