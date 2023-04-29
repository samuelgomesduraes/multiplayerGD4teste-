using Godot;
using System;

public partial class player_character : MeshInstance3D
{
    int Speed=10;
    Camera3D Camera;
    MultiplayerSynchronizer Sycron;
    public override void _Ready(){
        Camera=GetNode<Camera3D>("Camera3D");
        Sycron=GetNode<MultiplayerSynchronizer>("MultiplayerSynchronizer");
        Sycron.SetMultiplayerAuthority((Name.ToString()).ToInt());
        Camera.Current=Sycron.IsMultiplayerAuthority();
    }
    public override void _Process(double delta){
        if(Sycron.IsMultiplayerAuthority()){
            Vector3 Direction=new Vector3(0,0,0);
            if(Input.IsKeyPressed(Key.W)){
                Direction-=GlobalTransform.Basis.Z;
            }
            else if(Input.IsKeyPressed(Key.S)){
                Direction+=GlobalTransform.Basis.Z;
            }
             if(Input.IsKeyPressed(Key.A)){
                Direction-=GlobalTransform.Basis.X;
            }
            else if(Input.IsKeyPressed(Key.D)){
                Direction+=GlobalTransform.Basis.X;
            }

            GlobalPosition+=Direction.Normalized() * Speed /30;
        }
        
    }
}
