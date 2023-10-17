class_name Player
extends RigidBody3D

@export var speed = 3.0
var score = 0

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass
	
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
