/*
 Code based on https://github.com/microsoft/referencesource/blob/master/System.Numerics/System/Numerics/Matrix4x4.cs
 From the repository https://github.com/microsoft/referencesource
 Copyright (c) Microsoft. All rights reserved.
 Licensed under the MIT license. See LICENSE file in the project root for full license information.
*/

using System.Globalization;
using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Common;

/// <summary>
/// A structure encapsulating a 4x4 matrix.
/// </summary>
public struct Matrix4x4 : IEquatable<Matrix4x4>, IBinary
{
    #region Public Fields

    /// <summary>
    /// The matrix's data serialized into an array of float arrays
    /// </summary>
    public float[,] Data
    {
        get => new float[4, 4] { { M11, M12, M13, M14 }, { M21, M22, M23, M24 }, { M31, M32, M33, M34 }, { M41, M42, M43, M44 } };
        set
        {
            if (value.Length < 16)
                throw new ArgumentException("Matrix4x4.Data: Array must be of length 16");

            M11 = value[0, 0];
            M12 = value[0, 1];
            M13 = value[0, 2];
            M14 = value[0, 3];
            M21 = value[1, 0];
            M22 = value[1, 1];
            M23 = value[1, 2];
            M24 = value[1, 3];
            M31 = value[2, 0];
            M32 = value[2, 1];
            M33 = value[2, 2];
            M34 = value[2, 3];
            M41 = value[3, 0];
            M42 = value[3, 1];
            M43 = value[3, 2];
            M44 = value[3, 3];
        }
    }

    /// <summary>
    /// Value at row 1, column 1 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M11;

    /// <summary>
    /// Value at row 1, column 2 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M12;

    /// <summary>
    /// Value at row 1, column 3 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M13;

    /// <summary>
    /// Value at row 1, column 4 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M14;

    /// <summary>
    /// Value at row 2, column 1 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M21;

    /// <summary>
    /// Value at row 2, column 2 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M22;

    /// <summary>
    /// Value at row 2, column 3 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M23;

    /// <summary>
    /// Value at row 2, column 4 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M24;

    /// <summary>
    /// Value at row 3, column 1 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M31;

    /// <summary>
    /// Value at row 3, column 2 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M32;

    /// <summary>
    /// Value at row 3, column 3 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M33;

    /// <summary>
    /// Value at row 3, column 4 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M34;

    /// <summary>
    /// Value at row 4, column 1 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M41;

    /// <summary>
    /// Value at row 4, column 2 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M42;

    /// <summary>
    /// Value at row 4, column 3 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M43;

    /// <summary>
    /// Value at row 4, column 4 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M44;

    #endregion Public Fields

    private static readonly Matrix4x4 _identity = new(1f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 1f);

    /// <summary>
    /// Returns the multiplicative identity matrix.
    /// </summary>
    public static Matrix4x4 Identity
    {
        get { return _identity; }
    }

    /// <summary>
    /// Returns whether the matrix is the identity matrix.
    /// </summary>
    [JsonIgnore]
    public bool IsIdentity
    {
        get
        {
            return M11 == 1f &&
                   M22 == 1f &&
                   M33 == 1f &&
                   M44 == 1f && // Check diagonal element first for early out.
                   M12 == 0f &&
                   M13 == 0f &&
                   M14 == 0f &&
                   M21 == 0f &&
                   M23 == 0f &&
                   M24 == 0f &&
                   M31 == 0f &&
                   M32 == 0f &&
                   M34 == 0f &&
                   M41 == 0f &&
                   M42 == 0f &&
                   M43 == 0f;
        }
    }

    /// <summary>
    /// Gets or sets the translation component of this matrix.
    /// </summary>
    [JsonIgnore]
    public Vector3 Translation
    {
        get { return new Vector3(M14, M24, M34); }
        set
        {
            M14 = value.X;
            M24 = value.Y;
            M34 = value.Z;
        }
    }

    [JsonIgnore]
    public Quaternion Rotation
    {
        get => Quaternion.CreateFromRotationMatrix(this);
    }

    /// <summary>
    /// Constructs a Matrix4x4 from the given components.
    /// </summary>
    public Matrix4x4(
        float m11,
        float m12,
        float m13,
        float m14,
        float m21,
        float m22,
        float m23,
        float m24,
        float m31,
        float m32,
        float m33,
        float m34,
        float m41,
        float m42,
        float m43,
        float m44
    )
    {
        M11 = m11;
        M12 = m12;
        M13 = m13;
        M14 = m14;

        M21 = m21;
        M22 = m22;
        M23 = m23;
        M24 = m24;

        M31 = m31;
        M32 = m32;
        M33 = m33;
        M34 = m34;

        M41 = m41;
        M42 = m42;
        M43 = m43;
        M44 = m44;
    }

    public Matrix4x4(SBinaryReader binaryReader)
    {
        M11 = binaryReader.Read<float>();
        M21 = binaryReader.Read<float>();
        M31 = binaryReader.Read<float>();
        M41 = binaryReader.Read<float>();
        M12 = binaryReader.Read<float>();
        M22 = binaryReader.Read<float>();
        M32 = binaryReader.Read<float>();
        M42 = binaryReader.Read<float>();
        M13 = binaryReader.Read<float>();
        M23 = binaryReader.Read<float>();
        M33 = binaryReader.Read<float>();
        M43 = binaryReader.Read<float>();
        M14 = binaryReader.Read<float>();
        M24 = binaryReader.Read<float>();
        M34 = binaryReader.Read<float>();
        M44 = binaryReader.Read<float>();
    }

    /// <summary>
    /// Creates a translation matrix.
    /// </summary>
    /// <param name="position">The amount to translate in each axis.</param>
    /// <returns>The translation matrix.</returns>
    public static Matrix4x4 CreateTranslation(Vector3 position)
    {
        Matrix4x4 result;

        result.M11 = 1.0f;
        result.M12 = 0.0f;
        result.M13 = 0.0f;
        result.M14 = 0.0f;
        result.M21 = 0.0f;
        result.M22 = 1.0f;
        result.M23 = 0.0f;
        result.M24 = 0.0f;
        result.M31 = 0.0f;
        result.M32 = 0.0f;
        result.M33 = 1.0f;
        result.M34 = 0.0f;

        result.M41 = position.X;
        result.M42 = position.Y;
        result.M43 = position.Z;
        result.M44 = 1.0f;

        return result;
    }

    /// <summary>
    /// Creates a translation matrix.
    /// </summary>
    /// <param name="xPosition">The amount to translate on the X-axis.</param>
    /// <param name="yPosition">The amount to translate on the Y-axis.</param>
    /// <param name="zPosition">The amount to translate on the Z-axis.</param>
    /// <returns>The translation matrix.</returns>
    public static Matrix4x4 CreateTranslation(float xPosition, float yPosition, float zPosition)
    {
        Matrix4x4 result;

        result.M11 = 1.0f;
        result.M12 = 0.0f;
        result.M13 = 0.0f;
        result.M14 = 0.0f;
        result.M21 = 0.0f;
        result.M22 = 1.0f;
        result.M23 = 0.0f;
        result.M24 = 0.0f;
        result.M31 = 0.0f;
        result.M32 = 0.0f;
        result.M33 = 1.0f;
        result.M34 = 0.0f;

        result.M41 = xPosition;
        result.M42 = yPosition;
        result.M43 = zPosition;
        result.M44 = 1.0f;

        return result;
    }

    /// <summary>
    /// Creates a rotation matrix from the given Quaternion rotation value.
    /// </summary>
    /// <param name="quaternion">The source Quaternion.</param>
    /// <returns>The rotation matrix.</returns>
    public static Matrix4x4 CreateFromQuaternion(Quaternion quaternion)
    {
        Matrix4x4 result;

        float xx = quaternion.X * quaternion.X;
        float yy = quaternion.Y * quaternion.Y;
        float zz = quaternion.Z * quaternion.Z;

        float xy = quaternion.X * quaternion.Y;
        float wz = quaternion.Z * quaternion.W;
        float xz = quaternion.Z * quaternion.X;
        float wy = quaternion.Y * quaternion.W;
        float yz = quaternion.Y * quaternion.Z;
        float wx = quaternion.X * quaternion.W;

        result.M11 = 1.0f - 2.0f * (yy + zz);
        result.M12 = 2.0f * (xy + wz);
        result.M13 = 2.0f * (xz - wy);
        result.M14 = 0.0f;
        result.M21 = 2.0f * (xy - wz);
        result.M22 = 1.0f - 2.0f * (zz + xx);
        result.M23 = 2.0f * (yz + wx);
        result.M24 = 0.0f;
        result.M31 = 2.0f * (xz + wy);
        result.M32 = 2.0f * (yz - wx);
        result.M33 = 1.0f - 2.0f * (yy + xx);
        result.M34 = 0.0f;
        result.M41 = 0.0f;
        result.M42 = 0.0f;
        result.M43 = 0.0f;
        result.M44 = 1.0f;

        return result;
    }

    /// <summary>
    /// Calculates the determinant of the matrix.
    /// </summary>
    /// <returns>The determinant of the matrix.</returns>
    public float GetDeterminant()
    {
        // | a b c d |     | f g h |     | e g h |     | e f h |     | e f g |
        // | e f g h | = a | j k l | - b | i k l | + c | i j l | - d | i j k |
        // | i j k l |     | n o p |     | m o p |     | m n p |     | m n o |
        // | m n o p |
        //
        //   | f g h |
        // a | j k l | = a ( f ( kp - lo ) - g ( jp - ln ) + h ( jo - kn ) )
        //   | n o p |
        //
        //   | e g h |
        // b | i k l | = b ( e ( kp - lo ) - g ( ip - lm ) + h ( io - km ) )
        //   | m o p |
        //
        //   | e f h |
        // c | i j l | = c ( e ( jp - ln ) - f ( ip - lm ) + h ( in - jm ) )
        //   | m n p |
        //
        //   | e f g |
        // d | i j k | = d ( e ( jo - kn ) - f ( io - km ) + g ( in - jm ) )
        //   | m n o |
        //
        // Cost of operation
        // 17 adds and 28 muls.
        //
        // add: 6 + 8 + 3 = 17
        // mul: 12 + 16 = 28

        float a = M11, b = M12, c = M13, d = M14;
        float e = M21, f = M22, g = M23, h = M24;
        float i = M31, j = M32, k = M33, l = M34;
        float m = M41, n = M42, o = M43, p = M44;

        float kp_lo = k * p - l * o;
        float jp_ln = j * p - l * n;
        float jo_kn = j * o - k * n;
        float ip_lm = i * p - l * m;
        float io_km = i * o - k * m;
        float in_jm = i * n - j * m;

        return a * (f * kp_lo - g * jp_ln + h * jo_kn) -
               b * (e * kp_lo - g * ip_lm + h * io_km) +
               c * (e * jp_ln - f * ip_lm + h * in_jm) -
               d * (e * jo_kn - f * io_km + g * in_jm);
    }

    /// <summary>
    /// Attempts to calculate the inverse of the given matrix. If successful, result will contain the inverted matrix.
    /// </summary>
    /// <param name="matrix">The source matrix to invert.</param>
    /// <param name="result">If successful, contains the inverted matrix.</param>
    /// <returns>True if the source matrix could be inverted; False otherwise.</returns>
    public static bool Invert(Matrix4x4 matrix, out Matrix4x4 result)
    {
        //                                       -1
        // If you have matrix M, inverse Matrix M   can compute
        //
        //     -1       1
        //    M   = --------- A
        //            det(M)
        //
        // A is adjugate (adjoint) of M, where,
        //
        //      T
        // A = C
        //
        // C is Cofactor matrix of M, where,
        //           i + j
        // C   = (-1)      * det(M  )
        //  ij                    ij
        //
        //     [ a b c d ]
        // M = [ e f g h ]
        //     [ i j k l ]
        //     [ m n o p ]
        //
        // First Row
        //           2 | f g h |
        // C   = (-1)  | j k l | = + ( f ( kp - lo ) - g ( jp - ln ) + h ( jo - kn ) )
        //  11         | n o p |
        //
        //           3 | e g h |
        // C   = (-1)  | i k l | = - ( e ( kp - lo ) - g ( ip - lm ) + h ( io - km ) )
        //  12         | m o p |
        //
        //           4 | e f h |
        // C   = (-1)  | i j l | = + ( e ( jp - ln ) - f ( ip - lm ) + h ( in - jm ) )
        //  13         | m n p |
        //
        //           5 | e f g |
        // C   = (-1)  | i j k | = - ( e ( jo - kn ) - f ( io - km ) + g ( in - jm ) )
        //  14         | m n o |
        //
        // Second Row
        //           3 | b c d |
        // C   = (-1)  | j k l | = - ( b ( kp - lo ) - c ( jp - ln ) + d ( jo - kn ) )
        //  21         | n o p |
        //
        //           4 | a c d |
        // C   = (-1)  | i k l | = + ( a ( kp - lo ) - c ( ip - lm ) + d ( io - km ) )
        //  22         | m o p |
        //
        //           5 | a b d |
        // C   = (-1)  | i j l | = - ( a ( jp - ln ) - b ( ip - lm ) + d ( in - jm ) )
        //  23         | m n p |
        //
        //           6 | a b c |
        // C   = (-1)  | i j k | = + ( a ( jo - kn ) - b ( io - km ) + c ( in - jm ) )
        //  24         | m n o |
        //
        // Third Row
        //           4 | b c d |
        // C   = (-1)  | f g h | = + ( b ( gp - ho ) - c ( fp - hn ) + d ( fo - gn ) )
        //  31         | n o p |
        //
        //           5 | a c d |
        // C   = (-1)  | e g h | = - ( a ( gp - ho ) - c ( ep - hm ) + d ( eo - gm ) )
        //  32         | m o p |
        //
        //           6 | a b d |
        // C   = (-1)  | e f h | = + ( a ( fp - hn ) - b ( ep - hm ) + d ( en - fm ) )
        //  33         | m n p |
        //
        //           7 | a b c |
        // C   = (-1)  | e f g | = - ( a ( fo - gn ) - b ( eo - gm ) + c ( en - fm ) )
        //  34         | m n o |
        //
        // Fourth Row
        //           5 | b c d |
        // C   = (-1)  | f g h | = - ( b ( gl - hk ) - c ( fl - hj ) + d ( fk - gj ) )
        //  41         | j k l |
        //
        //           6 | a c d |
        // C   = (-1)  | e g h | = + ( a ( gl - hk ) - c ( el - hi ) + d ( ek - gi ) )
        //  42         | i k l |
        //
        //           7 | a b d |
        // C   = (-1)  | e f h | = - ( a ( fl - hj ) - b ( el - hi ) + d ( ej - fi ) )
        //  43         | i j l |
        //
        //           8 | a b c |
        // C   = (-1)  | e f g | = + ( a ( fk - gj ) - b ( ek - gi ) + c ( ej - fi ) )
        //  44         | i j k |
        //
        // Cost of operation
        // 53 adds, 104 muls, and 1 div.
        float a = matrix.M11, b = matrix.M12, c = matrix.M13, d = matrix.M14;
        float e = matrix.M21, f = matrix.M22, g = matrix.M23, h = matrix.M24;
        float i = matrix.M31, j = matrix.M32, k = matrix.M33, l = matrix.M34;
        float m = matrix.M41, n = matrix.M42, o = matrix.M43, p = matrix.M44;

        float kp_lo = k * p - l * o;
        float jp_ln = j * p - l * n;
        float jo_kn = j * o - k * n;
        float ip_lm = i * p - l * m;
        float io_km = i * o - k * m;
        float in_jm = i * n - j * m;

        float a11 = +(f * kp_lo - g * jp_ln + h * jo_kn);
        float a12 = -(e * kp_lo - g * ip_lm + h * io_km);
        float a13 = +(e * jp_ln - f * ip_lm + h * in_jm);
        float a14 = -(e * jo_kn - f * io_km + g * in_jm);

        float det = a * a11 + b * a12 + c * a13 + d * a14;

        if (Math.Abs(det) < float.Epsilon)
        {
            result = new Matrix4x4(float.NaN, float.NaN, float.NaN, float.NaN, float.NaN, float.NaN, float.NaN, float.NaN, float.NaN,
                float.NaN,
                float.NaN, float.NaN, float.NaN, float.NaN, float.NaN, float.NaN);

            return false;
        }

        float invDet = 1.0f / det;

        result.M11 = a11 * invDet;
        result.M21 = a12 * invDet;
        result.M31 = a13 * invDet;
        result.M41 = a14 * invDet;

        result.M12 = -(b * kp_lo - c * jp_ln + d * jo_kn) * invDet;
        result.M22 = +(a * kp_lo - c * ip_lm + d * io_km) * invDet;
        result.M32 = -(a * jp_ln - b * ip_lm + d * in_jm) * invDet;
        result.M42 = +(a * jo_kn - b * io_km + c * in_jm) * invDet;

        float gp_ho = g * p - h * o;
        float fp_hn = f * p - h * n;
        float fo_gn = f * o - g * n;
        float ep_hm = e * p - h * m;
        float eo_gm = e * o - g * m;
        float en_fm = e * n - f * m;

        result.M13 = +(b * gp_ho - c * fp_hn + d * fo_gn) * invDet;
        result.M23 = -(a * gp_ho - c * ep_hm + d * eo_gm) * invDet;
        result.M33 = +(a * fp_hn - b * ep_hm + d * en_fm) * invDet;
        result.M43 = -(a * fo_gn - b * eo_gm + c * en_fm) * invDet;

        float gl_hk = g * l - h * k;
        float fl_hj = f * l - h * j;
        float fk_gj = f * k - g * j;
        float el_hi = e * l - h * i;
        float ek_gi = e * k - g * i;
        float ej_fi = e * j - f * i;

        result.M14 = -(b * gl_hk - c * fl_hj + d * fk_gj) * invDet;
        result.M24 = +(a * gl_hk - c * el_hi + d * ek_gi) * invDet;
        result.M34 = -(a * fl_hj - b * el_hi + d * ej_fi) * invDet;
        result.M44 = +(a * fk_gj - b * ek_gi + c * ej_fi) * invDet;

        return true;
    }

    public Matrix4x4 Inverted()
    {
        if (Invert(this, out var invertedMatrix))
            return invertedMatrix;

        throw new Exception("Matrix is not invertible.");
    }

    /// <summary>
    /// Transforms the given matrix by applying the given Quaternion rotation.
    /// </summary>
    /// <param name="value">The source matrix to transform.</param>
    /// <param name="rotation">The rotation to apply.</param>
    /// <returns>The transformed matrix.</returns>
    public static Matrix4x4 Transform(Matrix4x4 value, Quaternion rotation)
    {
        // Compute rotation matrix.
        float x2 = rotation.X + rotation.X;
        float y2 = rotation.Y + rotation.Y;
        float z2 = rotation.Z + rotation.Z;

        float wx2 = rotation.W * x2;
        float wy2 = rotation.W * y2;
        float wz2 = rotation.W * z2;
        float xx2 = rotation.X * x2;
        float xy2 = rotation.X * y2;
        float xz2 = rotation.X * z2;
        float yy2 = rotation.Y * y2;
        float yz2 = rotation.Y * z2;
        float zz2 = rotation.Z * z2;

        float q11 = 1.0f - yy2 - zz2;
        float q21 = xy2 - wz2;
        float q31 = xz2 + wy2;

        float q12 = xy2 + wz2;
        float q22 = 1.0f - xx2 - zz2;
        float q32 = yz2 - wx2;

        float q13 = xz2 - wy2;
        float q23 = yz2 + wx2;
        float q33 = 1.0f - xx2 - yy2;

        Matrix4x4 result;

        // First row
        result.M11 = value.M11 * q11 + value.M12 * q21 + value.M13 * q31;
        result.M12 = value.M11 * q12 + value.M12 * q22 + value.M13 * q32;
        result.M13 = value.M11 * q13 + value.M12 * q23 + value.M13 * q33;
        result.M14 = value.M14;

        // Second row
        result.M21 = value.M21 * q11 + value.M22 * q21 + value.M23 * q31;
        result.M22 = value.M21 * q12 + value.M22 * q22 + value.M23 * q32;
        result.M23 = value.M21 * q13 + value.M22 * q23 + value.M23 * q33;
        result.M24 = value.M24;

        // Third row
        result.M31 = value.M31 * q11 + value.M32 * q21 + value.M33 * q31;
        result.M32 = value.M31 * q12 + value.M32 * q22 + value.M33 * q32;
        result.M33 = value.M31 * q13 + value.M32 * q23 + value.M33 * q33;
        result.M34 = value.M34;

        // Fourth row
        result.M41 = value.M41 * q11 + value.M42 * q21 + value.M43 * q31;
        result.M42 = value.M41 * q12 + value.M42 * q22 + value.M43 * q32;
        result.M43 = value.M41 * q13 + value.M42 * q23 + value.M43 * q33;
        result.M44 = value.M44;

        return result;
    }

    /// <summary>
    /// Transposes the rows and columns of a matrix.
    /// </summary>
    /// <param name="matrix">The source matrix.</param>
    /// <returns>The transposed matrix.</returns>
    public static Matrix4x4 Transpose(Matrix4x4 matrix)
    {
        Matrix4x4 result;

        result.M11 = matrix.M11;
        result.M12 = matrix.M21;
        result.M13 = matrix.M31;
        result.M14 = matrix.M41;
        result.M21 = matrix.M12;
        result.M22 = matrix.M22;
        result.M23 = matrix.M32;
        result.M24 = matrix.M42;
        result.M31 = matrix.M13;
        result.M32 = matrix.M23;
        result.M33 = matrix.M33;
        result.M34 = matrix.M43;
        result.M41 = matrix.M14;
        result.M42 = matrix.M24;
        result.M43 = matrix.M34;
        result.M44 = matrix.M44;

        return result;
    }

    /// <summary>
    /// Linearly interpolates between the corresponding values of two matrices.
    /// </summary>
    /// <param name="matrix1">The first source matrix.</param>
    /// <param name="matrix2">The second source matrix.</param>
    /// <param name="amount">The relative weight of the second source matrix.</param>
    /// <returns>The interpolated matrix.</returns>
    public static Matrix4x4 Lerp(Matrix4x4 matrix1, Matrix4x4 matrix2, float amount)
    {
        Matrix4x4 result;

        // First row
        result.M11 = matrix1.M11 + (matrix2.M11 - matrix1.M11) * amount;
        result.M12 = matrix1.M12 + (matrix2.M12 - matrix1.M12) * amount;
        result.M13 = matrix1.M13 + (matrix2.M13 - matrix1.M13) * amount;
        result.M14 = matrix1.M14 + (matrix2.M14 - matrix1.M14) * amount;

        // Second row
        result.M21 = matrix1.M21 + (matrix2.M21 - matrix1.M21) * amount;
        result.M22 = matrix1.M22 + (matrix2.M22 - matrix1.M22) * amount;
        result.M23 = matrix1.M23 + (matrix2.M23 - matrix1.M23) * amount;
        result.M24 = matrix1.M24 + (matrix2.M24 - matrix1.M24) * amount;

        // Third row
        result.M31 = matrix1.M31 + (matrix2.M31 - matrix1.M31) * amount;
        result.M32 = matrix1.M32 + (matrix2.M32 - matrix1.M32) * amount;
        result.M33 = matrix1.M33 + (matrix2.M33 - matrix1.M33) * amount;
        result.M34 = matrix1.M34 + (matrix2.M34 - matrix1.M34) * amount;

        // Fourth row
        result.M41 = matrix1.M41 + (matrix2.M41 - matrix1.M41) * amount;
        result.M42 = matrix1.M42 + (matrix2.M42 - matrix1.M42) * amount;
        result.M43 = matrix1.M43 + (matrix2.M43 - matrix1.M43) * amount;
        result.M44 = matrix1.M44 + (matrix2.M44 - matrix1.M44) * amount;

        return result;
    }

    /// <summary>
    /// Returns a new matrix with the negated elements of the given matrix.
    /// </summary>
    /// <param name="value">The source matrix.</param>
    /// <returns>The negated matrix.</returns>
    public static Matrix4x4 Negate(Matrix4x4 value)
    {
        Matrix4x4 result;

        result.M11 = -value.M11;
        result.M12 = -value.M12;
        result.M13 = -value.M13;
        result.M14 = -value.M14;
        result.M21 = -value.M21;
        result.M22 = -value.M22;
        result.M23 = -value.M23;
        result.M24 = -value.M24;
        result.M31 = -value.M31;
        result.M32 = -value.M32;
        result.M33 = -value.M33;
        result.M34 = -value.M34;
        result.M41 = -value.M41;
        result.M42 = -value.M42;
        result.M43 = -value.M43;
        result.M44 = -value.M44;

        return result;
    }

    /// <summary>
    /// Adds two matrices together.
    /// </summary>
    /// <param name="value1">The first source matrix.</param>
    /// <param name="value2">The second source matrix.</param>
    /// <returns>The resulting matrix.</returns>
    public static Matrix4x4 Add(Matrix4x4 value1, Matrix4x4 value2)
    {
        Matrix4x4 result;

        result.M11 = value1.M11 + value2.M11;
        result.M12 = value1.M12 + value2.M12;
        result.M13 = value1.M13 + value2.M13;
        result.M14 = value1.M14 + value2.M14;
        result.M21 = value1.M21 + value2.M21;
        result.M22 = value1.M22 + value2.M22;
        result.M23 = value1.M23 + value2.M23;
        result.M24 = value1.M24 + value2.M24;
        result.M31 = value1.M31 + value2.M31;
        result.M32 = value1.M32 + value2.M32;
        result.M33 = value1.M33 + value2.M33;
        result.M34 = value1.M34 + value2.M34;
        result.M41 = value1.M41 + value2.M41;
        result.M42 = value1.M42 + value2.M42;
        result.M43 = value1.M43 + value2.M43;
        result.M44 = value1.M44 + value2.M44;

        return result;
    }

    /// <summary>
    /// Subtracts the second matrix from the first.
    /// </summary>
    /// <param name="value1">The first source matrix.</param>
    /// <param name="value2">The second source matrix.</param>
    /// <returns>The result of the subtraction.</returns>
    public static Matrix4x4 Subtract(Matrix4x4 value1, Matrix4x4 value2)
    {
        Matrix4x4 result;

        result.M11 = value1.M11 - value2.M11;
        result.M12 = value1.M12 - value2.M12;
        result.M13 = value1.M13 - value2.M13;
        result.M14 = value1.M14 - value2.M14;
        result.M21 = value1.M21 - value2.M21;
        result.M22 = value1.M22 - value2.M22;
        result.M23 = value1.M23 - value2.M23;
        result.M24 = value1.M24 - value2.M24;
        result.M31 = value1.M31 - value2.M31;
        result.M32 = value1.M32 - value2.M32;
        result.M33 = value1.M33 - value2.M33;
        result.M34 = value1.M34 - value2.M34;
        result.M41 = value1.M41 - value2.M41;
        result.M42 = value1.M42 - value2.M42;
        result.M43 = value1.M43 - value2.M43;
        result.M44 = value1.M44 - value2.M44;

        return result;
    }

    /// <summary>
    /// Multiplies a matrix by another matrix.
    /// </summary>
    /// <param name="value1">The first source matrix.</param>
    /// <param name="value2">The second source matrix.</param>
    /// <returns>The result of the multiplication.</returns>
    public static Matrix4x4 Multiply(Matrix4x4 value1, Matrix4x4 value2)
    {
        Matrix4x4 result;

        // First row
        result.M11 = value1.M11 * value2.M11 + value1.M12 * value2.M21 + value1.M13 * value2.M31 + value1.M14 * value2.M41;

        result.M12 = value1.M11 * value2.M12 + value1.M12 * value2.M22 + value1.M13 * value2.M32 + value1.M14 * value2.M42;

        result.M13 = value1.M11 * value2.M13 + value1.M12 * value2.M23 + value1.M13 * value2.M33 + value1.M14 * value2.M43;

        result.M14 = value1.M11 * value2.M14 + value1.M12 * value2.M24 + value1.M13 * value2.M34 + value1.M14 * value2.M44;

        // Second row
        result.M21 = value1.M21 * value2.M11 + value1.M22 * value2.M21 + value1.M23 * value2.M31 + value1.M24 * value2.M41;

        result.M22 = value1.M21 * value2.M12 + value1.M22 * value2.M22 + value1.M23 * value2.M32 + value1.M24 * value2.M42;

        result.M23 = value1.M21 * value2.M13 + value1.M22 * value2.M23 + value1.M23 * value2.M33 + value1.M24 * value2.M43;

        result.M24 = value1.M21 * value2.M14 + value1.M22 * value2.M24 + value1.M23 * value2.M34 + value1.M24 * value2.M44;

        // Third row
        result.M31 = value1.M31 * value2.M11 + value1.M32 * value2.M21 + value1.M33 * value2.M31 + value1.M34 * value2.M41;

        result.M32 = value1.M31 * value2.M12 + value1.M32 * value2.M22 + value1.M33 * value2.M32 + value1.M34 * value2.M42;

        result.M33 = value1.M31 * value2.M13 + value1.M32 * value2.M23 + value1.M33 * value2.M33 + value1.M34 * value2.M43;

        result.M34 = value1.M31 * value2.M14 + value1.M32 * value2.M24 + value1.M33 * value2.M34 + value1.M34 * value2.M44;

        // Fourth row
        result.M41 = value1.M41 * value2.M11 + value1.M42 * value2.M21 + value1.M43 * value2.M31 + value1.M44 * value2.M41;

        result.M42 = value1.M41 * value2.M12 + value1.M42 * value2.M22 + value1.M43 * value2.M32 + value1.M44 * value2.M42;

        result.M43 = value1.M41 * value2.M13 + value1.M42 * value2.M23 + value1.M43 * value2.M33 + value1.M44 * value2.M43;

        result.M44 = value1.M41 * value2.M14 + value1.M42 * value2.M24 + value1.M43 * value2.M34 + value1.M44 * value2.M44;

        return result;
    }

    /// <summary>
    /// Multiplies a matrix by a scalar value.
    /// </summary>
    /// <param name="value1">The source matrix.</param>
    /// <param name="value2">The scaling factor.</param>
    /// <returns>The scaled matrix.</returns>
    public static Matrix4x4 Multiply(Matrix4x4 value1, float value2)
    {
        Matrix4x4 result;

        result.M11 = value1.M11 * value2;
        result.M12 = value1.M12 * value2;
        result.M13 = value1.M13 * value2;
        result.M14 = value1.M14 * value2;
        result.M21 = value1.M21 * value2;
        result.M22 = value1.M22 * value2;
        result.M23 = value1.M23 * value2;
        result.M24 = value1.M24 * value2;
        result.M31 = value1.M31 * value2;
        result.M32 = value1.M32 * value2;
        result.M33 = value1.M33 * value2;
        result.M34 = value1.M34 * value2;
        result.M41 = value1.M41 * value2;
        result.M42 = value1.M42 * value2;
        result.M43 = value1.M43 * value2;
        result.M44 = value1.M44 * value2;

        return result;
    }

    /// <summary>
    /// Returns a new matrix with the negated elements of the given matrix.
    /// </summary>
    /// <param name="value">The source matrix.</param>
    /// <returns>The negated matrix.</returns>
    public static Matrix4x4 operator -(Matrix4x4 value)
    {
        Matrix4x4 m;

        m.M11 = -value.M11;
        m.M12 = -value.M12;
        m.M13 = -value.M13;
        m.M14 = -value.M14;
        m.M21 = -value.M21;
        m.M22 = -value.M22;
        m.M23 = -value.M23;
        m.M24 = -value.M24;
        m.M31 = -value.M31;
        m.M32 = -value.M32;
        m.M33 = -value.M33;
        m.M34 = -value.M34;
        m.M41 = -value.M41;
        m.M42 = -value.M42;
        m.M43 = -value.M43;
        m.M44 = -value.M44;

        return m;
    }

    /// <summary>
    /// Adds two matrices together.
    /// </summary>
    /// <param name="value1">The first source matrix.</param>
    /// <param name="value2">The second source matrix.</param>
    /// <returns>The resulting matrix.</returns>
    public static Matrix4x4 operator +(Matrix4x4 value1, Matrix4x4 value2)
    {
        Matrix4x4 m;

        m.M11 = value1.M11 + value2.M11;
        m.M12 = value1.M12 + value2.M12;
        m.M13 = value1.M13 + value2.M13;
        m.M14 = value1.M14 + value2.M14;
        m.M21 = value1.M21 + value2.M21;
        m.M22 = value1.M22 + value2.M22;
        m.M23 = value1.M23 + value2.M23;
        m.M24 = value1.M24 + value2.M24;
        m.M31 = value1.M31 + value2.M31;
        m.M32 = value1.M32 + value2.M32;
        m.M33 = value1.M33 + value2.M33;
        m.M34 = value1.M34 + value2.M34;
        m.M41 = value1.M41 + value2.M41;
        m.M42 = value1.M42 + value2.M42;
        m.M43 = value1.M43 + value2.M43;
        m.M44 = value1.M44 + value2.M44;

        return m;
    }

    /// <summary>
    /// Subtracts the second matrix from the first.
    /// </summary>
    /// <param name="value1">The first source matrix.</param>
    /// <param name="value2">The second source matrix.</param>
    /// <returns>The result of the subtraction.</returns>
    public static Matrix4x4 operator -(Matrix4x4 value1, Matrix4x4 value2)
    {
        Matrix4x4 m;

        m.M11 = value1.M11 - value2.M11;
        m.M12 = value1.M12 - value2.M12;
        m.M13 = value1.M13 - value2.M13;
        m.M14 = value1.M14 - value2.M14;
        m.M21 = value1.M21 - value2.M21;
        m.M22 = value1.M22 - value2.M22;
        m.M23 = value1.M23 - value2.M23;
        m.M24 = value1.M24 - value2.M24;
        m.M31 = value1.M31 - value2.M31;
        m.M32 = value1.M32 - value2.M32;
        m.M33 = value1.M33 - value2.M33;
        m.M34 = value1.M34 - value2.M34;
        m.M41 = value1.M41 - value2.M41;
        m.M42 = value1.M42 - value2.M42;
        m.M43 = value1.M43 - value2.M43;
        m.M44 = value1.M44 - value2.M44;

        return m;
    }

    /// <summary>
    /// Multiplies a matrix by another matrix.
    /// </summary>
    /// <param name="value1">The first source matrix.</param>
    /// <param name="value2">The second source matrix.</param>
    /// <returns>The result of the multiplication.</returns>
    public static Matrix4x4 operator *(Matrix4x4 value1, Matrix4x4 value2)
    {
        Matrix4x4 m;

        // First row
        m.M11 = value1.M11 * value2.M11 + value1.M12 * value2.M21 + value1.M13 * value2.M31 + value1.M14 * value2.M41;

        m.M12 = value1.M11 * value2.M12 + value1.M12 * value2.M22 + value1.M13 * value2.M32 + value1.M14 * value2.M42;

        m.M13 = value1.M11 * value2.M13 + value1.M12 * value2.M23 + value1.M13 * value2.M33 + value1.M14 * value2.M43;

        m.M14 = value1.M11 * value2.M14 + value1.M12 * value2.M24 + value1.M13 * value2.M34 + value1.M14 * value2.M44;

        // Second row
        m.M21 = value1.M21 * value2.M11 + value1.M22 * value2.M21 + value1.M23 * value2.M31 + value1.M24 * value2.M41;

        m.M22 = value1.M21 * value2.M12 + value1.M22 * value2.M22 + value1.M23 * value2.M32 + value1.M24 * value2.M42;

        m.M23 = value1.M21 * value2.M13 + value1.M22 * value2.M23 + value1.M23 * value2.M33 + value1.M24 * value2.M43;

        m.M24 = value1.M21 * value2.M14 + value1.M22 * value2.M24 + value1.M23 * value2.M34 + value1.M24 * value2.M44;

        // Third row
        m.M31 = value1.M31 * value2.M11 + value1.M32 * value2.M21 + value1.M33 * value2.M31 + value1.M34 * value2.M41;

        m.M32 = value1.M31 * value2.M12 + value1.M32 * value2.M22 + value1.M33 * value2.M32 + value1.M34 * value2.M42;

        m.M33 = value1.M31 * value2.M13 + value1.M32 * value2.M23 + value1.M33 * value2.M33 + value1.M34 * value2.M43;

        m.M34 = value1.M31 * value2.M14 + value1.M32 * value2.M24 + value1.M33 * value2.M34 + value1.M34 * value2.M44;

        // Fourth row
        m.M41 = value1.M41 * value2.M11 + value1.M42 * value2.M21 + value1.M43 * value2.M31 + value1.M44 * value2.M41;

        m.M42 = value1.M41 * value2.M12 + value1.M42 * value2.M22 + value1.M43 * value2.M32 + value1.M44 * value2.M42;

        m.M43 = value1.M41 * value2.M13 + value1.M42 * value2.M23 + value1.M43 * value2.M33 + value1.M44 * value2.M43;

        m.M44 = value1.M41 * value2.M14 + value1.M42 * value2.M24 + value1.M43 * value2.M34 + value1.M44 * value2.M44;

        return m;
    }

    /// <summary>
    /// Multiplies a matrix by a scalar value.
    /// </summary>
    /// <param name="value1">The source matrix.</param>
    /// <param name="value2">The scaling factor.</param>
    /// <returns>The scaled matrix.</returns>
    public static Matrix4x4 operator *(Matrix4x4 value1, float value2)
    {
        Matrix4x4 m;

        m.M11 = value1.M11 * value2;
        m.M12 = value1.M12 * value2;
        m.M13 = value1.M13 * value2;
        m.M14 = value1.M14 * value2;
        m.M21 = value1.M21 * value2;
        m.M22 = value1.M22 * value2;
        m.M23 = value1.M23 * value2;
        m.M24 = value1.M24 * value2;
        m.M31 = value1.M31 * value2;
        m.M32 = value1.M32 * value2;
        m.M33 = value1.M33 * value2;
        m.M34 = value1.M34 * value2;
        m.M41 = value1.M41 * value2;
        m.M42 = value1.M42 * value2;
        m.M43 = value1.M43 * value2;
        m.M44 = value1.M44 * value2;
        return m;
    }

    /// <summary>
    /// Returns a boolean indicating whether the given two matrices are equal.
    /// </summary>
    /// <param name="value1">The first matrix to compare.</param>
    /// <param name="value2">The second matrix to compare.</param>
    /// <returns>True if the given matrices are equal; False otherwise.</returns>
    public static bool operator ==(Matrix4x4 value1, Matrix4x4 value2)
    {
        return value1.M11 == value2.M11 &&
               value1.M22 == value2.M22 &&
               value1.M33 == value2.M33 &&
               value1.M44 == value2.M44 && // Check diagonal element first for early out.
               value1.M12 == value2.M12 &&
               value1.M13 == value2.M13 &&
               value1.M14 == value2.M14 &&
               value1.M21 == value2.M21 &&
               value1.M23 == value2.M23 &&
               value1.M24 == value2.M24 &&
               value1.M31 == value2.M31 &&
               value1.M32 == value2.M32 &&
               value1.M34 == value2.M34 &&
               value1.M41 == value2.M41 &&
               value1.M42 == value2.M42 &&
               value1.M43 == value2.M43;
    }

    /// <summary>
    /// Returns a boolean indicating whether the given two matrices are not equal.
    /// </summary>
    /// <param name="value1">The first matrix to compare.</param>
    /// <param name="value2">The second matrix to compare.</param>
    /// <returns>True if the given matrices are not equal; False if they are equal.</returns>
    public static bool operator !=(Matrix4x4 value1, Matrix4x4 value2)
    {
        return value1.M11 != value2.M11 ||
               value1.M12 != value2.M12 ||
               value1.M13 != value2.M13 ||
               value1.M14 != value2.M14 ||
               value1.M21 != value2.M21 ||
               value1.M22 != value2.M22 ||
               value1.M23 != value2.M23 ||
               value1.M24 != value2.M24 ||
               value1.M31 != value2.M31 ||
               value1.M32 != value2.M32 ||
               value1.M33 != value2.M33 ||
               value1.M34 != value2.M34 ||
               value1.M41 != value2.M41 ||
               value1.M42 != value2.M42 ||
               value1.M43 != value2.M43 ||
               value1.M44 != value2.M44;
    }

    /// <summary>
    /// Returns a boolean indicating whether this matrix instance is equal to the other given matrix.
    /// </summary>
    /// <param name="other">The matrix to compare this instance to.</param>
    /// <returns>True if the matrices are equal; False otherwise.</returns>
    public bool Equals(Matrix4x4 other)
    {
        return M11 == other.M11 &&
               M22 == other.M22 &&
               M33 == other.M33 &&
               M44 == other.M44 && // Check diagonal element first for early out.
               M12 == other.M12 &&
               M13 == other.M13 &&
               M14 == other.M14 &&
               M21 == other.M21 &&
               M23 == other.M23 &&
               M24 == other.M24 &&
               M31 == other.M31 &&
               M32 == other.M32 &&
               M34 == other.M34 &&
               M41 == other.M41 &&
               M42 == other.M42 &&
               M43 == other.M43;
    }

    /// <summary>
    /// Returns a boolean indicating whether the given Object is equal to this matrix instance.
    /// </summary>
    /// <param name="obj">The Object to compare against.</param>
    /// <returns>True if the Object is equal to this matrix; False otherwise.</returns>
    public override bool Equals(object obj)
    {
        if (obj is Matrix4x4 matrix4)
        {
            return Equals(matrix4);
        }

        return false;
    }

    /// <summary>
    /// Returns a String representing this matrix instance.
    /// </summary>
    /// <returns>The string representation.</returns>
    public override string ToString()
    {
        CultureInfo ci = CultureInfo.CurrentCulture;

        return string.Format(
            ci,
            "{{ {{M11:{0} M12:{1} M13:{2} M14:{3}}} {{M21:{4} M22:{5} M23:{6} M24:{7}}} {{M31:{8} M32:{9} M33:{10} M34:{11}}} {{M41:{12} M42:{13} M43:{14} M44:{15}}} }}",
            M11.ToString(ci), M12.ToString(ci), M13.ToString(ci), M14.ToString(ci), M21.ToString(ci), M22.ToString(ci), M23.ToString(ci),
            M24.ToString(ci), M31.ToString(ci), M32.ToString(ci), M33.ToString(ci), M34.ToString(ci), M41.ToString(ci), M42.ToString(ci),
            M43.ToString(ci), M44.ToString(ci));
    }

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    /// <returns>The hash code.</returns>
    public override int GetHashCode()
    {
        return M11.GetHashCode() +
               M12.GetHashCode() +
               M13.GetHashCode() +
               M14.GetHashCode() +
               M21.GetHashCode() +
               M22.GetHashCode() +
               M23.GetHashCode() +
               M24.GetHashCode() +
               M31.GetHashCode() +
               M32.GetHashCode() +
               M33.GetHashCode() +
               M34.GetHashCode() +
               M41.GetHashCode() +
               M42.GetHashCode() +
               M43.GetHashCode() +
               M44.GetHashCode();
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        // 4 bytes per matrix cell
        var buffer = new List<byte>();
        buffer.AddRange(M11.GetBytes());
        buffer.AddRange(M21.GetBytes());
        buffer.AddRange(M31.GetBytes());
        buffer.AddRange(M41.GetBytes());
        buffer.AddRange(M12.GetBytes());
        buffer.AddRange(M22.GetBytes());
        buffer.AddRange(M32.GetBytes());
        buffer.AddRange(M42.GetBytes());
        buffer.AddRange(M13.GetBytes());
        buffer.AddRange(M23.GetBytes());
        buffer.AddRange(M33.GetBytes());
        buffer.AddRange(M43.GetBytes());
        buffer.AddRange(M14.GetBytes());
        buffer.AddRange(M24.GetBytes());
        buffer.AddRange(M34.GetBytes());
        buffer.AddRange(M44.GetBytes());
        return buffer;
    }
}
