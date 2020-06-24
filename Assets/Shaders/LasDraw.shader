Shader "Unlit/LasDraw"
{
    Properties
    {
        _StartRangeR ("StartRadiusR", Range(0, 100)) = 100
        _StartRangeY ("StartRadiusY", Range(0, 100)) = 100
        _RotateRadius ("RotateRadius", Range(0, 100)) = 100
        _RotateCycle ("RotateCycle", Range(0, 100)) = 100
        _T ("T", float) = 1
        _Radius ("Radius", float) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            
            StructuredBuffer<float3> colBuffer;
            StructuredBuffer<float3> posBuffer;
            float _StartRangeR;
            float _StartRangeY;
            float _RotateRadius;
            float _RotateCycle;
            float _Radius;
            float _T;

            struct v2g
            {
                float4 pos : POSITION;
                float4 col : COLOR;
            };
            struct g2f
            {
                float4 pos : POSITION;
                float4 col : COLOR;
            };
            #define PI 3.1415926535

            float hash( uint x ) {
                x += 100;
                x += ( x << 10u );
                x ^= ( x >>  6u );
                x += ( x <<  3u );
                x ^= ( x >> 11u );
                x += ( x << 15u );
                return x;
            }
            
            v2g vert (uint id : SV_VertexID)
            {
                v2g o;
                uint random = hash(id);
                float4 pos = float4(posBuffer[id], 1);
                float rt = pow(max(0, (1-_T)), 3);
                pos.x += _StartRangeR * cos(random) * rt;
                pos.z += _StartRangeR * sin(random) * rt;
                pos.y += _StartRangeY * (sin(random)+1)/2 * rt;
                pos.x += _RotateRadius * cos(rt*2*PI*_RotateCycle+random/10) * rt;
                pos.z += _RotateRadius * sin(rt*2*PI*_RotateCycle+random/10) * rt;
                o.pos = UnityObjectToClipPos(pos);
                o.col = float4(colBuffer[id] / 65536.0, 1);
                return o;
            }

            float4 frag (g2f i) : SV_Target
            {
                return i.col;
            }
            ENDCG
        }
    }
}
