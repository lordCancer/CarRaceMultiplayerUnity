using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Duge
{
    [System.Serializable]
    public class AxleInfo
    {
        public WheelCollider leftWheel;
        public WheelCollider rightWheel;
        public bool motor;
        public bool steering;
    }

    public class CarController : NetworkBehaviour
    {
        public List<AxleInfo> axleInfos;
        public float maxMotorTorque;
        public float maxSteeringAngle;
        public GameObject localCamera;
        public Material redMat;
        public Material blackMat;
        private NetworkIdentity objId;

        private void Start()
        {
            if (!isLocalPlayer)
            {
                localCamera.SetActive(false);
                return;
            }
            Camera.main.gameObject.SetActive(false);
            CmdChangeMaterial();
        }

        private void FixedUpdate()
        {
            if (!isLocalPlayer)
                return;

            float motor = maxMotorTorque * -Input.GetAxis("Vertical");
            float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

            foreach (AxleInfo axleInfo in axleInfos)
            {
                if (axleInfo.steering)
                {
                    axleInfo.leftWheel.steerAngle = steering;
                    axleInfo.rightWheel.steerAngle = steering;
                }
                if (axleInfo.motor)
                {
                    axleInfo.leftWheel.motorTorque = motor;
                    axleInfo.rightWheel.motorTorque = motor;
                }
                ApplyLocalPositionToVisuals(axleInfo.leftWheel);
                ApplyLocalPositionToVisuals(axleInfo.rightWheel);
            }


        }

        private void ApplyLocalPositionToVisuals(WheelCollider collider)
        {
            if (collider.transform.childCount == 0)
            {
                return;
            }

            Transform visualWheel = collider.transform.GetChild(0);

            Vector3 position;
            Quaternion rotation;
            collider.GetWorldPose(out position, out rotation);

            visualWheel.transform.position = position;
            visualWheel.transform.rotation = rotation;
        }

        [Command]
        private void CmdChangeMaterial()
        {
            objId = GetComponent<NetworkIdentity>();
            //objId.AssignClientAuthority(connectionToClient);
            RpcChangeMaterial();
            //objId.RemoveClientAuthority(connectionToClient);
        }

        [ClientRpc]
        private void RpcChangeMaterial()
        {
            switch(FindObjectOfType<NetworkController>().CarType)
            {
                case CarType.red:
                    transform.GetChild(0).GetComponent<Renderer>().material.color = redMat.color;
                    break;
                case CarType.black:
                    transform.GetChild(0).GetComponent<Renderer>().material.color = blackMat.color;
                    break;
            }
        }
    }
}
