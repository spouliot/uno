#!/bin/bash

pushd $GITPOD_REPO_ROOT/src/SamplesApp/SamplesApp.Skia.Gtk

export NUGET_PACKAGES=/workspace/.nuget

dotnet build /bl SamplesApp.Skia.Gtk.csproj /p:UnoTargetFrameworkOverride=netstandard2.0

popd
