#Project Variables
PROJECT_NAME ?= Inventory_Manager
ORG_NAME ?= Inventory_Manager
REPO_NAME ?= InventoryManager

.PHONY: migrations db

migrations:
	cd ./Data && dotnet ef -s ../Api/ migrations add $(mname) && cd ..

db:
	cd ./Data && dotnet ef -s ../Api/ database update && cd ..
