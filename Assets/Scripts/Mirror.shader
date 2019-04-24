Shader"Custom/Mirror"
{
  Properties
  {
    _MainTex("Base(RGB)",2D)="white"{}
    _MainTint("Diffuse Tint",Color)=(1,1,1,1)
    _Specular("Specular Color", Color)=(1,1,1,1)
    _SpecularPower("Specular Power",Range(0,1))=0.5
  }

  SubShader
  {
    Tags{"RenderType"="Opaque"}
    LOD 200

    CGPROGRAM
    #pragma surface surf Specular

    sampler2D _MainTex;
    float4 _MainTint;
    float4 _Specular;
    float _SpecularPower;

    inline fixed4 LightingSpecular(SurfaceOutput s,fixed3 lightDir,half3 viewDir,fixed atten)
    {
      half3 h = normalize(lightDir+viewDir);
      fixed diff = max(0,dot(s.Normal,lightDir));

      float nh = max(0,dot(s.Normal,h));
      float spec = pow(nh,s.Specular*128.0);

      fixed4 c;
      c.rgb = (s.Albedo*_LightColor0.rgb*diff + _LightColor0.rgb*_Specular*spec)*(atten*2);
      c.a = s.Alpha + _LightColor0.a*_Specular.z*spec*atten;
      return c;
    }

    struct Input
    {
      float2 uv_MainTex;
    };

    void surf (Input IN,inout SurfaceOutput o)
    {
    half4 c = tex2D(_MainTex,IN.uv_MainTex)*_MainTint;

    o.Specular = _SpecularPower;
    o.Albedo=c.rgb;
    o.Alpha = c.a;
    }
    ENDCG
  }
  FallBack"Diffuse"
}
