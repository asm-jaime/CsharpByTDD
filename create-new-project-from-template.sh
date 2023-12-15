#!/bin/bash

# Prompt for project name
read -p "Enter Project Name: " ProjectName

# Copy the template folder
cp -r template "$ProjectName"

# Change directory to the new project folder
cd "$ProjectName"

# Update namespaces in the files
sed -i "s/namespace template;/namespace $ProjectName;/" program.cs
sed -i "s/namespace template;/namespace $ProjectName;/" solution.cs
sed -i "s/namespace template;/namespace $ProjectName;/" test.cs

echo "Project $ProjectName has been set up."
