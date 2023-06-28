Shader "Unlit/Cel Shader"
{
    Properties
    {
        _Color("Color", Color) = (0.5, 0.65, 1, 1)
        _MainTex("Main Texture", 2D) = "white" {}
        // Ambient light is applied uniformly to all surfaces on the object.
        [HDR]
        _AmbientColor("Ambient Color", Color) = (0.4,0.4,0.4,1)
        [HDR]
        _SpecularColor("Specular Color", Color) = (0.9, 0.9, 0.9, 1)
        // specular color that tints / glos that controls size of the reflection 
        _Glossiness("Glossiness", Float) = 32
        [HDR]
        _RimColor("Rim Color", Color) = (1,1,1,1)
        _RimAmount("Rim Amount", Range(0,1)) = 0.716
            // Control how smoothly the rim blends when approaching unlit
            // parts of the surface.
            _RimThreshold("Rim Threshold", Range(0, 1)) = 0.1
            _OutlineColor("Outline Color", Color) = (1,1,1,1)
        _OutlineAmount("Outline Amount", Range(0,1)) = 0.716
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        Pass
        {
            Tags
            {
            "LightMode" = "ForwardBase"
            "PassFlags" = "OnlyDirectional"
            }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fwdbase
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "AutoLight.cginc"

            struct appdata
            {
                float3 normal : NORMAL;
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 viewDir : TEXCOORD1;
                float3 worldNormal : NORMAL;
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                SHADOW_COORDS(2)
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Glossiness;
            float4 _SpecularColor;


            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.viewDir = WorldSpaceViewDir(v.vertex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                TRANSFER_SHADOW(o)
                
                return o;
            }

            float4 _Color;
            float4 _AmbientColor;
            float4 _RimColor;
            float _RimAmount;
            float _RimThreshold;
            float4 _OutlineColor;
            float _OutlineAmount;
            float _OutlineThreshold;

            fixed4 frag (v2f i) : SV_Target
            {

                float3 normal = normalize(i.worldNormal);
                float NdotL = dot(_WorldSpaceLightPos0, normal);

                float shadow = SHADOW_ATTENUATION(i);
                
                float lightIntensity = smoothstep(0, 0.01, NdotL * shadow);
                float4 light = lightIntensity * _LightColor0;
                // sample the texture
                float3 viewDir = normalize(i.viewDir);

                float3 halfVector = normalize(_WorldSpaceLightPos0 + viewDir);
                float NdotH = dot(normal, halfVector);

                float specularIntensity = pow(NdotH * lightIntensity, _Glossiness * _Glossiness);
                float specularIntensitySmooth = smoothstep(0.005, 0.01, specularIntensity);
                float4 specular = specularIntensitySmooth * _SpecularColor;

                //mid tone for middle colour

                //find dot, 

                float4 rimDot = 1 - dot(viewDir, normal);
                float rimIntensity = rimDot * pow(NdotL, _RimThreshold);
                 rimIntensity = smoothstep(_RimAmount - 0.01, _RimAmount + 0.01, rimIntensity);
                float4 rim = rimIntensity * _RimColor;

                float4 OutlineDot = 1 - dot(viewDir, normal);
                float OutlineIntensity = smoothstep(_OutlineAmount - 0.01, _OutlineAmount + 0.01, OutlineDot);
                float4 Outline = OutlineIntensity * _OutlineColor;

                float4 sample = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return _Color * sample * (_AmbientColor + light + specular + rim + Outline);
            }
            ENDCG
        }
        UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"
    }
}
