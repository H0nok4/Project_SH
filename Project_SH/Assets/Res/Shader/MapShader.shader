// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/MapShader"
{
	Properties
	{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
	}
	SubShader
	{
		Pass{
			Tags { "RenderType" = "Opaque" }

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			#include "Lighting.cginc"

			sampler2D _MainTex;
			float4 _MainTex_ST;

			struct a2v {
				float4 pos : POSITION;
				float4 vertexColor : COLOR;
				float3 normal : NORMAL;
				float4 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 pos : SV_POSITION;
				float3 fragColor : COLOR;
				float3 worldNormal : TEXCOORD0;
				float4 worldPos : TEXCOORD1;
				float2 uv : TEXCOORD2;

			};



			v2f vert(a2v a) {
				v2f o;
				o.pos = UnityObjectToClipPos(a.pos);
				o.fragColor = a.vertexColor;
				o.worldPos = mul(unity_ObjectToWorld,a.pos);
				o.worldNormal = UnityObjectToWorldNormal(a.normal);
				o.uv = TRANSFORM_TEX(a.texcoord,_MainTex);

				return o;
			}

			float4 frag(v2f v) : SV_Target{
				float3 worldNormal = normalize(v.worldNormal);
				float3 worldLightDir = normalize(UnityWorldSpaceLightDir(v.worldPos));

				float3 albedo = tex2D(_MainTex,v.uv).rgb * v.fragColor.rgb;
				float3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz * albedo;

				float3 diffuse = _LightColor0.rgb * albedo * max(0,dot(worldNormal,worldLightDir));

				float3 viewDir = normalize(UnityWorldSpaceLightDir(v.worldPos));
				float3 halfDir = normalize(worldLightDir + viewDir);
			
				return float4(ambient + diffuse,1.0);
			}
			ENDCG
		}

	}
		FallBack "Diffuse"
}
