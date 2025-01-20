# Release notes

## v2.0.0

### Changed

- Changed package name, from Reflectis-PLG-Tasks to Reflecits-SDK-Tasks, and updated namespaces according to new package name.
- Replace `Pointer_stringify` with `UTF8ToString` in jslib utilities.
- Added `isMultiplayer` parameter in `PingMyOnlinePresence` method in `IClientModelSystem`.
- Changed type parameter in `UpdateSavedAssets` to string.
- Removed API utilities (`ApiResponse`, `JsonArrayHelper`). They are moved to their own HTTP module.

### Removed

- Removed dependecies to spawned object from `IClientModelSystem`.

### Added

- Added max fov parameter to spawn position data in `SpawnData`.
- Implemented web socket listeners. Added callbacks to `IWebSocketSystem`.

## v1.2.0

### Added

- Add Revert function to the `TaskSystem` used to reset the tasks

### Fixed

- Fixed `ITasksRPCManager` to handle networked tasks

## v1.1.0

### Changed

- Update `TaskStepSetter` to check for null references and to support networking in Reflectis
- Update `ITasksRPCManager` adding events for when a room is joined and on its initialization

## v1.0.0

- Initial release
