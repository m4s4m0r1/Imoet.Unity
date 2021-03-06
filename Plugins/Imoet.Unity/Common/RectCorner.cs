﻿using System;
using UnityEngine;

namespace Imoet.Unity
{
    /// <summary>
    /// Rectangle Corner Position in 3D Space
    /// </summary>
    [Serializable]
    public struct RectCorner
    {
        public Vector3 TopLeft, TopRight, BottomRight, BottomLeft;
        public RectCorner(Vector3 TopLeft, Vector3 TopRight, Vector3 BottomRight, Vector3 BottomLeft)
        {
            this.TopLeft = TopLeft;
            this.TopRight = TopRight;
            this.BottomRight = BottomRight;
            this.BottomLeft = BottomLeft;
        }
        /// <summary>
        ///     Get width of this active Rect
        /// </summary>
        public float width
        {
            get { return Vector3.Distance(TopLeft, TopRight); }
        }

        /// <summary>
        ///     Get height of this active Rect
        /// </summary>
        public float height
        {
            get { return Vector3.Distance(TopLeft, BottomLeft); }
        }

        /// <summary>
        ///     Get the size (width and height) of this active Rect represent in <see cref="Vector2" />
        /// </summary>
        /// <value>The size.</value>
        public SizeF size
        {
            get { return new Vector2(width, height); }
        }

        public Vector3 this[int idx]
        {
            get
            {
                switch (idx)
                {
                    case 0: return TopLeft;
                    case 1: return TopRight;
                    case 2: return BottomRight;
                    case 3: return BottomLeft;
                }
                throw new IndexOutOfRangeException();
            }
        }
        public static bool operator == (RectCorner l, RectCorner r)
        {
            for (int i = 0; i < 4; i++)
            {
                if (l[i] != r[i])
                    return false;
            }
            return true;
        }
        public static bool operator !=(RectCorner l, RectCorner r)
        {
            for (int i = 0; i < 4; i++)
            {
                if (l[i] == r[i])
                    return false;
            }
            return true;
        }
        public override int GetHashCode()
        {
            int hashCode = 0;
            for (int i = 0; i < 4; i++)
                hashCode += this[i].GetHashCode();
            return hashCode;
        }
        public override bool Equals(object obj)
        {
            if (obj is RectCorner)
                return (RectCorner)obj == this;
            return false;
        }
        public override string ToString()
        {
            return string.Format(
                "TopLeft:{0}, TopRight:{1}, BottomLeft:{2}, BottomRight:{3}",
                TopLeft, TopRight, BottomLeft, BottomRight);
        }
    }
}
