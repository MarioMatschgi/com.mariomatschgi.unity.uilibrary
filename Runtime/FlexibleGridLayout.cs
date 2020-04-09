﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MM.Libraries.UI
{
    [AddComponentMenu("MM UI/FlexibleGridLayout")]
    public class FlexibleGridLayout : LayoutGroup
    {
        public int rows;
        public int colums;
        public FitType fitType;
        public Vector2 space;
        public Vector2 cellSize;

        public bool fitX;
        public bool fitY;

        public new RectOffset padding;


        #region Callback Methodes
        /*
         *
         *  Callback Methodes
         * 
         */

        protected override void OnEnable()
        {
            rows = 1;
            colums = 1;
            fitType = FitType.Uniform;
            space = new Vector2(0, 0);
            cellSize = new Vector2(0, 0);

            fitX = true;
            fitY = true;

            padding = new RectOffset(0, 0, 0, 0);
        }
        public override void CalculateLayoutInputHorizontal()
        {
            // Manage base
            base.CalculateLayoutInputHorizontal();

            // If fitType is Width, Height or Uniform, set fit and amount
            if (fitType == FitType.Width || fitType == FitType.Height || fitType == FitType.Uniform)
            {
                fitX = true;
                fitY = true;

                int _amt = Mathf.CeilToInt(Mathf.Sqrt(transform.childCount));
                rows = _amt;
                colums = _amt;
            }

            // If fitType is Width or FixedColumns, calc rows for width fit
            if (fitType == FitType.Width || fitType == FitType.FixedColumns)
                rows = Mathf.CeilToInt(transform.childCount / (float)colums);
            // If fitType is Height or FixedRows, calc rows for height fit
            if (fitType == FitType.Height || fitType == FitType.FixedRows)
                colums = Mathf.CeilToInt(transform.childCount / (float)rows);

            // Limit rows/colums
            colums = Mathf.RoundToInt(Mathf.Clamp(colums, 1, Mathf.Infinity));
            rows = Mathf.RoundToInt(Mathf.Clamp(rows, 1, Mathf.Infinity));


            if (rectTransform != null)
            {
                // If fitX, calc cellsizeX
                if (fitX)
                    cellSize.x = (rectTransform.rect.width / (float)colums) - (space.x - space.x / (float)colums) - (padding.left / (float)colums) - (padding.right / (float)colums);
                // If fitY, calc cellsizeY
                if (fitY)
                    cellSize.y = (rectTransform.rect.height / (float)rows) - (space.y - space.y / (float)rows) - (padding.top / (float)rows) - (padding.bottom / (float)rows);
            }

            // Iterate through children and position and scale them accordingly
            for (int i = 0; i < rectTransform.childCount; i++)
            {
                SetChildAlongAxis(rectChildren[i], 0, (i % colums) * (cellSize.x + space.x) + padding.left, cellSize.x);
                SetChildAlongAxis(rectChildren[i], 1, (i / colums) * (cellSize.y + space.y) + padding.top, cellSize.y);
            }

            // Set size
            float _width = colums * (cellSize.x + space.x) - space.x + padding.left + padding.right;
            float _height = rows * (cellSize.y + space.y) - space.y + padding.top + padding.bottom;
            SetLayoutInputForAxis(_width, _width, _width, 0);
            SetLayoutInputForAxis(_height, _height, _height, 1);
        }

        public override void CalculateLayoutInputVertical() { }

        public override void SetLayoutHorizontal() { }

        public override void SetLayoutVertical() { }

        void Update()
        {

        }

        #endregion

        #region Gameplay Methodes
        /*
         *
         *  Gameplay Methodes
         *
         */

        #endregion

        #region Helper Methodes
        /*
         *
         *  Helper Methodes
         * 
         */

        #endregion
    }

    public enum FitType
    {
        Uniform,
        Width,
        Height,
        FixedRows,
        FixedColumns,
    }
}