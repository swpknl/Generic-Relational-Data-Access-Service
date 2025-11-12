# GenericDataAccessLayerService
This project is an implementation of a generic data access layer that can be used with any ODBC driver that scales to all entities.
The same is used by a RESTful WebAPI service.

## Dependency Updates (2025-11-12)
Security maintenance performed:

* Updated client libraries: jQuery `3.7.0` -> `3.7.1`, Bootstrap `5.3.0` -> `5.3.3`.
* Removed references to obsolete jQuery intellisense include to simplify build.

If you restore NuGet packages (`nuget restore`), the updated versions will be used. BundleConfig already uses the version token (`jquery-{version}.js`) so no code changes required.

### Rebuild Steps
1. Restore packages: `nuget restore DragonetWorksheetAPI.sln`
2. Build solution in Visual Studio or via MSBuild.
3. Run the web project; static assets now reference updated library versions in project file.

### Notes
If additional Dependabot alerts appear, repeat the process: bump the version in `packages.config`, adjust any file includes, and rebuild.
