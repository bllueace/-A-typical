
Shader "Custom/OverlayEmmisive" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.0
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_BumpMap ("Normal", 2D) = "bump" {} //Added: to have normal map

		//_EmissionColor ("Color", Color) = (0.000000,0.000000,0.000000,1.000000) //Added: Not useful, just in case we want to change color
		//Emmission (black by defqult so it is off if there is not files)
		_Emi_circles ("Emission circles", 2D) = "black" { } //Added: emissive texture
		_Emi_Line_door ("Emission line door", 2D) = "black" { } ///Added: emissive texture
		_Emi_Line_Top_Left ("Emission line top left", 2D) = "black" { } //Added: emissive texture
		_Emi_Line_Top_Right ("Emission line top right", 2D) = "black" { } //Added: emissive texture
		_Emi_Line_Bottom_Left ("Emission line bottom left", 2D) = "black" { } //Added: emissive texture
		_Emi_Line_Bottom_Right ("Emission line bottom right", 2D) = "black" { } //Added: emissive texture

		//_Emi_circles ("Emission Map", 2D) = "black" {} //Added
		//_Emi_Line_door ("Emission Map", 2D) = "black" {} //Added

	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _BumpMap; // Added: for normal map
		sampler2D _Emi_circles; //Added: Emmisive texture of the circles
		sampler2D _Emi_Line_door; //Added: Emmisive texture of the line going toward door
		sampler2D _Emi_Line_Top_Left; //Added: Emmisive texture of the top left line
		sampler2D _Emi_Line_Top_Right; //Added: Emmisive texture of the top right line
		sampler2D _Emi_Line_Bottom_Left; //Added: Emmisive texture of the bottom left line
		sampler2D _Emi_Line_Bottom_Right; //Added: Emmisive texture of the bottom right line

		struct Input {
			float2 uv_MainTex;
			float2 uv_BumpMap; // Added: for normal map
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;

			fixed4 basecol = tex2D(_MainTex, IN.uv_MainTex); //Added
			//Add the emission with an half4
			half4 emission = tex2D(_Emi_circles, IN.uv_MainTex) + tex2D(_Emi_Line_door, IN.uv_MainTex)
				+  tex2D(_Emi_Line_Top_Left, IN.uv_MainTex) +  tex2D(_Emi_Line_Top_Right, IN.uv_MainTex) 
				+  tex2D(_Emi_Line_Bottom_Left, IN.uv_MainTex) +  tex2D(_Emi_Line_Bottom_Right, IN.uv_MainTex) ; //Added: overlay all emissive textures

			o.Albedo = basecol * _Color;
			o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap)); // Added: for normal map
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;

			o.Emission = emission; // Added
		}
		ENDCG
	}
	FallBack "Diffuse"
}
