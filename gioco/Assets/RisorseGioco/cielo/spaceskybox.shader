Shader "Custom/SkyboxBlend" {
    Properties {
        _Tex1 ("Texture 1 (Earth)", Cube) = "" {}
        _Tex2 ("Texture 2 (Milky Way)", Cube) = "" {}
        _Blend ("Blend Factor", Range(0,1)) = 0.5
    }
    SubShader {
        Tags { "Queue" = "Background" }
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            samplerCUBE _Tex1;
            samplerCUBE _Tex2;
            float _Blend;

            struct appdata_t {
                float4 vertex : POSITION;
                float3 texcoord : TEXCOORD0;
            };

            struct v2f {
                float4 pos : SV_POSITION;
                float3 texcoord : TEXCOORD0;
            };

            v2f vert(appdata_t v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.texcoord = v.texcoord;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target {
                float scaleFactor = 0.4; // Riduce la Terra
                float3 offset = float3(0, -0.3, 0); // Sposta la Terra in basso
                float3 texcoord_mod = i.texcoord * scaleFactor + offset;

                float r = length(i.texcoord.xy); // Distanza dal centro
                fixed4 col1 = texCUBE(_Tex1, texcoord_mod);
                fixed4 col2 = texCUBE(_Tex2, i.texcoord);

                return lerp(col1, col2, _Blend);
            }
            ENDCG
        }
    }
}
