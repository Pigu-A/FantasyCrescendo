using UnityEditor;
using UnityEngine;

namespace Hourai.SmashBrew.Editor {

    public class HitboxEditor {

        [MenuItem("Hourai/Hitbox/Add")]
        public static void AddHitbox() {
            foreach (var go in Selection.gameObjects) {
                if (!go)
                    continue;
                var hitbox = new GameObject("Hitbox", typeof(SphereCollider), typeof(Hitbox));
                hitbox.AddComponent<Hitbox>();
                hitbox.transform.parent = go.transform;
                hitbox.transform.localPosition = Vector3.zero;
                hitbox.transform.rotation = Quaternion.identity;
                Selection.activeGameObject = hitbox;
            }
        }

    }

}