using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace KevinCastejon.MissingFeatures.MissingWindows
{
    internal class TransformRandomizerWindow : EditorWindow
    {
        internal enum RandomizerViewType
        {
            POSITION,
            ROTATION,
            SCALE,
        }
        private SerializedObject _settings;

        [SerializeField] private SerializedProperty _positionFolded;
        [SerializeField] private SerializedProperty _pointReferenceTypePos;
        [SerializeField] private SerializedProperty _usePosX;
        [SerializeField] private SerializedProperty _usePosY;
        [SerializeField] private SerializedProperty _usePosZ;
        [SerializeField] private SerializedProperty _posXRange;
        [SerializeField] private SerializedProperty _posYRange;
        [SerializeField] private SerializedProperty _posZRange;
        [SerializeField] private SerializedProperty _localPos;
        [SerializeField] private SerializedProperty _usePosRadius;
        [SerializeField] private SerializedProperty _posRadius;

        [SerializeField] private SerializedProperty _rotationFolded;
        [SerializeField] private SerializedProperty _useRotX;
        [SerializeField] private SerializedProperty _useRotY;
        [SerializeField] private SerializedProperty _useRotZ;
        [SerializeField] private SerializedProperty _rotXRange;
        [SerializeField] private SerializedProperty _rotYRange;
        [SerializeField] private SerializedProperty _rotZRange;
        [SerializeField] private SerializedProperty _localRot;
        [SerializeField] private SerializedProperty _additiveRotation;

        [SerializeField] private SerializedProperty _scaleFolded;
        [SerializeField] private SerializedProperty _useScaleX;
        [SerializeField] private SerializedProperty _useScaleY;
        [SerializeField] private SerializedProperty _useScaleZ;
        [SerializeField] private SerializedProperty _scaleXRange;
        [SerializeField] private SerializedProperty _scaleYRange;
        [SerializeField] private SerializedProperty _scaleZRange;
        [SerializeField] private SerializedProperty _uniformScaleRange;
        [SerializeField] private SerializedProperty _uniformScale;
        [SerializeField] private SerializedProperty _additiveScale;

        private RandomizerViewType _viewType;

        List<GameObject> _selections = new List<GameObject>();

        [MenuItem("Window/Unity Missing Windows/Transform Randomizer Window", false, 222)]
        internal static void OpenWindow()
        {
            EditorWindow window = GetWindow(typeof(TransformRandomizerWindow));
            window.titleContent = new GUIContent("Transform Randomizer");
        }

        private void OnEnable()
        {
            _settings = new SerializedObject(AssetDatabase.LoadAssetAtPath<TransformRandomizerSettings>(AssetDatabase.GUIDToAssetPath(AssetDatabase.FindAssets(string.Format("t:{0}", typeof(TransformRandomizerSettings)))[0])));

            _positionFolded = _settings.FindProperty("_positionFolded");
            _pointReferenceTypePos = _settings.FindProperty("_pointReferenceTypePos");
            _usePosX = _settings.FindProperty("_usePosX");
            _usePosY = _settings.FindProperty("_usePosY");
            _usePosZ = _settings.FindProperty("_usePosZ");
            _posXRange = _settings.FindProperty("_posXRange");
            _posYRange = _settings.FindProperty("_posYRange");
            _posZRange = _settings.FindProperty("_posZRange");
            _localPos = _settings.FindProperty("_localPos");
            _usePosRadius = _settings.FindProperty("_usePosRadius");
            _posRadius = _settings.FindProperty("_posRadius");

            _rotationFolded = _settings.FindProperty("_rotationFolded");
            _useRotX = _settings.FindProperty("_useRotX");
            _useRotY = _settings.FindProperty("_useRotY");
            _useRotZ = _settings.FindProperty("_useRotZ");
            _rotXRange = _settings.FindProperty("_rotXRange");
            _rotYRange = _settings.FindProperty("_rotYRange");
            _rotZRange = _settings.FindProperty("_rotZRange");
            _localRot = _settings.FindProperty("_localRot");
            _additiveRotation = _settings.FindProperty("_additiveRotation");

            _scaleFolded = _settings.FindProperty("_scaleFolded");
            _useScaleX = _settings.FindProperty("_useScaleX");
            _useScaleY = _settings.FindProperty("_useScaleY");
            _useScaleZ = _settings.FindProperty("_useScaleZ");
            _scaleXRange = _settings.FindProperty("_scaleXRange");
            _scaleYRange = _settings.FindProperty("_scaleYRange");
            _scaleZRange = _settings.FindProperty("_scaleZRange");
            _uniformScaleRange = _settings.FindProperty("_uniformScaleRange");
            _uniformScale = _settings.FindProperty("_uniformScale");
            _additiveScale = _settings.FindProperty("_additiveScale");
        }
        private void OnGUI()
        {
            _selections = Selection.objects.Where((x) => x.GetType() == typeof(GameObject)).Select((x) => (GameObject)x).Where((x) => x.scene.IsValid()).ToList();
            _settings.Update();
            EditorGUI.BeginChangeCheck();
            DrawPositionSettings();
            GUILayout.Space(10f);
            DrawRotationSettings();
            GUILayout.Space(10f);
            DrawScaleSettings();
            GUILayout.Space(10f);
            if (EditorGUI.EndChangeCheck())
            {
                SceneView.RepaintAll();
            }
            GUILine(1);
            GUILayout.Space(10f);
            DrawPositionButton();
            GUILayout.Space(10f);
            DrawRotationButton();
            GUILayout.Space(10f);
            DrawScaleButton();
            EditorGUI.EndDisabledGroup();
            _settings.ApplyModifiedProperties();
        }
        private void OnFocus()
        {
            // Remove delegate listener if it has previously
            // been assigned.
            SceneView.duringSceneGui -= this.OnSceneGUI;
            // Add (or re-add) the delegate.
            SceneView.duringSceneGui += this.OnSceneGUI;
        }
        private void OnDestroy()
        {
            // When the window is destroyed, remove the delegate
            // so that it will no longer do any drawing.
            SceneView.duringSceneGui -= this.OnSceneGUI;
        }

        private void OnSceneGUI(SceneView sceneView)
        {
            if (_selections.Count == 0)
            {
                return;
            }
            switch (_viewType)
            {
                case RandomizerViewType.POSITION:
                    DrawScenePositionHandles(sceneView.camera);
                    break;
                case RandomizerViewType.ROTATION:
                    DrawSceneRotationHandles();
                    break;
                case RandomizerViewType.SCALE:
                    DrawSceneScaleHandles();
                    break;
            }
        }
        private void DrawScenePositionHandles(Camera camera)
        {
            Vector3 pointRef = Vector3.zero;
            if ((PointReferenceType)_pointReferenceTypePos.enumValueIndex == PointReferenceType.GROUP)
            {
                pointRef = GetGroupPivot();
            }

            if ((PointReferenceType)_pointReferenceTypePos.enumValueIndex != PointReferenceType.SELF)
            {
                GameObject go = _selections[0] as GameObject;
                if (go == null)
                {
                    Debug.LogWarning("TransformRandomizer is usable with GameObjects only");
                    return;
                }
                DrawPositionHandles(camera, go, pointRef);
            }
            else
            {
                foreach (Object obj in _selections)
                {
                    GameObject go = obj as GameObject;
                    if (go == null)
                    {
                        Debug.LogWarning("TransformRandomizer is usable with GameObjects only");
                        continue;
                    }
                    DrawPositionHandles(camera, go, pointRef);
                }
            }
        }
        private void DrawPositionHandles(Camera camera, GameObject go, Vector3 pointRef)
        {
            if ((PointReferenceType)_pointReferenceTypePos.enumValueIndex == PointReferenceType.SELF)
            {
                pointRef = GetObjectPivot(go);
            }

            Vector3 refPoint = pointRef;
            float width = _usePosRadius.boolValue ? _posRadius.floatValue * 2f : _posXRange.vector2Value.y - _posXRange.vector2Value.x;
            refPoint.x += _posXRange.vector2Value.x + (width * 0.5f);
            float height = _usePosRadius.boolValue ? _posRadius.floatValue * 2f : _posYRange.vector2Value.y - _posYRange.vector2Value.x;
            refPoint.y += _posYRange.vector2Value.x + (height * 0.5f);
            float depth = _usePosRadius.boolValue ? _posRadius.floatValue * 2f : _posZRange.vector2Value.y - _posZRange.vector2Value.x;
            refPoint.z += _posZRange.vector2Value.x + (depth * 0.5f);
            Vector3 size = Vector3.zero;

            if (_usePosX.boolValue)
            {
                size.x = width;
            }
            if (_usePosY.boolValue)
            {
                size.y = height;
            }
            if (_usePosZ.boolValue)
            {
                size.z = depth;
            }
            if (_localPos.boolValue)
            {
                size = go.transform.TransformDirection(size);
            }
            Handles.color = Color.green;

            if (_usePosRadius.boolValue)
            {
                Vector3 position = pointRef;

                if (_usePosX.boolValue && _usePosY.boolValue && _usePosZ.boolValue)
                {
                    Handles.DrawWireDisc(position, Vector3.right, _posRadius.floatValue);
                    Handles.DrawWireDisc(position, Vector3.up, _posRadius.floatValue);
                    Handles.DrawWireDisc(position, Vector3.forward, _posRadius.floatValue);

                    if (camera.orthographic)
                    {
                        Vector3 normal = position - Handles.inverseMatrix.MultiplyVector(camera.transform.forward);
                        float sqrMagnitude = normal.sqrMagnitude;
                        float num0 = _posRadius.floatValue * _posRadius.floatValue;
                        Handles.DrawWireDisc(position - num0 * normal / sqrMagnitude, normal, _posRadius.floatValue);
                    }
                    else
                    {
                        Vector3 normal = position - Handles.inverseMatrix.MultiplyPoint(camera.transform.position);
                        float sqrMagnitude = normal.sqrMagnitude;
                        float num0 = _posRadius.floatValue * _posRadius.floatValue;
                        float num1 = num0 * num0 / sqrMagnitude;
                        float num2 = Mathf.Sqrt(num0 - num1);
                        Handles.DrawWireDisc(position - num0 * normal / sqrMagnitude, normal, num2);
                    }
                }
                else if (_usePosX.boolValue && _usePosY.boolValue)
                {
                    Handles.DrawWireDisc(position, Vector3.forward, _posRadius.floatValue);
                }
                else if (_usePosX.boolValue && _usePosZ.boolValue)
                {
                    Handles.DrawWireDisc(position, Vector3.up, _posRadius.floatValue);
                }
                else if (_usePosY.boolValue && _usePosZ.boolValue)
                {
                    Handles.DrawWireDisc(position, Vector3.right, _posRadius.floatValue);
                }
            }
            else
            {
                Handles.DrawWireCube(refPoint, size);
            }
        }
        private void DrawSceneScaleHandles()
        {
            foreach (Object obj in _selections)
            {
                GameObject go = obj as GameObject;
                if (go == null)
                {
                    Debug.LogWarning("TransformRandomizer is usable with GameObjects only");
                    continue;
                }
                DrawScaleHandles(go);

            }
        }
        private void DrawScaleHandles(GameObject go)
        {
            float minX = _useScaleX.boolValue ? (_uniformScale.boolValue ? _uniformScaleRange.vector2Value.x : _scaleXRange.vector2Value.x) : 0f;
            float maxX = _useScaleX.boolValue ? (_uniformScale.boolValue ? _uniformScaleRange.vector2Value.y : _scaleXRange.vector2Value.y) : 0f;
            float minY = _useScaleY.boolValue ? (_uniformScale.boolValue ? _uniformScaleRange.vector2Value.x : _scaleYRange.vector2Value.x) : 0f;
            float maxY = _useScaleY.boolValue ? (_uniformScale.boolValue ? _uniformScaleRange.vector2Value.y : _scaleYRange.vector2Value.y) : 0f;
            float minZ = _useScaleZ.boolValue ? (_uniformScale.boolValue ? _uniformScaleRange.vector2Value.x : _scaleZRange.vector2Value.x) : 0f;
            float maxZ = _useScaleZ.boolValue ? (_uniformScale.boolValue ? _uniformScaleRange.vector2Value.y : _scaleZRange.vector2Value.y) : 0f;
            Handles.color = Color.red;
            Handles.DrawWireCube(go.transform.position, new Vector3(maxX, maxY, maxZ));
            Handles.color = Color.blue;
            Handles.DrawWireCube(go.transform.position, new Vector3(_useScaleX.boolValue ? 1f : 0f, _useScaleY.boolValue ? 1f : 0f, _useScaleZ.boolValue ? 1f : 0f));
            Handles.color = Color.green;
            Handles.DrawWireCube(go.transform.position, new Vector3(minX, minY, minZ));
        }
        private void DrawSceneRotationHandles()
        {
            foreach (Object obj in _selections)
            {
                GameObject go = obj as GameObject;
                if (go == null)
                {
                    Debug.LogWarning("TransformRandomizer is usable with GameObjects only");
                    continue;
                }
                DrawRotationHandles(go);
            }
        }
        private void DrawRotationHandles(GameObject go)
        {
            float minX = _useRotX.boolValue ? _rotXRange.vector2Value.x : 0f;
            float maxX = _useRotX.boolValue ? _rotXRange.vector2Value.y : 0f;
            float minY = _useRotY.boolValue ? _rotYRange.vector2Value.x : 0f;
            float maxY = _useRotY.boolValue ? _rotYRange.vector2Value.y : 0f;
            float minZ = _useRotZ.boolValue ? _rotZRange.vector2Value.x : 0f;
            float maxZ = _useRotZ.boolValue ? _rotZRange.vector2Value.y : 0f;
            if (_localRot.boolValue)
            {
                //Handles.DrawSolidArc(go.transform.position, go.transform.up, Quaternion.AngleAxis(minY, go.transform.up) * (go.transform.forward), maxY - minY, 2f);
            }
            else
            {
                if (_additiveRotation.boolValue)
                {
                    Handles.color = new Color(1f, 0f, 0f, 0.5f);
                    Handles.DrawSolidArc(go.transform.position, Vector3.right, Quaternion.AngleAxis(minX, Vector3.right) * (go.transform.forward), maxX - minX, 2f);
                    Handles.color = new Color(0f, 1f, 0f, 0.5f);
                    Handles.DrawSolidArc(go.transform.position, Vector3.up, Quaternion.AngleAxis(minY, Vector3.up) * (go.transform.forward), maxY - minY, 2f);
                    Handles.color = new Color(0f, 0f, 1f, 0.5f);
                    Handles.DrawSolidArc(go.transform.position, Vector3.forward, Quaternion.AngleAxis(minZ, Vector3.forward) * (go.transform.forward), maxZ - minZ, 2f);
                }
                else
                {
                    Handles.color = new Color(1f, 0f, 0f, 0.5f);
                    Handles.DrawSolidArc(go.transform.position, Vector3.right, Quaternion.AngleAxis(minX, Vector3.right) * (Vector3.forward), maxX - minX, 2f);
                    Handles.color = new Color(0f, 1f, 0f, 0.5f);
                    Handles.DrawSolidArc(go.transform.position, Vector3.up, Quaternion.AngleAxis(minY, Vector3.up) * (Vector3.forward), maxY - minY, 2f);
                    Handles.color = new Color(0f, 0f, 1f, 0.5f);
                    Handles.DrawSolidArc(go.transform.position, Vector3.forward, Quaternion.AngleAxis(minZ, Vector3.right) * (Vector3.forward), maxZ - minZ, 2f);
                }
            }
            //Handles.color = Color.blue;
            //Handles.DrawWireCube(go.transform.position, new Vector3(_useScaleX.boolValue ? 1f : 0f, _useScaleY.boolValue ? 1f : 0f, _useScaleZ.boolValue ? 1f : 0f));
            //Handles.color = Color.green;
            //Handles.DrawWireCube(go.transform.position, new Vector3(minX, minY, minZ));
        }
        private void DrawPositionSettings()
        {
            Rect headerRect = EditorGUILayout.GetControlRect();
            _positionFolded.boolValue = EditorGUI.BeginFoldoutHeaderGroup(new Rect(headerRect.x,headerRect.y,headerRect.width-50f,headerRect.height),_positionFolded.boolValue, "Position");
            if (GUI.Button(new Rect(headerRect.width - 50f, headerRect.y, 50f, headerRect.height),EditorGUIUtility.IconContent("scenevis_visible_hover@2x")))
            {
                _viewType = RandomizerViewType.POSITION;
            }
            if (_positionFolded.boolValue)
            {
                _pointReferenceTypePos.enumValueIndex = (int)(PointReferenceType)EditorGUILayout.EnumPopup(new GUIContent("Reference"), (PointReferenceType)_pointReferenceTypePos.enumValueIndex);
                if ((PointReferenceType)_pointReferenceTypePos.enumValueIndex == PointReferenceType.SELF)
                {
                    _localPos.boolValue = GUILayout.Toolbar(_localPos.boolValue ? 0 : 1, new GUIContent[] { new GUIContent("Local"), new GUIContent("Global") }) == 0 ? true : false;
                }
                else
                {
                    _localPos.boolValue = false;
                }
                float labelWidthBkp = EditorGUIUtility.labelWidth;
                EditorGUIUtility.labelWidth = 30f;
                EditorGUILayout.BeginHorizontal();
                _usePosX.boolValue = EditorGUILayout.ToggleLeft("X", _usePosX.boolValue, GUILayout.Width(30f));
                EditorGUI.BeginDisabledGroup(!_usePosX.boolValue || _usePosRadius.boolValue);
                _posXRange.vector2Value = new Vector2(Mathf.Min(EditorGUILayout.FloatField(new GUIContent("Min"), _posXRange.vector2Value.x), _posXRange.vector2Value.y), EditorGUILayout.FloatField(new GUIContent("Max"), _posXRange.vector2Value.y));
                EditorGUILayout.EndHorizontal();
                EditorGUI.EndDisabledGroup();
                EditorGUILayout.BeginHorizontal();
                _usePosY.boolValue = EditorGUILayout.ToggleLeft("Y", _usePosY.boolValue, GUILayout.Width(30f));
                EditorGUI.BeginDisabledGroup(!_usePosY.boolValue || _usePosRadius.boolValue);
                _posYRange.vector2Value = new Vector2(Mathf.Min(EditorGUILayout.FloatField(new GUIContent("Min"), _posYRange.vector2Value.x), _posYRange.vector2Value.y), EditorGUILayout.FloatField(new GUIContent("Max"), _posYRange.vector2Value.y));
                EditorGUILayout.EndHorizontal();
                EditorGUI.EndDisabledGroup();
                EditorGUILayout.BeginHorizontal();
                _usePosZ.boolValue = EditorGUILayout.ToggleLeft("Z", _usePosZ.boolValue, GUILayout.Width(30f));
                EditorGUI.BeginDisabledGroup(!_usePosZ.boolValue || _usePosRadius.boolValue);
                _posZRange.vector2Value = new Vector2(Mathf.Min(EditorGUILayout.FloatField(new GUIContent("Min"), _posZRange.vector2Value.x), _posZRange.vector2Value.y), EditorGUILayout.FloatField(new GUIContent("Max"), _posZRange.vector2Value.y));
                EditorGUILayout.EndHorizontal();
                EditorGUI.EndDisabledGroup();
                if ((_usePosX.boolValue && _usePosY.boolValue) || (_usePosX.boolValue && _usePosZ.boolValue) || (_usePosY.boolValue && _usePosZ.boolValue))
                {
                    EditorGUILayout.BeginHorizontal();
                    _usePosRadius.boolValue = EditorGUILayout.ToggleLeft("Use Radius", _usePosRadius.boolValue, GUILayout.Width(85f));
                    EditorGUI.BeginDisabledGroup(!_usePosRadius.boolValue);
                    _posRadius.floatValue = EditorGUILayout.FloatField("  ", _posRadius.floatValue);
                    EditorGUI.EndDisabledGroup();
                    EditorGUILayout.EndHorizontal();
                }
                else
                {
                    _usePosRadius.boolValue = false;
                }
                EditorGUIUtility.labelWidth = labelWidthBkp;
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
        }
        private void DrawRotationSettings()
        {
            Rect headerRect = EditorGUILayout.GetControlRect();
            _rotationFolded.boolValue = EditorGUI.BeginFoldoutHeaderGroup(new Rect(headerRect.x, headerRect.y, headerRect.width - 50f, headerRect.height), _rotationFolded.boolValue, "Rotation");
            if (GUI.Button(new Rect(headerRect.width - 50f, headerRect.y, 50f, headerRect.height), EditorGUIUtility.IconContent("scenevis_visible_hover@2x")))
            {
                _viewType = RandomizerViewType.ROTATION;
            }
            if (_rotationFolded.boolValue)
            {
                _localRot.boolValue = GUILayout.Toolbar(_localRot.boolValue ? 0 : 1, new GUIContent[] { new GUIContent("Local"), new GUIContent("Global") }) == 0 ? true : false;
                float labelWidthBkp = EditorGUIUtility.labelWidth;
                EditorGUIUtility.labelWidth = 30f;
                EditorGUILayout.BeginHorizontal();
                _useRotX.boolValue = EditorGUILayout.ToggleLeft("X", _useRotX.boolValue, GUILayout.Width(30f));
                EditorGUI.BeginDisabledGroup(!_useRotX.boolValue);
                _rotXRange.vector2Value = new Vector2(Mathf.Clamp(EditorGUILayout.FloatField(new GUIContent("Min"), _rotXRange.vector2Value.x), -180f, _rotXRange.vector2Value.y), Mathf.Clamp(EditorGUILayout.FloatField(new GUIContent("Max"), _rotXRange.vector2Value.y), -180f, 360f));
                EditorGUI.EndDisabledGroup();
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                _useRotY.boolValue = EditorGUILayout.ToggleLeft("Y", _useRotY.boolValue, GUILayout.Width(30f));
                EditorGUI.BeginDisabledGroup(!_useRotY.boolValue);
                _rotYRange.vector2Value = new Vector2(Mathf.Clamp(EditorGUILayout.FloatField(new GUIContent("Min"), _rotYRange.vector2Value.x), -180f, _rotYRange.vector2Value.y), Mathf.Clamp(EditorGUILayout.FloatField(new GUIContent("Max"), _rotYRange.vector2Value.y), -180f, 360f));
                EditorGUI.EndDisabledGroup();
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
                _useRotZ.boolValue = EditorGUILayout.ToggleLeft("Z", _useRotZ.boolValue, GUILayout.Width(30f));
                EditorGUI.BeginDisabledGroup(!_useRotZ.boolValue);
                _rotZRange.vector2Value = new Vector2(Mathf.Clamp(EditorGUILayout.FloatField(new GUIContent("Min"), _rotZRange.vector2Value.x), -180f, _rotZRange.vector2Value.y), Mathf.Clamp(EditorGUILayout.FloatField(new GUIContent("Max"), _rotZRange.vector2Value.y), -180f, 360f));
                EditorGUI.EndDisabledGroup();
                EditorGUILayout.EndHorizontal();
                _additiveRotation.boolValue = EditorGUILayout.ToggleLeft("Additive", _additiveRotation.boolValue, GUILayout.Width(85f));
                EditorGUIUtility.labelWidth = labelWidthBkp;
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
        }
        private void DrawScaleSettings()
        {
            Rect headerRect = EditorGUILayout.GetControlRect();
            _scaleFolded.boolValue = EditorGUI.BeginFoldoutHeaderGroup(new Rect(headerRect.x, headerRect.y, headerRect.width - 50f, headerRect.height), _scaleFolded.boolValue, "Scale");
            if (GUI.Button(new Rect(headerRect.width - 50f, headerRect.y, 50f, headerRect.height), EditorGUIUtility.IconContent("scenevis_visible_hover@2x")))
            {
                _viewType = RandomizerViewType.SCALE;
            }
            if (_scaleFolded.boolValue)
            {
                float labelWidthBkp = EditorGUIUtility.labelWidth;
                EditorGUIUtility.labelWidth = 30f;
                EditorGUILayout.BeginHorizontal();
                EditorGUIUtility.labelWidth = 30f;
                _useScaleX.boolValue = EditorGUILayout.ToggleLeft("X", _useScaleX.boolValue, GUILayout.Width(30f));
                EditorGUI.BeginDisabledGroup(!_useScaleX.boolValue || _uniformScale.boolValue);
                _scaleXRange.vector2Value = new Vector2(Mathf.Min(EditorGUILayout.FloatField(new GUIContent("Min"), _scaleXRange.vector2Value.x), _scaleXRange.vector2Value.y), EditorGUILayout.FloatField(new GUIContent("Max"), _scaleXRange.vector2Value.y));
                EditorGUILayout.EndHorizontal();
                EditorGUI.EndDisabledGroup();
                EditorGUILayout.BeginHorizontal();
                _useScaleY.boolValue = EditorGUILayout.ToggleLeft("Y", _useScaleY.boolValue, GUILayout.Width(30f));
                EditorGUI.BeginDisabledGroup(!_useScaleY.boolValue || _uniformScale.boolValue);
                _scaleYRange.vector2Value = new Vector2(Mathf.Min(EditorGUILayout.FloatField(new GUIContent("Min"), _scaleYRange.vector2Value.x), _scaleYRange.vector2Value.y), EditorGUILayout.FloatField(new GUIContent("Max"), _scaleYRange.vector2Value.y));
                EditorGUILayout.EndHorizontal();
                EditorGUI.EndDisabledGroup();
                EditorGUILayout.BeginHorizontal();
                _useScaleZ.boolValue = EditorGUILayout.ToggleLeft("Z", _useScaleZ.boolValue, GUILayout.Width(30f));
                EditorGUI.BeginDisabledGroup(!_useScaleZ.boolValue || _uniformScale.boolValue);
                _scaleZRange.vector2Value = new Vector2(Mathf.Min(EditorGUILayout.FloatField(new GUIContent("Min"), _scaleZRange.vector2Value.x), _scaleZRange.vector2Value.y), EditorGUILayout.FloatField(new GUIContent("Max"), _scaleZRange.vector2Value.y));
                EditorGUILayout.EndHorizontal();
                EditorGUI.EndDisabledGroup();
                if ((_useScaleX.boolValue && _useScaleY.boolValue) || (_useScaleX.boolValue && _useScaleZ.boolValue) || (_useScaleY.boolValue && _useScaleZ.boolValue))
                {
                    EditorGUILayout.BeginHorizontal();
                    _uniformScale.boolValue = EditorGUILayout.ToggleLeft("Uniform", _uniformScale.boolValue, GUILayout.Width(85f));
                    EditorGUI.BeginDisabledGroup(!_uniformScale.boolValue);
                    _uniformScaleRange.vector2Value = new Vector2(Mathf.Min(EditorGUILayout.FloatField(new GUIContent("Min"), _uniformScaleRange.vector2Value.x), _uniformScaleRange.vector2Value.y), EditorGUILayout.FloatField(new GUIContent("Max"), _uniformScaleRange.vector2Value.y));
                    EditorGUI.EndDisabledGroup();
                    EditorGUILayout.EndHorizontal();
                }
                else
                {
                    _uniformScale.boolValue = false;
                }
                _additiveScale.boolValue = EditorGUILayout.ToggleLeft("Additive", _additiveScale.boolValue, GUILayout.Width(85f));
                EditorGUIUtility.labelWidth = labelWidthBkp;
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
        }
        private void DrawPositionButton()
        {
            EditorGUI.BeginDisabledGroup(_selections.Count == 0);
            if (GUILayout.Button("Randomize position(s)"))
            {
                Vector3 pointRef = Vector3.zero;
                if ((PointReferenceType)_pointReferenceTypePos.enumValueIndex == PointReferenceType.GROUP)
                {
                    pointRef = GetGroupPivot();
                }
                Undo.RecordObjects(_selections.Select((x) => x.transform).ToArray(), "Randomized GameObjects positions");
                foreach (Object obj in _selections)
                {
                    if ((PointReferenceType)_pointReferenceTypePos.enumValueIndex == PointReferenceType.SELF)
                    {
                        pointRef = GetObjectPivot(obj);
                    }
                    RandomizePosition(obj as GameObject, pointRef);
                }
            }
        }
        private void DrawRotationButton()
        {
            if (GUILayout.Button("Randomize rotation(s)"))
            {
                Undo.RecordObjects(_selections.Select((x) => x.transform).ToArray(), "Randomized GameObjects rotations");
                foreach (Object obj in _selections)
                {
                    RandomizeRotation(obj as GameObject);
                }
            }
        }
        private void DrawScaleButton()
        {
            if (GUILayout.Button("Randomize scale(s)"))
            {
                Undo.RecordObjects(_selections.Select((x) => x.transform).ToArray(), "Randomized GameObjects scales");
                foreach (Object obj in _selections)
                {
                    RandomizeScale(obj as GameObject);
                }
            }
        }

        [MenuItem("GameObject/Transform Randomizer", false, 10)]
        private static void OpenFromContextMenu()
        {
            EditorWindow window = GetWindow(typeof(TransformRandomizerWindow));
            window.titleContent = new GUIContent("Transform Randomizer");
        }
        private Vector3 GetGroupPivot()
        {
            Vector3 groupPivot = Vector3.zero;
            int skipped = 0;
            foreach (GameObject go in _selections)
            {
                groupPivot += go.transform.position;
            }
            return groupPivot / (_selections.Count - skipped);
        }
        private Vector3 GetObjectPivot(Object obj)
        {
            GameObject go = obj as GameObject;
            if (go == null)
            {
                return Vector3.zero;
            }
            return go.transform.position;
        }
        private void RandomizePosition(GameObject go, Vector3 pointReference)
        {
            Vector3 original = go.transform.position;
            if (_usePosRadius.boolValue)
            {
                if (_usePosX.boolValue && _usePosY.boolValue && _usePosZ.boolValue)
                {
                    go.transform.position = Random.insideUnitSphere * _posRadius.floatValue + pointReference;
                }
                else if (_usePosX.boolValue && _usePosY.boolValue)
                {
                    Vector2 p = Random.insideUnitCircle * _posRadius.floatValue;
                    go.transform.position = new Vector3(p.x, p.y, 0f) + pointReference;
                }
                else if (_usePosX.boolValue && _usePosZ.boolValue)
                {
                    Vector2 p = Random.insideUnitCircle * _posRadius.floatValue;
                    go.transform.position = new Vector3(p.x, 0f, p.y) + pointReference;
                }
                else if (_usePosZ.boolValue && _usePosY.boolValue)
                {
                    Vector2 p = Random.insideUnitCircle * _posRadius.floatValue;
                    go.transform.position = new Vector3(0f, p.x, p.y) + pointReference;
                }
            }
            else
            {
                float newX = Random.Range(_posXRange.vector2Value.x, _posXRange.vector2Value.y) + pointReference.x;
                float newY = Random.Range(_posYRange.vector2Value.x, _posYRange.vector2Value.y) + pointReference.y;
                float newZ = Random.Range(_posZRange.vector2Value.x, _posZRange.vector2Value.y) + pointReference.z;
                Vector3 newPos = new Vector3(_usePosX.boolValue ? newX : original.x, _usePosY.boolValue ? newY : original.y, _usePosZ.boolValue ? newZ : original.z);
                Vector3 motion = newPos - original;
                Vector3 convertedMotion = go.transform.TransformDirection(motion);
                go.transform.position += _localPos.boolValue ? convertedMotion : motion;
            }
        }
        private void RandomizeRotation(GameObject go)
        {
            Vector3 original = _localRot.boolValue ? go.transform.localEulerAngles : go.transform.eulerAngles;
            float newX = Random.Range(_rotXRange.vector2Value.x, _rotXRange.vector2Value.y);
            float newY = Random.Range(_rotYRange.vector2Value.x, _rotYRange.vector2Value.y);
            float newZ = Random.Range(_rotZRange.vector2Value.x, _rotZRange.vector2Value.y);
            if (_useRotX.boolValue)
            {
                original.x = (_additiveRotation.boolValue ? original.x : 0f) + newX;
            }
            if (_useRotY.boolValue)
            {
                original.y = (_additiveRotation.boolValue ? original.y : 0f) + newY;
            }
            if (_useRotZ.boolValue)
            {
                original.z = (_additiveRotation.boolValue ? original.z : 0f) + newZ;
            }
            if (_localRot.boolValue)
            {
                go.transform.localEulerAngles = original;
            }
            else
            {
                go.transform.eulerAngles = original;
            }
        }
        private void RandomizeScale(GameObject go)
        {
            Vector3 o = go.transform.localScale;
            float uniformScaleValue = Random.Range(_uniformScaleRange.vector2Value.x, _uniformScaleRange.vector2Value.y);
            float newX = _uniformScale.boolValue ? uniformScaleValue : Random.Range(_scaleXRange.vector2Value.x, _scaleXRange.vector2Value.y);
            float newY = _uniformScale.boolValue ? uniformScaleValue : Random.Range(_scaleYRange.vector2Value.x, _scaleYRange.vector2Value.y);
            float newZ = _uniformScale.boolValue ? uniformScaleValue : Random.Range(_scaleZRange.vector2Value.x, _scaleZRange.vector2Value.y);
            Vector3 scaleVector = new Vector3(_useScaleX.boolValue ? newX + (_additiveScale.boolValue ? o.x : 0f) : o.x, _useScaleY.boolValue ? newY + (_additiveScale.boolValue ? o.y : 0f) : o.y, _useScaleZ.boolValue ? newZ + (_additiveScale.boolValue ? o.z : 0f) : o.z);
            go.transform.localScale = scaleVector;
        }
        private void GUILine(int i_height = 1)
        {
            Rect rect = EditorGUILayout.GetControlRect(false, i_height);

            rect.height = i_height;

            EditorGUI.DrawRect(rect, new Color(0.5f, 0.5f, 0.5f, 1));
        }
    }
}
