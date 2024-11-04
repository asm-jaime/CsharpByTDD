#!/bin/bash

# Prompt for project name
read -p "Enter Project Name: " ProjectName

# Copy the template folder
cp -r template.yandexcup "$ProjectName"

# Change directory to the new project folder
cd "$ProjectName"

# Rename template.csproj to $ProjectName.csproj
mv template.csproj "$ProjectName.csproj"

# Remove dots and dashes from ProjectName for namespace
NamespaceName=$(echo $ProjectName | sed 's/[.-]//g')

# Update namespaces in the files
sed -i "s/namespace template;/namespace $NamespaceName;/" program.cs
sed -i "s/namespace template;/namespace $NamespaceName;/" test.cs

echo "Project $ProjectName has been set up."
