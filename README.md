# WarehouseSim

     A simulated automated warehouse, built in C#. It has two programs that talk to each other the way I assume
     real	warehouse software does: an **equipment emulator** that acts as the physical warehouse (conveyors, 	barcode scanners and diverters moving totes around), and a **control system** that decides where every tote 	should go.

## Why I built it

	While looking for software engineering roles, I noticed that a lot of the companies hiring near me in Grand 	Rapids build warehouse automation. I didn't want to just say I was interested, so I'm spending my own time 	learning how these systems actually work by building one from the ground up.
	
## Project structure

	- **`src/WarehouseSim.Core`**: The shared building blocks: totes, equipment classes and message types. Both 	apps use it, and it doesn't depend on either of them.
	
	- **`src/WarehouseSim.Emulator`**: The "warehouse." Simulates conveyors, scanners and diverters, and reports 	each time a tote gets scanned.
	
	- **`src/WarehouseSim.Control`**: The "brain." Receives scan events, decides where each tote goes, and sends 	divert commands back.
	
	- **`tests/WarehouseSim.Tests`**: Automated tests (xUnit) for the core logic.
	
## Getting started

	You'll need the [.NET 10 SDK](https://dotnet.microsoft.com/download).
	
	```
	git clone https://github.com/AlenHavicCS/WarehouseSim.git
	cd WarehouseSim
	dotnet build
	dotnet test
	```
## Status

	Early development. I'm building this in phases, starting with the core domain model. You can follow along on 	the [WarehouseSim Roadmap](https://github.com/users/AlenHavicCS/projects/1/views/1).
	