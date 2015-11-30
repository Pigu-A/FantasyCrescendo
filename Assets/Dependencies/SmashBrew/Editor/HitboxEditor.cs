using System.Collections.Generic;
using UnityConstants;
using UnityEditor;
using UnityEngine;

namespace Hourai.SmashBrew.Editor {

    public class HitboxEditor {

        [MenuItem("GameObject/Hitbox %h", false, 5)]
        public static void AddHitbox() {
            var createdHitboxes = new List<Object>();
            foreach (var go in Selection.gameObjects) {
                if (!go)
                    continue;
                var hitbox = new GameObject("Hitbox", typeof (SphereCollider), typeof (Hitbox)) {
                    tag = Tags.Hitbox,
                    layer = Layers.Hitbox
                };
                hitbox.transform.parent = go.transform;
                hitbox.transform.localPosition = Vector3.zero;
                hitbox.transform.localEulerAngles = Vector3.zero;
                createdHitboxes.Add(hitbox);
                Undo.RegisterCreatedObjectUndo(hitbox, "Create Hitbox");
            }
            Selection.objects = createdHitboxes.ToArray();
        }

    }

}