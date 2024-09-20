using Godot;
using System;
using Godot.NativeInterop;

public partial class Cell : Node3D
{
	private Color _color;
	private StandardMaterial3D _material;
	private MeshInstance3D _mesh;
	public Color Color
	{
		get => _color;
		set  => _color = value; 
	}
	
	public override void _Ready()
	{
		_mesh = GetNode("Mesh") as MeshInstance3D;
		_material = new StandardMaterial3D();
		_material.AlbedoColor = _color;
		_mesh?.SetSurfaceOverrideMaterial(0, _material);
	}
}
