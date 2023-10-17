class_name Player
extends RigidBody3D

@export var speed = 3.0
var score = 0:
	get:
		return score
	set(value):
		$Label.text = "Score: %s" % value
		score = value

# Called when the node enters the scene tree for the first time.
func _ready():
	score = 0
	
func _input(event):
	if event.is_action("player_move_forward"):
		apply_central_force(Vector3.FORWARD * speed)
	elif event.is_action("player_move_backward"):
		apply_central_force(Vector3.FORWARD * -1 * speed)
	elif event.is_action("player_move_leftward"):
		apply_central_force(Vector3.LEFT * speed)
	elif event.is_action("player_move_rightward"):
		apply_central_force(Vector3.LEFT * -1 * speed)

func _on_body_entered(body: Node):
	var player := body as Food
	
	if player:
		score += player.value
		player.queue_free()
