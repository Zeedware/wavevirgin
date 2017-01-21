 Shader "Custom/GradientColor"
 {
  Properties {
      [PerRendererData] _MainTex ("Texture", 2D) = "white" {}
      _ColorTop ("Top Color", Color) = (1,1,1,1)
      _ColorBot ("Bot Color", Color) = (1,1,1,1)
  }
   
  SubShader {
      Tags {"Queue"="Background"  "IgnoreProjector"="True"}
      LOD 100
   
      ZWrite On
   
      Pass {
          CGPROGRAM
          #pragma vertex vert  
          #pragma fragment frag
          #include "UnityCG.cginc"
   
          fixed4 _ColorTop;
          fixed4 _ColorBot;
          sampler2D _MainTex;
   
          struct v2f {
              float4 pos : SV_POSITION;
              fixed4 col : TEXCOORD0;
          };
   
          v2f vert (appdata_full v)
          {
              v2f o;
              o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
// 			  o.uv = TRANSFORM_TEX (b.texcoord, _MainTex);
 			  o.col = lerp(_ColorBot, _ColorTop, v.texcoord.y);
              return o;
          }
         
   
          float4 frag (v2f i) : COLOR {
              float4 c = i.col;
              c.a = 1;
//              fixed4 texcol = tex2D(_MainTex, i.uv);
              return c;
          }
              ENDCG
          }
      }
  }
