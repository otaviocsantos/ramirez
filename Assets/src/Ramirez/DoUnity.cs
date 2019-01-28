using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ramirez
{
    public class DoUnity
    {
        /// <summary>
        /// Try to GetComponent from target, if none is found then AddComponent desired and return
        /// </summary>
        /// <typeparam name="T">Component to be Get or Added</typeparam>
        /// <param name="fromGameObject">target</param>
        /// <returns></returns>
        public static T ProduceComponent<T>(GameObject fromGameObject) where T : Component
        {
            if (fromGameObject == null)
                throw new System.Exception("Cannot ProduceComponent in a null GameObject");
            T result = fromGameObject.GetComponent<T>() as T;
            if (result == null)
                result = fromGameObject.AddComponent<T>() as T;

            return result;
        }

        /// <summary>
        /// Search for a Component "withName" inside "fromGameObject".
        /// </summary>
        /// <param name="fromGameObject"></param>
        /// <param name="withName"></param>
        /// <returns></returns>
        public static T GetComponent<T>(GameObject fromGameObject, string withName) where T : class
        {
            T result = null;
            GameObject go = GetGameObject(fromGameObject, withName);
            if (go != null)
            {
                result = go.GetComponent<T>() as T;
            }
            return result;
        }

        /// <summary>
        /// Does a in depth search for a Component by its name.
        /// </summary>
        /// <param name="withName"></param>
        /// <returns></returns>
        public static T GetComponent<T>(string withName) where T : class
        {
            T result = null;
            GameObject go = GetGameObject(withName);
            if (go != null)
            {
                result = go.GetComponent<T>() as T;
            }
            return result;
        }

        /// <summary>
        /// Does a in depth search for a GameObject by its name.
        /// </summary>
        /// <param name="withName"></param>
        /// <returns></returns>
        public static GameObject GetGameObject(string withName)
        {
            GameObject result = null;
            Transform[] xform = UnityEngine.Object.FindObjectsOfType<Transform>();
            foreach (Transform t in xform)
            {
                GameObject rootObject = t.gameObject;
                result = GetGameObject(rootObject, withName);
                if (result != null)
                {
                    return result;
                }
            }
            return result;
        }

        /// <summary>
        /// Search for a GameObject "withName" inside "fromGameObject".
        /// </summary>
        /// <param name="fromGameObject"></param>
        /// <param name="withName"></param>
        /// <returns></returns>
        public static GameObject GetGameObject(GameObject fromGameObject, string withName)
        {
            if (fromGameObject != null)
            {
                Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform>(true);
                foreach (Transform t in ts)
                {
                    if (t.gameObject.name == withName) return t.gameObject;
                }
                return null;
            }
            else
                throw new System.Exception("Cannot get component of an empty Object");
        }

        /// <summary>
        /// Search for a Transform "withName" inside "fromGameObject".
        /// </summary>
        /// <param name="fromGameObject"></param>
        /// <param name="withName"></param>
        /// <returns></returns>
        public static Transform GetTransform(GameObject fromGameObject, string withName)
        {
            if (fromGameObject != null)
            {
                Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform>(true);
                foreach (Transform t in ts)
                {
                    if (t.name == withName) return t;
                }
                return null;
            }
            else
                throw new System.Exception("Cannot get component of an empty Object");
        }

        /// <summary>
        /// Copy position, localPosition, rotation, localRotation and localScale, from one GameObject to antother
        /// </summary>
        /// <param name="_from"></param>
        /// <param name="_to"></param>
        public static void CopyModifiers(GameObject _from, GameObject _to)
        {
            _to.transform.position = _from.transform.position;
            _to.transform.localPosition = _from.transform.localPosition;
            _to.transform.rotation = _from.transform.rotation;
            _to.transform.localRotation = _from.transform.localRotation;
            _to.transform.localScale = _from.transform.localScale;
        }

        /// <summary>
        /// Get greatest value of a Vector3
        /// </summary>
        /// <param name="dim"></param>
        /// <returns></returns>
        public static float GetGreatest(Vector3 dim)
        {
            return Mathf.Max(dim.x, Mathf.Max(dim.y, dim.z));
        }

        /// <summary>
        /// Get smallest value of a Vector3
        /// </summary>
        /// <param name="dim"></param>
        /// <returns></returns>
        public static float GetSmallest(Vector3 dim)
        {
            return Mathf.Min(dim.x, Mathf.Min(dim.y, dim.z));
        }

        /// <summary>
        /// Render target empty by remove all its children
        /// </summary>
        /// <param name="go"></param>
        public static void RemoveChildren(GameObject go)
        {
            if (go != null)
            {
                foreach (Transform t in go.transform)
                {
                    GameObject.Destroy(t.gameObject);
                }
            }
        }

        /// <summary>
        /// Disables every child in a gameobject
        /// </summary>
        /// <param name="go">Parent Game Object</param>
        public static void HideChildren(GameObject go)
        {
            ToggleChildren(go, false);
        }

        /// <summary>
        /// Disables every child in a gameobject
        /// </summary>
        /// <param name="go">Parent Game Object</param>
        public static void ShowChildren(GameObject go)
        {
            ToggleChildren(go, true);
        }

        /*
        Search up hierarchy for a specific named GameObject
        starting from "go" parameter, if "maxIterations" 
        is undefined maxIterations will continue until root element is reached
        */
        /// <param name="fromGameObject"></param>
        /// <param name="withName"></param>
        public static GameObject GetUpGameObject(GameObject fromGameObject, string withName, int maxIterations = default(int))
        {
            if (fromGameObject.name == withName)
            {
                return fromGameObject;
            }

            if (fromGameObject.transform.parent)
            {
                if (maxIterations == default(int))
                {
                    return GetUpGameObject(fromGameObject.transform.parent.gameObject, withName, maxIterations);
                }
                else if (maxIterations > 0)
                {
                    return GetUpGameObject(fromGameObject.transform.parent.gameObject, withName, --maxIterations);
                }
            }

            return null;

        }

        /// <summary>
        /// Does an upward search for a Component by its name.
        /// </summary>
        /// <param name="fromGameObject"></param>
        /// <param name="withName"></param>
        /// <returns></returns>
        public static T GetUpComponent<T>(GameObject fromGameObject, string withName, int maxIterations = default(int)) where T : class
        {
            T result = null;
            GameObject go = GetUpGameObject(fromGameObject, withName);
            if (go != null)
            {
                result = go.GetComponent<T>() as T;
            }
            return result;
        }



        public static void ToggleChildren(GameObject go, bool state = true)
        {
            if (go != null)
            {
                if (go.GetComponentInChildren<Renderer>())
                {
                    Renderer[] lChildRenderers = go.GetComponentsInChildren<Renderer>();
                    foreach (Renderer lRenderer in lChildRenderers)
                    {
                        lRenderer.enabled = state;
                    }
                }
            }
            else
            {
                throw new System.Exception("ToggleChildren GameObject cannot be empty");
            }
        }

    }
}