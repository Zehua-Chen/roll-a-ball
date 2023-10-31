class_name Food
extends StaticBody3D

@export var speed: float = 2
@export var value: int = 1

func _process(delta):
	rotate_y(delta * speed)
