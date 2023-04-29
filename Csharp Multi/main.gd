extends Node3D

var par = ENetMultiplayerPeer.new()#cria um pareamento/sala ,

@onready var menu = $Menu

#entra no servidor
func _on_join_pressed():
	var port = str($Menu/Port.text).to_int()
	par.create_client("127.0.0.1", port)
	multiplayer.multiplayer_peer = par
	menu.visible = false

#cria o servidor
func _on_host_pressed():
	var port = str($Menu/Port.text).to_int()
	par.create_server(port)
	multiplayer.multiplayer_peer = par
	par.peer_connected.connect(func(id): add_player_character(id))
	menu.visible = false
	add_player_character()

#funcao pra cria o jogador dentro da cena main ,no caso a cena main e um node3d
func add_player_character(id=1):
	var character = preload("res://player_character/player_character.tscn").instantiate()
	character.name = str(id)
	add_child(character)
	
