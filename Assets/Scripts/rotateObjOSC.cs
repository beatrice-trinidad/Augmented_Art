/*
* UniOSC
* Copyright © 2014-2015 Stefan Schlupek
* All rights reserved
* info@monoflow.org
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using OSCsharp.Data;


namespace UniOSC
{

	public class rotateObjOSC : UniOSCEventTarget
	{

		#region public
		[HideInInspector]
		public Transform transformToRotate;
		public float y_RotationFactor = 90;
		#endregion

		#region public
		private Quaternion rootRot;
		private float cx, cy, cz, x;
		private Quaternion rx, ry, rz;
		private float _damping;
		#endregion


		void Awake()
		{
		}


		public override void OnEnable()
		{

			base.OnEnable();
			if (transformToRotate == null)
			{
				Transform hostTransform = GetComponent<Transform>();
				if (hostTransform != null) transformToRotate = hostTransform;
			}

			rootRot = transformToRotate.localRotation;
		}


		public override void OnOSCMessageReceived(UniOSCEventArgs args)
		{

			if (transformToRotate == null) return;
			OscMessage msg = (OscMessage)args.Packet;

			if (msg.Data.Count < 3) return;
			if (!(msg.Data[0] is System.Single)) return;

			x = (float)msg.Data[1];
			//cy = 0;//(float)args.Message.Data[2];
			//cz = -(float)msg.Data[0];

			cy *= y_RotationFactor;

            //rx = Quaternion.AngleAxis(cx, Vector3.right);
            ry = Quaternion.AngleAxis(x, Vector3.up);
            //rz = Quaternion.AngleAxis(cz, Vector3.forward);

            //transformToRotate.localRotation = rootRot * rx * ry * rz;
            //intrObjts.GetComponent<Kino.AnalogGlitch>().colorDrift = transform.rotation.y / 5;
            transform.Rotate(Vector3.up * x/100, Space.Self);

			//transformToRotate.localRotation = Quaternion.Slerp(transformToRotate.localRotation, rootRot * rx * ry * rz, _damping);

		}


	}

}