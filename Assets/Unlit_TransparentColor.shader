﻿// UNITY_SHADER_NO_UPGRADE
Shader "Tilia/Unlit/TransparentColor"
{
	Properties
	{
		_Color("Color Tint", Color) = (1,1,1,1)
		_MainTex("Base (RGB) Alpha (A)", 2D) = "white"
	}

	Category
	{
		Lighting Off
		ZWrite On
		Cull back
		Blend SrcAlpha OneMinusSrcAlpha
		Tags{ Queue = Transparent }

        SubShader
		{
		    Tags { "RenderPipeline" = "UniversalPipeline" }
		    
			Pass
			{
				SetTexture[_MainTex]
				{
					ConstantColor[_Color]
					Combine Texture * constant
				}
			}
		}

		SubShader
		{
			Pass
			{
				SetTexture[_MainTex]
				{
					ConstantColor[_Color]
					Combine Texture * constant
				}
			}
		}
	}
}