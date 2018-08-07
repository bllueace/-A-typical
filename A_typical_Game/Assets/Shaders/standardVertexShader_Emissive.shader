//Shader to enable vertex color, found in forum : https://answers.unity.com/questions/923726/unity-5-standard-shader-support-for-vertex-colors.html

Shader "Custom/StandardVertex" {
     Properties {
         _Color ("Color", Color) = (1,1,1,1)
         _MainTex ("Albedo (RGB)", 2D) = "white" {}
         _Glossiness ("Smoothness", Range(0,1)) = 0.5
         _Metallic ("Metallic", Range(0,1)) = 0.0
		 _BumpMap ("Normal", 2D) = "bump" {} //Added: to have normal map
		 //_HeightMap ("Height Map", 2D) = "white" {} //added for height map
		 _Emission ("Emission", 2D) = "black" { } //Added: emissive texture
		 _EmissionColor("Emission Color", Color) = (0,0,0) //Added: emission
		 _EmissionIntensity("Emission Intensity", Range(0.0, 20.0)) = 0.0 //Added: emission
     }
     SubShader {
         Tags { "RenderType"="Opaque" }
         LOD 200
         
		  Cull Off //Added for two side




         CGPROGRAM
         #pragma surface surf Standard vertex:vert fullforwardshadows
         #pragma target 3.0

		 #pragma shader_feature _EMISSION //Added: emission

         struct Input {
             float2 uv_MainTex;
             float3 vertexColor; // Vertex color stored here by vert() method
			 float2 uv_BumpMap; // Added: for normal map
         };

		 half _HeightMapScale; //added for normal map
         
         struct v2f {
           float4 pos : SV_POSITION;
           fixed4 color : COLOR;
         };
 
         void vert (inout appdata_full v, out Input o)
         {
             UNITY_INITIALIZE_OUTPUT(Input,o);
             o.vertexColor = v.color; // Save the Vertex Color in the Input for the surf() method
         }
 
         sampler2D _MainTex;
		 sampler2D _BumpMap; // Added: for normal map
 		 //sampler2D _HeightMap; //Added for heightmap
		 sampler2D _Emission; //Added: Emmisive texture 

		 fixed4 _EmissionColor; // Added for emissive
		 float _EmissionIntensity; //Added for emissive

         half _Glossiness;
         half _Metallic;
         fixed4 _Color;
 
         void surf (Input IN, inout SurfaceOutputStandard o) 
         {
			//float textureHeightValue = tex2Dload(_HeightMap, float4(vertexPos.xz, 0, 0)).r;
			//vertexPos.y += textureHeightValue;

			half4 emission = tex2D(_Emission, IN.uv_MainTex); //Added; emission

             // Albedo comes from a texture tinted by color
             fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
             o.Albedo = c.rgb * IN.vertexColor; // Combine normal color with the vertex color
             // Metallic and smoothness come from slider variables
             o.Metallic = _Metallic;
             o.Smoothness = _Glossiness;
			 //o.Height = _HeightMap; //Added for height map
             o.Alpha = c.a;

			 o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap)); // Added: for normal map
			 o.Emission = emission * _EmissionColor * _EmissionIntensity; // Added emission
         }
         ENDCG
     } 
     FallBack "Diffuse"
 }
