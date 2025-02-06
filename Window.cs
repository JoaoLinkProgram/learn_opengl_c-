using Shaders;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;

namespace Janela{
    public class Window:GameWindow{
        
        Shader _shader=new Shader();
        //codenadas do verteces
        public float[] _mesh_vertex={
            0.0f, 0.5f, 0.0f,
            0.5f, 0.0f, 0.0f,
            -0.5f, 0.0f, 0.0f 
        };
        public int _vertexBufferObject;
        public int _vertexArrayObject;
        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) :base(gameWindowSettings ,nativeWindowSettings){

        }
        //executa uma vez quando a janela e chamada
        protected override void OnLoad(){
            base.OnLoad();
            GL.ClearColor(0.0f, 0.0f, 1.0f, 1.0f);
            _vertexBufferObject=GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _mesh_vertex.Length*sizeof(float), _mesh_vertex, BufferUsageHint.StaticDraw);
            _vertexArrayObject=GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3*sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            _shader.Source("shader/vertex.glsl","shader/fragment.glsl");
            _shader.createShader();
            _shader.Use();
        }
        //execulta varias vezes
        protected override void OnRenderFrame(FrameEventArgs args){
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            _shader.Use();
            GL.BindVertexArray(_vertexArrayObject);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
            SwapBuffers();
        }
        //execulta os buffers da tela
        protected override void OnFramebufferResize(FramebufferResizeEventArgs e){
            base.OnFramebufferResize(e);
            GL.Viewport(0, 0, e.Width, e.Height);
        }
    }
}