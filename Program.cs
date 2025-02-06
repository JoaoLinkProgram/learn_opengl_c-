using Janela;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
namespace Programa{
    public static class Programa{
        private static void Main(){
            var nativeWindowSettigs=new NativeWindowSettings(){
                ClientSize=new Vector2i(800,600),
                Title="janela",
                Flags=ContextFlags.ForwardCompatible,
            };
            using(var window=new Window(GameWindowSettings.Default, nativeWindowSettigs)){
                window.Run();
            }
        }
    }
};