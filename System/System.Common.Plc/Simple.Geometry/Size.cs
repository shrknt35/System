﻿namespace System.Common.Simple.Geometry
{
    public struct Size
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public Size(int width, int height)
            : this()
        {
            Width = width;
            Height = height;
        }
    }
}