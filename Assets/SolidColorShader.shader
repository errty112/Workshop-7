//UNITY_SHADER_NO_UPGRADE

Shader "Unlit/SolidColorShader"
{
	

	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"
			

			

			struct vertIn
			{
				float4 vertex : POSITION;
				float4 color : COLOR;
			};

			struct vertOut
			{
				float4 vertex : SV_POSITION;
				float4 color : COLOR;
			};

			uniform float4 _Color;

			// Implementation of the vertex shader
			vertOut vert(vertIn v)
			{
				vertOut o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.color = v.color * _Color;
				return o;
			}
			
			// Implementation of the fragment (pixel) shader
			fixed4 frag(vertOut i) : SV_Target
			{
				return i.color;
			}
			ENDCG
		}
	}
}
