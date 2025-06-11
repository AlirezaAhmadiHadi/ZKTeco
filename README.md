# ZKTecoUserImage

Initial project for ZKTeco device integration.

This repository demonstrates how to connect to ZKTeco attendance devices, listen for attendance transactions, and retrieve user images when available. The code samples are provided in C# using the ZKEM SDK (COM library).

> **Note:** Not all ZKTeco models support image retrieval via SDK. Please check your device's documentation for compatibility.

## Getting Started

1. Add a reference to `zkemkeeper.dll` (ZKEM SDK) to your project.
2. Update the device IP and port in `Program.cs` if necessary.
3. Build and run the solution.
4. Perform an attendance transaction on the device. If the device supports image retrieval, the user's image will be saved as `user_{EnrollNumber}.jpg`.

## License

MIT