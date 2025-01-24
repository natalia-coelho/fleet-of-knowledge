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
) *dagger.Container {
	dotnetCache := dag.CacheVolume("dotnet")

	return dag.Container().
		WithDirectory("/src", source).
		WithWorkdir("/src").
		WithMountedCache("/root/.nuget/packages", dotnetCache).
		Directory("/src").
		DockerBuild()
}

// Pushes a built container image to a container registry
func (m *VehicleRegistryApi) PushImage(
	ctx context.Context,
	container *dagger.Container,
) (string, error) {
	address, err := container.
		Publish(ctx, "ttl.sh/hello-dagger/bernats/fleet-of-knowledge:2h")
	if err != nil {
		return "", err
	}

	return address, nil
}

// End to end CI pipeline ready to run locally or in a pipeline runner
func (m *VehicleRegistryApi) Ci(
	ctx context.Context,
	source *dagger.Directory,
) (string, error) {
	m.Test(source)
	container := m.DockerBuild(ctx, source)
	image, err := m.PushImage(ctx, container)
	if err != nil {
		return "", err
	}

	return image, nil
}
