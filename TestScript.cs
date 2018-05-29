using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
        private Vector2 fingerDown;
        private Vector2 fingerUp;
        public bool detectSwipeOnlyAfterRelease = false;

        private float v;
        private float h;
        private float horozontalSpeed = 1.0f;
        private float verticalSpeed = 1.0f;

        public float SWIPE_THRESHOLD = 20f;

        // Update is called once per frame
        void Update()
        {

            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    fingerUp = touch.position;
                    fingerDown = touch.position;
                }

                //Detects Swipe while finger is still moving
                if (touch.phase == TouchPhase.Moved)
                {
                    if (!detectSwipeOnlyAfterRelease)
                    {
                        fingerDown = touch.position;
                        checkSwipe();
                    }
                }

                //Detects swipe after finger is released
                if (touch.phase == TouchPhase.Ended)
                {
                    fingerDown = touch.position;
                    checkSwipe();
                }
            }

            if (Input.touchCount == 1)
            {
                var touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {
                        var h = horozontalSpeed * touch.deltaPosition.y;
                        transform.Rotate(0, -v, 0);
                }
            }

    }

        void checkSwipe()
        {
            //Check if Vertical swipe
            if (VerticalMove() > SWIPE_THRESHOLD && VerticalMove() > HorizontalValMove())
            {
                //Debug.Log("Vertical");
                if (fingerDown.y - fingerUp.y > 0)//up swipe
                {
                    OnSwipeUp();
                }
                else if (fingerDown.y - fingerUp.y < 0)//Down swipe
                {
                    OnSwipeDown();
                }
                fingerUp = fingerDown;
            }

            //Check if Horizontal swipe
            else if (HorizontalValMove() > SWIPE_THRESHOLD && HorizontalValMove() > VerticalMove())
            {
                //Debug.Log("Horizontal");
                if (fingerDown.x - fingerUp.x > 0)//Right swipe
                {
                    OnSwipeRight();
                }
                else if (fingerDown.x - fingerUp.x < 0)//Left swipe
                {
                    OnSwipeLeft();
                }
                fingerUp = fingerDown;
            }

            //No Movement at-all
            else
            {
                //Debug.Log("No Swipe!");
            }
        }

        float VerticalMove()
        {
            return Mathf.Abs(fingerDown.y - fingerUp.y);
        }

        float HorizontalValMove()
        {
            return Mathf.Abs(fingerDown.x - fingerUp.x);
        }

        //////////////////////////////////CALLBACK FUNCTIONS/////////////////////////////
        void OnSwipeUp()
        {
            Debug.Log("Swipe UP");
        }

        void OnSwipeDown()
        {
            Debug.Log("Swipe Down");
        }

        void OnSwipeLeft()
        {
            Debug.Log("Swipe Left");
        }

        void OnSwipeRight()
        {
            Debug.Log("Swipe Right");
        }

}
