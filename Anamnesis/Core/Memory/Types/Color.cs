﻿// © Anamnesis.
// Developed by W and A Walsh.
// Licensed under the MIT license.

namespace Anamnesis.Memory
{
	using System;
	using System.Globalization;

	public struct Color : IEquatable<Color>
	{
		public static readonly Color White = new Color(1, 1, 1);
		public static readonly Color Black = new Color(0, 0, 0);

		public Color(float r = 1, float g = 1, float b = 1)
		{
			this.R = r;
			this.G = g;
			this.B = b;
		}

		public float R { get; set; }
		public float G { get; set; }
		public float B { get; set; }

		public static bool operator ==(Color a, Color b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(Color a, Color b)
		{
			return !a.Equals(b);
		}

		public static Color FromString(string str)
		{
			string[] parts = str.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

			if (parts.Length != 3)
				throw new FormatException();

			Color v = default;
			v.R = float.Parse(parts[0], CultureInfo.InvariantCulture);
			v.G = float.Parse(parts[1], CultureInfo.InvariantCulture);
			v.B = float.Parse(parts[2], CultureInfo.InvariantCulture);
			return v;
		}

		public override string ToString()
		{
			return this.R.ToString(CultureInfo.InvariantCulture) + ", "
				+ this.G.ToString(CultureInfo.InvariantCulture) + ", "
				+ this.B.ToString(CultureInfo.InvariantCulture);
		}

		public override bool Equals(object? obj)
		{
			return obj is Color color && this.Equals(color);
		}

		public bool Equals(Color other)
		{
			return this.R == other.R &&
				   this.G == other.G &&
				   this.B == other.B;
		}

		public override int GetHashCode()
		{
			int hashCode = -1520100960;
			hashCode = (hashCode * -1521134295) + this.R.GetHashCode();
			hashCode = (hashCode * -1521134295) + this.G.GetHashCode();
			hashCode = (hashCode * -1521134295) + this.B.GetHashCode();
			return hashCode;
		}
	}
}
