using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

namespace LevelUP.Dial
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] Transform linkedDial;
        [SerializeField] private int snapRotationAmount = 25;
        [SerializeField] private float angleTolerance;
        [SerializeField] private float targetAngle;

        // Make sure only 1 of these is set to 1
        // All others should be 0
        public float xFact, yFact, zFact = 0;
        public UnityEvent onTargetAngle;

        private XRBaseInteractor interactor;
        private float startAngle;
        private bool requiresStartAngle = true;
        private bool shouldGetHandRotation = false;
        private XRGrabInteractable grabInteractor => GetComponent<XRGrabInteractable>();

        private void OnEnable()
        {
            grabInteractor.selectEntered.AddListener(GrabbedBy);
            grabInteractor.selectExited.AddListener(GrabEnd);
        }
        private void OnDisable()
        {
            grabInteractor.selectEntered.RemoveListener(GrabbedBy);
            grabInteractor.selectExited.RemoveListener(GrabEnd);
        }

        private void GrabEnd(SelectExitEventArgs arg0)
        {
            shouldGetHandRotation = false;
            requiresStartAngle = true;
        }

        private void GrabbedBy(SelectEnterEventArgs arg0)
        {
            interactor = GetComponent<XRGrabInteractable>().selectingInteractor;
            interactor.GetComponent<XRDirectInteractor>().hideControllerOnSelect = true;

            shouldGetHandRotation = true;
            startAngle = 0f;

        }

        void Update()
        {
            if (xFact != 0)
            {
                if (Mathf.Abs(linkedDial.rotation.eulerAngles.x - targetAngle) < 2)
                {
                    // Invoke Event
                    onTargetAngle.Invoke();
                }
            } else if (yFact != 0)
            {
                if (Mathf.Abs(linkedDial.rotation.eulerAngles.y - targetAngle) < 2)
                {
                    // Invoke Event
                    onTargetAngle.Invoke();

                }
            } else if (zFact != 0)
            {
                if (Mathf.Abs(linkedDial.rotation.eulerAngles.z - targetAngle) < 2)
                {
                    // Invoke Event
                    onTargetAngle.Invoke();
                }
            }

            if (shouldGetHandRotation)
            {
                var rotationAngle = GetInteractorRotation(); //gets the current controller angle
                GetRotationDistance(rotationAngle);
            }
        }

        public float GetInteractorRotation() => interactor.GetComponent<Transform>().eulerAngles.z;

        #region TheMath!
        private void GetRotationDistance(float currentAngle)
        {
            if (!requiresStartAngle)
            {
                var angleDifference = Mathf.Abs(startAngle - currentAngle);

                if (angleDifference > angleTolerance)
                {
                    if (angleDifference > 270f) //checking to see if the user has gone from 0-360 - a very tiny movement but will trigger the angletolerance
                    {
                        float angleCheck;

                        if (startAngle < currentAngle) 
                        {
                            angleCheck = CheckAngle(currentAngle, startAngle);

                            if (angleCheck < angleTolerance)
                                return;
                            else
                            {
                                RotateDialClockwise();
                                startAngle = currentAngle;
                            }
                        }
                        else if (startAngle > currentAngle) 
                        {
                            angleCheck = CheckAngle(currentAngle, startAngle);

                            if (angleCheck < angleTolerance)
                                return;
                            else
                            {
                                RotateDialAntiClockwise();
                                startAngle = currentAngle;
                            }
                        }
                    }
                    else
                    {
                        if (startAngle < currentAngle)
                        {
                            RotateDialAntiClockwise();
                            startAngle = currentAngle;
                        }
                        else if (startAngle > currentAngle)
                        {
                            RotateDialClockwise();
                            startAngle = currentAngle;
                        }
                    }
                }
            }
            else
            {
                requiresStartAngle = false;
                startAngle = currentAngle;
            }
        }
        #endregion

        private float CheckAngle(float currentAngle, float startAngle) => (360f - currentAngle) + startAngle;

        private void RotateDialAntiClockwise()
        {
            linkedDial.localEulerAngles = new Vector3(linkedDial.localEulerAngles.x + (snapRotationAmount * xFact), 
                                                      linkedDial.localEulerAngles.y + (snapRotationAmount * yFact), 
                                                      linkedDial.localEulerAngles.z + (snapRotationAmount * zFact));
        }

        private void RotateDialClockwise()
        {
            linkedDial.localEulerAngles = new Vector3(linkedDial.localEulerAngles.x - (snapRotationAmount * xFact), 
                                                      linkedDial.localEulerAngles.y - (snapRotationAmount * yFact), 
                                                      linkedDial.localEulerAngles.z - (snapRotationAmount * zFact));
        }
    }
}
