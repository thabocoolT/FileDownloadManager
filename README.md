# File Download Manager

## Overview

The **File Download Manager** is a C# application that automatically organizes downloaded files based on their size. Files are categorized into two folders: 
- **Above500MB**: Files larger than 500 MB.
- **Below500MB**: Files smaller than or equal to 500 MB.

The program monitors the `Downloads` folder in real-time using the `FileSystemWatcher` class, ensuring new files are categorized as soon as they are downloaded.

---

## Features
- **Automatic File Organization**: Automatically moves files to the appropriate folders based on their size.
- **Real-Time Monitoring**: Uses a `FileSystemWatcher` to track new downloads and handle them immediately.
- **Folder Creation**: Creates the `Above500MB` and `Below500MB` folders automatically if they don’t exist.
- **File Lock Handling**: Ensures files are fully downloaded before moving them to avoid issues.

---

## Requirements
- **Operating System**: Windows
- **Programming Language**: C# (.NET Framework)
- **Development Environment**: Visual Studio
- **Dependencies**: None (uses standard .NET libraries)

---

## How to Use
1. Clone or download the repository to your local machine.
2. Build and run the project using Visual Studio.
3. Make sure your `Downloads` folder exists at:
4. Run the program. It will monitor the `Downloads` folder in real-time.
5. To stop the program, press `Enter` in the console window.

---

## How It Works
1. The program continuously monitors the `Downloads` folder for new files.
2. When a new file is detected:
- The program checks its size.
- Files larger than 500 MB are moved to the `Above500MB` folder.
- Files smaller than or equal to 500 MB are moved to the `Below500MB` folder.
3. If the required folders do not exist, the program creates them.

---

## Limitations
- The application is configured to monitor the `Downloads` folder only. This path can be updated in the source code.
- Currently works only on Windows systems due to folder path specifications.

---

## Contributing
Contributions are welcome! To contribute:
1. Fork the repository.
2. Create a new branch (`git checkout -b feature/your-feature`).
3. Commit your changes (`git commit -m "Add your message"`).
4. Push to the branch (`git push origin feature/your-feature`).
5. Open a pull request.

---

## License
This project is licensed under the [MIT License](LICENSE).

---

## Acknowledgments
- Inspired by the need to automate file organization for downloaded content.
- Thanks to the .NET and C# community for excellent resources and support.

---

## Author
**ThaboCoolIT**  
GitHub: [thabocoolIT](https://github.com/thabocoolIT)
