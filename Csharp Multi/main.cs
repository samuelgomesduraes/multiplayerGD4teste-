using Godot;
using System;
public partial class main : Node3D
{
    public VBoxContainer Menu;
    public LineEdit PortLineEdit;
    public override void _Ready(){
        Menu=GetNode<VBoxContainer>("Menu");
        PortLineEdit=GetNode<LineEdit>("Menu/Port");
    }
    private void _on_join_pressed(){//entra no servidor
        var Porta=PortLineEdit.Text.ToInt();
        var par=new ENetMultiplayerPeer();
        par.CreateClient("127.0.0.1",Porta);
        Multiplayer.MultiplayerPeer=par;
        Menu.Visible=false;
    }
    private void _on_host_pressed(){
        var Porta=PortLineEdit.Text.ToInt();
        var parclient=new ENetMultiplayerPeer();
        parclient.CreateServer(Porta);
        Multiplayer.MultiplayerPeer=parclient;
        Menu.Visible=false;
        AddPlayer(1);
    }
    private void AddPlayer(int id){//script pra instanciar o jogador na cena Main
        var player=ResourceLoader.Load<PackedScene>("res://player_character/player_character.tscn");
        var playernode=(player_character)player.Instantiate();
        playernode.Name = id.ToString();
        AddChild(playernode);
    }
}
