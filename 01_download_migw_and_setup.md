# 🛠️ Installing MinGW on Windows  
A Complete, Clean, and Beautiful Guide

## 📥 1. Download MinGW Installer
1. Visit the official MinGW page on SourceForge:  
   https://sourceforge.net/projects/mingw/
2. Click **Download** to get the `mingw-get-setup.exe` installer.
3. Once downloaded, run the installer.

---

## 📦 2. Install the MinGW Installer Manager
1. Launch `mingw-get-setup.exe`.
2. Accept the default installation directory (typically: `C:\MinGW`).
3. Finish the setup to open the **MinGW Installation Manager**.

---

## 📚 3. Select the Required Packages

Inside **MinGW Installation Manager**:

### ✔️ Essential packages to install:
- `mingw32-gcc-g++` — C++ compiler  
- `mingw32-gcc-gcc` — C compiler  
- `mingw32-make` — Make utility  
- `mingw32-binutils` — Binary utilities  
- `mingw32-gdb` — Debugger (optional)

### How to mark packages:
1. Right-click each required package.
2. Choose **Mark for Installation**.

---

## ▶️ 4. Apply Changes (Install the Packages)
1. Open the **Installation** menu.
2. Choose **Apply Changes**.
3. Confirm by clicking **Apply**.
4. Wait for installation to complete.

---

## 🌱 5. Set Up Environment Variables

### Add MinGW to the `PATH`
1. Press **Win + R**, type `sysdm.cpl`, and press **Enter**.
2. Open the **Advanced** tab → click **Environment Variables**.
3. Under **System variables**, select `Path` → click **Edit**.
4. Add the following entry:

