Shader "Hidden/_Shaderzin"
{
    Properties{
        _MainTex("Texture", 2D) = "white" {}
         _GrayScale("Gray Scale", Range(0, 1)) = 0
    }
    SubShader{
        Pass {
        CGPROGRAM
        #pragma vertex vert_img
        #pragma fragment frag

        #include "UnityCG.cginc"

        uniform sampler2D _MainTex;
        uniform float _GrayScale;

        float4 frag(v2f_img i) : COLOR {
            float4 c = tex2D(_MainTex, i.uv);

            float lum = c.r * .3 + c.g * .59 + c.b * .11;
            float3 gs = float3(lum, lum, lum);

            float4 result = c;
            result.rgb = lerp(c.rgb, gs, _GrayScale);

            return result;
        }
        ENDCG
    }
 }
}
