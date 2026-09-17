# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

WallRail2025 is a Tekla Structures plugin for creating wall-mounted handrails with brackets. The plugin generates complex 3D geometry including sloped, leveled, and straight rail configurations with automated bracket placement along the rail path.

## Tekla Open API Development Guidelines

When working with this codebase:

- Always assume I'm working with the Tekla Open API
- Provide solutions using Tekla-native methods and best practices always
- Include proper transaction handling and error management for Tekla
- Reference API documentation from https://developer.tekla.com/doc/tekla-structures/2025/tekla-structures-45473 always
- Prioritize code that's maintainable and follows Tekla patterns
- Always use existing Tekla Open API methods rather than developing custom implementations
- When I ask how to do something (e.g., move objects, modify properties), always show me the appropriate API classes and methods that already exist
- Always prioritize API-native solutions over workarounds or custom algorithms
- Reference specific API classes, methods, and properties
- Only suggest custom development when the API doesn't provide the functionality
- Always provide code using the actual API rather than pseudo-code

## Build and Development Commands

### Building the Project
```bash
# Build the project (outputs to Installer/BuildDrop)
dotnet build WallRail2025.csproj

# The Debug build includes a post-build event that copies the DLL to:
# C:\ProgramData\Trimble\Tekla Structures\2025.0\Environments\common\extensions\WallRail2025
```

### Requirements
- .NET Framework 4.8
- Tekla Structures 2025.0 installed at `C:\Program Files\Tekla Structures\2025.0\`
- Windows Forms and WPF support

## Architecture

### Plugin Structure

The plugin follows Tekla's plugin architecture with three main components:

1. **ModelPlugin.cs**: Core plugin logic implementing `PluginBase`
   - `WallRail2025` class: Main plugin entry point marked with `[Plugin("WallRail2025")]`
   - `PluginData` class: Serializable data structure for plugin parameters using `[StructuresField]` attributes
   - Handles two-point user input via `DefineInput()` and executes rail creation via `Run()`

2. **MainForm.cs/.Designer.cs**: WPF/WinForms dialog for user interface
   - Inherits from `Tekla.Structures.Dialog.PluginFormBase`
   - Provides profile/material catalog integration
   - Handles OK/Apply/Modify/Get/OnOff/Cancel button events

3. **XAML UI** (referenced in MainForm but file not present in source): User interface definition

### Geometry Creation Logic

The plugin creates complex polybeam geometry through several specialized methods:

- **CreateRail()**: Main orchestration method (ModelPlugin.cs:410)
  - Creates a `PolyBeam` with 5-6 points depending on rail type
  - Applies chamfering to specific corner points
  - Calls `InsertBrackets()` for bracket placement

- **Rail Type Configurations**:
  - **"leveled"**: 6-point polybeam with horizontal sections at top/bottom (default)
  - **"straight"**: 5-point polybeam following the slope directly

- **Geometry Calculation Methods**:
  - `GetLeveledRailPoints()`: Calculates knee point where sloped rail transitions to horizontal (ModelPlugin.cs:592)
  - `StraightBottomExtensionPoint()`: Extends rail down slope maintaining angle (ModelPlugin.cs:565)
  - `GetReturnPoint()`: Calculates perpendicular return based on left/right direction (ModelPlugin.cs:530)

- **Direction Handling**:
  - Uses cross product of rail direction and up vector to determine left/right perpendicular
  - `directionBox` parameter controls which side the return extends

### Bracket Placement

Brackets are Wagner-1929 profile `Brep` objects placed along the rail:

- **CopyBracketsAlongLine()**: Primary bracket distribution algorithm (ModelPlugin.cs:780)
  - Supports "max" spacing (fits as many as possible) or "exact" spacing
  - Alignment options: "start", "middle", "end" control where brackets begin
  - Uses `MoveWithDirectionVector()` helper for precise point calculation

- **insertLeveledRailBrackets()**: Handles bracket placement for leveled rails (ModelPlugin.cs:659)
  - Places single brackets at bottom and top horizontal sections
  - Distributes multiple brackets along sloped section

- **Bracket Properties** (hardcoded in ModelPlugin.cs:732-744):
  - Profile: "Wagner-1929"
  - Name: "WAGNER-RB 13251R"
  - Material: "BUY-OUT"
  - Class: "12"
  - Fixed offsets: Dz: -3.9574", Dy: 1.44"
  - Rotation: 90 degrees

### Unit Conversion

All user inputs are in inches but Tekla works in millimeters:
- `InchToMM()` method (ModelPlugin.cs:635): Converts inches to mm (multiply by 25.4)
- Applied in `GetValuesFromDialog()` to all dimensional parameters

### Default Values

`GetValuesFromDialog()` (ModelPlugin.cs:193) sets defaults using `IsDefaultValue()`:
- Heights: 36" (bottom, sloped, top)
- Extensions: 12" (bottom/top)
- Return lengths: 3"
- Rail offset: 3.25"
- Profile: "PIPE1-1/2STD"
- Material: "A500-GR.B"
- Bracket spacing: 60"
- Bracket offsets: 6"

## Important Development Notes

### Tekla API Patterns

1. **Model Connection**: Always check `model.GetConnectionStatus()` before operations
2. **Commit Required**: Call `Model.CommitChanges()` after successful insertions
3. **Point/Vector Math**: Extensive use of `Tekla.Structures.Geometry3d` for 3D calculations
4. **Contour Points**: PolyBeam uses `ContourPoint` with optional `Chamfer` for rounded corners

### Debugging

The code includes a `DebugOutput()` method (ModelPlugin.cs:753) that writes to:
```
C:\Users\WindowsPC\Desktop\WallRail_BracketDebug.txt
```

### Known Issues/TODOs

- `insertStraightRailBrackets()` is not implemented (ModelPlugin.cs:720-723)
- Hard-coded user-specific desktop path in debug output
- Properties files (AssemblyInfo.cs, Resources.*) are deleted but still referenced in .csproj

## Tekla Structures Integration

### Plugin Attributes
- `[Plugin("WallRail2025")]`: Registers plugin with Tekla
- `[PluginUserInterface("WallRail2025.MainForm")]`: Links to dialog
- `[StructuresField("FieldName")]`: Marks fields for Tekla serialization

### Installation Location (Debug)
Post-build copies DLL to:
```
%ProgramData%\Trimble\Tekla Structures\2025.0\Environments\common\extensions\WallRail2025
```

### Referenced Tekla Assemblies
All referenced from `C:\Program Files\Tekla Structures\2025.0\bin\`:
- Tekla.Structures.dll
- Tekla.Structures.Datatype.dll
- Tekla.Structures.Dialog.dll
- Tekla.Structures.Model.dll
- Tekla.Structures.Plugins.dll

(These are set to `<Private>False</Private>` - not copied to output)
