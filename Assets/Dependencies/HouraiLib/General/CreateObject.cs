﻿using UnityEngine;

namespace HouraiTeahouse {

    public class CreateObject : SingleActionBehaviour {

        [SerializeField] private Object _object;

        [SerializeField] private bool _copyPosiiton;

        [SerializeField] private bool _copyRotation;

        [SerializeField] private Transform _parent;

        protected override void Action() {
            if (!_object)
                return;
            Object obj = Instantiate(_object);
            if (!_copyPosiiton && !_parent)
                return;
            var go = obj as GameObject;
            var comp = obj as Component;
            Transform objTransform = null;
            if (go != null) 
                objTransform = go.transform;
            else if (comp != null)
                objTransform = comp.transform;
            if (!transform)
                return;
            objTransform.parent = _parent;
            if (_copyPosiiton)
                objTransform.position = transform.position;
            if (_copyRotation)
                objTransform.rotation = transform.rotation;
        }
    }
}
