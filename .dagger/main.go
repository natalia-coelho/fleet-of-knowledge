// A generated module for VehicleRegistryApi functions

package main

import (
	"context"
	"dagger/vehicle-registry-api/internal/dagger"
)

type VehicleRegistryApi struct{}

// Builds a base container with all dependencies installed
func (m *VehicleRegistryApi) BuildEnv(source *dagger.Directory) *dagger.Container {
	dotnetCache := dag.CacheVolume("dotnet")
	return dag.Container().
		From("mcr.microsoft.com/dotnet/sdk:8.0-alpine").
		WithDirectory("/source", source).
		WithMountedCache("/root/.nuget/packages", dotnetCache).
		WithWorkdir("/source").
		WithExec([]string{"dotnet", "restore", "VehicleRegistryAPI/VehicleRegistries.sln"})
}

// Runs dotnet test on the app
func (m *VehicleRegistryApi) Test(source *dagger.Directory) *dagger.Container {
	return m.BuildEnv(source).
		WithExec([]string{"dotnet", "test", "--no-restore", "VehicleRegistryAPI/VehicleRegistries.sln"})
}

// Builds the Dockerfile at the root of the project
func (m *VehicleRegistryApi) DockerBuild(
	ctx context.Context,
	source *dagger.Directory,
) (string, error) {
	ref, err := dag.Container().
		WithDirectory("/src", source).
		WithWorkdir("/src").
		Directory("/src").
		DockerBuild().
		Publish(ctx, "ttl.sh/hello-dagger/bernats/fleet-of-knowledge:2h")
	if err != nil {
		return "", err
	}

	return ref, nil
}

// publish
