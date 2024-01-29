
#ifndef CUSTOM_LIGHTING_INCLUDED
#define CUSTOM_LIGHTING_INCLUDED

#ifndef SHADERGRAPH_PREVIEW
    #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"
    #if (SHADERPASS != SHADERPASS_FORWARD)
        #undef REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR
    #endif
#endif

struct CustomLightingData
{
    // Position and orientation
    float3 positionWS;
    float3 normalWS;
    float3 viewDirectionWS;
    float4 shadowCoord;

    // Surface attributes
    float3 albedo;
    float smoothness;
    float ambientOcclusion;

    // Baked lighting
    float3 bakedGI;
    float4 shadowMask;
    float fogFactor;
};

#ifndef SHADERGRAPH_PREVIEW
float3 CustomLightHandling(CustomLightingData d, Light light)
{
    //diffuse lighting
    float3 radiance = light.color;
    float diffuse = saturate(dot(d.normalWS, light.direction));
    float3 color = d.albedo * radiance * diffuse;
    
    return color;
}
#endif


float3 CalculateCustomLighting(CustomLightingData d)
{
    #ifdef SHADERGRAPH_PREVIEW
        float3 lightDir = float3(0.5, 0.5, 0);
        float intensity = saturate(dot(d.normalWS, lightDir));
        return d.albedo * intensity;
    #else
        Light mainLight = GetMainLight();
        float3 color = 0;
            
        color += CustomLightHandling(d, mainLight);
            
        return color;
    #endif
}

void CalculateCustomLighting_float(float3 Normal,float3 Albedo,
    out float3 Color)
{

    CustomLightingData d;
    d.normalWS = Normal;
    d.albedo = Albedo;

    Color = CalculateCustomLighting(d);
}

#endif