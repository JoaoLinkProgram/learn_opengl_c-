using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
namespace Shaders{
    public class Shader{
        public int LinkPro;
        public string shaderVertex="";
        public string shaderFragment="";
        public string Source(string vertexPath, string fragmentPath){
            shaderVertex=vertexPath;
            shaderFragment=fragmentPath;
            return shaderVertex+shaderFragment;
        }
        public int createShader(){
            //vertex
            var shaderSource=File.ReadAllText(shaderVertex);
            var vertex=GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertex, shaderSource);
            GL.CompileShader(vertex);
            //fragment
            shaderSource=File.ReadAllText(shaderFragment);
            var fragment=GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragment, shaderSource);
            GL.CompileShader(fragment);
            //programa que link os shaders
            LinkPro=GL.CreateProgram();
            GL.AttachShader(LinkPro, vertex);
            GL.AttachShader(LinkPro, fragment);
            GL.LinkProgram(LinkPro);
            return LinkPro;
        }
        public void Use(){
            GL.UseProgram(LinkPro);
        }
    }
}