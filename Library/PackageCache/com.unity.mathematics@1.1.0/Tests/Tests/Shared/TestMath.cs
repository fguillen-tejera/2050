using NUnit.Framework;
using static Unity.Mathematics.math;
using Burst.Compiler.IL.Tests;
using System;

namespace Unity.Mathematics.Tests
{
    [TestFixture]
    public partial class TestMath
    {
        [TestCompiler]
        public static void asint_uint()
        {
            TestUtils.AreEqual(asint(0u), 0);
            TestUtils.AreEqual(asint(0x12345678u), 0x12345678);
            TestUtils.AreEqual(asint(0x7FFFFFFFu), 0x7FFFFFFF);
            TestUtils.AreEqual(asint(0x80000000u), -2147483648);
            TestUtils.AreEqual(asint(0x87654321u), -2023406815);
            TestUtils.AreEqual(asint(0xFFFFFFFFu), -1);
        }

        [TestCompiler]
        public static void asint_uint2()
        {
            TestUtils.AreEqual(asint(uint2(0u, 0x12345678u)), int2(0, 0x12345678));
            TestUtils.AreEqual(asint(uint2(0x7FFFFFFFu, 0x80000000u)), int2(0x7FFFFFFF, -2147483648));
            TestUtils.AreEqual(asint(uint2(0x87654321u, 0xFFFFFFFFu)), int2(-2023406815, -1));
        }

        [TestCompiler]
        public static void asint_uint3()
        {
            TestUtils.AreEqual(asint(uint3(0u, 0x12345678u, 0x7FFFFFFFu)), int3(0, 0x12345678, 0x7FFFFFFF));
            TestUtils.AreEqual(asint(uint3(0x80000000u, 0x87654321u, 0xFFFFFFFFu)), int3(-2147483648, -2023406815, -1));
        }

        [TestCompiler]
        public static void asint_uint4()
        {
            TestUtils.AreEqual(asint(uint4(0u, 0x12345678u, 0x7FFFFFFFu, 0x80000000u)), int4(0, 0x12345678, 0x7FFFFFFF, -2147483648));
            TestUtils.AreEqual(asint(uint4(0x87654321u, 0xFFFFFFFFu, 0u, 0u)), int4(-2023406815, -1, 0, 0));
        }

        [TestCompiler]
        public static void asint_float()
        {
            TestUtils.AreEqual(asint(0.0f), 0);
            TestUtils.AreEqual(asint(1.0f), 0x3F800000);
            TestUtils.AreEqual(asint(1234.56f), 0x449A51EC);
            TestUtils.AreEqual(asint(float.PositiveInfinity), 0x7F800000);
            TestUtils.AreEqual(asint(float.NaN), unchecked((int)0xFFC00000));

            TestUtils.AreEqual(asint(-1.0f), unchecked((int)0xBF800000));
            TestUtils.AreEqual(asint(-1234.56f), unchecked((int)0xC49A51EC));
            TestUtils.AreEqual(asint(float.NegativeInfinity), unchecked((int)0xFF800000));
        }

        [TestCompiler]
        [WindowsOnly("Mono on linux ignores signed zero.")]
        public static void asint_float_signed_zero()
        {
            TestUtils.AreEqual(asint(-0.0f), unchecked((int)0x80000000));
        }

        [TestCompiler]
        public static void asint_float2()
        {
            TestUtils.AreEqual(asint(float2(0.0f, 1.0f)), int2(0, 0x3F800000));
            TestUtils.AreEqual(asint(float2(1234.56f, float.PositiveInfinity)), int2(0x449A51EC, 0x7F800000));
            TestUtils.AreEqual(asint(float2(float.NaN, -1.0f)), int2(unchecked((int)0xFFC00000), unchecked((int)0xBF800000)));

            TestUtils.AreEqual(asint(float2(-1234.56f, float.NegativeInfinity)), int2(unchecked((int)0xC49A51EC), unchecked((int)0xFF800000)));
            TestUtils.AreEqual(asint(float2(0.0f, 0.0f)), int2(0, 0));
        }

        [TestCompiler]
        [WindowsOnly("Mono on linux ignores signed zero.")]
        public static void asint_float2_signed_zero()
        {
            TestUtils.AreEqual(asint(float2(-0.0f, -0.0f)), int2(unchecked((int)0x80000000), unchecked((int)0x80000000)));
        }

        [TestCompiler]
        public static void asint_float3()
        {
            TestUtils.AreEqual(asint(float3(0.0f, 1.0f, 1234.56f)), int3(0, 0x3F800000, 0x449A51EC));
            TestUtils.AreEqual(asint(float3(float.PositiveInfinity, float.NaN, -1.0f)), int3(0x7F800000, unchecked((int)0xFFC00000), unchecked((int)0xBF800000)));
            TestUtils.AreEqual(asint(float3(-1234.56f, float.NegativeInfinity, 0.0f)), int3(unchecked((int)0xC49A51EC), unchecked((int)0xFF800000), 0));
        }

        [TestCompiler]
        [WindowsOnly("Mono on linux ignores signed zero.")]
        public static void asint_float3_signed_zero()
        {
            TestUtils.AreEqual(asint(float3(-0.0f, -0.0f, -0.0f)), int3(unchecked((int)0x80000000), unchecked((int)0x80000000), unchecked((int)0x80000000)));
        }

        [TestCompiler]
        public static void asint_float4()
        {
            TestUtils.AreEqual(asint(float4(0.0f, 1.0f, 1234.56f, float.PositiveInfinity)), int4(0, 0x3F800000, 0x449A51EC, 0x7F800000));
            TestUtils.AreEqual(asint(float4(float.NaN, -1.0f, -1234.56f, float.NegativeInfinity)), int4(unchecked((int)0xFFC00000), unchecked((int)0xBF800000), unchecked((int)0xC49A51EC), unchecked((int)0xFF800000)));
        }

        [TestCompiler]
        [WindowsOnly("Mono on linux ignores signed zero.")]
        public static void asint_float4_signed_zero()
        {
            TestUtils.AreEqual(asint(float4(-0.0f, -0.0f, -0.0f, -0.0f)), int4(unchecked((int)0x80000000), unchecked((int)0x80000000), unchecked((int)0x80000000), unchecked((int)0x80000000)));
        }

        [TestCompiler]
        public static void asuint_int()
        {
            TestUtils.AreEqual(asuint(0), 0u);
            TestUtils.AreEqual(asuint(0x12345678), 0x12345678u);
            TestUtils.AreEqual(asuint(0x7FFFFFFF), 0x7FFFFFFFu);
            TestUtils.AreEqual(asuint(-2147483648), 0x80000000u);
            TestUtils.AreEqual(asuint(-2023406815), 0x87654321u);
            TestUtils.AreEqual(asuint(-1), 0xFFFFFFFFu);
        }

        [TestCompiler]
        public static void asuint_int2()
        {
            TestUtils.AreEqual(asuint(int2(0, 0x12345678)), uint2(0u, 0x12345678u));
            TestUtils.AreEqual(asuint(int2(0x7FFFFFFF, -2147483648)), uint2(0x7FFFFFFFu, 0x80000000u));
            TestUtils.AreEqual(asuint(int2(-2023406815, -1)), uint2(0x87654321u, 0xFFFFFFFFu));
        }

        [TestCompiler]
        public static void asuint_int3()
        {
            TestUtils.AreEqual(asuint(int3(0, 0x12345678, 0x7FFFFFFF)), uint3(0u, 0x12345678u, 0x7FFFFFFFu));
            TestUtils.AreEqual(asuint(int3(-2147483648, -2023406815, -1)), uint3(0x80000000u, 0x87654321u, 0xFFFFFFFFu));
        }

        [TestCompiler]
        public static void asuint_int4()
        {
            TestUtils.AreEqual(asuint(int4(0, 0x12345678, 0x7FFFFFFF, -2147483648)), uint4(0u, 0x12345678u, 0x7FFFFFFFu, 0x80000000u));
            TestUtils.AreEqual(asuint(int4(-2023406815, -1, 0, 0)), uint4(0x87654321u, 0xFFFFFFFFu, 0u, 0u));
        }

        [TestCompiler]
        public static void asuint_float()
        {
            TestUtils.AreEqual(asuint(0.0f), 0u);
            TestUtils.AreEqual(asuint(1.0f), 0x3F800000u);
            TestUtils.AreEqual(asuint(1234.56f), 0x449A51ECu);
            TestUtils.AreEqual(asuint(float.PositiveInfinity), 0x7F800000u);
            TestUtils.AreEqual(asuint(float.NaN), 0xFFC00000u);

            TestUtils.AreEqual(asuint(-1.0f), 0xBF800000u);
            TestUtils.AreEqual(asuint(-1234.56f), 0xC49A51ECu);
            TestUtils.AreEqual(asuint(float.NegativeInfinity), 0xFF800000u);
        }

        [TestCompiler]
        [WindowsOnly("Mono on linux ignores signed zero.")]
        public static void asuint_float_signed_zero()
        {
            TestUtils.AreEqual(asuint(-0.0f), 0x80000000u);
        }

        [TestCompiler]
        public static void asuint_float2()
        {
            TestUtils.AreEqual(asuint(float2(0.0f, 1.0f)), uint2(0u, 0x3F800000u));
            TestUtils.AreEqual(asuint(float2(1234.56f, float.PositiveInfinity)), uint2(0x449A51Ecu, 0x7F800000u));
            TestUtils.AreEqual(asuint(float2(float.NaN, -1.0f)), uint2(0xFFC00000u, 0xBF800000u));

            TestUtils.AreEqual(asuint(float2(-1234.56f, float.NegativeInfinity)), uint2(0xC49A51ECu, 0xFF800000u));
        }

        [TestCompiler]
        [WindowsOnly("Mono on linux ignores signed zero.")]
        public static void asuint_float2_signed_zero()
        {
            TestUtils.AreEqual(asuint(float2(-0.0f, -0.0f)), uint2(0x80000000u, 0x80000000u));
        }

        [TestCompiler]
        public static void asuint_float3()
        {
            TestUtils.AreEqual(asuint(float3(0.0f, 1.0f, 1234.56f)), uint3(0u, 0x3F800000u, 0x449A51ECu));
            TestUtils.AreEqual(asuint(float3(float.PositiveInfinity, float.NaN, -1.0f)), uint3(0x7F800000u, 0xFFC00000u, 0xBF800000u));
            TestUtils.AreEqual(asuint(float3(-1234.56f, float.NegativeInfinity, 0.0f)), uint3(0xC49A51ECu, 0xff800000u, 0u));
        }

        [TestCompiler]
        [WindowsOnly("Mono on linux ignores signed zero.")]
        public static void asuint_float3_signed_zero()
        {
            TestUtils.AreEqual(asuint(float3(-0.0f, -0.0f, -0.0f)), uint3(0x80000000u, 0x80000000u, 0x80000000u));
        }

        [TestCompiler]
        public static void asuint_float4()
        {
            TestUtils.AreEqual(asuint(float4(0.0f, 1.0f, 1234.56f, float.PositiveInfinity)), uint4(0u, 0x3F800000u, 0x449A51ECu, 0x7F800000u));
            TestUtils.AreEqual(asuint(float4(float.NaN, -1.0f, -1234.56f, float.NegativeInfinity)), uint4(0xFFC00000u, 0xBF800000u, 0xC49A51ECu, 0xFF800000u));
        }

        [TestCompiler]
        [WindowsOnly("Mono on linux ignores signed zero.")]
        public static void asuint_float4_singed_zero()
        {
            TestUtils.AreEqual(asuint(float4(-0.0f, -0.0f, -0.0f, -0.0f)), uint4(0x80000000u, 0x80000000u, 0x80000000u, 0x80000000u));
        }

        [TestCompiler]
        public static void aslong_ulong()
        {
            TestUtils.AreEqual(aslong(0ul), 0L);
            TestUtils.AreEqual(aslong(0x0123456789ABCDEFul), 0x0123456789ABCDEFL);
            TestUtils.AreEqual(aslong(0x7FFFFFFFFFFFFFFFul), 0x7FFFFFFFFFFFFFFFL);
            TestUtils.AreEqual(aslong(0x8000000000000000ul), -9223372036854775808L);
            TestUtils.AreEqual(aslong(0xFEDCBA9876543210ul), -81985529216486896L);
            TestUtils.AreEqual(aslong(0xFFFFFFFFFFFFFFFFul), -1L);
        }

        [TestCompiler]
        public static void aslong_double()
        {
            TestUtils.AreEqual(aslong(0.0), 0L);
            TestUtils.AreEqual(aslong(1.0), 0x3FF0000000000000L);
            TestUtils.AreEqual(aslong(1234.56), 0x40934A3D70A3D70AL);
            TestUtils.AreEqual(aslong(double.PositiveInfinity), 0x7FF0000000000000L);
            TestUtils.AreEqual(aslong(double.NaN), unchecked((long)0xFFF8000000000000UL));

            TestUtils.AreEqual(aslong(-1.0), unchecked((long)0xBFF0000000000000UL));
            TestUtils.AreEqual(aslong(-1234.56), unchecked((long)0xC0934A3D70A3D70AUL));
            TestUtils.AreEqual(aslong(double.NegativeInfinity), unchecked((long)0xFFF0000000000000UL));
        }

        [TestCompiler]
        [WindowsOnly("Mono on linux ignores signed zero.")]
        public static void aslong_double_signed_zero()
        {
            TestUtils.AreEqual(aslong(-0.0), unchecked((long)0x8000000000000000UL));
        }

        [TestCompiler]
        public static void asulong_long()
        {
            TestUtils.AreEqual(asulong(0L), 0ul);
            TestUtils.AreEqual(asulong(0x0123456789ABCDEFL), 0x0123456789ABCDEFul);
            TestUtils.AreEqual(asulong(0x7FFFFFFFFFFFFFFFL), 0x7FFFFFFFFFFFFFFFul);
            TestUtils.AreEqual(asulong(-9223372036854775808L), 0x8000000000000000ul);
            TestUtils.AreEqual(asulong(-81985529216486896L), 0xFEDCBA9876543210ul);
            TestUtils.AreEqual(asulong(-1L), 0xFFFFFFFFFFFFFFFFul);
        }

        [TestCompiler]
        public static void asulong_double()
        {
            TestUtils.AreEqual(asulong(0.0), 0UL);
            TestUtils.AreEqual(asulong(1.0), 0x3FF0000000000000UL);
            TestUtils.AreEqual(asulong(1234.56), 0x40934A3D70A3D70AUL);
            TestUtils.AreEqual(asulong(double.PositiveInfinity), 0x7FF0000000000000UL);
            TestUtils.AreEqual(asulong(double.NaN), 0xFFF8000000000000UL);

            TestUtils.AreEqual(asulong(-1.0), 0xBFF0000000000000UL);
            TestUtils.AreEqual(asulong(-1234.56), 0xC0934A3D70A3D70AUL);
            TestUtils.AreEqual(asulong(double.NegativeInfinity), 0xFFF0000000000000UL);
        }

        [TestCompiler]
        [WindowsOnly("Mono on linux ignores signed zero.")]
        public static void asulong_double_signed_zero()
        {
            TestUtils.AreEqual(asulong(-0.0), 0x8000000000000000UL);
        }

        [TestCompiler]
        public static void asfloat_int()
        {
            TestUtils.AreEqual(asfloat(0), 0.0f);
            TestUtils.AreEqual(asfloat(0x3F800000), 1.0f);
            TestUtils.AreEqual(asfloat(0x449A51EC), 1234.56f);
            TestUtils.AreEqual(asfloat(0x7F800000), float.PositiveInfinity);
            TestUtils.AreEqual(asfloat(unchecked((int)0x80000000)), -0.0f);
            TestUtils.AreEqual(asfloat(unchecked((int)0xBF800000)), -1.0f);
            TestUtils.AreEqual(asfloat(unchecked((int)0xC49A51EC)), -1234.56f);
            TestUtils.AreEqual(asfloat(unchecked((int)0xFF800000)), float.NegativeInfinity);

            TestUtils.AreEqual(asuint(asfloat(unchecked((int)0xFFC00000))), asuint(float.NaN));
        }

        [TestCompiler]
        public static void asfloat_int2()
        {
            TestUtils.AreEqual(asfloat(int2(0, 0x3F800000)), float2(0.0f, 1.0f));
            TestUtils.AreEqual(asfloat(int2(0x449A51EC, 0x7F800000)), float2(1234.56f, float.PositiveInfinity));
            TestUtils.AreEqual(asfloat(int2(unchecked((int)0x80000000), unchecked((int)0xBF800000))), float2(-0.0f, -1.0f));

            TestUtils.AreEqual(asfloat(int2(unchecked((int)0xC49A51EC), unchecked((int)0xFF800000))), float2(-1234.56f, float.NegativeInfinity));
            TestUtils.AreEqual(asuint(asfloat(int2(unchecked((int)0xFFC00000), unchecked((int)0xFFC00000)))), asuint(float2(float.NaN, float.NaN)));
        }

        [TestCompiler]
        public static void asfloat_int3()
        {
            TestUtils.AreEqual(asfloat(int3(0, 0x3F800000, 0x449A51EC)), float3(0.0f, 1.0f, 1234.56f));
            TestUtils.AreEqual(asfloat(int3(0x7F800000, unchecked((int)0x80000000), unchecked((int)0xBF800000))), float3(float.PositiveInfinity, -0.0f, -1.0f));

            TestUtils.AreEqual(asfloat(int3(unchecked((int)0xC49A51EC), unchecked((int)0xFF800000), 0)), float3(-1234.56f, float.NegativeInfinity, 0.0f));
            TestUtils.AreEqual(asuint(asfloat(int3(unchecked((int)0xFFC00000), unchecked((int)0xFFC00000), unchecked((int)0xFFC00000)))), asuint(float3(float.NaN, float.NaN, float.NaN)));
        }

        [TestCompiler]
        public static void asfloat_int4()
        {
            TestUtils.AreEqual(asfloat(int4(0, 0x3F800000, 0x449A51EC, 0x7F800000)), float4(0.0f, 1.0f, 1234.56f, float.PositiveInfinity));
            TestUtils.AreEqual(asfloat(int4(unchecked((int)0x80000000), unchecked((int)0xBF800000), unchecked((int)0xC49A51EC), unchecked((int)0xFF800000))), float4(-0.0f, -1.0f, -1234.56f, float.NegativeInfinity));

            TestUtils.AreEqual(asuint(asfloat(int4(unchecked((int)0xFFC00000), unchecked((int)0xFFC00000), unchecked((int)0xFFC00000), unchecked((int)0xFFC00000)))), asuint(float4(float.NaN, float.NaN, float.NaN, float.NaN)));
        }

        [TestCompiler]
        public static void asfloat_uint()
        {
            TestUtils.AreEqual(asfloat(0u), 0.0f);
            TestUtils.AreEqual(asfloat(0x3F800000u), 1.0f);
            TestUtils.AreEqual(asfloat(0x449A51ECu), 1234.56f);
            TestUtils.AreEqual(asfloat(0x7F800000u), float.PositiveInfinity);
            TestUtils.AreEqual(asfloat(0x80000000u), -0.0f);
            TestUtils.AreEqual(asfloat(0xBF800000u), -1.0f);
            TestUtils.AreEqual(asfloat(0xC49A51ECu), -1234.56f);
            TestUtils.AreEqual(asfloat(0xFF800000u), float.NegativeInfinity);

            TestUtils.AreEqual(asuint(asfloat(0xFFC00000u)), asuint(float.NaN));
        }

        [TestCompiler]
        public static void asfloat_uint2()
        {
            TestUtils.AreEqual(asfloat(uint2(0u, 0x3F800000u)), float2(0.0f, 1.0f));
            TestUtils.AreEqual(asfloat(uint2(0x449A51ECu, 0x7F800000u)), float2(1234.56f, float.PositiveInfinity));
            TestUtils.AreEqual(asfloat(uint2(0x80000000u, 0xBF800000u)), float2(-0.0f, -1.0f));

            TestUtils.AreEqual(asfloat(uint2(0xC49A51ECu, 0xFF800000u)), float2(-1234.56f, float.NegativeInfinity));
            TestUtils.AreEqual(asuint(asfloat(uint2(0xFFC00000u, 0xFFC00000u))), asuint(float2(float.NaN, float.NaN)));
        }

        [TestCompiler]
        public static void asfloat_uint3()
        {
            TestUtils.AreEqual(asfloat(uint3(0u, 0x3F800000u, 0x449A51ECu)), float3(0.0f, 1.0f, 1234.56f));
            TestUtils.AreEqual(asfloat(uint3(0x7F800000u, 0x80000000u, 0xBF800000u)), float3(float.PositiveInfinity, -0.0f, -1.0f));

            TestUtils.AreEqual(asfloat(uint3(0xC49A51ECu, 0xFF800000u, 0u)), float3(-1234.56f, float.NegativeInfinity, 0.0f));
            TestUtils.AreEqual(asuint(asfloat(uint3(0xFFC00000u, 0xFFC00000u, 0xFFC00000u))), asuint(float3(float.NaN, float.NaN, float.NaN)));
        }

        [TestCompiler]
        public static void asfloat_uint4()
        {
            TestUtils.AreEqual(asfloat(uint4(0u, 0x3F800000u, 0x449A51ECu, 0x7F800000u)), float4(0.0f, 1.0f, 1234.56f, float.PositiveInfinity));
            TestUtils.AreEqual(asfloat(uint4(0x80000000u, 0xBF800000u, 0xC49A51ECu, 0xFF800000u)), float4(-0.0f, -1.0f, -1234.56f, float.NegativeInfinity));

            TestUtils.AreEqual(asuint(asfloat(uint4(0xFFC00000u, 0xFFC00000u, 0xFFC00000u, 0xFFC00000u))), asuint(float4(float.NaN, float.NaN, float.NaN, float.NaN)));
        }

        [TestCompiler]
        public static void asdouble_long()
        {
            TestUtils.AreEqual(asdouble(0L), 0.0);
            TestUtils.AreEqual(asdouble(0x3FF0000000000000L), 1.0);
            TestUtils.AreEqual(asdouble(0x40934A3D70A3D70AL), 1234.56);
            TestUtils.AreEqual(asdouble(0x7FF0000000000000L), double.PositiveInfinity);
            TestUtils.AreEqual(asdouble(unchecked((long)0xFFF8000000000000UL)), double.NaN);

            TestUtils.AreEqual(asdouble(unchecked((long)0x8000000000000000UL)), -0.0);
            TestUtils.AreEqual(asdouble(unchecked((long)0xBFF0000000000000UL)), -1.0);
            TestUtils.AreEqual(asdouble(unchecked((long)0xC0934A3D70A3D70AUL)), -1234.56);
            TestUtils.AreEqual(asdouble(unchecked((long)0xFFF0000000000000UL)), double.NegativeInfinity);
        }

        [TestCompiler]
        public static void asdouble_ulong()
        {
            TestUtils.AreEqual(asdouble(0UL), 0.0);
            TestUtils.AreEqual(asdouble(0x3FF0000000000000UL), 1.0);
            TestUtils.AreEqual(asdouble(0x40934A3D70A3D70AUL), 1234.56);
            TestUtils.AreEqual(asdouble(0x7FF0000000000000UL), double.PositiveInfinity);
            TestUtils.AreEqual(asdouble(0xFFF8000000000000UL), double.NaN);

            TestUtils.AreEqual(asdouble(0x8000000000000000UL), -0.0);
            TestUtils.AreEqual(asdouble(0xBFF0000000000000UL), -1.0);
            TestUtils.AreEqual(asdouble(0xC0934A3D70A3D70AUL), -1234.56);
            TestUtils.AreEqual(asdouble(0xFFF0000000000000UL), double.NegativeInfinity);
        }

        [TestCompiler]
        public static void faceforward_float2()
        {
            TestUtils.AreEqual(faceforward(float2(3.5f, -4.5f), float2(1.0f, -2.0f), float2(3.0f, -4.0f)), float2(-3.5f, 4.5f));
            TestUtils.AreEqual(faceforward(float2(3.5f, -4.5f), float2(1.0f, -2.0f), float2(-3.0f, 4.0f)), float2(3.5f, -4.5f));
            TestUtils.AreEqual(faceforward(float2(3.5f, -4.5f), float2(1.0f, -2.0f), float2(0.0f, 0.0f)), float2(-3.5f, 4.5f));
        }

        [TestCompiler]
        public static void faceforward_float3()
        {
            TestUtils.AreEqual(faceforward(float3(3.5f, -4.5f, 5.5f), float3(1.0f, -2.0f, 3.0f), float3(3.0f, -4.0f, 5.0f)), float3(-3.5f, 4.5f, -5.5f));
            TestUtils.AreEqual(faceforward(float3(3.5f, -4.5f, 5.5f), float3(1.0f, -2.0f, 3.0f), float3(-3.0f, 4.0f, -5.0f)), float3(3.5f, -4.5f, 5.5f));
            TestUtils.AreEqual(faceforward(float3(3.5f, -4.5f, 5.5f), float3(1.0f, -2.0f, 3.0f), float3(0.0f, 0.0f, 0.0f)), float3(-3.5f, 4.5f, -5.5f));
        }

        [TestCompiler]
        public static void faceforward_float4()
        {
            TestUtils.AreEqual(faceforward(float4(3.5f, -4.5f, 5.5f, -6.5f), float4(1.0f, -2.0f, 3.0f, -4.0f), float4(3.0f, -4.0f, 5.0f, -6.0f)), float4(-3.5f, 4.5f, -5.5f, 6.5f));
            TestUtils.AreEqual(faceforward(float4(3.5f, -4.5f, 5.5f, -6.5f), float4(1.0f, -2.0f, 3.0f, -4.0f), float4(-3.0f, 4.0f, -5.0f, 6.0f)), float4(3.5f, -4.5f, 5.5f, -6.5f));
            TestUtils.AreEqual(faceforward(float4(3.5f, -4.5f, 5.5f, -6.5f), float4(1.0f, -2.0f, 3.0f, -4.0f), float4(0.0f, 0.0f, 0.0f, 0.0f)), float4(-3.5f, 4.5f, -5.5f, 6.5f));
        }

        [TestCompiler]
        public static void faceforward_double2()
        {
            TestUtils.AreEqual(faceforward(double2(3.5, -4.5), double2(1.0, -2.0), double2(3.0, -4.0)), double2(-3.5, 4.5));
            TestUtils.AreEqual(faceforward(double2(3.5, -4.5), double2(1.0, -2.0), double2(-3.0, 4.0)), double2(3.5, -4.5));
            TestUtils.AreEqual(faceforward(double2(3.5, -4.5), double2(1.0, -2.0), double2(0.0, 0.0)), double2(-3.5, 4.5));
        }

        [TestCompiler]
        public static void faceforward_double3()
        {
            TestUtils.AreEqual(faceforward(double3(3.5, -4.5, 5.5), double3(1.0, -2.0, 3.0), double3(3.0, -4.0, 5.0)), double3(-3.5, 4.5, -5.5));
            TestUtils.AreEqual(faceforward(double3(3.5, -4.5, 5.5), double3(1.0, -2.0, 3.0), double3(-3.0, 4.0, -5.0)), double3(3.5, -4.5, 5.5));
            TestUtils.AreEqual(faceforward(double3(3.5, -4.5, 5.5), double3(1.0, -2.0, 3.0), double3(0.0, 0.0, 0.0)), double3(-3.5, 4.5, -5.5));
        }

        [TestCompiler]
        public static void faceforward_double4()
        {
            TestUtils.AreEqual(faceforward(double4(3.5, -4.5, 5.5, -6.5), double4(1.0, -2.0, 3.0, -4.0), double4(3.0, -4.0, 5.0, -6.0)), double4(-3.5, 4.5, -5.5, 6.5));
            TestUtils.AreEqual(faceforward(double4(3.5, -4.5, 5.5, -6.5), double4(1.0, -2.0, 3.0, -4.0), double4(-3.0, 4.0, -5.0, 6.0)), double4(3.5, -4.5, 5.5, -6.5));
            TestUtils.AreEqual(faceforward(double4(3.5, -4.5, 5.5, -6.5), double4(1.0, -2.0, 3.0, -4.0), double4(0.0, 0.0, 0.0, 0.0)), double4(-3.5, 4.5, -5.5, 6.5));
        }

        [TestCompiler]
        public static void modf_float()
        {
            float f, i;
            f = modf(313.75f, out i);
            TestUtils.AreEqual(i, 313.0f);
            TestUtils.AreEqual(f, 0.75f);

            f = modf(-313.25f, out i);
            TestUtils.AreEqual(i, -313.0f);
            TestUtils.AreEqual(f, -0.25f);

            f = modf(-314.0f, out i);
            TestUtils.AreEqual(i, -314.0f);
            TestUtils.AreEqual(f, 0.0f);
        }

        [TestCompiler]
        public static void modf_float2()
        {
            float2 f, i;
            f = modf(float2(313.75f, -313.25f), out i);
            TestUtils.AreEqual(i, float2(313.0f, -313.0f));
            TestUtils.AreEqual(f, float2(0.75f, -0.25f));

            f = modf(float2(-314.0f, 7.5f), out i);
            TestUtils.AreEqual(i, float2(-314.0f, 7.0f));
            TestUtils.AreEqual(f, float2(0.0f, 0.5f));
        }

        [TestCompiler]
        public static void modf_float3()
        {
            float3 f, i;
            f = modf(float3(313.75f, -313.25f, -314.0f), out i);
            TestUtils.AreEqual(i, float3(313.0f, -313.0f, -314.0f));
            TestUtils.AreEqual(f, float3(0.75f, -0.25f, 0.0f));
        }

        [TestCompiler]
        public static void modf_float4()
        {
            float4 f, i;
            f = modf(float4(313.75f, -313.25f, -314.0f, 7.5f), out i);
            TestUtils.AreEqual(i, float4(313.0f, -313.0f, -314.0f, 7.0f));
            TestUtils.AreEqual(f, float4(0.75f, -0.25f, 0.0f, 0.5f));
        }

        [TestCompiler]
        public static void modf_double()
        {
            double f, i;
            f = modf(313.75, out i);
            TestUtils.AreEqual(i, 313.0);
            TestUtils.AreEqual(f, 0.75);

            f = modf(-313.25, out i);
            TestUtils.AreEqual(i, -313.0);
            TestUtils.AreEqual(f, -0.25);

            f = modf(-314.0, out i);
            TestUtils.AreEqual(i, -314.0);
            TestUtils.AreEqual(f, 0.0);
        }

        [TestCompiler]
        public static void modf_double2()
        {
            double2 f, i;
            f = modf(double2(313.75, -313.25), out i);
            TestUtils.AreEqual(i, double2(313.0, -313.0));
            TestUtils.AreEqual(f, double2(0.75, -0.25));

            f = modf(double2(-314.0, 7.5), out i);
            TestUtils.AreEqual(i, double2(-314.0, 7.0));
            TestUtils.AreEqual(f, double2(0.0, 0.5));
        }

        [TestCompiler]
        public static void modf_double3()
        {
            double3 f, i;
            f = modf(double3(313.75, -313.25, -314.0), out i);
            TestUtils.AreEqual(i, double3(313.0, -313.0, -314.0));
            TestUtils.AreEqual(f, double3(0.75, -0.25, 0.0));
        }

        [TestCompiler]
        public static void modf_double4()
        {
            double4 f, i;
            f = modf(double4(313.75, -313.25, -314.0, 7.5), out i);
            TestUtils.AreEqual(i, double4(313.0, -313.0, -314.0, 7.0));
            TestUtils.AreEqual(f, double4(0.75, -0.25, 0.0, 0.5f));
        }

        [TestCompiler]
        public static void normalize_float2()
        {
            TestUtils.AreEqual(normalize(float2(3.1f, -5.3f)), float2(0.504883f, -0.863188f), 0.0001f);
            TestUtils.AreEqual(all(isnan(normalize(float2(0.0f, 0.0f)))), true);
        }

        [TestCompiler]
        public static void normalize_float3()
        {
            TestUtils.AreEqual(normalizesafe(float3(3.1f, -5.3f, 2.6f)), float3(0.464916f, -0.794861f, 0.389932f), 0.0001f);
            TestUtils.AreEqual(all(isnan(normalize(float3(0.0f, 0.0f, 0.0f)))), true);
        }

        [TestCompiler]
        public static void normalize_float4()
        {
            TestUtils.AreEqual(normalizesafe(float4(3.1f, -5.3f, 2.6f, 11.4f)), float4(0.234727f, -0.401308f, 0.196868f, 0.863191f), 0.0001f);
            TestUtils.AreEqual(all(isnan(normalize(float4(0.0f, 0.0f, 0.0f, 0.0f)))), true);
        }


        [TestCompiler]
        public static void normalize_double2()
        {
            TestUtils.AreEqual(normalize(double2(3.1, -5.3)), double2(0.504883, -0.863188), 0.0001);
            TestUtils.AreEqual(all(isnan(normalize(double2(0.0, 0.0)))), true);
        }

        [TestCompiler]
        public static void normalize_double3()
        {
            TestUtils.AreEqual(normalizesafe(double3(3.1, -5.3, 2.6)), double3(0.464916, -0.794861, 0.389932), 0.0001);
            TestUtils.AreEqual(all(isnan(normalize(double3(0.0, 0.0, 0.0)))), true);
        }

        [TestCompiler]
        public static void normalize_double4()
        {
            TestUtils.AreEqual(normalizesafe(double4(3.1, -5.3, 2.6, 11.4)), double4(0.234727, -0.401308, 0.196868, 0.863191), 0.0001);
            TestUtils.AreEqual(all(isnan(normalize(double4(0.0, 0.0, 0.0, 0.0f)))), true);
        }

        [TestCompiler]
        public static void normalize_quaternion()
        {
            TestUtils.AreEqual(normalizesafe(quaternion(3.1f, -5.3f, 2.6f, 11.4f)), quaternion(0.234727f, -0.401308f, 0.196868f, 0.863191f), 0.0001f);
            TestUtils.AreEqual(all(isnan(normalize(quaternion(0.0f, 0.0f, 0.0f, 0.0f)).value)), true);
        }


        [TestCompiler]
        public static void normalizesafe_float2()
        {
            TestUtils.AreEqual(normalizesafe(float2(3.1f, -5.3f)), float2(0.504883f, -0.863188f), 0.0001f);
            TestUtils.AreEqual(normalizesafe(float2(0.0f, 0.0f)), float2(0.0f, 0.0f));
            TestUtils.AreEqual(normalizesafe(float2(0.0f, 0.0f), float2(1.0f, 2.0f)), float2(1.0f, 2.0f));
            TestUtils.AreEqual(normalizesafe(float2(1e-18f, 2e-18f)), float2(0.447214f, 0.894427f), 0.0001f);
            TestUtils.AreEqual(normalizesafe(float2(7.66e-20f, 7.66e-20f), float2(1.0f, 2.0f)), float2(1.0f, 2.0f));
        }

        [TestCompiler]
        public static void normalizesafe_float3()
        {
            TestUtils.AreEqual(normalizesafe(float3(3.1f, -5.3f, 2.6f)), float3(0.464916f, -0.794861f, 0.389932f), 0.0001f);
            TestUtils.AreEqual(normalizesafe(float3(0.0f, 0.0f, 0.0f)), float3(0.0f, 0.0f, 0.0f));
            TestUtils.AreEqual(normalizesafe(float3(0.0f, 0.0f, 0.0f), float3(1.0f, 2.0f, 3.0f)), float3(1.0f, 2.0f, 3.0f));
            TestUtils.AreEqual(normalizesafe(float3(1e-19f, 2e-19f, 3e-19f)), float3(0.267261f, 0.534523f, 0.801784f), 0.0001f);
            TestUtils.AreEqual(normalizesafe(float3(6.25e-20f, 6.25e-20f, 6.25e-20f), float3(1.0f, 2.0f, 3.0f)), float3(1.0f, 2.0f, 3.0f));
        }

        [TestCompiler]
        public static void normalizesafe_float4()
        {
            TestUtils.AreEqual(normalizesafe(float4(3.1f, -5.3f, 2.6f, 11.4f)), float4(0.234727f, -0.401308f, 0.196868f, 0.863191f), 0.0001f);
            TestUtils.AreEqual(normalizesafe(float4(0.0f, 0.0f, 0.0f, 0.0f)), float4(0.0f, 0.0f, 0.0f, 0.0f));
            TestUtils.AreEqual(normalizesafe(float4(0.0f, 0.0f, 0.0f, 0.0f), float4(1.0f, 2.0f, 3.0f, 4.0f)), float4(1.0f, 2.0f, 3.0f, 4.0f));
            TestUtils.AreEqual(normalizesafe(float4(1e-19f, 2e-19f, 3e-19f, 4e-19f)), float4(0.182574f, 0.3651484f, 0.547723f, 0.730297f), 0.0001f);
            TestUtils.AreEqual(normalizesafe(float4(5.42e-20f, 5.42e-20f, 5.42e-20f, 5.42e-20f), float4(1.0f, 2.0f, 3.0f, 4.0f)), float4(1.0f, 2.0f, 3.0f, 4.0f));
        }


        [TestCompiler]
        public static void normalizesafe_double2()
        {
            TestUtils.AreEqual(normalizesafe(double2(3.1, -5.3)), double2(0.504883, -0.863188), 0.0001);
            TestUtils.AreEqual(normalizesafe(double2(0.0, 0.0)), double2(0.0, 0.0));
            TestUtils.AreEqual(normalizesafe(double2(0.0, 0.0), double2(1.0, 2.0)), double2(1.0, 2.0));
            TestUtils.AreEqual(normalizesafe(double2(1e-18, 2e-18)), double2(0.447214, 0.894427), 0.0001);
            TestUtils.AreEqual(normalizesafe(double2(1.05e-154, 1.05e-154), double2(1.0, 2.0)), double2(1.0, 2.0));
        }

        [TestCompiler]
        public static void normalizesafe_double3()
        {
            TestUtils.AreEqual(normalizesafe(double3(3.1, -5.3, 2.6)), double3(0.464916, -0.794861, 0.389932), 0.0001);
            TestUtils.AreEqual(normalizesafe(double3(0.0, 0.0, 0.0)), double3(0.0, 0.0, 0.0));
            TestUtils.AreEqual(normalizesafe(double3(0.0, 0.0, 0.0), double3(1.0, 2.0, 3.0)), double3(1.0, 2.0, 3.0));
            TestUtils.AreEqual(normalizesafe(double3(1e-19, 2e-19, 3e-19)), double3(0.267261, 0.534523, 0.801784), 0.0001);
            TestUtils.AreEqual(normalizesafe(double3(8.61e-155, 8.61e-155, 8.61e-155), double3(1.0, 2.0, 3.0)), double3(1.0, 2.0, 3.0));
        }

        [TestCompiler]
        public static void normalizesafe_double4()
        {
            TestUtils.AreEqual(normalizesafe(double4(3.1, -5.3, 2.6, 11.4)), double4(0.234727, -0.401308, 0.196868, 0.863191), 0.0001);
            TestUtils.AreEqual(normalizesafe(double4(0.0, 0.0, 0.0, 0.0)), double4(0.0, 0.0, 0.0, 0.0));
            TestUtils.AreEqual(normalizesafe(double4(0.0, 0.0, 0.0, 0.0), double4(1.0, 2.0, 3.0, 4.0)), double4(1.0, 2.0, 3.0, 4.0));
            TestUtils.AreEqual(normalizesafe(double4(1e-19, 2e-19, 3e-19, 4e-19)), double4(0.182574, 0.3651484, 0.547723, 0.730297), 0.0001);
            TestUtils.AreEqual(normalizesafe(double4(7.45e-155, 7.45e-155, 7.45e-155, 7.45e-155), double4(1.0, 2.0, 3.0, 4.0)), double4(1.0, 2.0, 3.0, 4.0));
        }

        [TestCompiler]
        public static void normalizesafe_quaternion()
        {
            TestUtils.AreEqual(normalizesafe(quaternion(3.1f, -5.3f, 2.6f, 11.4f)), quaternion(0.234727f, -0.401308f, 0.196868f, 0.863191f), 0.0001f);
            TestUtils.AreEqual(normalizesafe(quaternion(0.0f, 0.0f, 0.0f, 0.0f)), quaternion(0.0f, 0.0f, 0.0f, 1.0f));
            TestUtils.AreEqual(normalizesafe(quaternion(0.0f, 0.0f, 0.0f, 0.0f), quaternion(1.0f, 2.0f, 3.0f, 4.0f)), quaternion(1.0f, 2.0f, 3.0f, 4.0f));
            TestUtils.AreEqual(normalizesafe(quaternion(1e-19f, 2e-19f, 3e-19f, 4e-19f)), quaternion(0.182574f, 0.3651484f, 0.547723f, 0.730297f), 0.0001f);
            TestUtils.AreEqual(normalizesafe(quaternion(5.42e-20f, 5.42e-20f, 5.42e-20f, 5.42e-20f), quaternion(1.0f, 2.0f, 3.0f, 4.0f)), quaternion(1.0f, 2.0f, 3.0f, 4.0f));
        }

        [TestCompiler]
        public static void f16tof32_float()
        {
            TestUtils.AreEqual(asuint(f16tof32(0x0000)), 0x00000000);
            TestUtils.AreEqual(asuint(f16tof32(0x0203)), 0x3800C000);
            TestUtils.AreEqual(asuint(f16tof32(0x4321)), 0x40642000);
            TestUtils.AreEqual(asuint(f16tof32(0x7BFF)), 0x477FE000);
            TestUtils.AreEqual(asuint(f16tof32(0x7C00)), 0x7F800000);
            TestUtils.AreEqual(isnan(f16tof32(0x7C01)), true);

            TestUtils.AreEqual(asuint(f16tof32(0x8000)), 0x80000000);
            TestUtils.AreEqual(asuint(f16tof32(0x8203)), 0xB800C000);
            TestUtils.AreEqual(asuint(f16tof32(0xC321)), 0xC0642000);
            TestUtils.AreEqual(asuint(f16tof32(0xFBFF)), 0xC77FE000);
            TestUtils.AreEqual(asuint(f16tof32(0xFC00)), 0xFF800000);
            TestUtils.AreEqual(isnan(f16tof32(0xFC01)), true);
        }

        [TestCompiler]
        public static void f16tof32_float2()
        {
            TestUtils.AreEqual(asuint(f16tof32(uint2(0x0000, 0x0203))), uint2(0x00000000, 0x3800C000));
            TestUtils.AreEqual(asuint(f16tof32(uint2(0x4321, 0x7BFF))), uint2(0x40642000, 0x477FE000));
            TestUtils.AreEqual(asuint(f16tof32(uint2(0x7C00, 0x7C00))), uint2(0x7F800000, 0x7F800000));
            TestUtils.AreEqual(all(isnan(f16tof32(uint2(0x7C01, 0x7C01)))), true);

            TestUtils.AreEqual(asuint(f16tof32(uint2(0x8000, 0x8203))), uint2(0x80000000, 0xB800C000));
            TestUtils.AreEqual(asuint(f16tof32(uint2(0xC321, 0xFBFF))), uint2(0xC0642000, 0xC77FE000));
            TestUtils.AreEqual(asuint(f16tof32(uint2(0xFC00, 0xFC00))), uint2(0xFF800000, 0xFF800000));
            TestUtils.AreEqual(all(isnan(f16tof32(uint2(0xFC01, 0xFC01)))), true);
        }

        [TestCompiler]
        public static void f16tof32_float3()
        {
            TestUtils.AreEqual(asuint(f16tof32(uint3(0x0000, 0x0203, 0x4321))), uint3(0x00000000, 0x3800C000, 0x40642000));
            TestUtils.AreEqual(asuint(f16tof32(uint3(0x7BFF, 0x7C00, 0x7C00))), uint3(0x477FE000, 0x7F800000, 0x7F800000));
            TestUtils.AreEqual(all(isnan(f16tof32(uint3(0x7C01, 0x7C01, 0x7C01)))), true);

            TestUtils.AreEqual(asuint(f16tof32(uint3(0x8000, 0x8203, 0xC321))), uint3(0x80000000, 0xB800C000, 0xC0642000));
            TestUtils.AreEqual(asuint(f16tof32(uint3(0xFBFF, 0xFC00, 0xFC00))), uint3(0xC77FE000, 0xFF800000, 0xFF800000));
            TestUtils.AreEqual(all(isnan(f16tof32(uint3(0xFC01, 0xFC01, 0xFC01)))), true);
        }

        [TestCompiler]
        public static void f16tof32_float4()
        {
            TestUtils.AreEqual(asuint(f16tof32(uint4(0x0000, 0x0203, 0x4321, 0x7BFF))), uint4(0x00000000, 0x3800C000, 0x40642000, 0x477FE000));
            TestUtils.AreEqual(asuint(f16tof32(uint4(0x7C00, 0x7C00, 0x7C00, 0x7C00))), uint4(0x7F800000, 0x7F800000, 0x7F800000, 0x7F800000));
            TestUtils.AreEqual(all(isnan(f16tof32(uint4(0x7C01, 0x7C01, 0x7C01, 0x7C01)))), true);

            TestUtils.AreEqual(asuint(f16tof32(uint4(0x8000, 0x8203, 0xC321, 0xFBFF))), uint4(0x80000000, 0xB800C000, 0xC0642000, 0xC77FE000));
            TestUtils.AreEqual(asuint(f16tof32(uint4(0xFC00, 0xFC00, 0xFC00, 0xFC00))), uint4(0xFF800000, 0xFF800000, 0xFF800000, 0xFF800000));
            TestUtils.AreEqual(all(isnan(f16tof32(uint4(0xFC01, 0xFC01, 0xFC01, 0xFC01)))), true);
        }

        [TestCompiler]
        public static void f32tof16_float()
        {
            TestUtils.AreEqual(f32tof16(0.0f), 0x0000);
            TestUtils.AreEqual(f32tof16(2.98e-08f), 0x0000);
            TestUtils.AreEqual(f32tof16(5.96046448e-08f), 0x0001);
            TestUtils.AreEqual(f32tof16(123.4f), 0x57B6);
            TestUtils.AreEqual(f32tof16(65504.0f), 0x7BFF);
            TestUtils.AreEqual(f32tof16(65520.0f), 0x7C00);
            TestUtils.AreEqual(f32tof16(float.PositiveInfinity), 0x7C00);
            TestUtils.AreEqual(f32tof16(float.NaN), 0xFE00);

            TestUtils.AreEqual(f32tof16(-2.98e-08f), 0x8000);
            TestUtils.AreEqual(f32tof16(-5.96046448e-08f), 0x8001);
            TestUtils.AreEqual(f32tof16(-123.4f), 0xD7B6);
            TestUtils.AreEqual(f32tof16(-65504.0f), 0xFBFF);
            TestUtils.AreEqual(f32tof16(-65520.0f), 0xFC00);
            TestUtils.AreEqual(f32tof16(float.NegativeInfinity), 0xFC00);
        }

        [TestCompiler]
        [WindowsOnly("Mono on linux ignores signed zero.")]
        public static void f32tof16_float_signed_zero()
        {
            TestUtils.AreEqual(f32tof16(-0.0f), 0x8000);
        }

        [TestCompiler]
        public static void f32tof16_float2()
        {
            TestUtils.AreEqual(f32tof16(float2(0.0f, 2.98e-08f)), uint2(0x0000, 0x0000));
            TestUtils.AreEqual(f32tof16(float2(5.96046448e-08f, 123.4f)), uint2(0x0001, 0x57B6));
            TestUtils.AreEqual(f32tof16(float2(65504.0f, 65520.0f)), uint2(0x7BFF, 0x7C00));
            TestUtils.AreEqual(f32tof16(float2(float.PositiveInfinity, float.NaN)), uint2(0x7C00, 0xFE00));

            TestUtils.AreEqual(f32tof16(float2(-2.98e-08f, -5.96046448e-08f)), uint2(0x8000, 0x8001));
            TestUtils.AreEqual(f32tof16(float2(-123.4f, -65504.0f)), uint2(0xD7B6, 0xFBFF));
            TestUtils.AreEqual(f32tof16(float2(-65520.0f, float.NegativeInfinity)), uint2(0xFC00, 0xFC00));
            TestUtils.AreEqual(f32tof16(float2(float.NegativeInfinity, 0.0f)), uint2(0xFC00, 0x0000));
        }

        [TestCompiler]
        [WindowsOnly("Mono on linux ignores signed zero.")]
        public static void f32tof16_float2_signed_zero()
        {
            TestUtils.AreEqual(f32tof16(float2(-0.0f, -0.0f)), uint2(0x8000, 0x8000));
        }

        [TestCompiler]
        public static void f32tof16_float3()
        {
            TestUtils.AreEqual(f32tof16(float3(0.0f, 2.98e-08f, 5.96046448e-08f)), uint3(0x0000, 0x0000, 0x0001));
            TestUtils.AreEqual(f32tof16(float3(123.4f, 65504.0f, 65520.0f)), uint3(0x57B6, 0x7BFF, 0x7C00));
            TestUtils.AreEqual(f32tof16(float3(float.PositiveInfinity, float.NaN, -2.98e-08f)), uint3(0x7C00, 0xFE00, 0x8000));

            TestUtils.AreEqual(f32tof16(float3(-5.96046448e-08f, -123.4f, -65504.0f)), uint3(0x8001, 0xD7B6, 0xFBFF));
            TestUtils.AreEqual(f32tof16(float3(-65520.0f, float.NegativeInfinity, 0.0f)), uint3(0xFC00, 0xFC00, 0x0000));
        }

        [TestCompiler]
        [WindowsOnly("Mono on linux ignores signed zero.")]
        public static void f32tof16_float3_signed_zero()
        {
            TestUtils.AreEqual(f32tof16(float3(-0.0f, -0.0f, -0.0f)), uint3(0x8000, 0x8000, 0x8000));
        }

        [TestCompiler]
        public static void f32tof16_float4()
        {
            TestUtils.AreEqual(f32tof16(float4(0.0f, 2.98e-08f, 5.96046448e-08f, 123.4f)), uint4(0x0000, 0x0000, 0x0001, 0x57B6));
            TestUtils.AreEqual(f32tof16(float4(65504.0f, 65520.0f, float.PositiveInfinity, float.NaN)), uint4(0x7BFF, 0x7C00, 0x7C00, 0xFE00));
            TestUtils.AreEqual(f32tof16(float4(-2.98e-08f, -5.96046448e-08f, -123.4f, -65504.0f)), uint4(0x8000, 0x8001, 0xD7B6, 0xFBFF));
            TestUtils.AreEqual(f32tof16(float4(-65520.0f, float.NegativeInfinity, float.NegativeInfinity, 0.0f)), uint4(0xFC00, 0xFC00, 0xFC00, 0x0000));
        }

        [TestCompiler]
        [WindowsOnly("Mono on linux ignores signed zero.")]
        public static void f32tof16_float4_signed_zero()
        {
            TestUtils.AreEqual(f32tof16(float4(-0.0f, -0.0f, -0.0f, -0.0f)), uint4(0x8000, 0x8000, 0x8000, 0x8000));
        }

        [TestCompiler]
        public static void reflect_float2()
        {
            TestUtils.AreEqual(reflect(float2(1.2f, 3.6f), float2(1.5f, -1.3f)), float2(9.84f, -3.888f), 8, false);
            TestUtils.AreEqual(reflect(float2(-1.2f, 3.6f), float2(-1.5f, -1.3f)), float2(-9.84f, -3.888f), 8, false);
            TestUtils.AreEqual(reflect(float2(-1.2f, 3.6f), float2(0.0f, 0.0f)), float2(-1.2f, 3.6f));
            TestUtils.AreEqual(reflect(float2(0.0f, 0.0f), float2(-1.5f, -1.3f)), float2(0.0f, 0.0f), 8, false);
        }

        [TestCompiler]
        public static void reflect_float3()
        {
            TestUtils.AreEqual(reflect(float3(1.2f, 3.6f, -2.8f), float3(1.5f, -1.3f, 3.1f)), float3(35.88f, -26.456f, 68.872f), 8, false);
            TestUtils.AreEqual(reflect(float3(-1.2f, 3.6f, -2.8f), float3(-1.5f, -1.3f, 3.1f)), float3(-35.88f, -26.456f, 68.872f), 8, false);
            TestUtils.AreEqual(reflect(float3(-1.2f, 3.6f, -2.8f), float3(0.0f, 0.0f, 0.0f)), float3(-1.2f, 3.6f, -2.8f));
            TestUtils.AreEqual(reflect(float3(0.0f, 0.0f, 0.0f), float3(-1.5f, -1.3f, 3.1f)), float3(0.0f, 0.0f, 0.0f), 8, false);
        }

        [TestCompiler]
        public static void reflect_float4()
        {
            TestUtils.AreEqual(reflect(float4(1.2f, 3.6f, -2.8f, 0.3f), float4(1.5f, -1.3f, 3.1f, -0.7f)), float4(36.51f, -27.002f, 70.174f, -16.178f), 8, false);
            TestUtils.AreEqual(reflect(float4(-1.2f, 3.6f, -2.8f, 0.3f), float4(-1.5f, -1.3f, 3.1f, -0.7f)), float4(-36.51f, -27.002f, 70.174f, -16.178f), 8, false);
            TestUtils.AreEqual(reflect(float4(-1.2f, 3.6f, -2.8f, 0.3f), float4(0.0f, 0.0f, 0.0f, 0.0f)), float4(-1.2f, 3.6f, -2.8f, 0.3f));
            TestUtils.AreEqual(reflect(float4(0.0f, 0.0f, 0.0f, 0.0f), float4(-1.5f, -1.3f, 3.1f, -0.7f)), float4(0.0f, 0.0f, 0.0f, 0.0f), 8, false);
        }


        [TestCompiler]
        public static void reflect_double2()
        {
            TestUtils.AreEqual(reflect(double2(1.2, 3.6), double2(1.5, -1.3)), double2(9.84, -3.888), 8, false);
            TestUtils.AreEqual(reflect(double2(-1.2, 3.6), double2(-1.5, -1.3)), double2(-9.84, -3.888), 8, false);
            TestUtils.AreEqual(reflect(double2(-1.2, 3.6), double2(0.0, 0.0)), double2(-1.2, 3.6));
            TestUtils.AreEqual(reflect(double2(0.0, 0.0), double2(-1.5, -1.3)), double2(0.0, 0.0), 8, false);
        }

        [TestCompiler]
        public static void reflect_double3()
        {
            TestUtils.AreEqual(reflect(double3(1.2, 3.6, -2.8), double3(1.5, -1.3, 3.1)), double3(35.88, -26.456, 68.872), 8, false);
            TestUtils.AreEqual(reflect(double3(-1.2, 3.6, -2.8), double3(-1.5, -1.3, 3.1)), double3(-35.88, -26.456, 68.872), 8, false);
            TestUtils.AreEqual(reflect(double3(-1.2, 3.6, -2.8), double3(0.0, 0.0, 0.0)), double3(-1.2, 3.6, -2.8));
            TestUtils.AreEqual(reflect(double3(0.0, 0.0, 0.0), double3(-1.5f, -1.3, 3.1)), double3(0.0, 0.0, 0.0), 8, false);
        }

        [TestCompiler]
        public static void reflect_double4()
        {
            TestUtils.AreEqual(reflect(double4(1.2, 3.6, -2.8, 0.3), double4(1.5, -1.3, 3.1, -0.7)), double4(36.51, -27.002, 70.174, -16.178), 8, false);
            TestUtils.AreEqual(reflect(double4(-1.2, 3.6, -2.8, 0.3), double4(-1.5, -1.3, 3.1, -0.7)), double4(-36.51, -27.002, 70.174, -16.178), 8, false);
            TestUtils.AreEqual(reflect(double4(-1.2, 3.6, -2.8, 0.3), double4(0.0, 0.0, 0.0, 0.0)), double4(-1.2, 3.6, -2.8, 0.3));
            TestUtils.AreEqual(reflect(double4(0.0, 0.0, 0.0, 0.0), double4(-1.5, -1.3, 3.1, -0.7)), double4(0.0, 0.0, 0.0, 0.0), 8, false);
        }


        [TestCompiler]
        public static void refract_float2()
        {
            TestUtils.AreEqual(refract(float2(0.316228f, 0.948683f), float2(0.755689f, -0.654931f), 0.5f), float2(-0.3676186f, 0.9299768f), 8, false);
            TestUtils.AreEqual(refract(float2(0.316228f, 0.948683f), float2(0.755689f, -0.654931f), 1.05f), float2(0.4523711f, 0.8918296f), 8, false);
            TestUtils.AreEqual(refract(float2(0.316228f, 0.948683f), float2(0.755689f, -0.654931f), 1.5f), float2(0.0f, 0.0f));
        }

        [TestCompiler]
        public static void refract_float3()
        {
            TestUtils.AreEqual(refract(float3(0.288375f, 0.865125f, -0.410365f), float3(0.662147f, -0.573861f, 0.481919f), 0.5f), float3(-0.2863437f, 0.8056898f, -0.5185286f), 8, false);
            TestUtils.AreEqual(refract(float3(0.288375f, 0.865125f, -0.410365f), float3(0.662147f, -0.573861f, 0.481919f), 1.05f), float3(0.3743219f, 0.8463902f, -0.3788242f), 8, false);
            TestUtils.AreEqual(refract(float3(0.288375f, 0.865125f, -0.410365f), float3(0.662147f, -0.573861f, 0.481919f), 1.5f), float3(0.0f, 0.0f, 0.0f));
        }

        [TestCompiler]
        public static void refract_float4()
        {
            TestUtils.AreEqual(refract(float4(0.278154f, 0.834461f, -0.39582f, -0.26388f), float4(0.652208f, -0.565247f, 0.474685f, -0.1726139f), 0.5f), float4(-0.302029191645545f, 0.799522577847971f, -0.518952508802814f, -0.015196476378571f), 16, false);
            TestUtils.AreEqual(refract(float4(0.278154f, 0.834461f, -0.39582f, -0.26388f), float4(0.652208f, -0.565247f, 0.474685f, -0.172613f), 1.05f), float4(0.378159678850401f, 0.801565792862319f, -0.352947832589293f, -0.299860642333894f), 16, false);
            TestUtils.AreEqual(refract(float4(0.278154f, 0.834461f, -0.39582f, -0.26388f), float4(0.652208f, -0.565247f, 0.474685f, -0.172613f), 1.5f), float4(0.0f, 0.0f, 0.0f, 0.0f));
        }


        [TestCompiler]
        public static void refract_double2()
        {
            TestUtils.AreEqual(refract(double2(0.316228, 0.948683), double2(0.755689, -0.654931), 0.5), double2(-0.367618540673032, 0.929976739623085), 8, false);
            TestUtils.AreEqual(refract(double2(0.316228, 0.948683), double2(0.755689, -0.654931), 1.05), double2(0.452371226326029, 0.891829482258995), 8, false);
            TestUtils.AreEqual(refract(double2(0.316228, 0.948683), double2(0.755689, -0.654931), 1.5), double2(0.0, 0.0));
        }

        [TestCompiler]
        public static void refract_double3()
        {
            TestUtils.AreEqual(refract(double3(0.288375, 0.865125, -0.410365), double3(0.662147, -0.573861, 0.481919), 0.5), double3(-0.286343746291412, 0.805689753507206, -0.518528611485079), 8, false);
            TestUtils.AreEqual(refract(double3(0.288375, 0.865125, -0.410365), double3(0.662147, -0.573861, 0.481919), 1.05), double3(0.374321889019825, 0.846390167376268, -0.378824161567529), 8, false);
            TestUtils.AreEqual(refract(double3(0.288375, 0.865125, -0.410365), double3(0.662147, -0.573861, 0.481919), 1.5), double3(0.0, 0.0, 0.0));
        }

        [TestCompiler]
        public static void refract_double4()
        {
            TestUtils.AreEqual(refract(double4(0.278154, 0.834461, -0.39582, -0.26388), double4(0.652208, -0.565247, 0.474685, -0.1726139), 0.5), double4(-0.302029191645545, 0.799522577847971, -0.518952508802814, -0.015196476378571), 16, false);
            TestUtils.AreEqual(refract(double4(0.278154, 0.834461, -0.39582, -0.26388), double4(0.652208, -0.565247, 0.474685, -0.172613), 1.05), double4(0.378159678850401, 0.801565792862319, -0.352947832589293, -0.299860642333894), 16, false);
            TestUtils.AreEqual(refract(double4(0.278154, 0.834461, -0.39582, -0.26388), double4(0.652208, -0.565247, 0.474685, -0.172613), 1.5), double4(0.0, 0.0, 0.0, 0.0));
        }

        [TestCompiler]
        public static void sincos_float()
        {
            float s, c;

            sincos(-1000000f, out s, out c);
            TestUtils.AreEqual(s, 0.3499935f, 1, false);
            TestUtils.AreEqual(c, 0.936752141f, 8, false);

            sincos(-1.2f, out s, out c);
            TestUtils.AreEqual(s, -0.9320391f, 1, false);
            TestUtils.AreEqual(c, 0.362357765f, 8, false);

            sincos(0f, out s, out c);
            TestUtils.AreEqual(s, 0f, 1, false);
            TestUtils.AreEqual(c, 1f, 8, false);

            sincos(1.2f, out s, out c);
            TestUtils.AreEqual(s, 0.9320391f, 1, false);
            TestUtils.AreEqual(c, 0.362357765f, 8, false);

            sincos(1000000f, out s, out c);
            TestUtils.AreEqual(s, -0.3499935f, 1, false);
            TestUtils.AreEqual(c, 0.936752141f, 8, false);

            sincos(float.NegativeInfinity, out s, out c);
            TestUtils.AreEqual(s, float.NaN, 1, false);
            TestUtils.AreEqual(c, float.NaN, 8, false);

            sincos(float.NaN, out s, out c);
            TestUtils.AreEqual(s, float.NaN, 1, false);
            TestUtils.AreEqual(c, float.NaN, 8, false);

            sincos(float.PositiveInfinity, out s, out c);
            TestUtils.AreEqual(s, float.NaN, 1, false);
            TestUtils.AreEqual(c, float.NaN, 8, false);
        }


        [TestCompiler]
        public static void sincos_float2()
        {
            float2 s, c;

            sincos(float2(-1000000f, -1.2f), out s, out c);
            TestUtils.AreEqual(s, float2(0.3499935f, -0.9320391f), 1, false);
            TestUtils.AreEqual(c, float2(0.936752141f, 0.362357765f), 8, false);

            sincos(float2(0f, 1.2f), out s, out c);
            TestUtils.AreEqual(s, float2(0f, 0.9320391f), 1, false);
            TestUtils.AreEqual(c, float2(1f, 0.362357765f), 8, false);

            sincos(float2(1000000f, float.NegativeInfinity), out s, out c);
            TestUtils.AreEqual(s, float2(-0.3499935f, float.NaN), 1, false);
            TestUtils.AreEqual(c, float2(0.936752141f, float.NaN), 8, false);

            sincos(float2(float.NaN, float.PositiveInfinity), out s, out c);
            TestUtils.AreEqual(s, float2(float.NaN, float.NaN), 1, false);
            TestUtils.AreEqual(c, float2(float.NaN, float.NaN), 8, false);
        }

        [TestCompiler]
        public static void sincos_float3()
        {
            float3 s, c;

            sincos(float3(-1000000f, -1.2f, 0f), out s, out c);
            TestUtils.AreEqual(s, float3(0.3499935f, -0.9320391f, 0f), 1, false);
            TestUtils.AreEqual(c, float3(0.936752141f, 0.362357765f, 1f), 8, false);

            sincos(float3(1.2f, 1000000f, float.NegativeInfinity), out s, out c);
            TestUtils.AreEqual(s, float3(0.9320391f, -0.3499935f, float.NaN), 1, false);
            TestUtils.AreEqual(c, float3(0.362357765f, 0.936752141f, float.NaN), 8, false);

            sincos(float3(float.NaN, float.PositiveInfinity, float.PositiveInfinity), out s, out c);
            TestUtils.AreEqual(s, float3(float.NaN, float.NaN, float.NaN), 1, false);
            TestUtils.AreEqual(c, float3(float.NaN, float.NaN, float.NaN), 8, false);
        }

        [TestCompiler]
        public static void sincos_float4()
        {
            float4 s, c;

            sincos(float4(-1000000f, -1.2f, 0f, 1.2f), out s, out c);
            TestUtils.AreEqual(s, float4(0.3499935f, -0.9320391f, 0f, 0.9320391f), 1, false);
            TestUtils.AreEqual(c, float4(0.936752141f, 0.362357765f, 1f, 0.362357765f), 8, false);

            sincos(float4(1000000f, float.NegativeInfinity, float.NaN, float.PositiveInfinity), out s, out c);
            TestUtils.AreEqual(s, float4(-0.3499935f, float.NaN, float.NaN, float.NaN), 1, false);
            TestUtils.AreEqual(c, float4(0.936752141f, float.NaN, float.NaN, float.NaN), 8, false);
        }

        [TestCompiler]
        public static void sincos_double()
        {
            double s, c;
            sincos(-1000000.0, out s, out c);
            TestUtils.AreEqual(s, 0.34999350217129294, 32, false);
            TestUtils.AreEqual(c, 0.93675212753314474, 32, false);

            sincos(-1.2, out s, out c);
            TestUtils.AreEqual(s, -0.9320390859672264, 32, false);
            TestUtils.AreEqual(c, 0.36235775447667357, 32, false);

            sincos(0.0, out s, out c);
            TestUtils.AreEqual(s, 0.0, 32, false);
            TestUtils.AreEqual(c, 1.0, 32, false);

            sincos(1.2, out s, out c);
            TestUtils.AreEqual(s, 0.9320390859672264, 32, false);
            TestUtils.AreEqual(c, 0.36235775447667357, 32, false);

            sincos(1000000.0, out s, out c);
            TestUtils.AreEqual(s, -0.34999350217129294, 32, false);
            TestUtils.AreEqual(c, 0.93675212753314474, 32, false);

            sincos(double.NegativeInfinity, out s, out c);
            TestUtils.AreEqual(s, double.NaN, 32, false);
            TestUtils.AreEqual(c, double.NaN, 32, false);

            sincos(double.NaN, out s, out c);
            TestUtils.AreEqual(s, double.NaN, 32, false);
            TestUtils.AreEqual(c, double.NaN, 32, false);

            sincos(double.NaN, out s, out c);
            TestUtils.AreEqual(s, double.NaN, 32, false);
            TestUtils.AreEqual(c, double.NaN, 32, false);
        }

        [TestCompiler]
        public static void sincos_double2()
        {
            double2 s, c;
            sincos(double2(-1000000.0, -1.2), out s, out c);
            TestUtils.AreEqual(s, double2(0.34999350217129294, -0.9320390859672264), 32, false);
            TestUtils.AreEqual(c, double2(0.93675212753314474, 0.36235775447667357), 32, false);

            sincos(double2(0.0, 1.2), out s, out c);
            TestUtils.AreEqual(s, double2(0.0, 0.9320390859672264), 32, false);
            TestUtils.AreEqual(c, double2(1.0, 0.36235775447667357), 32, false);

            sincos(double2(1000000.0, double.NegativeInfinity), out s, out c);
            TestUtils.AreEqual(s, double2(-0.34999350217129294, double.NaN), 32, false);
            TestUtils.AreEqual(c, double2(0.93675212753314474, double.NaN), 32, false);

            sincos(double2(double.NaN, double.PositiveInfinity), out s, out c);
            TestUtils.AreEqual(s, double2(double.NaN, double.NaN), 32, false);
            TestUtils.AreEqual(c, double2(double.NaN, double.NaN), 32, false);
        }

        [TestCompiler]
        public static void sincos_double3()
        {
            double3 s, c;

            sincos(double3(-1000000.0, -1.2, 0.0), out s, out c);
            TestUtils.AreEqual(s, double3(0.34999350217129294, -0.9320390859672264, 0.0), 32, false);
            TestUtils.AreEqual(c, double3(0.93675212753314474, 0.36235775447667357, 1.0), 32, false);

            sincos(double3(1.2, 1000000.0, double.NegativeInfinity), out s, out c);
            TestUtils.AreEqual(s, double3(0.9320390859672264, -0.34999350217129294, double.NaN), 32, false);
            TestUtils.AreEqual(c, double3(0.36235775447667357, 0.93675212753314474, double.NaN), 32, false);

            sincos(double3(double.NaN, double.PositiveInfinity, double.PositiveInfinity), out s, out c);
            TestUtils.AreEqual(s, double3(double.NaN, double.NaN, double.NaN), 32, false);
            TestUtils.AreEqual(c, double3(double.NaN, double.NaN, double.NaN), 32, false);
        }

        [TestCompiler]
        public static void sincos_double4()
        {
            double4 s, c;

            sincos(double4(-1000000.0, -1.2, 0.0, 1.2), out s, out c);
            TestUtils.AreEqual(s, double4(0.34999350217129294, -0.9320390859672264, 0.0, 0.9320390859672264), 32, false);
            TestUtils.AreEqual(c, double4(0.93675212753314474, 0.36235775447667357, 1.0, 0.36235775447667357), 32, false);

            sincos(double4(1000000.0, double.NegativeInfinity, double.NaN, double.PositiveInfinity), out s, out c);
            TestUtils.AreEqual(s, double4(-0.34999350217129294, double.NaN, double.NaN, double.NaN), 32, false);
            TestUtils.AreEqual(c, double4(0.93675212753314474, double.NaN, double.NaN, double.NaN), 32, false);
        }

        [TestCompiler]
        public static void select_int()
        {
            TestUtils.AreEqual(select(-123456789, 987654321, false), -123456789);
            TestUtils.AreEqual(select(-123456789, 987654321, true), 987654321);
        }

        [TestCompiler]
        public static void select_int2()
        {
            TestUtils.AreEqual(select(int2(-123456789, -123456790), int2(987654321, 987654322), false), int2(-123456789, -123456790));
            TestUtils.AreEqual(select(int2(-123456789, -123456790), int2(987654321, 987654322), true), int2(987654321, 987654322));

            TestUtils.AreEqual(select(int2(-123456789, -123456790), int2(987654321, 987654322), bool2(false, false)), int2(-123456789, -123456790));
            TestUtils.AreEqual(select(int2(-123456789, -123456790), int2(987654321, 987654322), bool2(false, true)), int2(-123456789, 987654322));
            TestUtils.AreEqual(select(int2(-123456789, -123456790), int2(987654321, 987654322), bool2(true, false)), int2(987654321, -123456790));
            TestUtils.AreEqual(select(int2(-123456789, -123456790), int2(987654321, 987654322), bool2(true, true)), int2(987654321, 987654322));
        }

        [TestCompiler]
        public static void select_int3()
        {
            TestUtils.AreEqual(select(int3(-123456789, -123456790, -123456791), int3(987654321, 987654322, 987654323), false), int3(-123456789, -123456790, -123456791));
            TestUtils.AreEqual(select(int3(-123456789, -123456790, -123456791), int3(987654321, 987654322, 987654323), true), int3(987654321, 987654322, 987654323));

            TestUtils.AreEqual(select(int3(-123456789, -123456790, -123456791), int3(987654321, 987654322, 987654323), bool3(false, false, false)), int3(-123456789, -123456790, -123456791));
            TestUtils.AreEqual(select(int3(-123456789, -123456790, -123456791), int3(987654321, 987654322, 987654323), bool3(false, false, true)), int3(-123456789, -123456790, 987654323));
            TestUtils.AreEqual(select(int3(-123456789, -123456790, -123456791), int3(987654321, 987654322, 987654323), bool3(false, true, false)), int3(-123456789, 987654322, -123456791));
            TestUtils.AreEqual(select(int3(-123456789, -123456790, -123456791), int3(987654321, 987654322, 987654323), bool3(false, true, true)), int3(-123456789, 987654322, 987654323));

            TestUtils.AreEqual(select(int3(-123456789, -123456790, -123456791), int3(987654321, 987654322, 987654323), bool3(true, false, false)), int3(987654321, -123456790, -123456791));
            TestUtils.AreEqual(select(int3(-123456789, -123456790, -123456791), int3(987654321, 987654322, 987654323), bool3(true, false, true)), int3(987654321, -123456790, 987654323));
            TestUtils.AreEqual(select(int3(-123456789, -123456790, -123456791), int3(987654321, 987654322, 987654323), bool3(true, true, false)), int3(987654321, 987654322, -123456791));
            TestUtils.AreEqual(select(int3(-123456789, -123456790, -123456791), int3(987654321, 987654322, 987654323), bool3(true, true, true)), int3(987654321, 987654322, 987654323));
        }

        [TestCompiler]
        public static void select_int4()
        {
            TestUtils.AreEqual(select(int4(-123456789, -123456790, -123456791, -123456792), int4(987654321, 987654322, 987654323, 987654324), false), int4(-123456789, -123456790, -123456791, -123456792));
            TestUtils.AreEqual(select(int4(-123456789, -123456790, -123456791, -123456792), int4(987654321, 987654322, 987654323, 987654324), true), int4(987654321, 987654322, 987654323, 987654324));

            TestUtils.AreEqual(select(int4(-123456789, -123456790, -123456791, -123456792), int4(987654321, 987654322, 987654323, 987654324), bool4(false, false, false, false)), int4(-123456789, -123456790, -123456791, -123456792));
            TestUtils.AreEqual(select(int4(-123456789, -123456790, -123456791, -123456792), int4(987654321, 987654322, 987654323, 987654324), bool4(false, false, false, true)), int4(-123456789, -123456790, -123456791, 987654324));
            TestUtils.AreEqual(select(int4(-123456789, -123456790, -123456791, -123456792), int4(987654321, 987654322, 987654323, 987654324), bool4(false, false, true, false)), int4(-123456789, -123456790, 987654323, -123456792));
            TestUtils.AreEqual(select(int4(-123456789, -123456790, -123456791, -123456792), int4(987654321, 987654322, 987654323, 987654324), bool4(false, false, true, true)), int4(-123456789, -123456790, 987654323, 987654324));

            TestUtils.AreEqual(select(int4(-123456789, -123456790, -123456791, -123456792), int4(987654321, 987654322, 987654323, 987654324), bool4(false, true, false, false)), int4(-123456789, 987654322, -123456791, -123456792));
            TestUtils.AreEqual(select(int4(-123456789, -123456790, -123456791, -123456792), int4(987654321, 987654322, 987654323, 987654324), bool4(false, true, false, true)), int4(-123456789, 987654322, -123456791, 987654324));
            TestUtils.AreEqual(select(int4(-123456789, -123456790, -123456791, -123456792), int4(987654321, 987654322, 987654323, 987654324), bool4(false, true, true, false)), int4(-123456789, 987654322, 987654323, -123456792));
            TestUtils.AreEqual(select(int4(-123456789, -123456790, -123456791, -123456792), int4(987654321, 987654322, 987654323, 987654324), bool4(false, true, true, true)), int4(-123456789, 987654322, 987654323, 987654324));

            TestUtils.AreEqual(select(int4(-123456789, -123456790, -123456791, -123456792), int4(987654321, 987654322, 987654323, 987654324), bool4(true, false, false, false)), int4(987654321, -123456790, -123456791, -123456792));
            TestUtils.AreEqual(select(int4(-123456789, -123456790, -123456791, -123456792), int4(987654321, 987654322, 987654323, 987654324), bool4(true, false, false, true)), int4(987654321, -123456790, -123456791, 987654324));
            TestUtils.AreEqual(select(int4(-123456789, -123456790, -123456791, -123456792), int4(987654321, 987654322, 987654323, 987654324), bool4(true, false, true, false)), int4(987654321, -123456790, 987654323, -123456792));
            TestUtils.AreEqual(select(int4(-123456789, -123456790, -123456791, -123456792), int4(987654321, 987654322, 987654323, 987654324), bool4(true, false, true, true)), int4(987654321, -123456790, 987654323, 987654324));

            TestUtils.AreEqual(select(int4(-123456789, -123456790, -123456791, -123456792), int4(987654321, 987654322, 987654323, 987654324), bool4(true, true, false, false)), int4(987654321, 987654322, -123456791, -123456792));
            TestUtils.AreEqual(select(int4(-123456789, -123456790, -123456791, -123456792), int4(987654321, 987654322, 987654323, 987654324), bool4(true, true, false, true)), int4(987654321, 987654322, -123456791, 987654324));
            TestUtils.AreEqual(select(int4(-123456789, -123456790, -123456791, -123456792), int4(987654321, 987654322, 987654323, 987654324), bool4(true, true, true, false)), int4(987654321, 987654322, 987654323, -123456792));
            TestUtils.AreEqual(select(int4(-123456789, -123456790, -123456791, -123456792), int4(987654321, 987654322, 987654323, 987654324), bool4(true, true, true, true)), int4(987654321, 987654322, 987654323, 987654324));
        }

        [TestCompiler]
        public static void select_uint()
        {
            TestUtils.AreEqual(select(123456789u, 987654321u, false), 123456789u);
            TestUtils.AreEqual(select(123456789u, 987654321u, true), 987654321u);
        }

        [TestCompiler]
        public static void select_uint2()
        {
            TestUtils.AreEqual(select(uint2(123456789u, 123456790u), uint2(987654321u, 987654322u), false), uint2(123456789u, 123456790u));
            TestUtils.AreEqual(select(uint2(123456789u, 123456790u), uint2(987654321u, 987654322u), true), uint2(987654321u, 987654322));

            TestUtils.AreEqual(select(uint2(123456789u, 123456790u), uint2(987654321u, 987654322u), bool2(false, false)), uint2(123456789u, 123456790u));
            TestUtils.AreEqual(select(uint2(123456789u, 123456790u), uint2(987654321u, 987654322u), bool2(false, true)), uint2(123456789u, 987654322u));
            TestUtils.AreEqual(select(uint2(123456789u, 123456790u), uint2(987654321u, 987654322u), bool2(true, false)), uint2(987654321u, 123456790u));
            TestUtils.AreEqual(select(uint2(123456789u, 123456790u), uint2(987654321u, 987654322u), bool2(true, true)), uint2(987654321u, 987654322u));
        }

        [TestCompiler]
        public static void select_uint3()
        {
            TestUtils.AreEqual(select(uint3(123456789u, 123456790u, 123456791u), uint3(987654321u, 987654322u, 987654323u), false), uint3(123456789u, 123456790u, 123456791u));
            TestUtils.AreEqual(select(uint3(123456789u, 123456790u, 123456791u), uint3(987654321u, 987654322u, 987654323u), true), uint3(987654321u, 987654322u, 987654323));

            TestUtils.AreEqual(select(uint3(123456789u, 123456790u, 123456791u), uint3(987654321u, 987654322u, 987654323u), bool3(false, false, false)), uint3(123456789u, 123456790u, 123456791u));
            TestUtils.AreEqual(select(uint3(123456789u, 123456790u, 123456791u), uint3(987654321u, 987654322u, 987654323u), bool3(false, false, true)), uint3(123456789u, 123456790u, 987654323u));
            TestUtils.AreEqual(select(uint3(123456789u, 123456790u, 123456791u), uint3(987654321u, 987654322u, 987654323u), bool3(false, true, false)), uint3(123456789u, 987654322u, 123456791u));
            TestUtils.AreEqual(select(uint3(123456789u, 123456790u, 123456791u), uint3(987654321u, 987654322u, 987654323u), bool3(false, true, true)), uint3(123456789u, 987654322u, 987654323u));

            TestUtils.AreEqual(select(uint3(123456789u, 123456790u, 123456791u), uint3(987654321u, 987654322u, 987654323u), bool3(true, false, false)), uint3(987654321u, 123456790u, 123456791u));
            TestUtils.AreEqual(select(uint3(123456789u, 123456790u, 123456791u), uint3(987654321u, 987654322u, 987654323u), bool3(true, false, true)), uint3(987654321u, 123456790u, 987654323u));
            TestUtils.AreEqual(select(uint3(123456789u, 123456790u, 123456791u), uint3(987654321u, 987654322u, 987654323u), bool3(true, true, false)), uint3(987654321u, 987654322u, 123456791u));
            TestUtils.AreEqual(select(uint3(123456789u, 123456790u, 123456791u), uint3(987654321u, 987654322u, 987654323u), bool3(true, true, true)), uint3(987654321u, 987654322u, 987654323u));
        }

        [TestCompiler]
        public static void select_uint4()
        {
            TestUtils.AreEqual(select(uint4(123456789u, 123456790u, 123456791u, 123456792u), uint4(987654321u, 987654322u, 987654323u, 987654324u), false), uint4(123456789u, 123456790u, 123456791u, 123456792u));
            TestUtils.AreEqual(select(uint4(123456789u, 123456790u, 123456791u, 123456792u), uint4(987654321u, 987654322u, 987654323u, 987654324u), true), uint4(987654321u, 987654322u, 987654323u, 987654324u));

            TestUtils.AreEqual(select(uint4(123456789u, 123456790u, 123456791u, 123456792u), uint4(987654321u, 987654322u, 987654323u, 987654324u), bool4(false, false, false, false)), uint4(123456789u, 123456790u, 123456791u, 123456792u));
            TestUtils.AreEqual(select(uint4(123456789u, 123456790u, 123456791u, 123456792u), uint4(987654321u, 987654322u, 987654323u, 987654324u), bool4(false, false, false, true)), uint4(123456789u, 123456790u, 123456791u, 987654324u));
            TestUtils.AreEqual(select(uint4(123456789u, 123456790u, 123456791u, 123456792u), uint4(987654321u, 987654322u, 987654323u, 987654324u), bool4(false, false, true, false)), uint4(123456789u, 123456790u, 987654323u, 123456792u));
            TestUtils.AreEqual(select(uint4(123456789u, 123456790u, 123456791u, 123456792u), uint4(987654321u, 987654322u, 987654323u, 987654324u), bool4(false, false, true, true)), uint4(123456789u, 123456790u, 987654323u, 987654324u));

            TestUtils.AreEqual(select(uint4(123456789u, 123456790u, 123456791u, 123456792u), uint4(987654321u, 987654322u, 987654323u, 987654324u), bool4(false, true, false, false)), uint4(123456789u, 987654322u, 123456791u, 123456792u));
            TestUtils.AreEqual(select(uint4(123456789u, 123456790u, 123456791u, 123456792u), uint4(987654321u, 987654322u, 987654323u, 987654324u), bool4(false, true, false, true)), uint4(123456789u, 987654322u, 123456791u, 987654324u));
            TestUtils.AreEqual(select(uint4(123456789u, 123456790u, 123456791u, 123456792u), uint4(987654321u, 987654322u, 987654323u, 987654324u), bool4(false, true, true, false)), uint4(123456789u, 987654322u, 987654323u, 123456792u));
            TestUtils.AreEqual(select(uint4(123456789u, 123456790u, 123456791u, 123456792u), uint4(987654321u, 987654322u, 987654323u, 987654324u), bool4(false, true, true, true)), uint4(123456789u, 987654322u, 987654323u, 987654324u));

            TestUtils.AreEqual(select(uint4(123456789u, 123456790u, 123456791u, 123456792u), uint4(987654321u, 987654322u, 987654323u, 987654324u), bool4(true, false, false, false)), uint4(987654321u, 123456790u, 123456791u, 123456792u));
            TestUtils.AreEqual(select(uint4(123456789u, 123456790u, 123456791u, 123456792u), uint4(987654321u, 987654322u, 987654323u, 987654324u), bool4(true, false, false, true)), uint4(987654321u, 123456790u, 123456791u, 987654324u));
            TestUtils.AreEqual(select(uint4(123456789u, 123456790u, 123456791u, 123456792u), uint4(987654321u, 987654322u, 987654323u, 987654324u), bool4(true, false, true, false)), uint4(987654321u, 123456790u, 987654323u, 123456792u));
            TestUtils.AreEqual(select(uint4(123456789u, 123456790u, 123456791u, 123456792u), uint4(987654321u, 987654322u, 987654323u, 987654324u), bool4(true, false, true, true)), uint4(987654321u, 123456790u, 987654323u, 987654324u));

            TestUtils.AreEqual(select(uint4(123456789u, 123456790u, 123456791u, 123456792u), uint4(987654321u, 987654322u, 987654323u, 987654324u), bool4(true, true, false, false)), uint4(987654321u, 987654322u, 123456791u, 123456792u));
            TestUtils.AreEqual(select(uint4(123456789u, 123456790u, 123456791u, 123456792u), uint4(987654321u, 987654322u, 987654323u, 987654324u), bool4(true, true, false, true)), uint4(987654321u, 987654322u, 123456791u, 987654324u));
            TestUtils.AreEqual(select(uint4(123456789u, 123456790u, 123456791u, 123456792u), uint4(987654321u, 987654322u, 987654323u, 987654324u), bool4(true, true, true, false)), uint4(987654321u, 987654322u, 987654323u, 123456792u));
            TestUtils.AreEqual(select(uint4(123456789u, 123456790u, 123456791u, 123456792u), uint4(987654321u, 987654322u, 987654323u, 987654324u), bool4(true, true, true, true)), uint4(987654321u, 987654322u, 987654323u, 987654324u));
        }

        [TestCompiler]
        public static void select_long()
        {
            TestUtils.AreEqual(select(-12345678910111314L, 987654321011121314L, false), -12345678910111314L);
            TestUtils.AreEqual(select(-12345678910111314L, 987654321011121314L, true), 987654321011121314L);
        }

        [TestCompiler]
        public static void select_ulong()
        {
            TestUtils.AreEqual(select(12345678910111314UL, 987654321011121314UL, false), 12345678910111314UL);
            TestUtils.AreEqual(select(12345678910111314UL, 987654321011121314UL, true), 987654321011121314UL);
        }


        [TestCompiler]
        public static void select_float()
        {
            TestUtils.AreEqual(select(-1234.5f, 9876.25f, false), -1234.5f);
            TestUtils.AreEqual(select(-1234.5f, 9876.25f, true), 9876.25f);
        }

        [TestCompiler]
        public static void select_float2()
        {
            TestUtils.AreEqual(select(float2(-1234.5f, -1235.5f), float2(9876.25f, 9877.25f), false), float2(-1234.5f, -1235.5f));
            TestUtils.AreEqual(select(float2(-1234.5f, -1235.5f), float2(9876.25f, 9877.25f), true), float2(9876.25f, 9877.25f));

            TestUtils.AreEqual(select(float2(-1234.5f, -1235.5f), float2(9876.25f, 9877.25f), bool2(false, false)), float2(-1234.5f, -1235.5f));
            TestUtils.AreEqual(select(float2(-1234.5f, -1235.5f), float2(9876.25f, 9877.25f), bool2(false, true)), float2(-1234.5f, 9877.25f));
            TestUtils.AreEqual(select(float2(-1234.5f, -1235.5f), float2(9876.25f, 9877.25f), bool2(true, false)), float2(9876.25f, -1235.5f));
            TestUtils.AreEqual(select(float2(-1234.5f, -1235.5f), float2(9876.25f, 9877.25f), bool2(true, true)), float2(9876.25f, 9877.25f));
        }

        [TestCompiler]
        public static void select_float3()
        {
            TestUtils.AreEqual(select(float3(-1234.5f, -1235.5f, -1236.5f), float3(9876.25f, 9877.25f, 9878.25f), false), float3(-1234.5f, -1235.5f, -1236.5f));
            TestUtils.AreEqual(select(float3(-1234.5f, -1235.5f, -1236.5f), float3(9876.25f, 9877.25f, 9878.25f), true), float3(9876.25f, 9877.25f, 9878.25f));

            TestUtils.AreEqual(select(float3(-1234.5f, -1235.5f, -1236.5f), float3(9876.25f, 9877.25f, 9878.25f), bool3(false, false, false)), float3(-1234.5f, -1235.5f, -1236.5f));
            TestUtils.AreEqual(select(float3(-1234.5f, -1235.5f, -1236.5f), float3(9876.25f, 9877.25f, 9878.25f), bool3(false, false, true)), float3(-1234.5f, -1235.5f, 9878.25f));
            TestUtils.AreEqual(select(float3(-1234.5f, -1                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          