using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KevinCastejon.MissingFeatures.MissingWindows
{
    internal enum PointReferenceType
    {
        WORLD,
        SELF,
        GROUP,
    }
    public class TransformRandomizerSettings : ScriptableObject
    {
        [SerializeField] private bool _positionFolded = true;
        [SerializeField] private PointReferenceType _pointReferenceTypePos;
        [SerializeField] private bool _usePosX = true;
        [SerializeField] private bool _usePosY = true;
        [SerializeField] private bool _usePosZ = true;
        [SerializeField] private Vector2 _posXRange;
        [SerializeField] private Vector2 _posYRange;
        [SerializeField] private Vector2 _posZRange;
        [SerializeField] private bool _localPos;
        [SerializeField] private bool _usePosRadius;
        [SerializeField] private float _posRadius;

        [SerializeField] private bool _rotationFolded = true;
        [SerializeField] private bool _useRotX = true;
        [SerializeField] private bool _useRotY = true;
        [SerializeField] private bool _useRotZ = true;
        [SerializeField] private Vector2 _rotXRange = new Vector2(0f, 360f);
        [SerializeField] private Vector2 _rotYRange = new Vector2(0f, 360f);
        [SerializeField] private Vector2 _rotZRange = new Vector2(0f, 360f);
        [SerializeField] private bool _localRot = true;
        [SerializeField] private bool _additiveRotation = true;

        [SerializeField] private bool _scaleFolded = true;
        [SerializeField] private bool _useScaleX = true;
        [SerializeField] private bool _useScaleY = true;
        [SerializeField] private bool _useScaleZ = true;
        [SerializeField] private Vector2 _scaleXRange;
        [SerializeField] private Vector2 _scaleYRange;
        [SerializeField] private Vector2 _scaleZRange;
        [SerializeField] private Vector2 _uniformScaleRange;
        [SerializeField] private bool _uniformScale;
        [SerializeField] private bool _additiveScale;

        public bool PositionFolded { get => _positionFolded; set => _positionFolded = value; }
        public bool UsePosX { get => _usePosX; set => _usePosX = value; }
        public bool UsePosY { get => _usePosY; set => _usePosY = value; }
        public bool UsePosZ { get => _usePosZ; set => _usePosZ = value; }
        public Vector2 PosXRange { get => _posXRange; set => _posXRange = value; }
        public Vector2 PosYRange { get => _posYRange; set => _posYRange = value; }
        public Vector2 PosZRange { get => _posZRange; set => _posZRange = value; }
        public bool LocalPos { get => _localPos; set => _localPos = value; }
        public bool UsePosRadius { get => _usePosRadius; set => _usePosRadius = value; }
        public float PosRadius { get => _posRadius; set => _posRadius = value; }
        public bool RotationFolded { get => _rotationFolded; set => _rotationFolded = value; }
        public bool UseRotX { get => _useRotX; set => _useRotX = value; }
        public bool UseRotY { get => _useRotY; set => _useRotY = value; }
        public bool UseRotZ { get => _useRotZ; set => _useRotZ = value; }
        public Vector2 RotXRange { get => _rotXRange; set => _rotXRange = value; }
        public Vector2 RotYRange { get => _rotYRange; set => _rotYRange = value; }
        public Vector2 RotZRange { get => _rotZRange; set => _rotZRange = value; }
        public bool LocalRot { get => _localRot; set => _localRot = value; }
        public bool AdditiveRotation { get => _additiveRotation; set => _additiveRotation = value; }
        public bool ScaleFolded { get => _scaleFolded; set => _scaleFolded = value; }
        public bool UseScaleX { get => _useScaleX; set => _useScaleX = value; }
        public bool UseScaleY { get => _useScaleY; set => _useScaleY = value; }
        public bool UseScaleZ { get => _useScaleZ; set => _useScaleZ = value; }
        public Vector2 ScaleXRange { get => _scaleXRange; set => _scaleXRange = value; }
        public Vector2 ScaleYRange { get => _scaleYRange; set => _scaleYRange = value; }
        public Vector2 ScaleZRange { get => _scaleZRange; set => _scaleZRange = value; }
        public Vector2 UniformScaleRange { get => _uniformScaleRange; set => _uniformScaleRange = value; }
        public bool UniformScale { get => _uniformScale; set => _uniformScale = value; }
        public bool AdditiveScale { get => _additiveScale; set => _additiveScale = value; }
        internal PointReferenceType PointReferenceTypePos { get => _pointReferenceTypePos; set => _pointReferenceTypePos = value; }
    }
}