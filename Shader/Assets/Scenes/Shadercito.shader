Shader "VJ-Jj2020/Grupo 1" {
    Properties{
      _Ambient("color ambiental", Color) = (0,0,1,1) 
      _Diffuse ("color difuso", Color) = (0,1,0,1)
    }
    SubShader{

        Pass{
                // El Pass funciona para las diferentes versiones que utilizarias entre
                //LSL, HLSL, CG

                CGPROGRAM
                // Entra el codigo aqui
                #pragma vertex vert
                #pragma fragment frag

                #include "UnityCG.cginc"
                
                //Se agregan las propiedades al codigo de CG
                //Para interactuar con las variables de fuera yusamos uniform
                //Para pegar las variables de fuera  con adentro solo usas uniform
                uniform float4 _LightColor0;
                uniform float4 _Ambient;
                uniform float4 _Diffuse;

                //Struct contiene datos como una clase pero sin metodo
                struct vInput{
                    float4 pos : POSITION;
                    float3 normal : NORMAL;
                };

                struct vOutput{
                    float4 pos : SV_POSITION;
                    float3 normal : NORMAL;
                };

                //Representar los pragma con una funcionv 
                vOutput vert(vInput input) {
                    vOutput resultado;
                    //float4 modPos = float4(input.pos.x,input.pos.y, input.pos.z + cos(input.pos.y + _Time.y) / 3, input.pos.w);
                    float4 modPos = input.pos.x + float4(input.normal,1) * cos(_Time.y);
                    resultado.pos = UnityObjectToClipPos(modPos);
                    resultado.normal = input.normal;
                    
                    //Se modifica la ubicacion del vertice en GPU
                    return resultado;
                }
                float4 frag(vOutput salidaVertice) : COLOR{
                    //R G B A
                    float4 cA = _Ambient * _LightColor0;
                    return float4(salidaVertice.normal, 1) ;
                }
                ENDCG
        }
    }
}