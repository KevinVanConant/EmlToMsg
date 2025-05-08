# EML to MSG Converter (.NET 8, WinForms)

This is a lightweight Windows application that converts `.eml` files to `.msg` format using [MimeKit](https://github.com/jstedfast/MimeKit) and [MsgKit](https://github.com/Sicos1977/MsgKit).

## 🔧 Features

- Convert multiple `.eml` files in bulk to `.msg` (Outlook) format
- GUI for selecting source and destination folders
- No Outlook required — works standalone
- Built on .NET 8 with Windows Forms

## 🖥 Requirements

- Windows 10 or later
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download) (for building)
- Or use the published `.exe` — no install required!

## 🚀 How to Build

Clone the repo and build it with Visual Studio 2022+:

1. Make sure your `.csproj` targets:

   ```xml
   <TargetFramework>net8.0-windows</TargetFramework>
   <UseWindowsForms>true</UseWindowsForms>
   ```

2. Add NuGet packages:

   ```bash
   dotnet add package MimeKit --version 4.12.0
   dotnet add package MsgKit --version 2.8.3
   ```

3. Build and run the project.

## 🧾 How to Publish as a Single EXE

From the terminal:

```bash
dotnet publish -c Release -r win-x64 --self-contained true ^
  /p:PublishSingleFile=true /p:IncludeAllContentForSelfExtract=true /p:PublishTrimmed=false
```

Your `.exe` will appear in:

```
bin\Release\net8.0-windows\win-x64\publish\
```

You can move/copy it freely — no install needed.

## 📂 Folder Layout

```
- Form1.cs                // Main UI logic
- Form1.Designer.cs       // Windows Forms layout
- Program.cs              // Entry point
- EmlToMsg.csproj         // Project file
```

<!-->
## 📸 Screenshot

![screenshot](https://user-images.githubusercontent.com/your-placeholder/screenshot.png)
-->
---

MIT License — © 2024 Kevin VanConant
