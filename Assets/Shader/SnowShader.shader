Shader "Custom/SnowShader"
{
    Properties
    {
        _CellCount("Cell Count", Float) = 8.0
        _Speed("Fall Speed", Float) = 0.15
        _SpeedX("Horizontal Speed", Float) = 0.15
        _FlakeSize("Flake Size", Float) = 0.15
        _WindStrength("Wind Strength", Float) = 0.3
    }

    SubShader
    {
        Tags { "RenderType" = "Transparent" "Queue" = "Transparent" "RenderPipeline" = "UniversalPipeline" }
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            HLSLPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

             float rand(float2 seed)
             {
                return frac(sin(dot(seed, float2(127.1, 311.7))) * 43758.5453);
             }

            CBUFFER_START(UnityPerMaterial)
            float _CellCount;
            float _Speed;
            float _FlakeSize;
            float _WindStrength;
            CBUFFER_END

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.uv = IN.uv;
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                float2 cellUV = frac(IN.uv * _CellCount);
                float2 cellID = floor(IN.uv * _CellCount);
                

                float flake = 0.0;

                for (int row = 0; row <= 1; row++) //boucle pour qu'il détecte les débordements
                {
                    float2 id = cellID + float2(0, row);
                    float2 uv = cellUV - float2(0, row);

                    
                    float2 seed = id;
                    float t = frac(_Time.y * _Speed + rand(seed));
                    float flakeY = 1 - t;
                    float flakeX = rand(seed + 1.0) - t * _WindStrength;
                    
                    float2 diff = uv - float2(flakeX, flakeY);
                    float bras_horizontal = (abs(diff.x) < _FlakeSize * 3) * (abs(diff.y) < _FlakeSize);
                    float bras_vertical = (abs(diff.x) < _FlakeSize) * (abs(diff.y) < _FlakeSize * 3);
                    flake = max(flake, saturate(bras_horizontal + bras_vertical)) * (1.0 - t);
                }
                return half4(1, 1, 1, flake);
                //rgba
            }
            ENDHLSL
        }
    }
}
