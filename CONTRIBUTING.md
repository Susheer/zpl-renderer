# Contributing

Thank you for considering contributing!

## Before starting

- Search existing issues.
- Open a discussion for large features.
- Keep pull requests focused.

## Development

- .NET 8+
- Visual Studio 2022
- Run tests before submitting

## Coding Style

- Follow .NET naming conventions.
- Keep public APIs documented.
- Write unit tests.

## Pull Requests

- One feature per PR.
- Include tests.
- Update documentation if needed.

# How to Change Version 
    - Changing dll version
        Edit Following function within Exports.cs, present within managed/ZplRenderer.Core
        ```
        public static IntPtr GetVersion(){
            return Memory.AllocString("0.3.0"); <-- Edit here
        }
        ```
    - Post Above code change, Run following scripts in the same order from the project root.
       ```
        npm run build:core
        npm run publish:core
        npm run rebuild

       ```