# Core Infrastructure Package

Shared interfaces, base services, and utilities for all game modules.

## What's Inside
- `IService` — Base interface all services implement
- `IAdsService` — Contract for ads implementations
- `IIAPService` — Contract for in-app purchase implementations
- `ServiceLocator` — Central service registry

## Usage
This package is a **dependency** for implementation modules (Module-Ads, Module-IAP, etc.).  
It should **never** be added as a Git Submodule inside those modules.  
Instead, the **host Game project** supplies this package via its `Packages/manifest.json`.
