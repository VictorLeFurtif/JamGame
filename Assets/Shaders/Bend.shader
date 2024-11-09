 Shader "Unlit/Bend"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BendAmount ("Bend Amount", Float) = 0.05
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float _BendAmount;

            fixed4 frag (v2f_img i) : SV_Target
            {
                float2 uv = i.uv;
                uv.y += (uv.x - 0.5) * (uv.x - 0.5) * _BendAmount;
                return tex2D(_MainTex, uv);
            }
            ENDCG
        }
    }
}
