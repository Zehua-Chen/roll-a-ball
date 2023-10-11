extends Node3D

@export var speed: float = 2
@export var value: int = 1

func _process(delta):
	$StaticBody3D.rotate_y(delta * speed)
