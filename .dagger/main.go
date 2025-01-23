// A generated module for VehicleRegistryApi functions

package main

import (
	"context"
	"dagger/vehicle-registry-api/internal/dagger"
)

type VehicleRegistryApi struct{}

// Returns a container that echoes whatever string argument is provided
func (m *VehicleRegistryApi) ContainerEcho(stringArg string) *dagger.Container {
	return dag.Container().From("alpine:latest").WithExec([]string{"echo", stringArg})
}

// Returns lines that match a pattern in the files of the provided Directory
func (m *VehicleRegistryApi) GrepDir(ctx context.Context, directoryArg *dagger.Directory, pattern string) (string, error) {
	return dag.Container().
		From("alpine:latest").
		WithMountedDirectory("/mnt", directoryArg).
		WithWorkdir("/mnt").
		WithExec([]string{"grep", "-R", pattern, "."}).
		Stdout(ctx)
}

// Builds the Dockerfile for this repository
func (m *VehicleRegistryApi) BuildDocker(
	ctx context.Context,
	src *dagger.Directory,
) (string, error) {
	ref, err := dag.Container().
		WithDirectory("/src", src).
		WithWorkdir("/src").
		Directory("/src").
		DockerBuild().
		Publish(ctx, "ttl.sh/bernats/hello-dagger:5m")
	if err != nil {
		return "", err
	}

	return ref, nil
}
