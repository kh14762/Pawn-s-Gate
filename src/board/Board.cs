using Godot;
using System;

public partial class Board : Node3D
{
	[Export(PropertyHint.Range, "0, 100")] private int _width;
	[Export(PropertyHint.Range, "0, 100")] private int _height;
	
	private Cell[] _cells; 
	public override void _Ready()
	{
		_CreateCells();
	}

	private void _CreateCells()
	{
		_cells = new Cell[_height * _width];
		for (int z = 0, i = 0; z < _width; z++)
		{
			for (int x = 0; x < _height; x++)
			{
				_CreateCell(x, z, i++);
			}
		}
	}

	private void _CreateCell(int x, int z, int i)
	{
		Vector3 position;
		position.X = x;
		position.Y = 0.0f; // raise / lower graph 
		position.Z = z;
		
		var color = ((z + x) % 2 == 0) ? Colors.White : Colors.Black;
		Cell cell = _cells[i] = _InstantiateCell(color);
		cell.Position = position;
	}

	private Cell _InstantiateCell(Color color)
	{
		PackedScene scene = GD.Load("res://scenes/board/Cell.tscn") as PackedScene;
		Cell cell = scene.Instantiate() as Cell;
		cell.Color = color;
		AddChild(cell);
		return cell;
	}
}
