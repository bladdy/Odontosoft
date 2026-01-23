# Odontosoft
Odontosoft es una aplicación diseñada para gestionar de manera eficiente y moderna todos los aspectos de una clínica dental. Desde el agendamiento de citas hasta la gestión de pacientes y su historial médico, Odontosoft facilita la administración y mejora la experiencia tanto para el personal de la clínica como para los pacientes.


# Odontosoft Frontend - Blazor WebAssembly + TailwindCSS

Este proyecto utiliza **Blazor WebAssembly** con **TailwindCSS** para los estilos.  
El siguiente instructivo explica cómo levantar el proyecto y cómo mantener **TailwindCSS actualizado automáticamente** durante el desarrollo.

---

## 🛠 Prerrequisitos

Antes de arrancar, asegúrate de tener instalados:

- [Node.js ≥ 18](https://nodejs.org/) (incluye `npm`)  
- .NET SDK ≥ 7.0  
- Visual Studio Code o Visual Studio 2022+  

---

## 🟢 Arrancar el proyecto en Visual Studio Code

1. Abrir la carpeta del proyecto en VS Code.
2. Abrir un terminal integrado (`Ctrl + ``) y ejecutar (solo la primera vez):

```bash
npm install

## Para mantener TailwindCSS actualizado automáticamente durante el desarrollo, ejecutar
npm run tailwind:watch

```
3. En otro terminal integrado, arrancar el proyecto Blazor:

```bash
dotnet run --project Odontosoft.Frontend/Odontosoft.Frontend.csproj